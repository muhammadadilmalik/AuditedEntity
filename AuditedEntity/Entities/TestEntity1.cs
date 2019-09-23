using AuditedEntity.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuditedEntity.Entities
{
	public class TestEntity1: AuditedEntity<long>, IAuditedEntity, ISoftDelete
	{
		public string TestEntityName { get; set; }
	}
}
