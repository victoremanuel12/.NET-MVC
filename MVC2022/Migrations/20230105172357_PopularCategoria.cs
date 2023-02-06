using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC2022.Migrations
{
    /// <inheritdoc />
    public partial class PopularCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias(categoriaNome,CategoriaDescricao)" +
                "VALUES('Normal', 'Lanche feito com ingredientes normais')");
            migrationBuilder.Sql("INSERT INTO Categorias(categoriaNome,CategoriaDescricao)" +
               "VALUES('Natural', 'Lanche feito com ingredientes naturais')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");
        }
    }
}
