using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RiptideMod.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class GelChestplate : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Slimy Chestpiece"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("5% increased critical strike chance");
		}

		public override void SetDefaults() 
		{
			item.width = 20;
			item.height = 20;
			item.value = 2500;
			item.rare = 1;
			item.defense = 3;
		}

        public override void UpdateEquip(Player player)
        {
			player.meleeCrit += 5;
			player.magicCrit += 5;
			player.rangedCrit += 5;
			player.thrownCrit += 5;
        }

        public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Gel, 35);
			recipe.AddIngredient(ItemID.Silk, 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}