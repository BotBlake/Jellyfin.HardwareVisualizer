﻿// <auto-generated />
using System;
using Jellyfin.HardwareVisualizer.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Jellyfin.HardwareVisualizer.Database.Migrations
{
    [DbContext(typeof(HardwareVisualizerDataContext))]
    [Migration("20231223225928_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Jellyfin.HardwareVisualizer.Database.CpuType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Identifier")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Vendor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CpuTypes");
                });

            modelBuilder.Entity("Jellyfin.HardwareVisualizer.Database.GpuType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Identifier")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Vendor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("GpuTypes");
                });

            modelBuilder.Entity("Jellyfin.HardwareVisualizer.Database.HardwareCodec", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Identifier")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("HardwareCodecs");
                });

            modelBuilder.Entity("Jellyfin.HardwareVisualizer.Database.HardwareDisplay", b =>
                {
                    b.Property<string>("HardwareCodec")
                        .HasColumnType("text");

                    b.Property<string>("ToResolution")
                        .HasColumnType("text");

                    b.Property<string>("FromResolution")
                        .HasColumnType("text");

                    b.Property<int>("DeviceType")
                        .HasColumnType("integer");

                    b.Property<string>("DeviceName")
                        .HasColumnType("text");

                    b.Property<float>("Diviation")
                        .HasColumnType("real");

                    b.Property<double>("MaxStreams")
                        .HasColumnType("double precision");

                    b.HasKey("HardwareCodec", "ToResolution", "FromResolution", "DeviceType", "DeviceName");

                    b.ToTable("HardwareDisplays");
                });

            modelBuilder.Entity("Jellyfin.HardwareVisualizer.Database.HardwareSurveyEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("FromResolutionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("HardwareCodecId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("HardwareSurveySubmissionId")
                        .HasColumnType("uuid");

                    b.Property<int>("MaxStreams")
                        .HasColumnType("integer");

                    b.Property<Guid>("ToResolutionId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("FromResolutionId");

                    b.HasIndex("HardwareCodecId");

                    b.HasIndex("HardwareSurveySubmissionId");

                    b.HasIndex("ToResolutionId");

                    b.ToTable("HardwareSurveyEntries");
                });

            modelBuilder.Entity("Jellyfin.HardwareVisualizer.Database.HardwareSurveySubmission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CpuTypeId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("GpuTypeId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RawSurveySubmissionId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CpuTypeId");

                    b.HasIndex("GpuTypeId");

                    b.HasIndex("RawSurveySubmissionId");

                    b.ToTable("HardwareSurveySubmissions");
                });

            modelBuilder.Entity("Jellyfin.HardwareVisualizer.Database.RawSurveySubmission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Json")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("RawSurveySubmission");
                });

            modelBuilder.Entity("Jellyfin.HardwareVisualizer.Database.TestResolution", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Identifier")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TestResolutions");
                });

            modelBuilder.Entity("Jellyfin.HardwareVisualizer.Database.HardwareSurveyEntry", b =>
                {
                    b.HasOne("Jellyfin.HardwareVisualizer.Database.TestResolution", "FromResolution")
                        .WithMany()
                        .HasForeignKey("FromResolutionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Jellyfin.HardwareVisualizer.Database.HardwareCodec", "HardwareCodec")
                        .WithMany()
                        .HasForeignKey("HardwareCodecId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Jellyfin.HardwareVisualizer.Database.HardwareSurveySubmission", "HardwareSurveySubmission")
                        .WithMany("HardwareSurveyEntry")
                        .HasForeignKey("HardwareSurveySubmissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Jellyfin.HardwareVisualizer.Database.TestResolution", "ToResolution")
                        .WithMany()
                        .HasForeignKey("ToResolutionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FromResolution");

                    b.Navigation("HardwareCodec");

                    b.Navigation("HardwareSurveySubmission");

                    b.Navigation("ToResolution");
                });

            modelBuilder.Entity("Jellyfin.HardwareVisualizer.Database.HardwareSurveySubmission", b =>
                {
                    b.HasOne("Jellyfin.HardwareVisualizer.Database.CpuType", "CpuType")
                        .WithMany()
                        .HasForeignKey("CpuTypeId");

                    b.HasOne("Jellyfin.HardwareVisualizer.Database.GpuType", "GpuType")
                        .WithMany()
                        .HasForeignKey("GpuTypeId");

                    b.HasOne("Jellyfin.HardwareVisualizer.Database.RawSurveySubmission", "RawSurveySubmission")
                        .WithMany()
                        .HasForeignKey("RawSurveySubmissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CpuType");

                    b.Navigation("GpuType");

                    b.Navigation("RawSurveySubmission");
                });

            modelBuilder.Entity("Jellyfin.HardwareVisualizer.Database.HardwareSurveySubmission", b =>
                {
                    b.Navigation("HardwareSurveyEntry");
                });
#pragma warning restore 612, 618
        }
    }
}
