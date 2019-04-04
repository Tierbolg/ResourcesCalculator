using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResourcesCalculator.Models;

namespace ResourcesCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourcesController : ControllerBase
    {
        private readonly ResourcesContext _context;

        public ResourcesController(ResourcesContext context)
        {
            _context = context;
            if (_context.BuildingsItems.Count() == 0)
            {

                // Create a new BuildingItemObtained if collection is empty,
                // which means you can't delete all BuildingItemObtaineds.
                _context.BuildingsItems.Add(new BuildingItem { Name = "Choza", Resource = "gold" });

                _context.SaveChanges();

            }
        }

        // GET: api/Resources
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuildingItem>>> GetResourcesItems()
        {
            return await _context.BuildingsItems.ToListAsync();
        }

        // GET: api/Resources/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BuildingItem>> GetBuildingItem(long id)
        {
            var buildItem = await _context.BuildingsItems.FindAsync(id);

            if (buildItem == null)
            {
                return NotFound();
            }

            return buildItem;
        }

        // POST: api/Resources
        [HttpPost]
        public async Task<ActionResult<BuildingItem>> PostBuildingItem(BuildingItem item)
        {
            _context.BuildingsItems.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBuildingItem), new { id = item.Id }, item);
        }

        // PUT: api/Resources/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuildingItem(long id, BuildingItem item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Resources/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuildingItem(long id)
        {
            var BuildingItemObtained = await _context.BuildingsItems.FindAsync(id);

            if (BuildingItemObtained == null)
            {
                return NotFound();
            }

            _context.BuildingsItems.Remove(BuildingItemObtained);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}