using Terraria.Audio;
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
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.width = 4;
			Projectile.height = 20;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 400;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
			Projectile.scale = 0.7f;
			Projectile.extraUpdates = 1;
		}

		int bounce = 0;
		int maxBounces = 5;

        public override void AI()
        {
			Projectile.aiStyle = 0;
			Lighting.AddLight(Projectile.position, 0.2f, 0.2f, 0.6f);
			Lighting.Brightness(1, 1);
		}

        public override void Kill(int timeLeft)
        {
			SoundEngine.PlaySound(SoundID.Dig.WithVolumeScale(0.5f).WithPitchOffset(0.8f), Projectile.position);
			for (var i = 0; i < 6; i++)
            {
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 7, 0f, 0f, 0, default(Color), 1f);
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			SoundEngine.PlaySound(SoundID.Item10, new Vector2(Projectile.position.X,Projectile.position.Y));
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
			bounce++;
			SoundEngine.PlaySound(SoundID.Dig.WithVolumeScale(0.5f).WithPitchOffset(0.8f), Projectile.position);
			for (var i = 0; i < 4; i++)
			{
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 7, 0f, 0f, 0, default(Color), 1f);
			}
			if (Projectile.velocity.X != oldVelocity.X) Projectile.velocity.X = -oldVelocity.X;
			if (Projectile.velocity.Y != oldVelocity.Y) Projectile.velocity.Y = -oldVelocity.Y;
			Projectile.aiStyle = 1;

			if (bounce >= maxBounces) return true;
			else return false;
		}
    }
}