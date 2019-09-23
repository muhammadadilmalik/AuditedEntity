using System;
using System.Collections.Generic;
using System.Text;

namespace AuditedEntity.Core
{
	public interface ISoftDelete
	{
		bool IsDeleted { get; set; }
	}
}
