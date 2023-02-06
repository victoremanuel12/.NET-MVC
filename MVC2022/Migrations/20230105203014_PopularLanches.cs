using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC2022.Migrations
{
    /// <inheritdoc />
    public partial class PopularLanches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId,LancheNome,LanchePreco,LancheDescricaoCurta,LancheDescricaoDetalhada,IsLanchePreferido,LancheImagemUrl,EmEstoque,LancheImagemThumbnailUrl) " +
                "VALUES(1,'Hamburger Americado',5.00,'Delicioso Lanche para noite','Pão,alface,tomate,uma delicia!',1,'https://img.freepik.com/fotos-gratis/sanduiche_1339-1108.jpg?w=2000',0,'https://storage.googleapis.com/grandchef-apps/gc6971/images/products/60ff4379453e2.jpg')");
            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }


    
    
}
