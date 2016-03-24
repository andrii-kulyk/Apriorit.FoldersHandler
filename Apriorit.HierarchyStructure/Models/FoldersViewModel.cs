using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Apriorit.HierarchyStructure.Mvc.Models
{
    public class FoldersViewModel
    {
        public FoldersViewModel()
        {
            SubFolders = new Collection<FolderViewModel>();
        }
        public string CurrentFolder { get; set; }
        public ICollection<FolderViewModel> SubFolders { get; set; }
    }
}