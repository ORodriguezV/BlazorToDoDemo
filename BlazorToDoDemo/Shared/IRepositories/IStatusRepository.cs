using BlazorToDoDemo.Shared.Entities;
using BlazorToDoDemo.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorToDoDemo.Shared.IRepositories
{
    public interface IStatusRepository
    {
        Task<List<Status>> GetStatus();

        Task<Status> GetStatus(Guid idStatus);

        Task CreateStatus(Status status);

        Task UpdateStatus(Status status);

        Task DeleteStatus(Guid idStatus);
    }
}
