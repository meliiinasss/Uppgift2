namespace WestcoastEducation;

public class Supervisor : Teacher
{
    public DateOnly EmploymentDate { get; set; }

    internal static void Add(Supervisor supervisor)
    {
        throw new NotImplementedException();
    }

    public override string GetDetails() =>
        $"{base.GetDetails()}, anställd: {EmploymentDate:yyyy-MM-dd}";
}