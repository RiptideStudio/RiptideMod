using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace RiptideMod.Projectiles
{
	public class GelProjectile : ModProjectile
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Gel Projectile"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
		}

		public override void SetDefaults() 
		{
			projectile.magic = true;
			projectile.width = 8;
			projectile.height = 8;
			projectile.aiStyle = 0;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.penetrate = 2;
			projectile.timeLeft = 600;
			projectile.light = 0.25f;
			projectile.ignoreWater = false;
			projectile.tileCollide = true;
		}

        public override void AI()
        {
			int dust = Dust.NewDust(projectile.Center, 1, 1, 15, 0f, 0f, 0, default(Color), 1f);
			Main.dust[dust].velocity *= 0.3f;
			Main.dust[dust].scale = (float)Main.rand.Next(100, 135) * 0.013f;
			Main.dust[dust].noGravity = true;

			int dust2 = Dust.NewDust(projectile.Center, 1, 1, 137, 0f, 0f, 0, default(Color), 1f);
			Main.dust[dust2].velocity *= 0.3f;
			Main.dust[dust2].scale = (float)Main.rand.Next(80, 115) * 0.013f;
			Main.dust[dust2].noGravity = true;
		}
    }
}