using Application.FeatureFlagsTracker;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using SQLitePCL;

namespace API.Controllers
{    
    public class ProjectFlagsController : BaseApiController
    {      

        [HttpGet]//api/ProjectFlags
        public async Task<ActionResult<List<ProjectFeatureFlag>>> GetProjectsWithFlags()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]////api/ProjectFlags/{id}
        public async Task<ActionResult<ProjectFeatureFlag?>> GetProjectWithFlag(int id)
        {            
            return await Mediator.Send(new Details.Query{ProjectFeatureFlagId = id});
        }

        [HttpPost]
        public async Task<IActionResult> CreateProjectFeatureFlag([FromBody] ProjectFeatureFlag projflag)
        {
            await Mediator.Send(new Create.Command{projectFeatureFlag = projflag});
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProjectFeatureFlag(int id, ProjectFeatureFlag newProjectFeatureFlag)
        {
            newProjectFeatureFlag.ProjectFeatureFlagId = id;
            await Mediator.Send(new Edit.Command{projectFeatureFlag = newProjectFeatureFlag});

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectFeatureFlag(int id)
        {
            await Mediator.Send(new Delete.Command{ProjectFeatureFlagId = id});
            return Ok();
        }
    }
}
