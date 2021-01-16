using BlazorToDoDemo.Shared.DTOs;
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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusRepository statusRepository;
        public StatusController(IStatusRepository statusRepository)
        {
            this.statusRepository = statusRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Status>>> Get()
        {
            return await statusRepository.GetStatus();
        }
        
        [HttpGet("{idStatus}")]
        public async Task<ActionResult<Status>> GetById(Guid idStatus)
        {
            return await statusRepository.GetStatus(idStatus);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Status status)
        {
            // Create the new Guid on the server side to prevent client side "hacking"...
            status.IdStatus = Guid.NewGuid();
            await statusRepository.CreateStatus(status);
            return Created(string.Empty, status);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Status status)
        {
            await statusRepository.UpdateStatus(status);
            return NoContent();
        }

        [HttpDelete("{idStatus}")]
        public async Task<ActionResult> Delete(Guid idStatus)
        {
            await statusRepository.DeleteStatus(idStatus);
            return NoContent();
        }
    }
}
