using BlazorToDoDemo.Shared.Entities;
using BlazorToDoDemo.Shared.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorToDoDemo.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDosController : ControllerBase
    {
        private readonly IToDoRepository toDoRepository;
        public ToDosController(IToDoRepository toDoRepository)
        {
            this.toDoRepository = toDoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ToDo>>> Get()
        {
            return await toDoRepository.GetToDos();
        }

        [HttpGet("{idToDo}")]
        public async Task<ActionResult<ToDo>> GetById(Guid idToDo)
        {
            return await toDoRepository.GetToDo(idToDo);
        }

        [HttpPost]
        public async Task<ActionResult> Post(ToDo toDo)
        {
            await toDoRepository.CreateToDo(toDo);
            return Created(string.Empty, toDo);
        }

        [HttpPut]
        public async Task<ActionResult> Put(ToDo toDo)
        {
            await toDoRepository.UpdateToDo(toDo);
            return NoContent();
        }

        [HttpDelete("{idToDo}")]
        public async Task<ActionResult> Delete(Guid idToDo)
        {
            await toDoRepository.DeleteToDo(idToDo);
            return NoContent();
        }
    }
}
