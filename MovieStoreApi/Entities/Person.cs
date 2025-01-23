using System.ComponentModel.DataAnnotations;

namespace MovieStoreApi.Entities
{
    public class Person
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }
        
        [MaxLength(50)]
        public string? Phone { get; set; }
 
        public DateTime CreateDate { get; } = DateTime.Now;
    }
}