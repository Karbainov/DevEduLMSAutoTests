using System.Data.SqlClient;

namespace DevEduLMSAutoTests.API.Support
{
    public class ClearBase
    {
        public void ClearDB()
        {
            string connectionString = Options.ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();

                command.CommandText = "delete from dbo.[User_Role] where UserId not in (5799, 5800, 5801, 5802, 6081, 6082)";
                command.Connection = connection;
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[User_Group]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Group_Lesson]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Lesson_Topic]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Student_Lesson]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[StudentRating]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Tag_Topic]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Tag_Material]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Tag_Task]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Tag]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Lesson]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Course_Material]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Course_Task]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Course_Topic]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Topic] where Id not in (703)";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Group_Material]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Student_Homework]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Homework]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Material]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Payment]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Task]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Group] where Id not in (1647)";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Comment]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Notification]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[User] where Id not in (5799, 5800, 5801, 5802, 6081, 6082)";
                command.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}
