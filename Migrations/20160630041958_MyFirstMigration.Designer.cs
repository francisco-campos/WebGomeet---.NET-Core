using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebGomeet.Models;

namespace WebGomeet.Migrations
{
    [DbContext(typeof(GoMeetContext))]
    [Migration("20160630041958_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebGomeet.Models.Institucion", b =>
                {
                    b.Property<int>("InstitucionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FulllUrl");

                    b.Property<string>("Logo");

                    b.Property<string>("Nombre");

                    b.Property<int>("PlanId");

                    b.HasKey("InstitucionId");

                    b.HasIndex("PlanId");

                    b.ToTable("Intituciones");
                });

            modelBuilder.Entity("WebGomeet.Models.Plan", b =>
                {
                    b.Property<int>("PlanId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nombre");

                    b.HasKey("PlanId");

                    b.ToTable("Planes");
                });

            modelBuilder.Entity("WebGomeet.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Clave");

                    b.Property<string>("Email");

                    b.Property<int>("InstitucionId");

                    b.Property<string>("Nombre");

                    b.HasKey("UsuarioId");

                    b.HasIndex("InstitucionId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("WebGomeet.Models.Institucion", b =>
                {
                    b.HasOne("WebGomeet.Models.Plan", "Plan")
                        .WithMany()
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebGomeet.Models.Usuario", b =>
                {
                    b.HasOne("WebGomeet.Models.Institucion", "Institucion")
                        .WithMany("Usuarios")
                        .HasForeignKey("InstitucionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
