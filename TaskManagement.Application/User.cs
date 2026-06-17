namespace TaskManagement.Application;


public class User
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;


    private User() { }


    public User(string name, string email)
    {
        if(string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty", nameof(name));

        if(string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email cannot be empty",nameof(email));


        Name = name;
        Email = email;

    }


}