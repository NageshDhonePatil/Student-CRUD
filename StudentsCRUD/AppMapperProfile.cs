using AutoMapper;
using StudentsCRUD.Entities;
using StudentsCRUD.Services.Dtos;

namespace StudentsCRUD
{
    public class AppMapperProfile : Profile
    {
        public AppMapperProfile()
        {
            CreateMap<StudentDto, Student>();
            CreateMap<Student, StudentDto>();

            // CreateMap<DepartmentDto, Department>();
        }
    }
}
