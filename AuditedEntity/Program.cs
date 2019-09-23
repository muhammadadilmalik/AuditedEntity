using AuditedEntity.Entities;
using System;
using System.Linq;

namespace AuditedEntity
{
	class Program
	{
		static void Main(string[] args)
		{
			MyDBContext context = new MyDBContext();

			context.TestEntity.Add(new TestEntity()
			{
				TestField = "Testing..."
			});
			context.SaveChanges();

			var entity = context.TestEntity
									.Where(x => x.TestField == "Testing...")
									.FirstOrDefault();
			if (entity != null)
				entity.TestField = "Test Field Updated.";
			context.SaveChanges();

			var tentity = context.TestEntity
									.Where(x => x.TestField == "Test Field Updated.")
									.OrderByDescending(x => x.Id)
									.FirstOrDefault();
			context.TestEntity.Remove(tentity);
			context.SaveChanges();






			context.TestEntity1.Add(new TestEntity1()
			{
				 TestEntityName = "Testing..."
			});
			context.SaveChanges();

			var entity1 = context.TestEntity1
									.Where(x => x.TestEntityName == "Testing...")
									.FirstOrDefault();
			if (entity1 != null)
				entity1.TestEntityName = "Test Field Updated.";
			context.SaveChanges();

			var tentity1 = context.TestEntity1
									.Where(x => x.TestEntityName == "Test Field Updated.")
									.OrderByDescending(x => x.Id)
									.FirstOrDefault();
			context.TestEntity1.Remove(tentity1);
			context.SaveChanges();








			context.TestEntityWithoutAudit.Add(new TestEntityWithoutAudit()
			{
				 TestEntityName = "Testing..."
			});
			context.SaveChanges();

			var entity2 = context.TestEntityWithoutAudit
									.Where(x => x.TestEntityName == "Testing...")
									.FirstOrDefault();
			if (entity2 != null)
				entity2.TestEntityName = "Test Field Updated.";
			context.SaveChanges();

			var tentity2 = context.TestEntityWithoutAudit
									.Where(x => x.TestEntityName == "Test Field Updated.")
									.OrderByDescending(x => x.Id)
									.FirstOrDefault();
			context.TestEntityWithoutAudit.Remove(tentity2);
			context.SaveChanges();
		}
	}
}
