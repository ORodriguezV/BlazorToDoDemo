using BlazorToDoDemo.Client.Helpers;
using BlazorToDoDemo.Shared.DTOs;
using BlazorToDoDemo.Shared.Entities;
using BlazorToDoDemo.Shared.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorToDoDemo.Client.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly IHttpService httpService;
        private string url = "api/todos";

        public ToDoRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }
        public async Task<List<ToDo>> GetToDos()
        {
            return await httpService.GetHelper<List<ToDo>>($"{url}/get");
        }
        public async Task<List<ToDoDTO>> GetToDosDTO()
        {
            return await httpService.GetHelper<List<ToDoDTO>>($"{url}/getdto");
        }
        public async Task<ToDo> GetToDo(Guid idToDo)
        {
            return await httpService.GetHelper<ToDo>($"{url}/getbyid/{idToDo}");
        }
        public async Task CreateToDo(ToDo toDo)
        {
            await httpService.PostHelper($"{url}/post", toDo);
        }
        public async Task UpdateToDo(ToDo toDo)
        {
            await httpService.PutHelper($"{url}/put", toDo);
        }
        public async Task DeleteToDo(Guid idToDo)
        {
            await httpService.DeleteHelper($"{url}/delete/{idToDo}");
        }
    }
}
