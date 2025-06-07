using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendApi.Database.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabaseAndTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Database/Migration");

            migrationBuilder.CreateTable(
                name: "usu_t009ppd",
                schema: "Database/Migration",
                columns: table => new
                {
                    usu_numppd = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usu_datemi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    usu_obsped = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usu_codcli = table.Column<int>(type: "int", nullable: true),
                    usu_codrep = table.Column<int>(type: "int", nullable: true),
                    usu_codcpg = table.Column<int>(type: "int", nullable: true),
                    usu_pedcli = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usu_datprv = table.Column<DateTime>(type: "datetime2", nullable: true),
                    usu_pedime = table.Column<short>(type: "smallint", nullable: true),
                    usu_tipfat = table.Column<short>(type: "smallint", nullable: true),
                    usu_natope = table.Column<short>(type: "smallint", nullable: true),
                    usu_perdsc = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    usu_numped = table.Column<int>(type: "int", nullable: true),
                    usu_numpe2 = table.Column<int>(type: "int", nullable: true),
                    usu_sitppd = table.Column<short>(type: "smallint", nullable: true),
                    usu_ciffob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usu_codcrt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usu_codfpg = table.Column<short>(type: "smallint", nullable: true),
                    usu_codtra = table.Column<int>(type: "int", nullable: true),
                    usu_tipdis = table.Column<short>(type: "smallint", nullable: true),
                    usu_numnfv = table.Column<int>(type: "int", nullable: true),
                    usu_numnf2 = table.Column<int>(type: "int", nullable: true),
                    usu_datfat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    usu_obsfin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usu_prvfat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    usu_retmer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usu_codemp = table.Column<short>(type: "smallint", nullable: false),
                    usu_necage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usu_t009ppd", x => x.usu_numppd);
                });

            migrationBuilder.CreateTable(
                name: "usu_t009ppi",
                schema: "Database/Migration",
                columns: table => new
                {
                    UsuNumppd = table.Column<long>(type: "bigint", nullable: false),
                    UsuSeqipd = table.Column<short>(type: "smallint", nullable: false),
                    UsuCodpro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuQtdped = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UsuPreuni = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UsuVlrtot = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UsuCodagc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuCodfam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuFinrec = table.Column<int>(type: "int", nullable: true),
                    UsuDesnfv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuUnimed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuCodemp = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usu_t009ppi", x => new { x.UsuNumppd, x.UsuSeqipd });
                });

            migrationBuilder.CreateTable(
                name: "usu_t025perf",
                schema: "Database/Migration",
                columns: table => new
                {
                    usu_concstamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    usu_nomeperf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usu_normname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usu_t025perf", x => x.usu_concstamp);
                });

            migrationBuilder.CreateTable(
                name: "usu_t025usu",
                schema: "Database/Migration",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usu_t025usu", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "usu_t009ppd",
                schema: "Database/Migration");

            migrationBuilder.DropTable(
                name: "usu_t009ppi",
                schema: "Database/Migration");

            migrationBuilder.DropTable(
                name: "usu_t025perf",
                schema: "Database/Migration");

            migrationBuilder.DropTable(
                name: "usu_t025usu",
                schema: "Database/Migration");
        }
    }
}
