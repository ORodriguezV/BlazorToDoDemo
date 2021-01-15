using BlazorToDoDemo.Shared.Entities;
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

        Task<ToDo> GetToDo(Guid idToDo);

        Task CreateToDo(ToDo toDo);

        Task UpdateToDo(ToDo toDo);

        Task DeleteToDo(Guid idToDo);
    }
}
