using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Apriorit.HierarchyStructure.Mvc.DAL
{
    public class FoldersDbContext : DbContext
    {
        public FoldersDbContext() : base("name=FoldersDbContext")
        {
        }
        public FoldersDbContext(string connString) : base(connString)
        {
        }

        public virtual DbSet<FolderEntity> Folders { get; set; } 
    }
}