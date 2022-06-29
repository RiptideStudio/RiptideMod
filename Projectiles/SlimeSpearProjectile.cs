using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace RiptideMod.Projectiles
{
	public class SlimeSpearProjectile : ModProjectile
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Sticky Spear Projectile"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
		}

		public override void SetDefaults() 
		{
			Projectile.DamageType = DamageClass.Melee;
			Projectile.scale = 1.25f;
			Projectile.penetrate = -1;
			Projectile.aiStyle = 19;
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.timeLeft = 600;
			Projectile.light = 0.25f;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = false;
			Projectile.ownerHitCheck = true;
			Projectile.hide = true;
		}

		public float movementFactor
        {
			get => Projectile.ai[0] - 0.3f;
			set => Projectile.ai[0] = value;
        }

        public override void AI()
        {
			Player player = Main.player[Projectile.owner];
			Vector2 ownerMountedCenter = player.RotatedRelativePoint(player.MountedCenter, true);

			Projectile.direction = player.direction;
			player.heldProj = Projectile.whoAmI;
			player.itemTime = player.itemAnimation;

			Projectile.position.X = (ownerMountedCenter.X) - (float)Projectile.width / 2;
			Projectile.position.Y = (ownerMountedCenter.Y) - (float)Projectile.height / 2;

			Projectile.ai[1] += 1f;

			if (!player.frozen)
            {
				if (movementFactor == 0)
                {
					movementFactor = 2.6f;
					Projectile.netUpdate = true;
                }
				if (player.itemAnimation < player.itemAnimationMax/3)
                {
					movementFactor -= 1.8f;
                } else
                {
					movementFactor += 1.8f; //This is how fast the spear moves
                }
            }

			Projectile.position += Projectile.velocity * movementFactor;

			if (player.itemAnimation == 0)
            {
				Projectile.Kill();
            }

			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);

			if (Projectile.spriteDirection == -1)
            {
				Projectile.rotation -= MathHelper.ToRadians(90f);
            }

        }
    }
}