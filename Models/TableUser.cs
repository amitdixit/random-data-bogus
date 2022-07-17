namespace nuget_demo;

public class TableUser
{
    private string _customerId;
    public TableUser(string customerId)
    {
        _customerId = customerId;
    }
    public string CustomerId { get { return _customerId; } }
    public DateTime ModifiedDate { get; set; }
    public string Title { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public bool NameStyle { get; set; }
    public string Suffix { get; set; }
    public string CompanyName { get; set; }
    public string SalesPerson { get; set; }
    public string EmailAddress { get; set; }
    public string Phone { get; set; }
}