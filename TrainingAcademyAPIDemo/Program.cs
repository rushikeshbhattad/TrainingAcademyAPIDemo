using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
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
            int rollno;
            Connection1.CreateConnection();
            Console.WriteLine("Connection with database Successful");
            Console.WriteLine("Training_Academy");
            Console.WriteLine();
            Console.ReadKey();


            do
            {


                Console.WriteLine("Press 1 For Display Data");
                Console.WriteLine("Press 2 For Insert Data");
                Console.WriteLine("Press 3 For Update Data");
                Console.WriteLine("Press 4 For Delete Data");
                Console.WriteLine("Press 5 For Display Top 5 Student Data");
                Console.WriteLine("Press 6 For Display Top 5 Course Name and Trainer Name Data");
                Console.WriteLine("Press 7 for exit");

                int ch = Convert.ToInt32(Console.ReadLine());

                switch (ch)
                {
                    case 1:
                        Console.WriteLine("------------Display the Details----------------");
                        Connection1.DisplayData();
                        break;

                    case 2:
                        Console.WriteLine("Enter your Details");
                        Console.WriteLine("--------------Insert Student Details--------------");
                        Console.WriteLine("Enter the Rollno");
                        Student_Rollno = Convert.ToInt32(Console.ReadLine());
                        
                         
                        Console.WriteLine("enter the StudentName");
                        StudentName = Console.ReadLine();

                            while (String.IsNullOrEmpty(StudentName))
                            {
                                Console.WriteLine("please enter the student name it cannot be blank");
                                Console.WriteLine("Enter the student name again");
                                StudentName = Console.ReadLine();
                            }
                                
                         Console.WriteLine("enter the Address");
                         Address1 = Console.ReadLine();

                        while (String.IsNullOrEmpty(Address1))
                        {
                            Console.WriteLine("please enter the Address name it cannot be blank");
                            Console.WriteLine("Enter the Address  again");
                            Address1 = Console.ReadLine();
                        }

                        
                        Console.WriteLine("enter the Gender");
                        Gender = Console.ReadLine();

                        while (String.IsNullOrEmpty(Gender))
                        {
                            Console.WriteLine("please enter the Gender it cannot be blank");
                            Console.WriteLine("Enter the Gender  again");
                            Gender = Console.ReadLine();
                        }


                        Console.WriteLine("enter the ContactNo");
                        Contact_No = Console.ReadLine();

                        while (true)
                        {
                            Console.Write("Enter Contact number : ");
                           long Cno = Convert.ToInt64(Console.ReadLine());
                            bool check = isValidContactNumber(Cno);


                            if (check == true)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Length of Contact number must be 10!!!");
                                continue;
                            }

                        }

                         bool isValidContactNumber(long inputContactNumber)
                        {
                            string strRegex = @"(^[0-9]{10}$)|(^\+[0-9]{2}\s+[0-9] {2}[0-9]{8}$)|(^[0-9]{3}-[0-9]{4}-[0-9]{4}$)";


                            Regex re = new Regex(strRegex);


                            if (re.IsMatch(Convert.ToString(inputContactNumber)))
                            {
                                return (true);
                            }

                            else
                            {
                                return (false);
                            }

                        }






                        Console.WriteLine("enter the CourseName");
                        Course_Name = Console.ReadLine();

                        while (String.IsNullOrEmpty(Course_Name))
                        {
                            Console.WriteLine("please enter the Course_Name it cannot be blank");
                            Console.WriteLine("Enter the Course_Name again");
                            Course_Name = Console.ReadLine();
                        }


                        Console.WriteLine("enter the Course_Fee");
                        Course_Fee = Console.ReadLine();

                        while (String.IsNullOrEmpty(Course_Fee))
                        {
                            Console.WriteLine("please enter the Course_Fee it cannot be blank");
                            Console.WriteLine("Enter the Course_Fee again");
                            Course_Fee = Console.ReadLine();
                        }

                        
                        Console.WriteLine("enter the TrainerName");
                        Trainer_Name = Console.ReadLine();

                        while (String.IsNullOrEmpty(Trainer_Name))
                        {
                            Console.WriteLine("please enter the Trainer_Name it cannot be blank");
                            Console.WriteLine("Enter the Trainer_Name again");
                            Trainer_Name = Console.ReadLine();
                        }

                        Console.WriteLine("Enter the Marks out of 50");
                        Student_Marks = Convert.ToInt32(Console.ReadLine());



                        
                        
                        Connection1.InsertData(Student_Rollno, StudentName, Address1, Gender, Contact_No, Course_Name, Course_Fee, Trainer_Name, Student_Marks);
                        break;

                    case 3:
                        Console.WriteLine("--------Update Details--------------");
                        Console.WriteLine("enter rollno");
                        rollno = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the new Marks");
                        int marks = Convert.ToInt32(Console.ReadLine());
                        Connection1.UpdateData(rollno,marks);
                        break;

                    case 4:
                        Console.WriteLine("--------Delete Student Rollno--------------");
                        Console.WriteLine("Enter the Rollno you want to delete");
                        Student_Rollno = Convert.ToInt32(Console.ReadLine());
                        Connection1.DeleteData(Student_Rollno);
                        break;

                    case 5:
                        Console.WriteLine("-----------Display Top 5--------------");
                        Console.WriteLine("Display Top5 StudentData");
                        Connection1.DisplayTop5();
                        break;

                    case 6:
                        Console.WriteLine("-----------Display Top Student Trainer and Course_Name--------------");
                        Console.WriteLine("Top Student Trainer and Course_Name");
                        Connection1.DisplayAverage();
                        break;


                    case 7:
                        Console.WriteLine("Exiting From Application");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Enter correct option");
                        break;


                }
            } while (true);



        }
        }
}
