using Volo.Abp.Domain.Entities;

namespace StudentsCRUD.Entities
{
    public class Student:BasicAggregateRoot<Guid>
    {
        public string? Name { get; set; }
        public string? Email { get; set; }

    }
}
