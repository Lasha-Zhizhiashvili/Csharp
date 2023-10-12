using Xunit;

namespace Teacher.Service.Tests
{
    public class Teacher_Service_Should
    {
        [Fact]
        void Return_All_Teachers_From_Database()
        {
            TeacherServiceRepository studentServiceRepository = new();
            var result = studentServiceRepository.GetAllTeachers();
        }
    }
}
