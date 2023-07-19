using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RiptideMod.Tiles
{
    public class GelBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gel Block");
        }

        public override void SetDefaults()
        {
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.autoReuse = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = 25;
            Item.width = 8;
            Item.height = 8;
            Item.createTile = ModContent.TileType<GelBlockTile>();
            Item.consumable = true;
            Item.maxStack = 999;
            Item.useStyle = ItemUseStyleID.Swing;
        }
    }
}
