using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace RiptideMod
{
	public class WoodSlime : ModPlayer
	{
		public bool slimeShoes = false;

        public override void PostUpdate()
        {
            if (player.velocity.X != 0 && slimeShoes)
            {
                if (player.velocity.Y == 0f)
                {
                    int dust = Dust.NewDust(player.position + new Vector2(0, player.height - 4), player.width, 4, 16, 0f, 0f, 0, Colors.RarityBlue, 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 0;
                }
            }
        }

        public override void ResetEffects()
        {
            slimeShoes = false;
        }
    }
}