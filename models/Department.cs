using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dotnetcore_ef_mysql_docker.models
{
    public class Department
    {
         [Required]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<Student> Student { get; set; }
    }
}