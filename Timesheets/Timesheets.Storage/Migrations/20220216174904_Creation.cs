using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Timesheets.Storage.Migrations
{
    public partial class Creation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            AddTestData(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "users");
        }

        private void AddTestData(MigrationBuilder migrationBuilder)
        {
            //users
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("C0A68C93-9977-4F22-8B37-D5E4AEAEB3A5"), "Rene", "Williamson", "42", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("EB69F691-516F-407D-84F0-2E1EB0B39015"), "Phillip", "Parker", "33", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("D55E1E02-8581-469B-AC6D-904579A22026"), "Dale", "Holt", "28", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("ABA51D50-A782-4195-8F41-3897172C3526"), "Terrance", "Daniels", "60", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("4B830B9C-8A07-481B-99B2-D3061E6F69EF"), "Chloe", "Webb", "44", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("26B6F3C6-4D37-45E1-8E9B-CD64E7A61115"), "Riley", "Lane", "38", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("FD1E0DE2-118D-4FA2-B9B3-AF278FC3B3BF"), "Carla", "Palmer", "29", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("688B678B-6A8A-49D9-8FA8-424BCACCB516"), "Denise", "Wood", "33", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("62B34730-FC16-4B98-8005-946884E70DCE"), "Mary", "Stewart", "67", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("9F5CA94C-0735-495C-A2FA-AD83045BEA00"), "Annette", "Matthews", "57", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("BB5DCC8B-EF79-44F3-8F37-72C54F9808A4"), "Maureen", "Chavez", "38", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("28BEF1CE-C7C7-4AC2-A3EC-3E2E1CF1939F"), "Mattie", "Wade", "34", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("561D0D57-3F79-4673-A817-99EDC682067F"), "Georgia", "Wallace", "27", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("528FEC6D-C8C3-4D0E-902F-2B33429F4E8F"), "Marvin", "Chavez", "54", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("82BCAAF8-E539-4531-A3E7-4420B137120F"), "Brooklyn", "Mason", "72", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("2E95ACE6-50F6-4C95-997E-DF04F2F348B9"), "Andy", "Gray", "29", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("06B57D52-BDA9-4A8B-A9E9-095345391F03"), "Franklin", "Woods", "46", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("F5E65720-944B-48CF-85EE-54CF4523A65C"), "Carl", "Rhodes", "38", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("57353C2F-8158-4814-A4AC-61CE71319177"), "Vivan", "Terry", "32", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("CC94B4ED-BF80-4C51-9763-9A76AA91C76E"), "Marsha", "Lawson", "25", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("C87B2298-5BEA-425B-A26E-7878FE735BEA"), "Jeanette", "Gilbert", "47", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("4975D475-B539-40FA-8F16-B103B0BE47E3"), "Lawrence", "Reid", "47", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("35F5B20A-D9A2-4567-9276-CB1CD5CAFDE2"), "William", "Fields", "29", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("61A9EE19-91E9-4918-B676-111E3C030A59"), "Derek", "Warren", "48", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("C25E9ECB-2F32-4276-AB1D-2394E1ED7A45"), "Brennan", "Jones", "40", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("B1032FB2-26B9-438D-8F98-FAD4F3257D8B"), "Felicia", "Barrett", "28", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("245B7CAD-F1C3-4CC2-90D0-98817456CFD5"), "Wanda", "Wagner", "56", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("D9D410F7-368C-446D-B811-15EEF7DA0C10"), "Alexander", "Mcdonalid", "50", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("5C4697AB-56D0-48C6-8EE9-0F69C5B35231"), "Zoe", "Douglas", "28", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("4E7C9B78-EA2A-441B-9A9A-C1CF3226767D"), "Bill", "Olson", "39", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("4AE6CBE4-A7EE-4F68-A9A9-1CB12CF41B8D"), "Rhonda", "Jennings", "52", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("A740000E-EB1C-4A16-AECA-A65F19DBCB02"), "Tanya", "Castro", "37", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("24686BF1-364B-4425-A90F-67A3130C442C"), "Tristan", "Edwards", "61", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("5F42DB91-C9EA-4965-B01B-E24416447E51"), "Edith", "Dean", "35", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("D88B3255-FA23-4B23-871F-6AF68D5F131E"), "Krin", "Foster", "25", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("C59B12D4-9D4E-46C6-8475-EF6395854316"), "Erica", "Turner", "25", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("FC5DFC14-4492-44C8-9960-1BEF4B10B6D4"), "Catherine", "Kelly", "67", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("4E777501-9A44-48CD-992E-EAED4C32516E"), "Riley", "Little", "43", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("02883636-583E-42D2-83D1-28EF84FAA443"), "Arlene", "Dean", "75", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("89035624-C98B-416A-A402-355F5054D4FA"), "Darren", "Terry", "77", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("DDC4B90C-931F-4D8C-9A15-0B49E80979B4"), "Jessie", "Chambers", "33", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("CC7B831E-8526-44E3-9D5C-24338A87CA17"), "Austin", "Brooks", "34", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("33FE60A0-73DE-44D2-AFE9-D08F342884A6"), "Natalie", "Butler", "77", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("23E05293-0C2E-4DD6-97AA-3552247292C1"), "Edward", "Herrera", "72", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("BE00DE6D-CD38-46F1-BB2D-163FB27A30AF"), "Felecia", "Morris", "40", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("85F10E8C-445E-4AE6-B260-0CB33A4B6140"), "Addison", "Kennedy", "25", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("53E26FC8-25A1-4CAB-B7E9-5EA7D8543BA0"), "Florence", "Fisher", "32", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("7C176992-4AEE-410C-B300-3A137867D44D"), "Zoe", "Watkins", "50", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("132A9C01-3103-41F9-AF22-650A3CEF372F"), "Brayden", "Bishop", "50", false, "" });
            migrationBuilder.InsertData("users", new string[] { "Id", "FirstName", "LastName", "Age", "IsDeleted", "Comment" }, new object[] { Guid.Parse("91C1DDD8-2CD1-472B-8083-B870B9369E11"), "Craig", "Phillips", "45", false, "" });

            //employees
            migrationBuilder.InsertData("employees", new string[] { "Id", "UserId", "IsDeleted", "Comment" }, new object[] { Guid.Parse("D51F7D2A-C04C-4ACF-856A-09284C73EDD5"), Guid.Parse("26B6F3C6-4D37-45E1-8E9B-CD64E7A61115"), false, "" });
            migrationBuilder.InsertData("employees", new string[] { "Id", "UserId", "IsDeleted", "Comment" }, new object[] { Guid.Parse("0597702A-09AF-4D3B-8684-109248DFE246"), Guid.Parse("62B34730-FC16-4B98-8005-946884E70DCE"), false, "" });
            migrationBuilder.InsertData("employees", new string[] { "Id", "UserId", "IsDeleted", "Comment" }, new object[] { Guid.Parse("634EF4B1-DB69-487D-BC63-6199E9A9AD87"), Guid.Parse("9F5CA94C-0735-495C-A2FA-AD83045BEA00"), false, "" });
            migrationBuilder.InsertData("employees", new string[] { "Id", "UserId", "IsDeleted", "Comment" }, new object[] { Guid.Parse("6027736E-0506-4107-B2A7-900F0EC1040C"), Guid.Parse("F5E65720-944B-48CF-85EE-54CF4523A65C"), false, "" });
            migrationBuilder.InsertData("employees", new string[] { "Id", "UserId", "IsDeleted", "Comment" }, new object[] { Guid.Parse("8D783157-1135-4570-9915-0121F208C38D"), Guid.Parse("57353C2F-8158-4814-A4AC-61CE71319177"), false, "" });
            migrationBuilder.InsertData("employees", new string[] { "Id", "UserId", "IsDeleted", "Comment" }, new object[] { Guid.Parse("46EB2E98-F139-42A1-978C-165DB51D9765"), Guid.Parse("5F42DB91-C9EA-4965-B01B-E24416447E51"), false, "" });
            migrationBuilder.InsertData("employees", new string[] { "Id", "UserId", "IsDeleted", "Comment" }, new object[] { Guid.Parse("35ED6966-007D-45D2-A72C-A6B1105F0183"), Guid.Parse("D88B3255-FA23-4B23-871F-6AF68D5F131E"), false, "" });
            migrationBuilder.InsertData("employees", new string[] { "Id", "UserId", "IsDeleted", "Comment" }, new object[] { Guid.Parse("A5F381EB-3F1C-4261-B66D-3D51E57DE240"), Guid.Parse("CC7B831E-8526-44E3-9D5C-24338A87CA17"), false, "" });
            migrationBuilder.InsertData("employees", new string[] { "Id", "UserId", "IsDeleted", "Comment" }, new object[] { Guid.Parse("D85479F7-09A8-4826-996D-795E4A48E949"), Guid.Parse("132A9C01-3103-41F9-AF22-650A3CEF372F"), false, "" });
            migrationBuilder.InsertData("employees", new string[] { "Id", "UserId", "IsDeleted", "Comment" }, new object[] { Guid.Parse("8DDBEEC5-CA71-4EC9-997A-B0E90A0DE758"), Guid.Parse("91C1DDD8-2CD1-472B-8083-B870B9369E11"), false, "" });
        }
    }
}
