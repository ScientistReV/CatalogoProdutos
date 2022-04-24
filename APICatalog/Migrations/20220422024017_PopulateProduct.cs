using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalog.Migrations
{
    public partial class PopulateProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Product(ProductName, ProductDescription, ProductPrice, UrlImagem, Inventory, DateRegister, CategoryId) values ('Coca Cola', 'Refrigerante de 1 Litro', '5.45', 'cocacola.jpg', 50, now(), 1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Product");
        }
    }
}
