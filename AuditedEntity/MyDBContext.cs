using AuditedEntity.Core;
using AuditedEntity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace AuditedEntity
{
	public class MyDBContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=localhost;Database=AuditedEntities;Trusted_Connection=True;");
			base.OnConfiguring(optionsBuilder);
		}

		public override int SaveChanges()
		{
			List<AuditReport> tAuditReport = new List<AuditReport>();
			foreach (var tEntry in ChangeTracker.Entries())
			{
				if (tEntry.State == EntityState.Added || tEntry.State == EntityState.Modified || tEntry.State == EntityState.Deleted)
				{
					string entityName = tEntry.Entity.GetType().Name;
					string entityType = tEntry.State.ToString();
					var tempKeyEntity = tEntry.Entity.GetType().GetProperties().Where(x => x.CustomAttributes.Where(y => y.AttributeType.Name == "KeyAttribute").Count() > 0).FirstOrDefault();
					string primaryKey = "0";

					if (tempKeyEntity != null && tEntry.State != EntityState.Added)
					{
						primaryKey = tempKeyEntity.GetValue(tEntry.Entity).ToString();
					}

					if (tEntry.State == EntityState.Deleted)
					{
						AuditReport tReport = new AuditReport()
						{
							PrimaryKey = primaryKey,
							EntityName = entityName,
							Type = entityType
						};
						tAuditReport.Add(tReport);
					}
					else
					{
						foreach (var prop in tEntry.Properties)
						{
							if (tEntry.State == EntityState.Modified && prop.CurrentValue.ToString() == prop.OriginalValue.ToString())
								continue;

							AuditReport tReport = new AuditReport()
							{
								PrimaryKey = primaryKey,
								EntityName = entityName,
								Type = entityType,
								NewValue = prop.CurrentValue.ToString(),
								Column = prop.Metadata.Name
							};

							if (tEntry.State == EntityState.Modified)
								tReport.OldValue = prop.OriginalValue.ToString();

							tAuditReport.Add(tReport);
						}
					}
				}

				if (tEntry.State == EntityState.Added)
				{
					if (tEntry.Entity is IAuditedEntity)
					{
						IAuditedEntity tempEntity = (IAuditedEntity)tEntry.Entity;

						tempEntity.AddedBy = 1;
						tempEntity.AddedDate = DateTime.Now;
					}
				}
				else if (tEntry.State == EntityState.Modified)
				{
					if (tEntry.Entity is IAuditedEntity)
					{
						IAuditedEntity tempEntity = (IAuditedEntity)tEntry.Entity;

						tempEntity.UpdatedBy = 1;
						tempEntity.UpdateDate = DateTime.Now;
					}
				}
				else if (tEntry.State == EntityState.Deleted)
				{
					tEntry.Reload();
					tEntry.State = EntityState.Modified;

					if (tEntry.Entity is ISoftDelete)
					{
						IAuditedEntity tempEntity = (IAuditedEntity)tEntry.Entity;
						tempEntity.DeletedBy = 1;
						tempEntity.DeletedDate = DateTime.Now;

						ISoftDelete softDeleteEntity = (ISoftDelete)tEntry.Entity;
						tempEntity.IsDeleted = true;
					}
				}
			}

			AuditReport.AddRange(tAuditReport);
			return base.SaveChanges();
		}

		public DbSet<TestEntity> TestEntity { get; set; }
		public DbSet<AuditReport> AuditReport { get; set; }
	}
}
