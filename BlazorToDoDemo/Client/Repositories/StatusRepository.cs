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
    public class StatusRepository : IStatusRepository
    {
        private readonly IHttpService httpService;
        private string url = "api/status";

        public StatusRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }
        public async Task<List<Status>> GetStatus()
        {
            return await httpService.GetHelper<List<Status>>($"{url}/get");
        }
        public async Task<Status> GetStatus(Guid idStatus)
        {
            return await httpService.GetHelper<Status>($"{url}/getbyid/{idStatus}");
        }
        public async Task CreateStatus(Status status)
        {
            await httpService.PostHelper($"{url}/post", status);
        }
        public async Task UpdateStatus(Status status)
        {
            await httpService.PutHelper($"{url}/put", status);
        }
        public async Task DeleteStatus(Guid idStatus)
        {
            await httpService.DeleteHelper($"{url}/delete/{idStatus}");
        }
    }
}
