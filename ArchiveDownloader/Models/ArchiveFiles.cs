using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveDownloader
{
    public class ArchiveFiles
    {
        public ArchiveFile[] Files { get; set; }
    }

    public class ArchiveFile
    {
        public string Name { get; set; }
        public string Link { get; set; }
    }

}
