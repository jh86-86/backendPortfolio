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

  public void Delete(long id)
  {
    using var connection= CreateConnection();
    connection.Execute("DELETE FROM Projects WHERE Id= @Id ", new {Id= id});
  }

    public async Task<Project> Insert(Project projectToInsert)
  {
    using var connection = CreateConnection();
    return await connection.QuerySingleAsync<Project>("INSERT INTO project(Name, Link , Image, ProjectInfo,Description) VALUES (@Name, @Link, @Image, @ProjectInfo,@Description)  RETURNING *", projectToInsert);
  }
  
}