using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apriorit.HierarchyStructure.Mvc.DAL
{
    [Table("Folders")]
    public class FolderEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public virtual FolderEntity Parent { get; set; }
    }
}