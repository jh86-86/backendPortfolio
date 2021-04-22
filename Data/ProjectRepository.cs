using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Threading.Tasks;
using System;

public class ProjectRepository : BaseRepository, IRepository<Project>
{
  public ProjectRepository(IConfiguration configuration) : base(configuration) { }
  public async Task<IEnumerable<Project>> GetAll()
  {
    using var connection = CreateConnection();
    return await connection.QueryAsync<Project>("SELECT * FROM Projects;");
  }
}