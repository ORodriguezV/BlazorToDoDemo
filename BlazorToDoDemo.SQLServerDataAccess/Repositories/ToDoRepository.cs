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
    public class ToDoRepository : IToDoRepository
    {
        private readonly ConnectionStringsOptions connectionStringsOptions;

        public ToDoRepository(IOptions<ConnectionStringsOptions> connectionStringsOptions)
        {
            this.connectionStringsOptions = connectionStringsOptions.Value;
        }

        public async Task<List<ToDo>> GetToDos()
        {
            using (SqlConnection sqlConn = new SqlConnection(this.connectionStringsOptions.DefaultConnection))
            {
                return (await sqlConn.QueryAsync<ToDo>(@"
                    select * from ToDo")).ToList();
            }
        }
        public async Task<List<ToDoDTO>> GetToDosDTO()
        {
            using (SqlConnection sqlConn = new SqlConnection(this.connectionStringsOptions.DefaultConnection))
            {
                return (await sqlConn.QueryAsync<ToDoDTO>(@"
                    select ToDo.*, Status.StatusName from ToDo inner join Status on ToDo.IdStatus = Status.IdStatus")).ToList();
            }
        }
        public async Task<ToDo> GetToDo(Guid IdToDo)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.connectionStringsOptions.DefaultConnection))
            {
                return (await sqlConn.QueryAsync<ToDo>(@"
                    select * from ToDo where IdToDo = @IdToDo", 
                    new { IdToDo })).FirstOrDefault();
            }
        }
        public async Task CreateToDo(ToDo toDo)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.connectionStringsOptions.DefaultConnection))
            {
                await sqlConn.ExecuteAsync(@"
                    insert into ToDo 
                    (IdToDo, Subject, Description, IdStatus)
                    values
                    (@IdToDo, @Subject, @Description, @IdStatus)",
                    new { 
                        toDo.IdToDo,
                        toDo.Subject,
                        toDo.Description,
                        toDo.IdStatus
                    });
            }
        }
        public async Task UpdateToDo(ToDo toDo)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.connectionStringsOptions.DefaultConnection))
            {
                await sqlConn.ExecuteAsync(@"
                    update 
                        ToDo
                    set 
	                    Subject = @Subject, 
	                    Description = @Description, 
	                    IdStatus = @IdStatus
                    where
	                    IdToDo = @IdToDo",
                    new
                    {
                        toDo.IdToDo,
                        toDo.Subject,
                        toDo.Description,
                        toDo.IdStatus
                    });
            }
        }
        public async Task DeleteToDo(Guid IdToDo)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.connectionStringsOptions.DefaultConnection))
            {
                await sqlConn.ExecuteAsync(@"
                    delete from ToDo where IdToDo = @IdToDo",
                    new { IdToDo });
            }
        }

    }
}
