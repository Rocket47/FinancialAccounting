using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancialAccounting
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Description { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public double Sum {get; set;} 

        [Column(TypeName = "nvarchar(100)")]      
        public string Date { get; set; }
    }
}
