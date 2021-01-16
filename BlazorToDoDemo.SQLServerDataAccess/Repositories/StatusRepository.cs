using BlazorToDoDemo.Shared.DTOs;
using BlazorToDoDemo.Shared.Entities;
using BlazorToDoDemo.Shared.Helpers;
using BlazorToDoDemo.Shared.IRepositories;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorToDoDemo.SQLServerDataAccess.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly ConnectionStringsOptions connectionStringsOptions;

        public StatusRepository(IOptions<ConnectionStringsOptions> connectionStringsOptions)
        {
            this.connectionStringsOptions = connectionStringsOptions.Value;
        }

        public async Task<List<Status>> GetStatus()
        {
            using (SqlConnection sqlConn = new SqlConnection(this.connectionStringsOptions.DefaultConnection))
            {
                return (await sqlConn.QueryAsync<Status>(@"
                    select * from Status order by [Order] asc")).ToList();
            }
        }
        public async Task<Status> GetStatus(Guid IdStatus)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.connectionStringsOptions.DefaultConnection))
            {
                return (await sqlConn.QueryAsync<Status>(@"
                    select * from Status where IdStatus = @IdStatus", 
                    new { IdStatus })).FirstOrDefault();
            }
        }
        public async Task CreateStatus(Status status)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.connectionStringsOptions.DefaultConnection))
            {
                await sqlConn.ExecuteAsync(@"
                    insert into Status 
                    (IdStatus, StatusName)
                    values
                    (@IdStatus, @StatusName)",
                    new { 
                        status.IdStatus,
                        status.StatusName
                    });
            }
        }
        public async Task UpdateStatus(Status status)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.connectionStringsOptions.DefaultConnection))
            {
                await sqlConn.ExecuteAsync(@"
                    update 
                        Status
                    set 
	                    StatusName = @StatusName
                    where
	                    IdStatus = @IdStatus",
                    new
                    {
                        status.IdStatus,
                        status.StatusName
                    });
            }
        }
        public async Task DeleteStatus(Guid IdStatus)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.connectionStringsOptions.DefaultConnection))
            {
                await sqlConn.ExecuteAsync(@"
                    delete from Status where IdStatus = @IdStatus",
                    new { IdStatus });
            }
        }

    }
}
