using System.Text.Json;
using Bogus;

namespace nuget_demo;

public static class BogusDataGenerator
{
    public static List<TableUser> GetSampleTableData()
    {
        var customerId = 1;
        var userFaker = new Faker<TableUser>()
            .CustomInstantiator(f => new TableUser(customerId++.ToString()))
            .RuleFor(o => o.ModifiedDate, f => f.Date.Recent(100))
            .RuleFor(o => o.NameStyle, f => f.Random.Bool())
            .RuleFor(o => o.Phone, f => f.Person.Phone)
            .RuleFor(o => o.FirstName, f => f.Name.FirstName())
            .RuleFor(o => o.LastName, f => f.Name.LastName())
            .RuleFor(o => o.Title, f => f.Name.Prefix(f.Person.Gender))
            .RuleFor(o => o.Suffix, f => f.Name.Suffix())
            .RuleFor(o => o.MiddleName, f => f.Name.FirstName())
            .RuleFor(o => o.EmailAddress, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
            .RuleFor(o => o.SalesPerson, f => f.Name.FullName())
            .RuleFor(o => o.CompanyName, f => f.Company.CompanyName());

        return userFaker.Generate(1000);
    }

    public static BlogPost GetSampleBlogPostData()
    {
        var fakeTags = new Faker<Tag>()
           .RuleFor(t => t.Id, f => f.IndexFaker)
           .RuleFor(t => t.Description, f => f.Lorem.Word());

        var fakeBlogPostTags = new Faker<BlogPostTag>()
            .RuleFor(t => t.Tag, f => fakeTags.Generate());


        var testBlogPosts = new Faker<BlogPost>()
            .RuleFor(bp => bp.Id, f => f.IndexFaker)
            .RuleFor(bp => bp.Content, f => f.Lorem.Paragraphs())
            .RuleFor(bp => bp.Created, f => f.Date.Past())
            .RuleFor(bp => bp.IsActive, f => f.PickRandomParam(new bool[] { true, true, false }))
            .RuleFor(bp => bp.MetaDescription, f => f.Lorem.Sentences(3))
            .RuleFor(bp => bp.Keywords, f => string.Join(", ", f.Lorem.Words()))
            .RuleFor(bp => bp.Title, f => f.Lorem.Sentence(10))
            .RuleFor(bp => bp.Tags, f => fakeBlogPostTags.Generate(3).ToList())
            .FinishWith((f, bp) => Console.WriteLine($"Blog post created. Id={bp.Id}"));


        return testBlogPosts.Generate();
    }

    internal static async Task<Order> GetTestOrders()
    {
        //To generate Deterministic Data  Use Randomiser

        Randomizer.Seed = new Random(255);

        var billingDetails = new Faker<BillingDetails>()
        .RuleFor(x => x.CustomerName, f => f.Person.FullName)
        .RuleFor(x => x.Email, f => f.Person.Email)
        .RuleFor(x => x.Address, f => f.Address.StreetAddress())
        .RuleFor(x => x.City, f => f.Address.City())
        .RuleFor(x => x.PostalCode, f => f.Address.ZipCode())
        .RuleFor(x => x.Country, f => f.Address.Country());


        var billingDetails1 = billingDetails.Generate();

        var order = new Faker<Order>()
        .RuleFor(x => x.Price, f => f.Finance.Amount())
        .RuleFor(x => x.Currency, f => f.Finance.Currency().Code)
        .RuleFor(x => x.Id, Guid.NewGuid)
        .RuleFor(x => x.BillingDetails, f => billingDetails);


        foreach (var ord in order.GenerateBetween(1, 10))
        {
            var data = JsonSerializer.Serialize(ord);
            System.Console.WriteLine($"{data}\n");

            await Task.Delay(1000);
        }

        return order;
    }
}