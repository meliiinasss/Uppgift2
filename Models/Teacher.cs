namespace WestcoastEducation;

public class Teacher : Person
{
    public string Subject { get; set; } = "";
    public List<int> CourseNumbers { get; set; } = [];

    public override string GetDetails() =>
        $"{base.GetDetails()}, område: {Subject}, kurser: {string.Join(", ", CourseNumbers)}";
}