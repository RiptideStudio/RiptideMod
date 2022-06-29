using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace RiptideMod.Enemies
{
    public class WoodSlime : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wooden Slime");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[2];
        }

        public override void SetDefaults()
        {
            npc.width = 32;
            npc.height = 15;
            npc.damage = 11;
            npc.defense = 3;
            npc.lifeMax = 22;
            npc.value = 50f;
            npc.aiStyle = 1;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            aiType = NPCID.GreenSlime;
            animationType = NPCID.GreenSlime;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDaySlime.Chance * 0.2f;
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter++;
            if (npc.frameCounter >= 20)
            {
                npc.frameCounter = 0;
            }
            npc.frame.Y = (int)npc.frameCounter / 10 * frameHeight;
        }

        public override void NPCLoot()
        {
            Item.NewItem(npc.getRect(), ItemID.Gel, Main.rand.Next(0, 2));
            Item.NewItem(npc.getRect(), ItemID.Wood, Main.rand.Next(5, 10));
        }

    }
}