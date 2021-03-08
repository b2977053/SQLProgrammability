using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLProgrammability.Models
{
    public class ProStoredProcedure
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar"), MaxLength(200)]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Execute{ get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Content { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Remark { get; set; }
        [Column(TypeName = "nvarchar"), MaxLength(100)]
        public string Tags { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}