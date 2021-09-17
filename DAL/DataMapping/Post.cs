using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataMapping
{
    public class Post : BaseModel
    {
        [Key] public int Id { get; set; }

        [Required] public string Title { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        [Index]
        public string Slug { get; set; }

        public string Description { get; set; }

        [Required] public string Content { get; set; }

        public int? Status { get; set; }
    }
}