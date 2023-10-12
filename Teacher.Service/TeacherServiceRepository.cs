using Microsoft.Data.SqlClient;
using Teacher.Library;
using Teacher.Service.Interfaces;


namespace Teacher.Service
{
    public class TeacherServiceRepository : ITeacherServiceRepository
    {
        public List<TeacherModel> GetAllTeachers()
        {
            const string sqlExpression = @"SELECT
	                                        Id,
	                                        FirstName,
	                                        LastName,
	                                        DateOfBirth,
	                                        Pin,
                                            Email
                                        FROM Teachers";

            List<TeacherModel> result = new();

            using (SqlConnection connection = new(HelperConfig.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(sqlExpression, connection);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            result.Add(new TeacherModel
                            {
                                Id = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                DateOfBirth = reader.GetDateTime(3),
                                Pin = reader.GetString(4),
                                Email = reader.GetString(5)
                            });
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }


            return result;
        }
    }
}
