using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MovieStoreApi.Entities
{
    public class Person : IdentityUser<int>
    {
        
        [MaxLength(50)]
        public string? Name { get; set; }

        public DateTime BirthDate { get; set; }


        [MaxLength(50)]
        public string? Phone { get; set; }  

        public DateTime CreateDate { get; private set; } = DateTime.Now;
    }
}