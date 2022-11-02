using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RiptideMod.Projectiles;
using RiptideMod;

namespace RiptideMod.Projectiles
{
    public class GelYoyoProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Adhesive");
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = 8;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 260;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 15;
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Melee;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 99;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = -1;
        }
    }
}