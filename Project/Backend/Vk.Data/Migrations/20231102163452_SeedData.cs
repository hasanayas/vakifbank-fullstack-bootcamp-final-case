using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vk.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
    INSERT INTO [dbo].[User]([UserNumber], [UserName], [UserEmail], [UserPassword], [UserPasswordRetryCount], [UserRole], [UserBalance], [UserProfitMargin], [InsertDate])
    VALUES (100001, 'hasan', 'hasan@gmail.com', 'bfca5277c883b619adf051f25604411a', 0, 'Admin', 500.0, 0, '2023-09-06')


    INSERT INTO [dbo].[Product]([ProductName], [ProductImage], [ProductQuantity], [ProductPrice], [ProductInformation], [InsertDate])
    VALUES ('Chair ', 'example.jpg', 100, 10.0, 'Desc ', '2023-06-02')


    INSERT INTO [dbo].[Order]([UserId], [OrderStatus], [OrderPaymentMethod], [OrderAmount], [InsertDate])
    VALUES (1, 'Waiting', 'Credit Card', 100.0, '2023-06-01')


    INSERT INTO[dbo].[Basket] ([UserId], [ProductId], [OrderId], [BasketQuantity], [BasketPrice], [BasketStatus], [InsertDate])
    VALUES(1, 1, 1, 1, 30, 0, '2023-01-01')


"
);


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
