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
		}
	}
}
