using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using RiptideMod.Projectiles;

namespace RiptideMod.Items
{
	public class GelWhip : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			DisplayName.SetDefault("Gel Whip");
		}

		public override void SetDefaults()
		{
			Item.DefaultToWhip(ModContent.ProjectileType<GelWhipProjectile>(), 20, 2, 4);
			Item.shootSpeed = 4;
			Item.rare = ItemRarityID.Green;
			Item.channel = true;
		}

		// Makes the whip receive melee prefixes
		public override bool MeleePrefix()
		{
			return true;
		}
	}
}