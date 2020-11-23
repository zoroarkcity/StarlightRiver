﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StarlightRiver.Core;
using StarlightRiver.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

using StarlightRiver.Core;

namespace StarlightRiver.Tiles.Vitric
{
    internal class AncientSandstone : ModTile
    {
        public override void SetDefaults()
        {
            minPick = int.MaxValue;
            QuickBlock.QuickSet(this, 200, DustID.Copper, SoundID.Tink, new Color(150, 105, 65), ItemType<AncientSandstoneItem>());
            Main.tileMerge[Type][TileType<AncientSandstoneTile>()] = true;
        }
    }

    public class AncientSandstoneItem : QuickTileItem { public AncientSandstoneItem() : base("Ancient Sandstone Brick", "", StarlightRiver.Instance.TileType("AncientSandstone"), 0) { } }


    internal class AncientSandstoneTile : ModTile
    {
        public override void SetDefaults()
        {
            minPick = int.MaxValue;
            QuickBlock.QuickSet(this, 200, DustID.Copper, SoundID.Tink, new Color(160, 115, 75), ItemType<AncientSandstoneTileItem>());
            Main.tileMerge[Type][mod.TileType("AncientSandstone")] = true;
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];
            Color color = i % 2 == 0 ? Lighting.GetColor(i, j) * 1.5f : Lighting.GetColor(i, j) * 1.1f;

            spriteBatch.Draw(Main.tileTexture[mod.TileType("AncientSandstone")], (new Vector2(i, j) + Helper.TileAdj) * 16 - Main.screenPosition, new Rectangle(tile.frameX, tile.frameY, 16, 16), Lighting.GetColor(i, j));
            spriteBatch.Draw(Main.tileTexture[Type], (new Vector2(i, j) + Helper.TileAdj) * 16 - Main.screenPosition, new Rectangle(tile.frameX, tile.frameY, 16, 16), color);
        }
    }

    public class AncientSandstoneTileItem : QuickTileItem { public AncientSandstoneTileItem() : base("Ancient Sandstone Tiles", "", TileType<AncientSandstoneTile>(), 0) { } }

    internal class AncientSandstonePlatform : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolidTop[Type] = true;
            Main.tileBlockLight[Type] = false;
            minPick = 200;
            AddMapEntry(new Color(150, 105, 65));
        }

    }

    internal class AncientSandstonePlatformItem : QuickTileItem { public AncientSandstonePlatformItem() : base("Ancient Sandstone Platform", "", TileType<AncientSandstonePlatform>(), 0) { } }

    internal class AncientSandstoneWall : ModWall
    {
        public override void SetDefaults() => QuickBlock.QuickSetWall(this, DustID.Copper, SoundID.Dig, ItemType<AncientSandstoneWallItem>(), false, new Color(71, 46, 41));
    }

    internal class AncientSandstoneWallItem : QuickWallItem
    {
        public AncientSandstoneWallItem() : base("Ancient Sandstone Wall", "", WallType<AncientSandstoneWall>(), 0) { }
    }

    internal class AncientSandstonePillarWall : ModWall
    {
        public override void SetDefaults() => QuickBlock.QuickSetWall(this, DustID.Copper, SoundID.Dig, ItemType<AncientSandstonePillarWallItem>(), false, new Color(75, 48, 44));
    }

    internal class AncientSandstonePillarWallItem : QuickWallItem
    {
        public AncientSandstonePillarWallItem() : base("Ancient Sandstone Wall", "", WallType<AncientSandstonePillarWall>(), 0) { }
    }
}