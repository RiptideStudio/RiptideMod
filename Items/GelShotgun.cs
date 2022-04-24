using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace RiptideMod.Items
{
	public class GelShotgun : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Sticky Shotgun"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Shoots a spread of bullets\nConverts normal bullets into slimey bullets");
		}

		public override void SetDefaults() 
		{
			item.damage = 14;
			item.ranged = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 40;
			item.useAnimation = 40;
			item.useStyle = 5;
			item.knockBack = 0.1f;
			item.value = 3500;
			item.rare = 1;
			item.UseSound = SoundID.Item36;
			item.autoReuse = true;
			item.shoot = 1;
			item.useAmmo = AmmoID.Bullet;
			item.shootSpeed = 7.5f;
			item.noMelee = true;
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			Vector2 offset = new Vector2(speedX * 1, speedY * 1);
			position += offset;
			if (type == ProjectileID.Bullet)
			{
				type = mod.ProjectileType("GelBulletProjectile");
			}
			for (var i = 0; i < Main.rand.Next(3,4); i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(25));
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
        }
        public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Gel, 25);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override Vector2? HoldoutOffset()
		{
			Vector2 offset = new Vector2(6, 0);
			return offset;
		}

	}
}