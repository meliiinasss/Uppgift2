namespace WestcoastEducation;

public class Supervisor : Teacher
{
    public DateOnly EmploymentDate { get; set; }

    public override string GetDetails() =>
        $"{base.GetDetails()}, anställd: {EmploymentDate:yyyy-MM-dd}";
}
