using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace RiptideMod
{
	public class GlobalPlayer : ModPlayer
	{
		public bool slimeShoes = false;
        public bool livingSlimeMinion = false;

        public float stickyDamage = 0f;

        public override void PostUpdate()
        {
            if (Player.velocity.X != 0 && slimeShoes)
            {
                if (Player.velocity.Y == 0f)
                {
                    int dust = Dust.NewDust(Player.position + new Vector2(0, Player.height - 4), Player.width, 4, 16, 0f, 0f, 0, Colors.RarityBlue, 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 0;
                }
            }
        }

        public override void ResetEffects()
        {
            slimeShoes = false;
            stickyDamage = 0f;
        }
    }
}