using WestcoastEducation;

var school = new School();

while (true)
{
    Console.WriteLine("\n1 Lägg till kurs");
    Console.WriteLine("2 Lägg till lärare");
    Console.WriteLine("3 Lägg till studerande");
    Console.WriteLine("4 Lägg till handledare/utbildningsledare");
    Console.WriteLine("5 Lägg till administratör");
    Console.WriteLine("6 Lista kurser");
    Console.WriteLine("7 Lista studenter");
    Console.WriteLine("0 Avsluta");
    Console.Write("Val: ");

    switch (Console.ReadLine())
    {
        case "1": school.AddCourse(); break;
        case "2": school.AddTeacher(); break;
        case "3": school.AddStudent(); break;
        case "4": school.AddSupervisor(); break;
        case "5": school.AddAdministrator(); break;
        case "6": school.ListCourses(); break;
        case "7": school.ListStudents(); break;
        case "0": return;
        default: Console.WriteLine("Ogiltigt val."); break;
    }
}