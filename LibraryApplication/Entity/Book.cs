using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Book
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public int Stock { get; set; }

        public virtual Category Category { get; set; }
        public virtual List<Author> GetBookAuthors { get; set; }
        public virtual Reservation Reservation { get; set; }

    }


}
