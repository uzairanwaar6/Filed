using Microsoft.EntityFrameworkCore.Migrations;

namespace Filed.Services.Payment.Migrations
{
    public partial class UpdateRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PaymentStatuses_PaymentID",
                table: "PaymentStatuses");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentStatuses_PaymentID",
                table: "PaymentStatuses",
                column: "PaymentID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PaymentStatuses_PaymentID",
                table: "PaymentStatuses");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentStatuses_PaymentID",
                table: "PaymentStatuses",
                column: "PaymentID");
        }
    }
}
