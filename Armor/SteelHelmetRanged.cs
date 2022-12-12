using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TestMod.Projectiles;

namespace TestMod.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class SteelHelmetRanged : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Steel Helmet");
            Tooltip.SetDefault("5% Increased ranged damage");
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.value = 1000;
            Item.rare = 1;
            Item.defense = 2;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "15% Increased movement speed";
            player.moveSpeed += 0.15f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            if (body.type == Mod.Find<ModItem>("SteelChest").Type)
            {
                return legs.type == Mod.Find<ModItem>("SteelPants").Type;
            }
            return false;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Ranged) += 0.05f;
        }


    }
}