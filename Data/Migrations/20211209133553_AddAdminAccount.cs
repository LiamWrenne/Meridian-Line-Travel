using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Text;

namespace Meridian_Line_Travel.Data.Migrations
{
    public partial class AddAdminAccount : Migration
    {            
        const string ADMIN_USER_GUID = "6738c1ba-424a-43a2-a8cc-4f1d24397ddb";
        const string ADMIN_ROLE_GUID = "901b6dda-f7a3-45b6-a55e-9ece6523bc5a";
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var hasher = new PasswordHasher<IdentityUser>();
            var passwordHash = hasher.HashPassword(null, "Safe"); //Not a safe password needs hidding
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("INSERT INTO AspNetUsers(Id, UserName, NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount)");
            sb.AppendLine("VALUES(");
            sb.AppendLine($"'{ADMIN_USER_GUID}'");
            sb.AppendLine(",'admin@email.com'");
            sb.AppendLine(",'ADMIN@EMAIL.COM'");
            sb.AppendLine(",'admin@email.com'");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine($", '{passwordHash}'");
            sb.AppendLine(", ''");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 09,12,2021");
            sb.AppendLine(", 09,12,2021");
            sb.AppendLine(", 0");
            sb.AppendLine(")");

            migrationBuilder.Sql(sb.ToString());
            migrationBuilder.Sql($"INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES ('{ADMIN_ROLE_GUID}','Admin','ADMIN')");
            migrationBuilder.Sql($"INSERT INTO AspNetUserRoles (UserId, RoleId) VALUES ('{ADMIN_USER_GUID}','{ADMIN_ROLE_GUID}')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DELETE FROM AspNetUserRoles WHAERE UserId = '{ADMIN_USER_GUID}' AND RoleID = '{ADMIN_ROLE_GUID}'");
            migrationBuilder.Sql($"DELETE FROM AspNetUsers WHAERE Id = '{ADMIN_USER_GUID}'");
            migrationBuilder.Sql($"DELETE FROM AspNetRoles WHAERE Id = '{ADMIN_ROLE_GUID}'");
        }
    }
}
