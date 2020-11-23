﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

using StarlightRiver.Core;

namespace StarlightRiver.Tiles.Purified
{
    internal class StonePure : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileStone[Type] = true;
            dustType = mod.DustType("Purify");
            drop = TileID.Stone;
            AddMapEntry(new Color(208, 201, 199));
        }
    }

    internal class GrassPure : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            TileID.Sets.Grass[Type] = true;
            SetModTree(new TreePure());
            dustType = mod.DustType("Purify");
            drop = ItemID.DirtBlock;
            AddMapEntry(new Color(208, 201, 199));
        }
    }
    internal class SandPure : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileSand[Type] = true;
            dustType = mod.DustType("Purify");
            AddMapEntry(new Color(208, 201, 199));
        }
    }
}
