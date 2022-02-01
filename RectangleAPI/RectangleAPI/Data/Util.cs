using RectangleAPI.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RectangleAPI.Data
{
    public class Util
    {
        public async Task<List<Rectangle>> SortRectanglesAsync(List<Rectangle> rectangles)
        {
            return (rectangles.OrderByDescending(x => x.Length * x.Breadth)).ToList<Rectangle>();
        }
    }
}
