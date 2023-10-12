using Teacher.Library;

namespace Teacher.Service.Interfaces
{
    public interface ITeacherServiceRepository
    {
        List<TeacherModel> GetAllTeachers();
    }
}
