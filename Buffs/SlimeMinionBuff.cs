using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Diagnostics;
using RiptideMod.Projectiles;

namespace RiptideMod.Buffs
{
    public class SlimeMinionBuff : ModBuff
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Living Slime");
			Description.SetDefault("A living slime is fighting for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			if (player.ownedProjectileCounts[ModContent.ProjectileType<SlimeMinionProjectile>()] > 0)
			{
				player.buffTime[buffIndex] = 18000;
			}
			else
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
		}
	}
}