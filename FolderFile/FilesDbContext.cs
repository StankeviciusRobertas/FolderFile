using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderFile
{
    public class FilesDbContext : DbContext
    {
        public DbSet<File> Files { get; set; }
        public DbSet<Folder> Folders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Server=localhost;Database=FolderFilesDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
