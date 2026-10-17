namespace WestcoastEducation;

public enum CourseType { Classroom, Distance }

public class Course : IDetails
{
    public int CourseNumber { get; set; }
    public string Title { get; set; } = "";
    public int LengthWeeks { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public CourseType Type { get; set; }

    public string GetDetails() =>
        $"{CourseNumber}: {Title}, {Type}, {LengthWeeks} veckor, " +
        $"{StartDate:yyyy-MM-dd}–{EndDate:yyyy-MM-dd}";
}