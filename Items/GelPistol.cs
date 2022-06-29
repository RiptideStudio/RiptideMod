using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace RiptideMod.Items
{
	public class GelPistol : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Sticky Revolver"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Converts normal bullets into bouncy bullets");
		}

		public override void SetDefaults() 
		{
			Item.damage = 8;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 5;
			Item.knockBack = 0.1f;
			Item.value = 2500;
			Item.rare = 1; 
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = 1;
			Item.useAmmo = AmmoID.Bullet;
			Item.shootSpeed = 6.5f;
			Item.noMelee = true;
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {

			Vector2 offset = new Vector2(velocity.X * 3, velocity.Y * 3);
			position += offset;
			if (type == ProjectileID.Bullet)
            {
				type = Mod.Find<ModProjectile>("GelBulletProjectile").Type;
            }
			return true;
        }
        public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Gel, 25);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}

		public override Vector2? HoldoutOffset()
		{
			Vector2 offset = new Vector2(6, 0);
			return offset;
		}

	}
}