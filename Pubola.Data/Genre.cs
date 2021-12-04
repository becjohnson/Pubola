using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pubola.Data
{
    public class Genre
    {
        public int GenreId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<GraphicNovel> GraphicNovels { get; set; }
        public virtual ICollection<Magazine> Magazines { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
