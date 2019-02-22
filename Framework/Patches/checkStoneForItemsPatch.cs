using System;
using Netcode;
using StardewValley;
using StardewValley.Locations;

namespace MoreMineLadders.Framework.Patches
{
	
	public static class CheckStoneForItemsPatch
	{
		
		private static void Prefix(int x, int y)
		{
			if (!MoreMineLadders.Instance.Config.Enabled)
			{
				return;
			}
			CreateLadderDownPatch.Hx = x;
			CreateLadderDownPatch.Hy = y;
		}

		
		private static void Postfix(MineShaft __instance, int x, int y, bool ___ladderHasSpawned, NetIntDelta ___netStonesLeftOnThisLevel)
		{
			CreateLadderDownPatch.Hx = -1;
			CreateLadderDownPatch.Hy = -1;
			if (__instance == null || !MoreMineLadders.Instance.Config.Enabled || ___ladderHasSpawned)
			{
				return;
			}
			MoreMineLaddersConfig config = MoreMineLadders.Instance.Config;
			if (___netStonesLeftOnThisLevel.Value == 0)
			{
				__instance.createLadderDown(x, y, false);
				return;
			}
			Random random = new Random(x * 1000 + y + __instance.mineLevel + (int)Game1.uniqueIDForThisGame / 2);
			random.NextDouble();
			double num = config.AffectedByLuck ? ((double)config.DropLadderChance + (double)Game1.player.LuckLevel / 100.0 + Game1.dailyLuck / 3.5) : ((double)config.DropLadderChance);
			if (random.NextDouble() < num)
			{
				__instance.createLadderDown(x, y, false);
			}
		}
	}
}
