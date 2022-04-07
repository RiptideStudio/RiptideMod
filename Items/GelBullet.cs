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
			item.damage = 4;
			item.ranged = true;
			item.width = 40;
			item.height = 40;
			item.knockBack = 2;
			item.value = 50;
			item.rare = 1;
			item.consumable = true;
			item.shoot = mod.ProjectileType("GelBulletProjectile");
			item.ammo = AmmoID.Bullet;
			item.maxStack = 999;
			item.shootSpeed = 4.5f;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Gel, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 25);
			recipe.AddRecipe();
		}
	}
}