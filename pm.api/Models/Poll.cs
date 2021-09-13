using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pm.Api.Models
{
    [Table("Polls", Schema = "dbo")]
    public class Poll
    {
        [Key]
        public Guid ProfileId { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Opportunities { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Activities { get; set; }

        public byte Contacts { get; set; }

        public bool Follower { get; set; }

    }
}
