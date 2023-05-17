using StudentsCRUD.Entities;
using StudentsCRUD.Services.Dtos;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace StudentsCRUD.Services
{
    public class StudentAppService:ApplicationService
    {
        private readonly IRepository<Student, Guid> _studentRepositary;
        
        public StudentAppService (IRepository<Student, Guid> studentRepositary)
        {
            _studentRepositary = studentRepositary;
        }

        public async Task<StudentDto> Create(StudentDto input)
        {
            // Validate input
            if (await _studentRepositary.FirstOrDefaultAsync(x => x.Email == input.Email) != null)
            {
                throw new UserFriendlyException("Email already exists!");
            }

            // Create student entity
            var student = ObjectMapper.Map<StudentDto, Student>(input);
            await _studentRepositary.InsertAsync(student);
            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<Student, StudentDto>(student);

        }

     
        public async Task<StudentDto> Get(Guid id)
        {
            // Get student entity
            var studentQuery = await _studentRepositary.GetQueryableAsync();
            var student = studentQuery.FirstOrDefault(x => x.Id == id);

            // Return DTO
            return ObjectMapper.Map<Student, StudentDto>(student);
        }

        public async Task<List<StudentDto>> GetAll()
        {
            // Get all student entities
            var studentQuery = await _studentRepositary.GetQueryableAsync();
            var students = studentQuery.ToList();

            // Return DTOs
            return ObjectMapper.Map<List<Student>, List<StudentDto>>(students);
        }


        public async Task<StudentDto> Update(StudentDto input, Guid id)
        {
            // Validate input
            if (await _studentRepositary.FirstOrDefaultAsync(x => x.Email == input.Email && x.Id != input.Id) != null)
            {
                throw new UserFriendlyException("Email already exists!");
            }

            // Get student entity
            var studentQuery = await _studentRepositary.GetQueryableAsync();
            var studentToUpdate = studentQuery.FirstOrDefault(x => x.Id == id);
            if (studentToUpdate != null)
            {
                studentToUpdate.Email = input.Email;
                studentToUpdate.Name = input.Name;
            }
            await _studentRepositary.UpdateAsync(studentToUpdate);
            return ObjectMapper.Map<Student, StudentDto>(studentToUpdate);

        }

        public async Task Delete(Guid id)
        {
            // Delete student entity
            var students = await _studentRepositary.GetQueryableAsync();
            var student = students.FirstOrDefault(x => x.Id == id);
            await _studentRepositary.DeleteAsync(student);
        }
    }
}

