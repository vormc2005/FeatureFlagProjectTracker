using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using SQLitePCL;

namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProjectFlagsController : ControllerBase
    {
        private DataContext _context;

        public ProjectFlagsController(DataContext context)
        {
            _context = context; 
        }  

        [HttpGet]//api/ProjectFlags
        public async Task<ActionResult<List<ProjectFeatureFlag>>> GetProjectsWithFlags()
        {
            return await _context.ProjectFeatureFlags.ToListAsync();
        }

        [HttpGet("{id}")]////api/ProjectFlags/{id}
        public async Task<ActionResult<ProjectFeatureFlag?>> GetProjectWithFlag(int id)
        {
            var result = await _context.ProjectFeatureFlags.FindAsync(id);
            return result;
        }
    }
}
