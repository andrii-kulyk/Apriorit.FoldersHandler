using System.Collections.Generic;
using Apriorit.HierarchyStructure.Mvc.Models;

namespace Apriorit.HierarchyStructure.Mvc.BL
{
    public interface IFoldersFacade
    {
        FoldersViewModel GetPathContent(string path);
    }
}