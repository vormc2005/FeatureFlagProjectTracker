using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectFeatureFlags",
                columns: table => new
                {
                    ProjectFeatureFlagId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FlagName = table.Column<string>(type: "TEXT", nullable: true),
                    TaskNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PRLinks = table.Column<string>(type: "TEXT", nullable: true),
                    WorkedOnBy = table.Column<string>(type: "TEXT", nullable: true),
                    IsUiChanged = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsApiChanged = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsFredChanged = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsIvanChanged = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsOtherChanged = table.Column<bool>(type: "INTEGER", nullable: false),
                    OtherChangedApps = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectFeatureFlags", x => x.ProjectFeatureFlagId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectFeatureFlags");
        }
    }
}
