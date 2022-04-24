using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RiptideMod;

namespace RiptideMod.Accessories
{
	public class GelBoot : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Slimy Shoes"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Allows the user to run relatively fast");
		}

		public override void SetDefaults() 
		{
			item.width = 20;
			item.height = 20;
			item.value = 2500;
			item.rare = 1;
			item.accessory = true;
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.moveSpeed += 0.3f;
			player.accRunSpeed += 0.25f;
			player.GetModPlayer<WoodSlime>().slimeShoes = true;
        }

        public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Gel, 18);
			recipe.AddIngredient(ItemID.Silk, 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}