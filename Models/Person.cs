namespace WestcoastEducation;

public abstract class Person : IDetails
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Phone { get; set; } = "";
    public string SocialSecurityNumber { get; set; } = "";
    public string Address { get; set; } = "";
    public string PostalCode { get; set; } = "";
    public string City { get; set; } = "";

    public virtual string GetDetails() =>
        $"{FirstName} {LastName}, {Phone}, {SocialSecurityNumber}, " +
        $"{Address}, {PostalCode} {City}";
}