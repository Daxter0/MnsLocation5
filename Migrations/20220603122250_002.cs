using Microsoft.EntityFrameworkCore.Migrations;

namespace MnsLocation5.Migrations
{
    public partial class _002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialRentalCart_Materials_ChoosenMaterialsID",
                table: "MaterialRentalCart");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialRentalCart_RentalCarts_CartID",
                table: "MaterialRentalCart");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Types_MaterialTypeID",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_Rents_RentalCarts_RentalCartID",
                table: "Rents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Types",
                table: "Types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rents",
                table: "Rents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RentalCarts",
                table: "RentalCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Materials",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Materials_MaterialTypeID",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "MaterialTypeID",
                table: "Materials");

            migrationBuilder.RenameTable(
                name: "Types",
                newName: "Type");

            migrationBuilder.RenameTable(
                name: "Rents",
                newName: "Rent");

            migrationBuilder.RenameTable(
                name: "RentalCarts",
                newName: "RentalCart");

            migrationBuilder.RenameTable(
                name: "Materials",
                newName: "Material");

            migrationBuilder.RenameColumn(
                name: "ChoosenMaterialsID",
                table: "MaterialRentalCart",
                newName: "ChoosenMaterialsId");

            migrationBuilder.RenameIndex(
                name: "IX_MaterialRentalCart_ChoosenMaterialsID",
                table: "MaterialRentalCart",
                newName: "IX_MaterialRentalCart_ChoosenMaterialsId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Type",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Rents_RentalCartID",
                table: "Rent",
                newName: "IX_Rent_RentalCartID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Material",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeRefId",
                table: "Material",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Type",
                table: "Type",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rent",
                table: "Rent",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentalCart",
                table: "RentalCart",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Material",
                table: "Material",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Material_TypeRefId",
                table: "Material",
                column: "TypeRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Material_Type_TypeRefId",
                table: "Material",
                column: "TypeRefId",
                principalTable: "Type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialRentalCart_Material_ChoosenMaterialsId",
                table: "MaterialRentalCart",
                column: "ChoosenMaterialsId",
                principalTable: "Material",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialRentalCart_RentalCart_CartID",
                table: "MaterialRentalCart",
                column: "CartID",
                principalTable: "RentalCart",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rent_RentalCart_RentalCartID",
                table: "Rent",
                column: "RentalCartID",
                principalTable: "RentalCart",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Material_Type_TypeRefId",
                table: "Material");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialRentalCart_Material_ChoosenMaterialsId",
                table: "MaterialRentalCart");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialRentalCart_RentalCart_CartID",
                table: "MaterialRentalCart");

            migrationBuilder.DropForeignKey(
                name: "FK_Rent_RentalCart_RentalCartID",
                table: "Rent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Type",
                table: "Type");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RentalCart",
                table: "RentalCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rent",
                table: "Rent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Material",
                table: "Material");

            migrationBuilder.DropIndex(
                name: "IX_Material_TypeRefId",
                table: "Material");

            migrationBuilder.DropColumn(
                name: "Adress",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TypeRefId",
                table: "Material");

            migrationBuilder.RenameTable(
                name: "Type",
                newName: "Types");

            migrationBuilder.RenameTable(
                name: "RentalCart",
                newName: "RentalCarts");

            migrationBuilder.RenameTable(
                name: "Rent",
                newName: "Rents");

            migrationBuilder.RenameTable(
                name: "Material",
                newName: "Materials");

            migrationBuilder.RenameColumn(
                name: "ChoosenMaterialsId",
                table: "MaterialRentalCart",
                newName: "ChoosenMaterialsID");

            migrationBuilder.RenameIndex(
                name: "IX_MaterialRentalCart_ChoosenMaterialsId",
                table: "MaterialRentalCart",
                newName: "IX_MaterialRentalCart_ChoosenMaterialsID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Types",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Rent_RentalCartID",
                table: "Rents",
                newName: "IX_Rents_RentalCartID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Materials",
                newName: "ID");

            migrationBuilder.AddColumn<int>(
                name: "MaterialTypeID",
                table: "Materials",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Types",
                table: "Types",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentalCarts",
                table: "RentalCarts",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rents",
                table: "Rents",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Materials",
                table: "Materials",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_MaterialTypeID",
                table: "Materials",
                column: "MaterialTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialRentalCart_Materials_ChoosenMaterialsID",
                table: "MaterialRentalCart",
                column: "ChoosenMaterialsID",
                principalTable: "Materials",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialRentalCart_RentalCarts_CartID",
                table: "MaterialRentalCart",
                column: "CartID",
                principalTable: "RentalCarts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Types_MaterialTypeID",
                table: "Materials",
                column: "MaterialTypeID",
                principalTable: "Types",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_RentalCarts_RentalCartID",
                table: "Rents",
                column: "RentalCartID",
                principalTable: "RentalCarts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
