using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using System.Collections.Generic;
using Terraria.DataStructures;

namespace BetterTerraria
{
    public class GlobalPlayer : ModPlayer
    {
        public bool copperArmor = false;
        public bool tinArmor = false;
        public bool woodArmor = false;
        public bool dashFeather = false;
        public bool superDash = false;

        // Dashing enums and variables 
        // Keeps track of type of dash, speed, and control variables
        public enum DashType
        {
            feather = 0,
            superShield = 1,
            invalid = -1
        }

        public DashType dashType = DashType.feather;

        public const int dashRight = 2;
        public const int dashLeft = 3;

        public int dashCooldown = 40;
        public int dashDuration = 15; 

        public float dashVelocity = 7.5f;

        public int dashDir = -1;

        public bool dashAccessoryEquipped = false;
        public int dashDelay = 0; 
        public int dashTimer = 0;

        public override void ResetEffects()
        {
            // Set base stats
            Player.pickSpeed = 0.8f;

            // Reset armor setbonuses
            copperArmor = false;
            tinArmor = false;
            woodArmor = false;
            dashFeather = false;
            dashAccessoryEquipped = false;
            superDash = false;

            // Check if we are dashing left or right
            if (Player.controlRight && Player.releaseRight && Player.doubleTapCardinalTimer[dashRight] < 15)
            {
                dashDir = dashRight;
            }
            else if (Player.controlLeft && Player.releaseLeft && Player.doubleTapCardinalTimer[dashLeft] < 15)
            {
                dashDir = dashLeft;
            }
            else
            {
                dashDir = -1;
            }

            switch (dashType)
            {
                case DashType.superShield:
                    dashVelocity = 16f;
                    dashDuration = 20;
                    break;
                case DashType.feather:
                    dashVelocity = 7.5f;
                    dashDuration = 15;
                    break;
            }

            dashType = DashType.invalid;
        }

        public override void PreUpdateMovement()
        {
            // If the player can use our dash and has double tapped in a direction, then apply the dash
            if (CanUseDash())
            {
                Vector2 newVelocity = Player.velocity;

                switch (dashDir)
                {
                    case dashLeft when Player.velocity.X > -dashVelocity:
                    case dashRight when Player.velocity.X < dashVelocity:
                        {
                            float dashDirection = dashDir == dashRight ? 1 : -1;
                            newVelocity.X = dashDirection * dashVelocity;
                            break;
                        }
                    default:
                        return; 
                }

                dashDelay = dashCooldown;
                dashTimer = dashDuration;
                Player.velocity = newVelocity;
                SoundEngine.PlaySound(SoundID.DD2_MonkStaffSwing, Player.position); // This is a dash sound
            }

            // Decrement the dash delay
            if (dashDelay > 0)
                dashDelay--;

            // Particle effect while dashing
            if (dashTimer > 0)
            {
                switch (dashType)
                {
                    case DashType.feather:
                        int dust = Dust.NewDust(Player.position, Player.width, Player.height, DustID.Cloud, 0, 0, default, default, Main.rand.NextFloat(0.75f, 1.25f));
                        Main.dust[dust].velocity.Y = 0;
                        Main.dust[dust].velocity.X = Player.direction * -1;
                        break;
                    case DashType.superShield:
                        int dust2 = Dust.NewDust(Player.position, Player.width, Player.height, DustID.Torch, 0, 0, default, default, Main.rand.NextFloat(0.75f, 1.25f));
                        Main.dust[dust2].velocity.Y = 0;
                        Main.dust[dust2].velocity.X = Player.direction * -1;
                        break;
                }
            }

            if (dashTimer > 0)
            {
                Player.eocDash = dashTimer;
                dashTimer--;
            }
        }

        // Function to check if we can use the dash
        private bool CanUseDash()
        {
            return dashAccessoryEquipped
                && Player.dashType == 0 
                && !Player.setSolar
                && dashDir != -1 
                && dashDelay == 0
                && !Player.mount.Active; 
        }

        // Wooden armor set bonus (reduced knockback)
        public override void ModifyHitByNPC(NPC npc, ref Player.HurtModifiers modifiers)
        {
            if (woodArmor)
            {
                modifiers.Knockback *= 0.5f;
            }
        }

        // Add custom starting items to our inventory
        public override void ModifyStartingInventory(IReadOnlyDictionary<string, List<Item>> itemsByMod, bool mediumCoreDeath)
        {
            itemsByMod["Terraria"].Clear();

            Item sword = new Item(ItemID.CopperBroadsword);
            Item pick = new Item(ItemID.CopperPickaxe);
            Item axe = new Item(ItemID.CopperAxe);
            Item torch = new Item(ItemID.Torch,5);

            if (Main.rand.NextBool(5))
            {
                sword = new Item(ItemID.TinBroadsword);
                pick = new Item(ItemID.TinPickaxe);
                axe = new Item(ItemID.TinAxe);
            }

            itemsByMod["Terraria"].Add(sword);
            itemsByMod["Terraria"].Add(pick);
            itemsByMod["Terraria"].Add(axe);
            itemsByMod["Terraria"].Add(torch);
        }
    }
}
