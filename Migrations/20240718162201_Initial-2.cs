using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Menu.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImagUrl",
                value: "https://imgs.search.brave.com/F5mqn8OwsbQInaxf7FpT-S6cNU4QnXttBfcmfAn90GI/rs:fit:500:0:0:0/g:ce/aHR0cHM6Ly9pbWcu/ZnJlZXBpay5jb20v/ZnJlZS1waG90by9w/aXp6YV8xNDQ2Mjct/Mzk1MDAuanBnP3Np/emU9NjI2JmV4dD1q/cGc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImagUrl",
                value: "https://www.istockphoto.com/photos/pizza-margherita");
        }
    }
}
