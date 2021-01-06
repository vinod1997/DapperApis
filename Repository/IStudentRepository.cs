using Dapper;
using Microsoft.Extensions.Configuration;
using Student.Api.POCO;
using Student.Api.Services;
using Student.Api.Services.Queries.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student.Api.Repository
{
   public interface IStudentRepository
    {
        ValueTask<Student1> GetById(int id);
        
        Task<IEnumerable<Student1>> GetAllStudents();
        
        Task  AddStudent(Student1 entity);

    }
    public class StudentRepository : BaseRepository , IStudentRepository
    {
        private readonly IStudentCommandText _commandText;

        public StudentRepository(IConfiguration configuration, IStudentCommandText commandText) : base(configuration)
        {
            _commandText = commandText;

        }
        public Task AddStudent(Student1 entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Student1>> GetAllStudents()
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Student1>(_commandText.GetAllStudents);
                return query;
            });
        }

        public ValueTask<Student1> GetById(int id)
        {
            throw new NotImplementedException();
        }

       
    }
}
