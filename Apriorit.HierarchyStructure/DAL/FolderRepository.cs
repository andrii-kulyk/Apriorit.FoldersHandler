using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Apriorit.HierarchyStructure.Mvc.Infrastructure;

namespace Apriorit.HierarchyStructure.Mvc.DAL
{
    public class FolderRepository : IFolderRepository
    {
        private readonly FoldersDbContext _context;

        public FolderRepository(FoldersDbContext context)
        {
            context.ThrowIfNull(nameof(context));
            _context = context;
        }

        public ICollection<FolderEntity> GetFolderContent(int? parentId)
        {
            return _context.Folders.Where(f => f.ParentId == parentId).ToList();
        }

        public ICollection<FolderEntity> GetFoldersTree(string lastFolder, int depth)
        {
            return _context.Database.SqlQuery<FolderEntity>("exec GetTrees @hierarchyLimit, @folderName", 
                new SqlParameter("hierarchyLimit", depth), 
                new SqlParameter("folderName", lastFolder))
                .ToList();
        }
    }
}