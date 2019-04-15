using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LibraryContext : DbContext
    {
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }

        protected override void OnModelCreating(DbModelBuilder mb)
        {
            #region Relation
            mb.Entity<Category>().HasMany(x => x.GetCategoryBooks).WithRequired(x => x.Category).HasForeignKey(x => x.CategoryId);
            mb.Entity<Book>().HasMany(x => x.GetBookAuthors).WithMany(x => x.GetAuthorBooks);
            mb.Entity<Book>().HasRequired(x => x.Reservation).WithRequiredPrincipal(x => x.GetResBook);
            mb.Entity<User>().HasRequired(x => x.Reservation).WithRequiredPrincipal(x => x.GetResUser);
            #endregion
            base.OnModelCreating(mb);
        }

    }
}
