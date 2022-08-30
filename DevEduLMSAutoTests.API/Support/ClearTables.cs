using System.Data.SqlClient;

namespace DevEduLMSAutoTests.API.Support
{
    public class ClearTables
    {
        public void ClearDB()
        {
            string connectionString = Options.ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();

                command.CommandText = "delete from dbo.[User_Role] where UserId not in (5799, 5800, 5801, 5802)";
                command.Connection = connection;
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[User_Group]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Group_Lesson]";
                command.ExecuteNonQuery();
                
                command.CommandText = "delete from dbo.[Lesson_Topic]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Lesson]";
                command.ExecuteNonQuery();
                
                command.CommandText = "delete from dbo.[Student_Homework]";
                command.ExecuteNonQuery();
                
                command.CommandText = "delete from dbo.[Notification]";
                command.ExecuteNonQuery();
                
                command.CommandText = "delete from dbo.[User] where Id not in (5799, 5800, 5801, 5802)";
                command.ExecuteNonQuery();



                connection.Close();
            }
        }
    }
}
