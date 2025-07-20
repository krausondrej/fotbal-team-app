using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fotbalTeam.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateTwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6548747d-998e-4beb-b270-4b5cb34ed8a8", "AQAAAAIAAYagAAAAEMvUBUKjskhBO5xaMzqgOt+BtTTrtUPH7J3J1e0/T/2m0A5jxemm7Qc3np4gp35/jw==", "60f9eba8-b2d3-4068-936e-509fca340efd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "34730f27-a113-4685-b71f-cb07848925fc", "AQAAAAIAAYagAAAAEPnuybE8hKLc5RTsFMmasaUaXpuBEWqU237jlutwER4AqQtFsIAq8J6uAmKzWxGdQQ==", "398174dc-6e75-46f1-b555-8a42d65d5694" });

            migrationBuilder.UpdateData(
                table: "Carousel",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageSrc",
                value: "/img/carousel/pic1.jpeg?v=2");

            migrationBuilder.UpdateData(
                table: "Carousel",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageSrc",
                value: "/img/carousel/pic2.jpeg?v=2");

            migrationBuilder.UpdateData(
                table: "Carousel",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageSrc",
                value: "/img/carousel/pic3.jpeg?v=2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4db5e3e7-8c79-49b6-aa7c-6ce09474ecf7", "AQAAAAIAAYagAAAAEHyT36Y1n1PjAAxBzKWM/GgVVjMDvmNWe7PBoR0FrDHIrxPFc26fHmBNHQC3wxi0vg==", "3b8ac2b6-1b73-49f1-82ac-3aa214cd4d6b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90f4b5fe-b51b-474d-857a-1719ec9b4546", "AQAAAAIAAYagAAAAEDpEHMz78R5uXgcqULB677NflG/2XeKEAv8dDp374BEjnC1u5/gaBJfRgthMtl2TnA==", "ecbb3196-45da-4e86-916a-3846dc8ae27a" });

            migrationBuilder.UpdateData(
                table: "Carousel",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageSrc",
                value: "/img/carousel/information-technology-specialist.jpg");

            migrationBuilder.UpdateData(
                table: "Carousel",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageSrc",
                value: "/img/carousel/Information-Technology-1-1.jpg");

            migrationBuilder.UpdateData(
                table: "Carousel",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageSrc",
                value: "/img/carousel/itec-index-banner.jpg");
        }
    }
}
