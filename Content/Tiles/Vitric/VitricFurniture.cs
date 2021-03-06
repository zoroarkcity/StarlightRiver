﻿using Microsoft.Xna.Framework;
using StarlightRiver.Core;
using static Terraria.ModLoader.ModContent;

namespace StarlightRiver.Content.Tiles.Vitric
{
    class VitricFurniture : FurnitureLoader
    {
        public VitricFurniture() : base("Vitric", AssetDirectory.VitricTile + "Decoration/", new Color(140, 97, 86), new Color(255, 220, 150), DustType<Dusts.Air>(), StarlightRiver.Instance.ItemType("AncientSandstoneItem")) { }
    }
}
