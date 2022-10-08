namespace Blog.Models;

public class Role
{
    public Role()
    {
        Users = new List<User>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public List<User> Users { get; set; }
}