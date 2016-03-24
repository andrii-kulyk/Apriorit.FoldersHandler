using System.Collections.Generic;

namespace Apriorit.HierarchyStructure.Mvc.DAL
{
    public interface IFolderRepository
    {
        ICollection<FolderEntity> GetFolderContent(int? parentId);
        ICollection<FolderEntity> GetFoldersTree(string lastFolder, int depth);
    }
}