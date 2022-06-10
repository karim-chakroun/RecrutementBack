using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppRecrutement.Migrations
{
    public partial class m111111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DepartementsDepartementID",
                table: "AspNetUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Score",
                table: "AspNetUsers",
                type: "real",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Departement",
                columns: table => new
                {
                    DepartementID = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Libelle = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departement", x => x.DepartementID);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    LanguageID = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Libelle = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.LanguageID);
                });

            migrationBuilder.CreateTable(
                name: "Offre",
                columns: table => new
                {
                    OffreID = table.Column<Guid>(type: "uuid", nullable: false),
                    NomOffre = table.Column<string>(type: "text", nullable: false),
                    Département = table.Column<string>(type: "text", nullable: false),
                    Pays = table.Column<string>(type: "text", nullable: false),
                    Région = table.Column<string>(type: "text", nullable: false),
                    Date_début = table.Column<string>(type: "text", nullable: true),
                    Activités_principales = table.Column<string>(type: "text", nullable: true),
                    Qualités_interpersonnelles = table.Column<string>(type: "text", nullable: true),
                    Compétences_techniques = table.Column<string>(type: "text", nullable: true),
                    Diplome_démandé = table.Column<string>(type: "text", nullable: false),
                    Experience_démandée = table.Column<string>(type: "text", nullable: false),
                    Niveau_démandé = table.Column<string>(type: "text", nullable: false),
                    salaire = table.Column<long>(type: "bigint", nullable: false),
                    Type_contrat = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offre", x => x.OffreID);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserLanguage",
                columns: table => new
                {
                    LanguagesLanguageID = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserLanguage", x => new { x.LanguagesLanguageID, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserLanguage_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserLanguage_Language_LanguagesLanguageID",
                        column: x => x.LanguagesLanguageID,
                        principalTable: "Language",
                        principalColumn: "LanguageID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Candidature",
                columns: table => new
                {
                    CandidatureID = table.Column<Guid>(type: "uuid", nullable: false),
                    Date_postulation = table.Column<string>(type: "text", nullable: true),
                    Etat = table.Column<int>(type: "integer", nullable: false),
                    Motivation_poste = table.Column<string>(type: "text", nullable: false),
                    Questions = table.Column<string>(type: "text", nullable: true),
                    Curriculum_Vitae = table.Column<string>(type: "text", nullable: false),
                    Letrre_motivation = table.Column<string>(type: "text", nullable: false),
                    CandidatId = table.Column<string>(type: "text", nullable: true),
                    CorrespondanceOffreID = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidature", x => x.CandidatureID);
                    table.ForeignKey(
                        name: "FK_Candidature_AspNetUsers_CandidatId",
                        column: x => x.CandidatId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Candidature_Offre_CorrespondanceOffreID",
                        column: x => x.CorrespondanceOffreID,
                        principalTable: "Offre",
                        principalColumn: "OffreID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntretienRH",
                columns: table => new
                {
                    EntretienID = table.Column<Guid>(type: "uuid", nullable: false),
                    Equipe_recrutement = table.Column<string>(type: "text", nullable: true),
                    Localisation = table.Column<string>(type: "text", nullable: false),
                    Durée = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<int>(type: "integer", nullable: false),
                    Heure = table.Column<int>(type: "integer", nullable: false),
                    RendezVousOffreID = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntretienRH", x => x.EntretienID);
                    table.ForeignKey(
                        name: "FK_EntretienRH_Offre_RendezVousOffreID",
                        column: x => x.RendezVousOffreID,
                        principalTable: "Offre",
                        principalColumn: "OffreID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestTechnique",
                columns: table => new
                {
                    TestID = table.Column<Guid>(type: "uuid", nullable: false),
                    Destination = table.Column<string>(type: "text", nullable: true),
                    Date_dépot = table.Column<string>(type: "text", nullable: true),
                    Durée = table.Column<int>(type: "integer", nullable: false),
                    lien_test = table.Column<string>(type: "text", nullable: false),
                    OffreTestOffreID = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestTechnique", x => x.TestID);
                    table.ForeignKey(
                        name: "FK_TestTechnique_Offre_OffreTestOffreID",
                        column: x => x.OffreTestOffreID,
                        principalTable: "Offre",
                        principalColumn: "OffreID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartementsDepartementID",
                table: "AspNetUsers",
                column: "DepartementsDepartementID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserLanguage_UsersId",
                table: "ApplicationUserLanguage",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidature_CandidatId",
                table: "Candidature",
                column: "CandidatId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidature_CorrespondanceOffreID",
                table: "Candidature",
                column: "CorrespondanceOffreID");

            migrationBuilder.CreateIndex(
                name: "IX_EntretienRH_RendezVousOffreID",
                table: "EntretienRH",
                column: "RendezVousOffreID");

            migrationBuilder.CreateIndex(
                name: "IX_TestTechnique_OffreTestOffreID",
                table: "TestTechnique",
                column: "OffreTestOffreID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Departement_DepartementsDepartementID",
                table: "AspNetUsers",
                column: "DepartementsDepartementID",
                principalTable: "Departement",
                principalColumn: "DepartementID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Departement_DepartementsDepartementID",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ApplicationUserLanguage");

            migrationBuilder.DropTable(
                name: "Candidature");

            migrationBuilder.DropTable(
                name: "Departement");

            migrationBuilder.DropTable(
                name: "EntretienRH");

            migrationBuilder.DropTable(
                name: "TestTechnique");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "Offre");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DepartementsDepartementID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DepartementsDepartementID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "AspNetUsers");
        }
    }
}
