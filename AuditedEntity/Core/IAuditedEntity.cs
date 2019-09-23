using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AuditedEntity.Core
{
	public class AuditedEntity<T>
	{
		[Key]
		public T Id { get; set; }
		public long UpdatedBy { get; set; }
		public DateTime UpdateDate { get; set; }
		public long AddedBy { get; set; }
		public DateTime AddedDate { get; set; }
		public bool IsDeleted { get; set; }
		public long DeletedBy { get; set; }
		public DateTime DeletedDate { get; set; }
	}

	public interface IAuditedEntity
	{
		long UpdatedBy { get; set; }
		DateTime UpdateDate { get; set; }
		long AddedBy { get; set; }
		DateTime AddedDate { get; set; }
		bool IsDeleted { get; set; }
		long DeletedBy { get; set; }
		DateTime DeletedDate { get; set; }
	}
}
