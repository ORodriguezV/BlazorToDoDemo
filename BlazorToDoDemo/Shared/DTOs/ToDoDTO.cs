using BlazorToDoDemo.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorToDoDemo.Shared.DTOs
{
    public class ToDoDTO : ToDo
    {
        public string StatusName { get; set; }
    }
}
