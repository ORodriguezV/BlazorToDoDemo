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
        [Required(ErrorMessage = "id Status is required")]
        public Guid idStatus { get; set; }
        [MaxLength(100)]
        [Required(ErrorMessage = "status is required")]
        public string status { get; set; }
    }

    [Table("ToDo")]
    public class ToDo
    {
        [Key]
        [Required(ErrorMessage = "id To Do is required")]
        public Guid idToDo { get; set; }
        [MaxLength(255)]
        [Required(ErrorMessage = "subject is required")]
        public string subject { get; set; }
        [MaxLength]
        public string description { get; set; }
        [Required(ErrorMessage = "start Date is required")]
        public DateTime startDate { get; set; }
        public DateTime? dueDate { get; set; }
        [Required(ErrorMessage = "id Status is required")]
        public Guid idStatus { get; set; }
    }

}
