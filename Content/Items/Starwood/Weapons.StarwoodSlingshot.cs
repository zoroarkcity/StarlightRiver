using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using StarlightRiver.Core;
using StarlightRiver.Projectiles.WeaponProjectiles;

namespace StarlightRiver.Content.Items.Starwood.Weapons
{
    public class StarwoodSlingshot : StarwoodItem
    {
        public StarwoodSlingshot() : base(ModContent.GetTexture("StarlightRiver/Assets/Items/Starwood/StarwoodSlingshot_Alt")) { }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Starwood Slingshot");
            Tooltip.SetDefault("Shoots fallen stars \n5% chance to consume ammo");
        }

        public override void SetDefaults()
        {
            item.damage = 20;
            item.ranged = true;
            item.width = 18;
            item.height = 34;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = ItemUseStyleID.HoldingOut; ;
            item.knockBack = 4f;
            item.UseSound = SoundID.Item19;
            item.shoot = ModContent.ProjectileType<StarwoodSlingshotProjectile>();
            item.shootSpeed = 16f;
            item.noMelee = true;
            item.useAmmo = ItemID.FallenStar;
        }

        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= .95f;
        }
    }
}