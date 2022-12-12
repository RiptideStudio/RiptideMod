using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TestMod.Projectiles;

namespace TestMod.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class SteelPants : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Steel Leggings");
            Tooltip.SetDefault("7% Increased movement speed");
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.value = 1500;
            Item.rare = 1;
            Item.defense = 3;
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.07f;
        }
    }
}