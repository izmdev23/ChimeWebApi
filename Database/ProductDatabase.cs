using ChimeWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChimeWebApi.Database
{
	public class ProductDatabase(DbContextOptions<ProductDatabase> options) : DbContext(options)
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductType> ProductTypes { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var product = modelBuilder.Entity<Product>();
			product.HasKey(e => e.Id);
			product.HasOne(e => e.Category)
				.WithMany(e => e.Products)
				.HasForeignKey(e => e.CategoryId);
			product.HasData(
				new Product()
				{
					Id = Guid.NewGuid(),
					CategoryId = 2,
					Description = "A blockbuster follow-up to one of the most successful books in recent years in signature manson style, an anti-self help guide to finding hope in a world that’s falling apart. From the author of the international bestseller The subtle art of not giving a f*ck comes a counterintuitive guide to the problems of hope. We live in an interesting time. Materially, everything is the best it’s ever been—we are Freer, healthier and wealthier than any people in human history. Yet, somehow everything seems to be irreparably and horribly f*cked—the planet is warming, governments are failing, economies are collapsing, and everyone is perpetually offended on Twitter. At this moment in history, when we have access to technology, education and Communication our ancestors couldnt even dream of, so many of us come back to an overriding feeling of hopelessness.",
					Name = "The Subtle Art of Not Giving A F*ck Mark Manson Everything Is F*cked: A Book about Hope Foreign Life",
					Price = 788,
					SalePrice = 200,
					Rating = 0,
					StoreId = Guid.Empty,
					UploaderId = Guid.Parse("08ddfe7f-1ec6-47ee-8b74-ef4846c95c55")
				},
				new Product()
				{
					Id = Guid.NewGuid(),
					CategoryId = 2,
					Description = "This 75th anniversary edition of a classic bestseller is stunningly illustrated and designed to enchant fans of Greek, Roman, and Norse mythology at all ages.",
					Name = "Mythology: Timeless Tales of Gods and Heroes, 75th Anniversary Illustrated Edition by Edith Hamilton",
					Price = 199,
					SalePrice = 138,
					Rating = 0,
					StoreId = Guid.Empty,
					UploaderId = Guid.Parse("08ddfe7f-1ec6-47ee-8b74-ef4846c95c55")
				},
				new Product()
				{
					Id = Guid.NewGuid(),
					CategoryId = 3,
					Description = "Soft remainder: \r\n\r\n- CH340 driver need to be installed on the computer so that it can recognize the device. \r\n\r\n- Please contact us if you need this driver and its install guideline.",
					Name = "ESP32 KIT ESP32 Development Board ESP32 WROOM 32 with WiFi and Bluetooth",
					Price = 229,
					SalePrice = 229,
					Rating = 0,
					StoreId = Guid.Empty,
					UploaderId = Guid.Parse("08ddfe7c-b9ae-4602-871b-a2e50fcf48a2")
				},
				new Product()
				{
					Id = Guid.NewGuid(),
					CategoryId = 3,
					Description = "Weight : 0.35Output Type : tripleModel Number : UNOR3Type : DC/AC InvertersOrigin : Mainland ChinaCertification : CE",
					Name = "DIY Project Starter Kit For Arduino UNO R3 DIY Electronic Component Set With 830/400 Tie-points Breadboard",
					Price = 389,
					SalePrice = 195,
					Rating = 0,
					StoreId = Guid.Empty,
					UploaderId = Guid.Parse("08ddfe7c-b9ae-4602-871b-a2e50fcf48a2")
				},
				new Product()
				{
					Id = Guid.NewGuid(),
					CategoryId = 4,
					Description = "𝐍𝐨𝐭𝐞：\r\n\r\n𝐃𝐨𝐧'𝐭 𝐟𝐨𝐫𝐠𝐞𝐭 𝐭𝐨 𝐬𝐞𝐥𝐞𝐜𝐭 𝐭𝐡𝐞 𝐢𝐧𝐜𝐥𝐮𝐝𝐢𝐧𝐠 𝐠𝐢𝐟𝐭 𝐮𝐩𝐨𝐧 𝐩𝐥𝐚𝐜𝐞 𝐲𝐨𝐮𝐫 𝐨𝐫𝐝𝐞𝐫！！！！\r\n\r\n𝐏𝐥𝐞𝐚𝐬𝐞 𝐚𝐝𝐝 𝐭𝐨 𝐜𝐚𝐫𝐭 𝐚𝐧𝐝 𝐬𝐞𝐥𝐞𝐜𝐭 𝐭𝐡𝐞 𝐠𝐢𝐟𝐭！！\r\n\r\n𝐏𝐥𝐞𝐚𝐬𝐞 𝐦𝐚𝐤𝐞 𝐬𝐮𝐫𝐞 𝐲𝐨𝐮𝐫 𝐨𝐫𝐝𝐞𝐫 𝐢𝐧𝐜𝐥𝐮𝐝𝐞𝐬 𝐭𝐡𝐞 𝐠𝐢𝐟𝐭, 𝐨𝐭𝐡𝐞𝐫𝐰𝐢𝐬𝐞 𝐭𝐡𝐞 𝐠𝐢𝐟𝐭 𝐰𝐢𝐥𝐥 𝐧𝐨𝐭 𝐛𝐞 𝐬𝐡𝐢𝐩𝐩𝐞𝐝！！\r\n\r\n𝐀𝐥𝐥 𝐯𝐚𝐫𝐢𝐚𝐧𝐭𝐬 𝐥𝐢𝐬𝐭𝐞𝐝 𝐚𝐫𝐞 𝐁𝐑𝐀𝐍𝐃-𝐍𝐄𝐖. \r\n\r\n𝐓𝐡𝐞 𝐬𝐚𝐦𝐞 𝐦𝐨𝐝𝐞𝐥 𝐰𝐢𝐭𝐡 𝐩𝐫𝐢𝐜𝐞 𝐝𝐢𝐟𝐟𝐞𝐫𝐞𝐧𝐜𝐞𝐬 𝐢𝐬 𝐝𝐮𝐞 𝐭𝐨 𝐯𝐚𝐫𝐢𝐨𝐮𝐬 𝐩𝐫𝐨𝐦𝐨𝐭𝐢𝐨𝐧𝐬. \r\n\r\n𝐅𝐞𝐞𝐥 𝐟𝐫𝐞𝐞 𝐭𝐨 𝐜𝐡𝐨𝐨𝐬𝐞 𝐭𝐡𝐞 𝐨𝐧𝐞 𝐭𝐡𝐚𝐭 𝐛𝐞𝐬𝐭 𝐬𝐮𝐢𝐭𝐬 𝐲𝐨𝐮𝐫 𝐩𝐫𝐞𝐟𝐞𝐫𝐞𝐧𝐜𝐞!\r\n\r\nOnly one strap can be used per order！！\r\n\r\n\r\n\r\n🎉Name:Xiaomi Redmi Watch 5 Lite\r\n\r\n⌚Main body dimensions:49.1 × 40.4 × 11.4 mm (excluding heart rate tab)\r\n\r\nScreen size and type: 1.96-inch, AMOLED colour square screen\r\n\r\nScreen resolution: 410 × 502, support full-screen touch operation\r\n\r\nScreen brightness: up to 600nits, support for automatic brightness adjustment\r\n\r\n❤️Sensors：\r\n\r\nAccelerometer Sensor\r\n\r\nGyroscope Sensor\r\n\r\nOptical Heart Rate and Oxygen Sensor\r\n\r\nAmbient Light Sensor\r\n\r\nGeomagnetic Sensor\r\n\r\n💧Waterproof rating:5ATM\r\n\r\n🔗Data Connectivity:Bluetooth 5.3\r\n\r\n🔋Battery Capacity:470mAh\r\n\r\nBattery Type:Li-Ion Polymer Battery\r\n\r\n⌚Applicable wrist size:135mm - 200mm\r\n\r\nWristband Material:TPU",
					Name = "[Free Strap] Xiaomi Redmi Watch 5 Lite 1.96inch AMOLED Display Built-in GPS 5ATM Water Resistance",
					Price = 4999,
					SalePrice = 2379,
					Rating = 0,
					StoreId = Guid.Empty,
					UploaderId = Guid.Parse("08ddfe7c-b9ae-4602-871b-a2e50fcf48a2")
				});


			base.OnModelCreating(modelBuilder);
		}
	}
}
