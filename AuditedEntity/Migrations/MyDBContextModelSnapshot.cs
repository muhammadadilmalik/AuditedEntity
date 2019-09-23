﻿// <auto-generated />
using System;
using AuditedEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AuditedEntity.Migrations
{
    [DbContext(typeof(MyDBContext))]
    partial class MyDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AuditedEntity.Entities.AuditReport", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Column");

                    b.Property<string>("EntityName");

                    b.Property<string>("NewValue");

                    b.Property<string>("OldValue");

                    b.Property<string>("PrimaryKey");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("AuditReport");
                });

            modelBuilder.Entity("AuditedEntity.Entities.TestEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<long>("DeletedBy");

                    b.Property<DateTime>("DeletedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("TestField");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<long>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("TestEntity");
                });
#pragma warning restore 612, 618
        }
    }
}
