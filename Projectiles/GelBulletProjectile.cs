using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RiptideMod.Projectiles
{
	public class GelBulletProjectile : ModProjectile
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Gel Bullet"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
		}

		public override void SetDefaults() 
		{
			projectile.ranged = true;
			projectile.width = 4;
			projectile.height = 20;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.penetrate = 1;
			projectile.timeLeft = 400;
			projectile.ignoreWater = false;
			projectile.tileCollide = true;
			projectile.scale = 0.7f;
			projectile.extraUpdates = 1;
		}

		int bounce = 0;
		int maxBounces = 5;

        public override void AI()
        {
			projectile.aiStyle = 0;
			Lighting.AddLight(projectile.position, 0.2f, 0.2f, 0.6f);
			Lighting.Brightness(1, 1);
		}

        public override void Kill(int timeLeft)
        {
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 21, 0.5f, 0.8f);
			for (var i = 0; i < 6; i++)
            {
				Dust.NewDust(projectile.position, projectile.width, projectile.height, 7, 0f, 0f, 0, default(Color), 1f);
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
			bounce++;
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 21, 0.5f, 0.8f);
			for (var i = 0; i < 4; i++)
			{
				Dust.NewDust(projectile.position, projectile.width, projectile.height, 7, 0f, 0f, 0, default(Color), 1f);
			}
			if (projectile.velocity.X != oldVelocity.X) projectile.velocity.X = -oldVelocity.X;
			if (projectile.velocity.Y != oldVelocity.Y) projectile.velocity.Y = -oldVelocity.Y;
			projectile.aiStyle = 1;

			if (bounce >= maxBounces) return true;
			else return false;
		}
    }
}