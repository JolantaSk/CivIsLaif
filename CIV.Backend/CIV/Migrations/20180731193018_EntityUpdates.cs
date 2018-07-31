using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CIV.Migrations
{
    public partial class EntityUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPaused",
                table: "Game",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "TurnId",
                table: "Game",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pause",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StartedOn = table.Column<DateTimeOffset>(nullable: false),
                    StopedOn = table.Column<DateTimeOffset>(nullable: true),
                    GameId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pause", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pause_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Phase",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NextPhaseId = table.Column<Guid>(nullable: true),
                    SimultaniousTurns = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phase_Phase_NextPhaseId",
                        column: x => x.NextPhaseId,
                        principalTable: "Phase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TurnOrder",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurnOrder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActivePhase",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PhaseId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivePhase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivePhase_Phase_PhaseId",
                        column: x => x.PhaseId,
                        principalTable: "Phase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerTurnOrder",
                columns: table => new
                {
                    PlayerId = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    _id = table.Column<Guid>(nullable: false),
                    TurnOrderId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerTurnOrder", x => x._id);
                    table.ForeignKey(
                        name: "FK_PlayerTurnOrder_AspNetUsers_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerTurnOrder_TurnOrder_TurnOrderId",
                        column: x => x.TurnOrderId,
                        principalTable: "TurnOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayerTurn",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PlayerId = table.Column<string>(nullable: true),
                    StartedOn = table.Column<DateTimeOffset>(nullable: true),
                    FinishedOn = table.Column<DateTimeOffset>(nullable: true),
                    ActivePhaseId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerTurn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerTurn_ActivePhase_ActivePhaseId",
                        column: x => x.ActivePhaseId,
                        principalTable: "ActivePhase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerTurn_AspNetUsers_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Turn",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CurrentPhaseId = table.Column<Guid>(nullable: false),
                    TurnOrderId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turn_ActivePhase_CurrentPhaseId",
                        column: x => x.CurrentPhaseId,
                        principalTable: "ActivePhase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Turn_TurnOrder_TurnOrderId",
                        column: x => x.TurnOrderId,
                        principalTable: "TurnOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Game_TurnId",
                table: "Game",
                column: "TurnId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivePhase_PhaseId",
                table: "ActivePhase",
                column: "PhaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Pause_GameId",
                table: "Pause",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Phase_NextPhaseId",
                table: "Phase",
                column: "NextPhaseId",
                unique: true,
                filter: "[NextPhaseId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTurn_ActivePhaseId",
                table: "PlayerTurn",
                column: "ActivePhaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTurn_PlayerId",
                table: "PlayerTurn",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTurnOrder_PlayerId",
                table: "PlayerTurnOrder",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTurnOrder_TurnOrderId",
                table: "PlayerTurnOrder",
                column: "TurnOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Turn_CurrentPhaseId",
                table: "Turn",
                column: "CurrentPhaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Turn_TurnOrderId",
                table: "Turn",
                column: "TurnOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Turn_TurnId",
                table: "Game",
                column: "TurnId",
                principalTable: "Turn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Turn_TurnId",
                table: "Game");

            migrationBuilder.DropTable(
                name: "Pause");

            migrationBuilder.DropTable(
                name: "PlayerTurn");

            migrationBuilder.DropTable(
                name: "PlayerTurnOrder");

            migrationBuilder.DropTable(
                name: "Turn");

            migrationBuilder.DropTable(
                name: "ActivePhase");

            migrationBuilder.DropTable(
                name: "TurnOrder");

            migrationBuilder.DropTable(
                name: "Phase");

            migrationBuilder.DropIndex(
                name: "IX_Game_TurnId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "IsPaused",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "TurnId",
                table: "Game");
        }
    }
}
