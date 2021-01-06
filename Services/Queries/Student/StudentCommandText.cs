using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student.Api.Services.Queries.Student
{
    public interface IStudentCommandText
    {
        public string GetAllStudents { get; }
        public string GetStudentById { get; }
        public string AddStudent { get; }
    }
    public class StudentCommandText : IStudentCommandText
    {
        public string GetAllStudents => "select * from Student";

        public string GetStudentById => "select * from Student where Id = @Id";

        public string AddStudent => "Insert Into  Student (Name, Department) Values (@Name, @Department)";

    }
}
