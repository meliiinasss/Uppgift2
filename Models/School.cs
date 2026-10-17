using System.Text.Json;

namespace WestcoastEducation;

public class School
{
    private const string FilePath = "Data/Courses.json";

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
            CourseNumber = AskInt("Kursnummer: "),
            Title = Ask("Titel: "),
            LengthWeeks = AskInt("Längd i veckor: "),
            StartDate = AskDate("Startdatum (ÅÅÅÅ-MM-DD): "),
            EndDate = AskDate("Slutdatum (ÅÅÅÅ-MM-DD): "),
            Type = AskCourseType()
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
        supervisor.EmploymentDate = AskDate("Anställningsdatum (ÅÅÅÅ-MM-DD): ");
        Supervisors.Add(supervisor);
    }

    public void AddAdministrator()
    {
        var admin = new Administrator();
        ReadPerson(admin);
        admin.Subject = Ask("Kunskapsområde: ");
        admin.CourseNumbers = ReadCourseNumbers();
        admin.EmploymentDate = AskDate("Anställningsdatum (ÅÅÅÅ-MM-DD): ");
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

    private static int AskInt(string prompt)
    {
        while (true)
        {
            if (int.TryParse(Ask(prompt), out int value))
                return value;

            Console.WriteLine("Skriv ett giltigt heltal.");
        }
    }

    private static DateOnly AskDate(string prompt)
    {
        while (true)
        {
            if (DateOnly.TryParse(Ask(prompt), out DateOnly date))
                return date;

            Console.WriteLine("Skriv ett giltigt datum, till exempel 2026-10-17.");
        }
    }

    private static CourseType AskCourseType()
    {
        while (true)
        {
            string answer = Ask("1 = klassrum, 2 = distans: ");
            if (answer == "1")
                return CourseType.Classroom;
            if (answer == "2")
                return CourseType.Distance;

            Console.WriteLine("Välj 1 för klassrum eller 2 för distans.");
        }
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
        int courseNumber = AskInt("Kursnummer: ");
        return [courseNumber];
    }
}
