using BlazorToDoDemo.Shared.Entities;
using BlazorToDoDemo.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorToDoDemo.Shared.IRepositories
{
    public interface IToDoRepository
    {
        Task<List<ToDo>> GetToDos();

        Task<List<ToDoDTO>> GetToDosDTO();

        Task<ToDo> GetToDo(Guid idToDo);

        Task CreateToDo(ToDo toDo);

        Task UpdateToDo(ToDo toDo);

        Task DeleteToDo(Guid idToDo);
    }
}
