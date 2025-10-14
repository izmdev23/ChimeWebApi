using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ChimeWebApi.Migrations.ProductDatabaseMigrations
{
    /// <inheritdoc />
    public partial class ProdDb1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1cb3b63c-c1b8-44a6-8452-dce9475ebd24"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c0de78e0-8f72-467e-8ec7-d0f9316d5877"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c3f1b6d8-143b-4683-87e0-f519aecde25b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d171b44b-b279-4417-a95d-a1af73a93448"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("de1a7f92-5429-4af3-a5b4-2b7bcd648aea"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price", "Rating", "SaleEnd", "SalePrice", "SaleStart", "Stock", "StoreId", "TransactionId", "UploaderId" },
                values: new object[,]
                {
                    { new Guid("67b97501-cb20-44d6-98a9-a9ea77f4574c"), 4, "𝐍𝐨𝐭𝐞：\r\n\r\n𝐃𝐨𝐧'𝐭 𝐟𝐨𝐫𝐠𝐞𝐭 𝐭𝐨 𝐬𝐞𝐥𝐞𝐜𝐭 𝐭𝐡𝐞 𝐢𝐧𝐜𝐥𝐮𝐝𝐢𝐧𝐠 𝐠𝐢𝐟𝐭 𝐮𝐩𝐨𝐧 𝐩𝐥𝐚𝐜𝐞 𝐲𝐨𝐮𝐫 𝐨𝐫𝐝𝐞𝐫！！！！\r\n\r\n𝐏𝐥𝐞𝐚𝐬𝐞 𝐚𝐝𝐝 𝐭𝐨 𝐜𝐚𝐫𝐭 𝐚𝐧𝐝 𝐬𝐞𝐥𝐞𝐜𝐭 𝐭𝐡𝐞 𝐠𝐢𝐟𝐭！！\r\n\r\n𝐏𝐥𝐞𝐚𝐬𝐞 𝐦𝐚𝐤𝐞 𝐬𝐮𝐫𝐞 𝐲𝐨𝐮𝐫 𝐨𝐫𝐝𝐞𝐫 𝐢𝐧𝐜𝐥𝐮𝐝𝐞𝐬 𝐭𝐡𝐞 𝐠𝐢𝐟𝐭, 𝐨𝐭𝐡𝐞𝐫𝐰𝐢𝐬𝐞 𝐭𝐡𝐞 𝐠𝐢𝐟𝐭 𝐰𝐢𝐥𝐥 𝐧𝐨𝐭 𝐛𝐞 𝐬𝐡𝐢𝐩𝐩𝐞𝐝！！\r\n\r\n𝐀𝐥𝐥 𝐯𝐚𝐫𝐢𝐚𝐧𝐭𝐬 𝐥𝐢𝐬𝐭𝐞𝐝 𝐚𝐫𝐞 𝐁𝐑𝐀𝐍𝐃-𝐍𝐄𝐖. \r\n\r\n𝐓𝐡𝐞 𝐬𝐚𝐦𝐞 𝐦𝐨𝐝𝐞𝐥 𝐰𝐢𝐭𝐡 𝐩𝐫𝐢𝐜𝐞 𝐝𝐢𝐟𝐟𝐞𝐫𝐞𝐧𝐜𝐞𝐬 𝐢𝐬 𝐝𝐮𝐞 𝐭𝐨 𝐯𝐚𝐫𝐢𝐨𝐮𝐬 𝐩𝐫𝐨𝐦𝐨𝐭𝐢𝐨𝐧𝐬. \r\n\r\n𝐅𝐞𝐞𝐥 𝐟𝐫𝐞𝐞 𝐭𝐨 𝐜𝐡𝐨𝐨𝐬𝐞 𝐭𝐡𝐞 𝐨𝐧𝐞 𝐭𝐡𝐚𝐭 𝐛𝐞𝐬𝐭 𝐬𝐮𝐢𝐭𝐬 𝐲𝐨𝐮𝐫 𝐩𝐫𝐞𝐟𝐞𝐫𝐞𝐧𝐜𝐞!\r\n\r\nOnly one strap can be used per order！！\r\n\r\n\r\n\r\n🎉Name:Xiaomi Redmi Watch 5 Lite\r\n\r\n⌚Main body dimensions:49.1 × 40.4 × 11.4 mm (excluding heart rate tab)\r\n\r\nScreen size and type: 1.96-inch, AMOLED colour square screen\r\n\r\nScreen resolution: 410 × 502, support full-screen touch operation\r\n\r\nScreen brightness: up to 600nits, support for automatic brightness adjustment\r\n\r\n❤️Sensors：\r\n\r\nAccelerometer Sensor\r\n\r\nGyroscope Sensor\r\n\r\nOptical Heart Rate and Oxygen Sensor\r\n\r\nAmbient Light Sensor\r\n\r\nGeomagnetic Sensor\r\n\r\n💧Waterproof rating:5ATM\r\n\r\n🔗Data Connectivity:Bluetooth 5.3\r\n\r\n🔋Battery Capacity:470mAh\r\n\r\nBattery Type:Li-Ion Polymer Battery\r\n\r\n⌚Applicable wrist size:135mm - 200mm\r\n\r\nWristband Material:TPU", "[Free Strap] Xiaomi Redmi Watch 5 Lite 1.96inch AMOLED Display Built-in GPS 5ATM Water Resistance", 4999m, 0f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2379m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("08ddfe7c-b9ae-4602-871b-a2e50fcf48a2") },
                    { new Guid("73909736-f9be-412f-9c49-1defe7a9da75"), 3, "Weight : 0.35Output Type : tripleModel Number : UNOR3Type : DC/AC InvertersOrigin : Mainland ChinaCertification : CE", "DIY Project Starter Kit For Arduino UNO R3 DIY Electronic Component Set With 830/400 Tie-points Breadboard", 389m, 0f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 195m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("08ddfe7c-b9ae-4602-871b-a2e50fcf48a2") },
                    { new Guid("75b74286-a116-49be-86c7-6bb489076a9d"), 2, "This 75th anniversary edition of a classic bestseller is stunningly illustrated and designed to enchant fans of Greek, Roman, and Norse mythology at all ages.", "Mythology: Timeless Tales of Gods and Heroes, 75th Anniversary Illustrated Edition by Edith Hamilton", 199m, 0f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 138m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("08ddfe7f-1ec6-47ee-8b74-ef4846c95c55") },
                    { new Guid("879553df-49e6-416f-bf48-cc5a2a9e7327"), 2, "A blockbuster follow-up to one of the most successful books in recent years in signature manson style, an anti-self help guide to finding hope in a world that’s falling apart. From the author of the international bestseller The subtle art of not giving a f*ck comes a counterintuitive guide to the problems of hope. We live in an interesting time. Materially, everything is the best it’s ever been—we are Freer, healthier and wealthier than any people in human history. Yet, somehow everything seems to be irreparably and horribly f*cked—the planet is warming, governments are failing, economies are collapsing, and everyone is perpetually offended on Twitter. At this moment in history, when we have access to technology, education and Communication our ancestors couldnt even dream of, so many of us come back to an overriding feeling of hopelessness.", "The Subtle Art of Not Giving A F*ck Mark Manson Everything Is F*cked: A Book about Hope Foreign Life", 788m, 0f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 200m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("08ddfe7f-1ec6-47ee-8b74-ef4846c95c55") },
                    { new Guid("bbd255cc-4e31-44e4-aea9-cc6f30670511"), 3, "Soft remainder: \r\n\r\n- CH340 driver need to be installed on the computer so that it can recognize the device. \r\n\r\n- Please contact us if you need this driver and its install guideline.", "ESP32 KIT ESP32 Development Board ESP32 WROOM 32 with WiFi and Bluetooth", 229m, 0f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 229m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("08ddfe7c-b9ae-4602-871b-a2e50fcf48a2") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("67b97501-cb20-44d6-98a9-a9ea77f4574c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("73909736-f9be-412f-9c49-1defe7a9da75"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("75b74286-a116-49be-86c7-6bb489076a9d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("879553df-49e6-416f-bf48-cc5a2a9e7327"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bbd255cc-4e31-44e4-aea9-cc6f30670511"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price", "Rating", "SaleEnd", "SalePrice", "SaleStart", "Stock", "StoreId", "TransactionId", "UploaderId" },
                values: new object[,]
                {
                    { new Guid("1cb3b63c-c1b8-44a6-8452-dce9475ebd24"), 2, "A blockbuster follow-up to one of the most successful books in recent years in signature manson style, an anti-self help guide to finding hope in a world that’s falling apart. From the author of the international bestseller The subtle art of not giving a f*ck comes a counterintuitive guide to the problems of hope. We live in an interesting time. Materially, everything is the best it’s ever been—we are Freer, healthier and wealthier than any people in human history. Yet, somehow everything seems to be irreparably and horribly f*cked—the planet is warming, governments are failing, economies are collapsing, and everyone is perpetually offended on Twitter. At this moment in history, when we have access to technology, education and Communication our ancestors couldnt even dream of, so many of us come back to an overriding feeling of hopelessness.", "The Subtle Art of Not Giving A F*ck Mark Manson Everything Is F*cked: A Book about Hope Foreign Life", 788m, 0f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 200m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("08ddfe7f-1ec6-47ee-8b74-ef4846c95c55") },
                    { new Guid("c0de78e0-8f72-467e-8ec7-d0f9316d5877"), 2, "This 75th anniversary edition of a classic bestseller is stunningly illustrated and designed to enchant fans of Greek, Roman, and Norse mythology at all ages.", "Mythology: Timeless Tales of Gods and Heroes, 75th Anniversary Illustrated Edition by Edith Hamilton", 199m, 0f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 138m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("08ddfe7f-1ec6-47ee-8b74-ef4846c95c55") },
                    { new Guid("c3f1b6d8-143b-4683-87e0-f519aecde25b"), 4, "𝐍𝐨𝐭𝐞：\r\n\r\n𝐃𝐨𝐧'𝐭 𝐟𝐨𝐫𝐠𝐞𝐭 𝐭𝐨 𝐬𝐞𝐥𝐞𝐜𝐭 𝐭𝐡𝐞 𝐢𝐧𝐜𝐥𝐮𝐝𝐢𝐧𝐠 𝐠𝐢𝐟𝐭 𝐮𝐩𝐨𝐧 𝐩𝐥𝐚𝐜𝐞 𝐲𝐨𝐮𝐫 𝐨𝐫𝐝𝐞𝐫！！！！\r\n\r\n𝐏𝐥𝐞𝐚𝐬𝐞 𝐚𝐝𝐝 𝐭𝐨 𝐜𝐚𝐫𝐭 𝐚𝐧𝐝 𝐬𝐞𝐥𝐞𝐜𝐭 𝐭𝐡𝐞 𝐠𝐢𝐟𝐭！！\r\n\r\n𝐏𝐥𝐞𝐚𝐬𝐞 𝐦𝐚𝐤𝐞 𝐬𝐮𝐫𝐞 𝐲𝐨𝐮𝐫 𝐨𝐫𝐝𝐞𝐫 𝐢𝐧𝐜𝐥𝐮𝐝𝐞𝐬 𝐭𝐡𝐞 𝐠𝐢𝐟𝐭, 𝐨𝐭𝐡𝐞𝐫𝐰𝐢𝐬𝐞 𝐭𝐡𝐞 𝐠𝐢𝐟𝐭 𝐰𝐢𝐥𝐥 𝐧𝐨𝐭 𝐛𝐞 𝐬𝐡𝐢𝐩𝐩𝐞𝐝！！\r\n\r\n𝐀𝐥𝐥 𝐯𝐚𝐫𝐢𝐚𝐧𝐭𝐬 𝐥𝐢𝐬𝐭𝐞𝐝 𝐚𝐫𝐞 𝐁𝐑𝐀𝐍𝐃-𝐍𝐄𝐖. \r\n\r\n𝐓𝐡𝐞 𝐬𝐚𝐦𝐞 𝐦𝐨𝐝𝐞𝐥 𝐰𝐢𝐭𝐡 𝐩𝐫𝐢𝐜𝐞 𝐝𝐢𝐟𝐟𝐞𝐫𝐞𝐧𝐜𝐞𝐬 𝐢𝐬 𝐝𝐮𝐞 𝐭𝐨 𝐯𝐚𝐫𝐢𝐨𝐮𝐬 𝐩𝐫𝐨𝐦𝐨𝐭𝐢𝐨𝐧𝐬. \r\n\r\n𝐅𝐞𝐞𝐥 𝐟𝐫𝐞𝐞 𝐭𝐨 𝐜𝐡𝐨𝐨𝐬𝐞 𝐭𝐡𝐞 𝐨𝐧𝐞 𝐭𝐡𝐚𝐭 𝐛𝐞𝐬𝐭 𝐬𝐮𝐢𝐭𝐬 𝐲𝐨𝐮𝐫 𝐩𝐫𝐞𝐟𝐞𝐫𝐞𝐧𝐜𝐞!\r\n\r\nOnly one strap can be used per order！！\r\n\r\n\r\n\r\n🎉Name:Xiaomi Redmi Watch 5 Lite\r\n\r\n⌚Main body dimensions:49.1 × 40.4 × 11.4 mm (excluding heart rate tab)\r\n\r\nScreen size and type: 1.96-inch, AMOLED colour square screen\r\n\r\nScreen resolution: 410 × 502, support full-screen touch operation\r\n\r\nScreen brightness: up to 600nits, support for automatic brightness adjustment\r\n\r\n❤️Sensors：\r\n\r\nAccelerometer Sensor\r\n\r\nGyroscope Sensor\r\n\r\nOptical Heart Rate and Oxygen Sensor\r\n\r\nAmbient Light Sensor\r\n\r\nGeomagnetic Sensor\r\n\r\n💧Waterproof rating:5ATM\r\n\r\n🔗Data Connectivity:Bluetooth 5.3\r\n\r\n🔋Battery Capacity:470mAh\r\n\r\nBattery Type:Li-Ion Polymer Battery\r\n\r\n⌚Applicable wrist size:135mm - 200mm\r\n\r\nWristband Material:TPU", "[Free Strap] Xiaomi Redmi Watch 5 Lite 1.96inch AMOLED Display Built-in GPS 5ATM Water Resistance", 4999m, 0f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2379m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("08ddfe7c-b9ae-4602-871b-a2e50fcf48a2") },
                    { new Guid("d171b44b-b279-4417-a95d-a1af73a93448"), 3, "Weight : 0.35Output Type : tripleModel Number : UNOR3Type : DC/AC InvertersOrigin : Mainland ChinaCertification : CE", "DIY Project Starter Kit For Arduino UNO R3 DIY Electronic Component Set With 830/400 Tie-points Breadboard", 389m, 0f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 195m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("08ddfe7c-b9ae-4602-871b-a2e50fcf48a2") },
                    { new Guid("de1a7f92-5429-4af3-a5b4-2b7bcd648aea"), 3, "Soft remainder: \r\n\r\n- CH340 driver need to be installed on the computer so that it can recognize the device. \r\n\r\n- Please contact us if you need this driver and its install guideline.", "ESP32 KIT ESP32 Development Board ESP32 WROOM 32 with WiFi and Bluetooth", 229m, 0f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 229m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("08ddfe7c-b9ae-4602-871b-a2e50fcf48a2") }
                });
        }
    }
}
