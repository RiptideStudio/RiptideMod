using System;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace RiptideMod.Tiles
{
    public class GelBlockTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = false;
            Main.tileBouncy[Type] = true;

            DustType = DustID.BubbleBurst_Blue;
            ItemDrop = ModContent.ItemType<GelBlock>();
        }
    }
}
