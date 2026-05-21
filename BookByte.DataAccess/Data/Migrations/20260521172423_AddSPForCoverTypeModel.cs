using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookByte.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddSPForCoverTypeModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        CREATE PROCEDURE CreateCoverType
        @name varchar(50)
        AS
        INSERT INTO CoverTypes(Name)
        VALUES (@name)
    ");

            migrationBuilder.Sql(@"
        CREATE PROCEDURE UpdateCoverType
        @id int,
        @name varchar(50)
        AS
        UPDATE CoverTypes
        SET Name = @name
        WHERE Id = @id
    ");

            migrationBuilder.Sql(@"
        CREATE PROCEDURE DeleteCoverType
        @id int
        AS
        DELETE FROM CoverTypes
        WHERE Id = @id
    ");

            migrationBuilder.Sql(@"
        CREATE PROCEDURE GetCoverTypes
        AS
        SELECT * FROM CoverTypes
    ");

            migrationBuilder.Sql(@"
        CREATE PROCEDURE GetCoverType
        @id int
        AS
        SELECT * FROM CoverTypes
        WHERE Id = @id
    ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
