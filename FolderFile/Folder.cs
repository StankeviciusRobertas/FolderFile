using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderFile
{
    public class Folder
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<File> Files { get; set; }
    }
}
