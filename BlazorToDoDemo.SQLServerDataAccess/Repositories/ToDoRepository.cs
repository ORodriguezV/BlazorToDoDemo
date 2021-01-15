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
                    select * FROM ToDo")).ToList();
            }
        }
        public async Task<ToDo> GetToDo(Guid idToDo)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.connectionStringsOptions.DefaultConnection))
            {
                return (await sqlConn.QueryAsync<ToDo>(@"
                    select * from ToDo where idToDo = @idToDo", 
                    new { idToDo })).FirstOrDefault();
            }
        }
        public async Task CreateToDo(ToDo toDo)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.connectionStringsOptions.DefaultConnection))
            {
                await sqlConn.ExecuteAsync(@"
                    insert into ToDo 
                    (idToDo, subject, description, startDate, dueDate, idStatus)
                    values
                    (@idToDo, @subject, @description, @startDate, @dueDate, @idStatus)",
                    new { 
                        toDo.idToDo,
                        toDo.subject,
                        toDo.description,
                        toDo.startDate,
                        toDo.dueDate,
                        toDo.idStatus
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
	                    subject = @subject, 
	                    description = @description, 
	                    startDate = @startDate,
	                    dueDate = @dueDate,
	                    idStatus = @idStatus
                    where
	                    idToDo = @idToDo",
                    new
                    {
                        toDo.idToDo,
                        toDo.subject,
                        toDo.description,
                        toDo.startDate,
                        toDo.dueDate,
                        toDo.idStatus
                    });
            }
        }
        public async Task DeleteToDo(Guid idToDo)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.connectionStringsOptions.DefaultConnection))
            {
                await sqlConn.ExecuteAsync(@"
                    delete from ToDo where idToDo = @idToDo",
                    new { idToDo });
            }
        }

    }
}
