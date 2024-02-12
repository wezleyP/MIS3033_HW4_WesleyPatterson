// MIS 3033
// 02/12/2024
// Wesley Patterson 
// 113562579

using a;

StuDB db = new StuDB();// create a database connection


while (true)
{
    db.SaveChanges();
    Console.WriteLine(@"*********************************************************" +
    "\r\nMenu options:\r\n1. Add a new student’s information\r\n" +
    "2. Show all the students’ information\r\n" +
    "3. Show one student’s information for a given Student ID\r\n" +
    "4. Edit one student’s information for a given Student ID\r\n" +
    "5. Delete one student’s information for a given Student ID\r\n" +
    "6. Show the student’s information with highest grade\r\n" +
    "7. Show the average grade of all the students\r\n" +
    "Press other keys to exit\r\n********************************************************* \n");

    Console.Write("Enter your option: ");
    string option = Console.ReadLine();

    if (option == "1")
    {
        Console.WriteLine("\r\nAdd a new student");
        Student s = new Student();

        Console.Write("Enter the student's id: ");
        s.Id = Convert.ToInt16(Console.ReadLine());

        Console.Write("Enter the student's name: ");
        s.name = Console.ReadLine();

        Console.Write("Enter the student's grade: ");
        s.grade = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the student's grade level: ");
        s.gradeLevel = Convert.ToInt32(Console.ReadLine());

        db.Students.Add(s);
        db.SaveChanges();
        Console.WriteLine("New student infor added to database!");
        Console.WriteLine(s);

    }
    else if (option == "2")
    {
        List<Student> stus = db.Students.ToList();
        foreach (Student s in stus)
        {
            Console.WriteLine(s);
        }
    }
    else if (option == "3")
    {

        Console.Write("Enter the student's ID: ");
        int id = Convert.ToInt32(Console.ReadLine());   
        Student s = db.Students.Where(x => x.Id == id).FirstOrDefault();
        if (s != null)
        {
            Console.WriteLine(s);
        }
        else
        {
            Console.WriteLine("Student not found");
        }   
    }
    else if (option == "4")
    {
        // Edit one student’s information for a given Student ID
        Console.Write("Enter the student's ID: ");
        int id = Convert.ToInt32(Console.ReadLine());
        Student s = db.Students.Where(x => x.Id == id).FirstOrDefault();
        if (s != null)
        {
            Console.Write("Enter the student's name: ");
            s.name = Console.ReadLine();
            Console.Write("Enter the student's grade: ");
            s.grade = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter the student's grade level: ");
            s.gradeLevel = Convert.ToInt32(Console.ReadLine());
            db.SaveChanges();
        }
        else
        {
            Console.WriteLine("Student not found");
        }
    }
    else if (option == "5")
    {
        // Delete one student’s information for a given Student ID
        Console.Write("Enter the student's ID: ");
        int id = Convert.ToInt32(Console.ReadLine());
        Student s = db.Students.Where(x => x.Id == id).FirstOrDefault();
        if (s != null)
        {
            db.Remove(s);
            db.SaveChanges();
        }
        else
        {
            Console.WriteLine("Student not found");
        }
    }
    else if (option == "6")
    {
        // Show the student’s information with highest grade
        Student s = db.Students.OrderByDescending(x => x.grade).FirstOrDefault();
        if (s != null)
        {
            Console.WriteLine(s);
        }
        else
        {
            Console.WriteLine("No students found");
        }
    }
    else if (option == "7")
    {
        // Show the average grade of all the students
        double avg = db.Students.Average(x => x.grade);
        Console.WriteLine($"The average grade is {avg:F2}");
    }
    else
    {
        break;
    }
}
Console.WriteLine("sucess!");