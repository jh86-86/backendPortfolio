using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Linq;

[ApiController]
[Route("[controller]s")]

public class ProjectController: ControllerBase
{
    public readonly IRepository<Project>   _projectRepository;

    public ProjectController(IRepository<Project> projectRepository)
    {
        _projectRepository= projectRepository;
    }

[HttpGet]

public async Task<IActionResult> Get()
{
    try
    {
      var allProjects = await _projectRepository.GetAll();
      return Ok(allProjects);
    }
    catch (Exception)
    {
      return NotFound("Sorry there are no projects");
    }
}

[HttpDelete("{id}")]
  public IActionResult Delete(long id)
  {
    try
    {
      _projectRepository.Delete(id);
      return Ok($"Project at id {id} is successfully deleted.");
    }
    catch (Exception)
    {
      return BadRequest($"Sorry, project of id {id} cannot be deleted, since it does not exit.\nAre you sure the id is correct?");
    }
  }

    [HttpPost]

  public async Task<IActionResult> Post([FromBody] Project projectToPost)
  {
    try
    {
      var postedProject = await _projectRepository.Insert(projectToPost);
      return Created($"/project/{postedProject.Id}", postedProject);
    }
    catch (Exception)
    {
      return BadRequest("Sorry can not insert your project, is it valid?\nTry another project");
    }
  }

  [HttpPut("{id}")]

  public async Task<IActionResult> Put(long id, [FromBody] Project projectToPut)
  {
    try
    {
      projectToPut.Id = id;
      var updatedProject = await _projectRepository.Update(projectToPut);
      return Ok(updatedProject);
    }
    catch (Exception)
    {
      return BadRequest("Sorry can not update your project. Is your id and your project valid?");
    }
}
}