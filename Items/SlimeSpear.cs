using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RiptideMod.Items
{
	public class SlimeSpear : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Sticky Spear"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("");
		}
		public override void SetDefaults() 
		{
			Item.CloneDefaults(ItemID.Spear);
			Item.damage = 13;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 28;
			Item.useAnimation = 28;
			Item.knockBack = 7;
			Item.value = 500;
			Item.rare = 1; 
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("SlimeSpearProjectile").Type;
		}

        public override bool CanUseItem(Player player)
        {
			return player.ownedProjectileCounts[Mod.Find<ModProjectile>("SlimeSpearProjectile").Type] < 1;
        }

        public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Gel, 12);
			recipe.AddRecipeGroup("Wood", 5);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}