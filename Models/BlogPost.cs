namespace nuget_demo;

public class BlogPost
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string MetaDescription { get; set; }
    public string Keywords { get; set; }
    public bool IsActive { get; set; }

    public DateTime Created { get; set; }

    public string AuthorId { get; set; }
    public ApplicationUser Author { get; set; }

    public List<BlogPostTag> Tags { get; set; }

    public BlogPost()
    {
        Tags = new List<BlogPostTag>();
    }
}

public class ApplicationUser
{
    public int AuthorId { get; set; }
    public string AuthorName { get; set; }
}


public class BlogPostTag
{
    public int BlogPostId { get; set; }
    public string BlogPost { get; set; }
    public int TagId { get; set; }
    public Tag Tag { get; set; }
}

public class Tag
{
    public int Id { get; set; }
    public string Description { get; set; }
    public object BlogPosts { get; set; }
}
