using AuditedEntity.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuditedEntity.Entities
{
	public class TestEntity: AuditedEntity<long>, IAuditedEntity, ISoftDelete
	{
		public string TestField { get; set; }
	}
}
