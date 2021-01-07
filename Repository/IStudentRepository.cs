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
        ValueTask<Student1> GetById(Product entity, int id);
        
        Task<IEnumerable<Student1>> GetAllStudents();
        
        Task AddStudent(Student1 entity);
        //Task UpdateStudent(Student1 entity, int id);
        //Task RemoveStudent(int id);

    }
    public class StudentRepository : BaseRepository , IStudentRepository
    {
        private readonly IStudentCommandText _commandText;

        public StudentRepository(IConfiguration configuration, IStudentCommandText commandText) : base(configuration)
        {
            _commandText = commandText;

        }

        public async Task AddStudent(Student1 entity)
        {
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync(_commandText.AddStudent,
                    new { Name = entity.Name, Department = entity.Department });
            });
        }

        public async Task<IEnumerable<Student1>> GetAllStudents()
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Student1>(_commandText.GetAllStudents);
                return query;
            });
        }



        public async ValueTask<Student1> GetById(Product entity, int id)
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryFirstOrDefaultAsync<Student1>(_commandText.GetStudentById, new { Id = id });
                return query;
            });
        }

        //public Task RemoveStudent(int id)
        //{
        //    await WithConnection(async conn =>
        //    {
        //        await conn.ExecuteAsync(_commandText.RemoveStudent, new { Id = id });
        //    });
        //}

        //public Task UpdateStudent(Student1 entity, int id)
        //{
        //    throw new NotImplementedException();
        //}
      }
   }
