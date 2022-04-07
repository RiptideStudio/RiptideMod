using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RiptideMod.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class GelLeggings : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Slimy Pants"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("7% increased movement speed");
		}

		public override void SetDefaults() 
		{
			item.width = 20;
			item.height = 20;
			item.value = 2000;
			item.rare = 1;
			item.defense = 2;
		}

        public override void UpdateEquip(Player player)
        {
			player.moveSpeed += 0.07f;
        }

        public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Gel, 30);
			recipe.AddIngredient(ItemID.Silk, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}