using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResourcesCalculator.Models;

namespace ResourcesCalculator.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourcesController : ControllerBase
    {
        private readonly ResourcesContext _context;

        public ResourcesController (ResourcesContext context){
            _context=context;
            if(_context.BuildingsItems.Count()==0){
                
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.BuildingsItems.Add(new BuildingItem{Name="Choza",Resource="gold"});
                
                _context.SaveChanges();
            
            }
        }

// GET: api/Resources
[HttpGet]
public async Task<ActionResult<IEnumerable<BuildingItem>>> GetResourcesItems()
{
    return await _context.BuildingsItems.ToListAsync();
}
    }
}