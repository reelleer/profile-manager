using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pm.Api.Models
{
    [Table("Profiles", Schema = "dbo")]
    public class Profile
    {
        public Guid ProfileId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        [Required]
        [MaxLength(150)]
        public string BirthPlace { get; set; }

        [Required]
        [MaxLength(150)]
        public string Country { get; set; }

        [Required]
        [MaxLength(150)]
        public string Address { get; set; }

        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(256)]
        public string Email { get; set; }

        [Required]
        [MaxLength(256)]
        public string Twitter { get; set; }

        [Required]
        [MaxLength(256)]
        public string Facebook { get; set; }

        [Required]
        [MaxLength(256)]
        public string Linkedin { get; set; }

        [Required]
        [MaxLength(256)]
        public string Instagram { get; set; }

        public byte Working { get; set; }

        [NotMapped]
        public string FullName => $"{Name} {LastName}";

        public virtual ICollection<StudyItem> Studies { get; set; }

        public Poll Poll { get; set; }
    }  
}
