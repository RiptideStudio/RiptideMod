using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RiptideMod.Items
{
	public class SlimeSpear : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Sticky Spear"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("");
		}
		public override void SetDefaults() 
		{
			item.CloneDefaults(ItemID.Spear);
			item.damage = 13;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 28;
			item.useAnimation = 28;
			item.knockBack = 7;
			item.value = 500;
			item.rare = 1; 
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("SlimeSpearProjectile");
		}

        public override bool CanUseItem(Player player)
        {
			return player.ownedProjectileCounts[mod.ProjectileType("SlimeSpearProjectile")] < 1;
        }

        public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Gel, 12);
			recipe.AddRecipeGroup("Wood", 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}