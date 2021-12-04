using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pubola.Model.Book
{
    public class BookListItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int GenreId { get; set; }
    }
}
