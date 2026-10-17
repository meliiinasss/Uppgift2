using System.Text.Json;

namespace WestcoastEducation;

public class School
{
    private const string FilePath = "Data/courses.json";

    public List<Course> Courses { get; private set; } = [];
    public List<Student> Students { get; } = [];
    public List<Teacher> Teachers { get; } = [];
    public List<Supervisor> Supervisors { get; } = [];
    public List<Administrator> Administrators { get; } = [];

    public School()
    {
        Directory.CreateDirectory("Data");
        if (File.Exists(FilePath))
            Courses = JsonSerializer.Deserialize<List<Course>>(File.ReadAllText(FilePath)) ?? [];
    }

    public void AddCourse()
    {
        Courses.Add(new Course
        {
            CourseNumber = int.Parse(Ask("Kursnummer: ")),
            Title = Ask("Titel: "),
            LengthWeeks = int.Parse(Ask("Längd i veckor: ")),
            StartDate = DateOnly.Parse(Ask("Startdatum (ÅÅÅÅ-MM-DD): ")),
            EndDate = DateOnly.Parse(Ask("Slutdatum (ÅÅÅÅ-MM-DD): ")),
            Type = Ask("1 = klassrum, 2 = distans: ") == "1"
                ? CourseType.Classroom : CourseType.Distance
        });
        SaveCourses();
    }

    public void AddStudent()
    {
        var student = new Student();
        ReadPerson(student);
        Students.Add(student);
    }

    public void AddTeacher()
    {
        var teacher = new Teacher();
        ReadPerson(teacher);
        teacher.Subject = Ask("Kunskapsområde: ");
        teacher.CourseNumbers = ReadCourseNumbers();
        Teachers.Add(teacher);
    }

    public void AddSupervisor()
    {
        var supervisor = new Supervisor();
        ReadPerson(supervisor);
        supervisor.Subject = Ask("Kunskapsområde: ");
        supervisor.CourseNumbers = ReadCourseNumbers();
        supervisor.EmploymentDate = DateOnly.Parse(Ask("Anställningsdatum: "));
        Supervisors.Add(supervisor);
    }

    public void AddAdministrator()
    {
        var admin = new Administrator();
        ReadPerson(admin);
        admin.Subject = Ask("Kunskapsområde: ");
        admin.CourseNumbers = ReadCourseNumbers();
        admin.EmploymentDate = DateOnly.Parse(Ask("Anställningsdatum: "));
        Administrators.Add(admin);
    }

    public void ListCourses()
    {
        foreach (var course in Courses)
            Console.WriteLine(course.GetDetails());
    }

    public void ListStudents()
    {
        foreach (var student in Students)
            Console.WriteLine(student.GetDetails());
    }

    public void SaveCourses() =>
        File.WriteAllText(FilePath,
            JsonSerializer.Serialize(Courses, new JsonSerializerOptions { WriteIndented = true }));

    private static string Ask(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine() ?? "";
    }

    private static void ReadPerson(Person person)
    {
        person.FirstName = Ask("Förnamn: ");
        person.LastName = Ask("Efternamn: ");
        person.Phone = Ask("Telefon: ");
        person.SocialSecurityNumber = Ask("Personnummer: ");
        person.Address = Ask("Adress: ");
        person.PostalCode = Ask("Postnummer: ");
        person.City = Ask("Ort: ");
    }

    private List<int> ReadCourseNumbers()
    {
        Console.Write("Kursnummer, separerade med komma: ");
        return (Console.ReadLine() ?? "")
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();
    }
}