using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorToDoDemo.Shared.Entities
{

    [Table("Status")]
    public class Status
    {
        [Key]
        [Required]
        public Guid IdStatus { get; set; }
        [MaxLength(100)]
        [Required]
        public string StatusName { get; set; }
        [Required]
        public int Order { get; set; }
    }

    [Table("ToDo")]
    public class ToDo
    {
        [Key]
        [Required]
        public Guid IdToDo { get; set; }
        [MaxLength(255)]
        [Required]
        public string Subject { get; set; }
        [Required]
        public Guid IdStatus { get; set; }
        [MaxLength(4000)]
        public string Description { get; set; }
    }

}
