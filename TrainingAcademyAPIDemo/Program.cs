using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TrainingModule;

namespace TrainingAcademyAPIDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int Student_Rollno;
            String StudentName;
            String Address1;
            String Gender;
            String Contact_No;
            String Course_Name;
            String Course_Fee;
            String Trainer_Name;
            int Student_Marks;
            Connection1.CreateConnection();
            Console.WriteLine("Connection with database Successful");
            Console.ReadKey();
            Console.WriteLine("Enter your Details");
            Console.WriteLine("Enter the Rollno");
            Student_Rollno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the StudentName");
            StudentName = Console.ReadLine();
            Console.WriteLine("enter the Address");
            Address1 = Console.ReadLine();
            Console.WriteLine("enter the Gender");
            Gender = Console.ReadLine();
            Console.WriteLine("enter the ContactNo");
            Contact_No = Console.ReadLine();
            Console.WriteLine("enter the CourseName");
            Course_Name = Console.ReadLine();
            Console.WriteLine("enter the Course_Fee");
            Course_Fee = Console.ReadLine();
            Console.WriteLine("enter the TrainerName");
            Trainer_Name = Console.ReadLine();
            Console.WriteLine("Enter the Marks");
            Student_Marks= Convert.ToInt32(Console.ReadLine());
            Connection1.InsertData( Student_Rollno,  StudentName,  Address1,  Gender,  Contact_No,  Course_Name,  Course_Fee, Trainer_Name ,Student_Marks);
            
            
        }
    }
}
