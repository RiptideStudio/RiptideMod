using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RiptideMod.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class GelHelmet : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Slimy Helmet"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("5% increased melee damage");
		}

		public override void SetDefaults() 
		{
			item.width = 20;
			item.height = 20;
			item.value = 1500;
			item.rare = 1;
			item.defense = 2;
		}

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
			return body.type == mod.ItemType("GelChestplate") && legs.type == mod.ItemType("GelLeggings");
        }

        public override void UpdateArmorSet(Player player)
        {
			player.setBonus = "20% increased movement speed";
			player.moveSpeed += 0.20f;
        }

        public override void UpdateEquip(Player player)
        {
			player.meleeDamage += 0.05f;
        }

        public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Gel, 25);
			recipe.AddIngredient(ItemID.Silk, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}