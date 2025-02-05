﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using sumsub_api.DAL;

#nullable disable

namespace sumsub_api.Migrations
{
    [DbContext(typeof(ApplicantContext))]
    [Migration("20240408113201_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("sumsub_api.Models.Applicant", b =>
                {
                    b.Property<string>("ApplicantId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ExternalUserId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ApplicantId");

                    b.ToTable("Applicants");
                });

            modelBuilder.Entity("sumsub_api.Models.ApplicantReview", b =>
                {
                    b.Property<string>("_ApplicantId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("applicantId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("correlationId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("createdAtMs")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("externalUserId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("inspectionId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("levelName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("reviewStatus")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("_ApplicantId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("sumsub_api.Models.ReviewResult", b =>
                {
                    b.Property<string>("ApplicantReviewId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("clientComment")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("moderationComment")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("rejectLabels")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("reviewAnswer")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("reviewRejectType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ApplicantReviewId");

                    b.ToTable("ReviewResults");
                });

            modelBuilder.Entity("sumsub_api.Models.ApplicantReview", b =>
                {
                    b.HasOne("sumsub_api.Models.Applicant", "Applicant")
                        .WithOne("Review")
                        .HasForeignKey("sumsub_api.Models.ApplicantReview", "_ApplicantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applicant");
                });

            modelBuilder.Entity("sumsub_api.Models.ReviewResult", b =>
                {
                    b.HasOne("sumsub_api.Models.ApplicantReview", "ApplicantReview")
                        .WithOne("reviewResult")
                        .HasForeignKey("sumsub_api.Models.ReviewResult", "ApplicantReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicantReview");
                });

            modelBuilder.Entity("sumsub_api.Models.Applicant", b =>
                {
                    b.Navigation("Review")
                        .IsRequired();
                });

            modelBuilder.Entity("sumsub_api.Models.ApplicantReview", b =>
                {
                    b.Navigation("reviewResult")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
