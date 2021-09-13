using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pm.Api.Models
{
	[Table("Studies", Schema = "dbo")]
	public class StudyItem
	{
		[Key]
		public int StudyId { get; set; }

		public Guid ProfileId { get; set; }

		public byte Type { get; set; }

		[Required]
		[MaxLength(150)]
		public string Country { get; set; }

		[Required]
		[MaxLength(256)]
		public string University { get; set; }

		[Required]
		[MaxLength(256)]
		public string Study { get; set; }

		public DateTime Begin { get; set; }

		public DateTime? End { get; set; }

	}
}
