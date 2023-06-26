namespace ProdavnicaPiva.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6870a343-c916-4ea5-a06b-424c5dd80f4f', N'admin@gmail.com', 0, N'AEwgNJkep0CRnkp+Cy3DtdwznUxpE/xZ0Y80CoBUYGVBr6RTPGK+qB4iEb/zqmX79w==', N'41ab9881-eff7-49cb-b990-6294c1b60a21', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f7e5ed05-2816-45f1-a147-ac3576b60219', N'guest@gmail.com', 0, N'ACRSnOeOBCdPa9y2dOL0jdsd2FGWHeOt7Lyp7QYueuBSrAfCDBtd00GzJaylCkP3fw==', N'3bbc6aa9-44eb-409e-a5c5-1eeedc154305', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')
                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd3cbf7c5-1603-4500-99d4-9e2eb8883125', N'CanManageBrands')
                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6870a343-c916-4ea5-a06b-424c5dd80f4f', N'd3cbf7c5-1603-4500-99d4-9e2eb8883125')
                ");
        }

        public override void Down()
        {
        }
    }
}
