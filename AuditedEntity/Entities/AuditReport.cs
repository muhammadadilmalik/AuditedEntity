using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AuditedEntity.Entities
{
	public class AuditReport
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }
		public string PrimaryKey { get; set; }
		public string Column { get; set; }
		public string EntityName { get; set; }
		public string Type { get; set; }
		public string OldValue { get; set; }
		public string NewValue { get; set; }
	}
}
