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
}