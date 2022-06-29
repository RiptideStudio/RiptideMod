using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RiptideMod.Items
{
	public class GelBullet : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Sticky Bullet"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Bounces off walls");
		}

		public override void SetDefaults() 
		{
			Item.damage = 4;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 40;
			Item.knockBack = 2;
			Item.value = 50;
			Item.rare = 1;
			Item.consumable = true;
			Item.shoot = Mod.Find<ModProjectile>("GelBulletProjectile").Type;
			Item.ammo = AmmoID.Bullet;
			Item.maxStack = 999;
			Item.shootSpeed = 4.5f;
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe(25);
			recipe.AddIngredient(ItemID.Gel, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}