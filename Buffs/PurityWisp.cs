using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace RothurMod.Buffs
{
	public class PurityWisp : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Mechanical eye");
			Description.SetDefault("The mechanical eye will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			ExamplePlayer modPlayer = player.GetModPlayer<ExamplePlayer>();
			if (player.ownedProjectileCounts[ProjectileType<Projectiles.Minions.PurityWisp>()] > 0) {
				modPlayer.purityMinion = true;
			}
			if (!modPlayer.purityMinion) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
		}
	}
}