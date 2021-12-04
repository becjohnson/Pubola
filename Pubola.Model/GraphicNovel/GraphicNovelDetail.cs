using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pubola.Model.GraphicNovel
{
    public class GraphicNovelDetail
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public long Isbn { get; set; }
        public int Edition { get; set; }
        public int GenreId { get; set; }
    }
}
