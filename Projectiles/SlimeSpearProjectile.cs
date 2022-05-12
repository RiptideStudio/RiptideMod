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
			projectile.melee = true;
			projectile.scale = 1.25f;
			projectile.penetrate = -1;
			projectile.aiStyle = 19;
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.timeLeft = 600;
			projectile.light = 0.25f;
			projectile.ignoreWater = false;
			projectile.tileCollide = false;
			projectile.ownerHitCheck = true;
			projectile.hide = true;
		}

		public float movementFactor
        {
			get => projectile.ai[0] - 0.3f;
			set => projectile.ai[0] = value;
        }

        public override void AI()
        {
			Player player = Main.player[projectile.owner];
			Vector2 ownerMountedCenter = player.RotatedRelativePoint(player.MountedCenter, true);

			projectile.direction = player.direction;
			player.heldProj = projectile.whoAmI;
			player.itemTime = player.itemAnimation;

			projectile.position.X = (ownerMountedCenter.X) - (float)projectile.width / 2;
			projectile.position.Y = (ownerMountedCenter.Y) - (float)projectile.height / 2;

			projectile.ai[1] += 1f;

			if (!player.frozen)
            {
				if (movementFactor == 0)
                {
					movementFactor = 2.6f;
					projectile.netUpdate = true;
                }
				if (player.itemAnimation < player.itemAnimationMax/3)
                {
					movementFactor -= 1.8f;
                } else
                {
					movementFactor += 1.8f; //This is how fast the spear moves
                }
            }

			projectile.position += projectile.velocity * movementFactor;

			if (player.itemAnimation == 0)
            {
				projectile.Kill();
            }

			projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);

			if (projectile.spriteDirection == -1)
            {
				projectile.rotation -= MathHelper.ToRadians(90f);
            }

        }
    }
}