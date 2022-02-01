using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RectangleAPI.Data;
using RectangleAPI.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RectangleAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RectanglesController : ControllerBase
    {
        private readonly ILogger<RectanglesController> _logger;

        public RectanglesController()
        {
        }

        public RectanglesController(ILogger<RectanglesController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("area/sort")]
        public async Task<ActionResult<List<Rectangle>>> Post([FromBody] List<Rectangle> rectangles)
        {
            //validate model here
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return (rectangles.OrderByDescending(x => (x.Length * x.Breadth))).ToList<Rectangle>();
        }

        //Simplified with Lamda Expression
        [HttpPost]
        [Route("area/sort1")]
        public async Task<ActionResult<List<Rectangle>>> Post1([FromBody] List<Rectangle> rectangles) =>
            (rectangles.OrderByDescending(x => (x.Length * x.Breadth))).ToList<Rectangle>();

        [HttpPost]
        [Route("area/sort2")]
        public async Task<ActionResult<List<Rectangle>>> Post2([FromBody] List<Rectangle> rectangles)
        {
            //validate model here
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return await new Util().SortRectanglesAsync(rectangles);
        }
    }
}
