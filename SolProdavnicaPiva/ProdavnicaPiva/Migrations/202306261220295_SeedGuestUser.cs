namespace ProdavnicaPiva.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedGuestUser : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f7e5ed05-2816-45f1-a147-ac3576b60219', N'guest@gmail.com', 0, N'ACRSnOeOBCdPa9y2dOL0jdsd2FGWHeOt7Lyp7QYueuBSrAfCDBtd00GzJaylCkP3fw==', N'3bbc6aa9-44eb-409e-a5c5-1eeedc154305', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')
                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'123', N'CanManageBeer')
                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f7e5ed05-2816-45f1-a147-ac3576b60219', N'123')

                ");
        }

        public override void Down()
        {
        }
    }
}
