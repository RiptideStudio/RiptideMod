using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TestMod.Projectiles;

namespace TestMod.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class SteelChest : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Steel Chestpiece");
            Tooltip.SetDefault("3% Increased critical strike chance");
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.value = 2000;
            Item.rare = 1;
            Item.defense = 5;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetCritChance(DamageClass.Ranged) += 3;
        }
    }
}