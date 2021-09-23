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
        [Key]
        public Guid ProfileId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        [MaxLength(150)]
        public string BirthPlace { get; set; }

        [MaxLength(150)]
        public string Country { get; set; }

        [MaxLength(150)]
        public string Address { get; set; }

        [MaxLength(100)]
        public string Phone { get; set; }

        [MaxLength(256)]
        public string Email { get; set; }

        [MaxLength(256)]
        public string Twitter { get; set; }

        [MaxLength(256)]
        public string Facebook { get; set; }

        [MaxLength(256)]
        public string Linkedin { get; set; }

        [MaxLength(256)]
        public string Instagram { get; set; }

        public byte Working{ get; set; }

        [NotMapped]
        public string FullName => $"{Name} {LastName}";

        public string OriEmail { get; set; }

        public DateTime? Updated { get; set; }

        public virtual ICollection<StudyItem> Studies { get; set; }

        public virtual Poll Poll { get; set; }
    }  
}
