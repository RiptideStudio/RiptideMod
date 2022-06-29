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
			Item.width = 20;
			Item.height = 20;
			Item.value = 2500;
			Item.rare = 1;
			Item.accessory = true;
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.moveSpeed += 0.3f;
			player.accRunSpeed += 0.25f;
			player.GetModPlayer<GlobalPlayer>().slimeShoes = true;
        }

        public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Gel, 18);
			recipe.AddIngredient(ItemID.Silk, 3);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}