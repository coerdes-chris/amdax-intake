using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sumsub_api.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    ApplicantId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ExternalUserId = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.ApplicantId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    _ApplicantId = table.Column<string>(type: "varchar(255)", nullable: false),
                    applicantId = table.Column<string>(type: "longtext", nullable: false),
                    inspectionId = table.Column<string>(type: "longtext", nullable: false),
                    correlationId = table.Column<string>(type: "longtext", nullable: false),
                    externalUserId = table.Column<string>(type: "longtext", nullable: false),
                    levelName = table.Column<string>(type: "longtext", nullable: false),
                    type = table.Column<string>(type: "longtext", nullable: false),
                    reviewStatus = table.Column<string>(type: "longtext", nullable: false),
                    createdAtMs = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x._ApplicantId);
                    table.ForeignKey(
                        name: "FK_Reviews_Applicants__ApplicantId",
                        column: x => x._ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "ApplicantId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ReviewResults",
                columns: table => new
                {
                    ApplicantReviewId = table.Column<string>(type: "varchar(255)", nullable: false),
                    moderationComment = table.Column<string>(type: "longtext", nullable: false),
                    clientComment = table.Column<string>(type: "longtext", nullable: false),
                    reviewAnswer = table.Column<string>(type: "longtext", nullable: false),
                    rejectLabels = table.Column<string>(type: "longtext", nullable: false),
                    reviewRejectType = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewResults", x => x.ApplicantReviewId);
                    table.ForeignKey(
                        name: "FK_ReviewResults_Reviews_ApplicantReviewId",
                        column: x => x.ApplicantReviewId,
                        principalTable: "Reviews",
                        principalColumn: "_ApplicantId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReviewResults");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Applicants");
        }
    }
}
