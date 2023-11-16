using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderFile
{
    public class File
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullDirectory { get; set; }
        public int Size { get; set; }
    }
}
