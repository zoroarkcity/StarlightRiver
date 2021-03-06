﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

using StarlightRiver.Core;
using StarlightRiver.Helpers;

namespace StarlightRiver.Content.Bosses.GlassBoss
{
    internal class SandCone : ModProjectile, IDrawAdditive
    {
        public override string Texture => AssetDirectory.Invisible;

        public override void SetDefaults()
        {
            projectile.hostile = false;
            projectile.width = 1;
            projectile.height = 1;
            projectile.timeLeft = 2;
        }

        public override void AI()
        {
            projectile.timeLeft = 2;
            projectile.ai[0]++; //ticks up the timer

            if (projectile.ai[0] >= 70) //when this projectile goes off
            {
                for (int k = 0; k < 100; k++) Dust.NewDustPerfect(projectile.Center, DustType<Dusts.Sand>(), new Vector2(Main.rand.NextFloat(-35f, 0), 0).RotatedBy(projectile.rotation + Main.rand.NextFloat(-0.2f, 0.2f)), Main.rand.Next(200, 255), default, 0.8f);
                foreach (Player player in Main.player.Where(n => Helper.CheckConicalCollision(projectile.Center, 700, projectile.rotation, 0.2f, n.Hitbox)))
                {
                    player.Hurt(PlayerDeathReason.ByCustomReason(player.name + " bit the dust..."), Main.expertMode ? 50 : 35, 0); //hurt em
                    if (Main.rand.Next(Main.expertMode ? 4 : 5) == 0) player.AddBuff(BuffID.Obstructed, 60); //blind em
                }
                Main.PlaySound(SoundID.DD2_BookStaffCast); //sound
                projectile.Kill(); //self-destruct
            }
        }

        public void DrawAdditive(SpriteBatch spriteBatch)
        {
            if (projectile.ai[0] <= 66) //draws the proejctile's tell ~1 second before it goes off
            {
                Texture2D tex = GetTexture("StarlightRiver/Assets/Bosses/GlassBoss/ConeTell");
                float alpha = (projectile.ai[0] * 2 / 33 - (float)Math.Pow(projectile.ai[0], 2) / 1086) * 0.6f;
                spriteBatch.Draw(tex, projectile.Center - Main.screenPosition, tex.Frame(), new Color(240, 220, 180) * alpha, projectile.rotation - 1.57f, new Vector2(tex.Width / 2, tex.Height), 1, 0, 0);
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor) => false;
    }
}