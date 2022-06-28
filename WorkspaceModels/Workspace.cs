using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkspaceModels
{
    public class Workspace
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public List<Dictionary<DirectoryInfo, FileInfo>> DirectoriesAndFiles { get; set; } = new List<Dictionary<DirectoryInfo, FileInfo>>();
        public List<DirectoryInfo> FavoriteDictonaries { get; set; } = new List<DirectoryInfo>();
        public List<FileInfo> FavoriteFiles { get; set; } = new List<FileInfo>();   
    }
}
