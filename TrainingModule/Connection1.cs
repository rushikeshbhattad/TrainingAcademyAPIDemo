﻿using System;
using System.Data.SqlClient;

namespace TrainingModule
{
    public class Connection1
    {
        public string constr;
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataReader dr;

        public static void CreateConnection()
        {
            string constr = "Data Source = DESKTOP-ECNJ0P3\\SQLEXPRESS; Initial Catalog=Training_Academy;user =sa; Password=pass@123";

            con = new SqlConnection();
            con.ConnectionString = constr;
            Console.WriteLine("Connection Successful");
        }

        public static void InsertData(int Student_Rollno, string StudentName, string Address1, string Gender, string Contact_No, string Course_Name, string Course_Fee, string Trainer_Name,int Student_Marks)
        {
            con.Open();
            

            string query = "insert into StudentDetails (Student_Rollno, StudentName, Address1,Gender,Contact_No, Course_Name, Course_Fee, Trainer_Name, Student_Marks) values (" + Student_Rollno + ",'" + StudentName + "','" + Address1 + "','" + Gender + "','" + Contact_No + "','" + Course_Name + "','" + Course_Fee + "','" + Trainer_Name +"'," +  Student_Marks +")";
            cmd = new SqlCommand(query, con);

            int r = cmd.ExecuteNonQuery();
            Console.WriteLine("{0} of rows affected", r);
            con.Close();

        }

        public static void DisplayData()
        {
            con.Open();
            string query = "Select * from StudentDetails";
            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();
            Console.WriteLine("Student_Rollno\t\t\t\t\t\t ||||||||||||StudentName\t\t\t\t\t\t |||||||||Address\t\t\t\t\t Gender \t\t\t Contact_No \t\t\t\t\t\t Course_Name \t\t\t\t\t\t Course_Fee \t\t\t\t\t\t Trainer_Name \t\t\t\t\t\t Student_Marks");
           





            while (dr.Read())
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}", dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7], dr[8]);
                
            }
            dr.Close();
            string cmdcount = "Select count(*) from StudentDetails ";
            cmd = new SqlCommand(cmdcount, con);
            int count = (int)cmd.ExecuteScalar();
            Console.WriteLine("{0} Records in the table", count);
            Console.ReadKey();
            con.Close();
        }
        public static void UpdateData(int x,int y)
        {
            con.Open();
            
            string query = "Update StudentDetails Set Student_Marks =@marks where Student_Rollno=@rn";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("rn",x));
            cmd.Parameters.Add(new SqlParameter("marks", y));

            int r = cmd.ExecuteNonQuery();
            Console.WriteLine("{0} rows affected", r);
            con.Close();

        }
        public static void DeleteData(int y)
        {
            con.Open();
            string query = "Delete from StudentDetails Where Student_Rollno=@rn";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("rn",y));
            int r = cmd.ExecuteNonQuery();

            Console.WriteLine("{0} rows affected", r);
            con.Close();
        }

        public static void DisplayTop5()
        {
            con.Open();
            string query = "SELECT Top 5 * From StudentDetails ORDER BY Student_Marks DESC ";
            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();
            Console.WriteLine("Student_Rollno \t StudentName \t Address \t Gender \t Contact_No \t Course_Name \t Course_Fee \t Trainer_Name \t Student_Marks ");
            while (dr.Read())
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}", dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7], dr[8]);

            }
            dr.Close();
            string cmdcount = "Select count(*) from StudentDetails ";
            cmd = new SqlCommand(cmdcount, con);
            int count = (int)cmd.ExecuteScalar();
            Console.WriteLine("{0} Records in the table", count);
            Console.ReadKey();
            con.Close();
        }

        public static void DisplayAverage()
        {
            con.Open();
            string query = "SELECT Top 5 * From StudentDetails ORDER BY Student_Marks DESC ";
            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();
            Console.Write("Course Name | Trainer Name | Marks \n");
            while (dr.Read())
            {
                Console.Write("{0}\t\t|{1}\t\t|{2}\n", dr[5], dr[7],dr[8]);
                
            }
            Console.WriteLine("----------------------*************--------------------");
            dr.Close();
            con.Close();
        }
    }
}
