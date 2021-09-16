using System;
using System.Data.SqlClient

namespace TrainingModule
{
    public class Connection
    {
        public string connstr;
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataReader dr;

        public static void CreateConnection()
        {
            string connstr = "Data Source = DESKTOP-ECNJ0P3\\SQLEXPRESS; Initial Catalog=Training_Academy; Integrated Security=true; User ID=sa; Password=pass@123";

            con = new SqlConnection();
            con.ConnectionString = connstr;
            Console.WriteLine("Connection Successful");
        }

        public static void InsertData(int Student_Rollno, string StudentName, string Address, string Gender, string Contact_No, string Course_Name, string Course_Fee, string Trainer_Name)
        {
            con.Open();

            string query = "insert into Training_Academy values ('" + StudentName + "','" + Student_Rollno + "','" + Address + "','" + Gender + "','" + Contact_No + "','" + Course_Name + "','" + Course_Fee + "','" + Trainer_Name + "')";
            cmd = new SqlCommand(query, con);

            int r = cmd.ExecuteNonQuery();
            Console.WriteLine("{0} of rows affected", r);
            con.Close();

        }
        public static void DisplayData()
        {
            con.Open();
            string query = "Select * from Training_Academy";
            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();
            Console.WriteLine("StudentName \t Student_Rollno \t Address \t Gender \t Contact_No \t Course_Name \t Course_Fee \t Trainer_Name");
            while (dr.Read())
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}", dr[0], dr["1"], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7]);

            }
            dr.Close();
            string cmdcount = "Select count(*) from Training_Academy";
            cmd = new SqlCommand(cmdcount, con);
            int count = (int)cmd.ExecuteScalar();
            Console.WriteLine("{0} Records in the table", count);
            Console.ReadKey();
            con.Close();
        }
        public static void UpdateData()
        {
            con.Open();
            string query = "Update StudentDetails Set StudentName=", Where Student_RollNo = "'";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter());
            cmd.Parameters.Add(new SqlParameter());
            int r = cmd.ExecuteNonQuery();
            Console.WriteLine("{0} rows affected", r);
            con.Close();

        }
        public static void DeleteData()
        {
            con.Open();
            string query = "Delete from StudentDetails Where Student_RollNo="'"
            cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter());
            int r = cmd.ExecuteNonQuery();

            Console.WriteLine("{0} rows affected", r);
            con.Close();
        }

    }
}
