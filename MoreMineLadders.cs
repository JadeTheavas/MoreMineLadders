using Harmony;
using StardewModdingAPI;
using StardewValley;
using StardewValley.Locations;
using MoreMineLadders.Framework;
using MoreMineLadders.Framework.Patches;

namespace MoreMineLadders
{
	
	public class MoreMineLadders : Mod
	{
	    public static MoreMineLadders Instance;


	    public HarmonyInstance Harmony;


	    public MoreMineLaddersConfig Config;


        public override void Entry(IModHelper mod)
		{
			Instance = this;
			InitConfig();

            //Harmony
			Harmony = HarmonyInstance.Create("JadeTheavas.StardewValley.MoreMineLadders");
			Harmony.Patch(AccessTools.Method(typeof(MineShaft), "createLadderDown"), new HarmonyMethod(typeof(CreateLadderDownPatch), "Prefix"), null);
			Harmony.Patch(AccessTools.Method(typeof(MineShaft), "checkStoneForItems"), new HarmonyMethod(typeof(CheckStoneForItemsPatch), "Prefix"), new HarmonyMethod(typeof(CheckStoneForItemsPatch), "Postfix"));
            
            //Add commands
            mod.ConsoleCommands.Add("makeladder", "Creates a ladder at the player's position.",MakeLadder);
			mod.ConsoleCommands.Add("mml_reloadconfig", "Reloads your MoreMineLadders settings from config.", ReloadConfig);
		}

		
		private void InitConfig()
		{
			Config = Helper.ReadConfig<MoreMineLaddersConfig>();
		}

		//Commands
		private void MakeLadder(string cmd, string[] args)
		{
			if (!Game1.inMine)
			{
				Monitor.Log("You need to be inside the mine to use this command.", LogLevel.Trace);
				return;
			}
			Game1.mine.createLadderDown(Game1.player.getTileX(), Game1.player.getTileY());
			Monitor.Log($"Created a ladder at the player's position: {Game1.player.getTileLocation()}", LogLevel.Trace);
		}

	    private void ReloadConfig(string cmd, string[] args)
	    {
	        InitConfig();
            Monitor.Log("The config was reloaded.");
	    }
	}
}
