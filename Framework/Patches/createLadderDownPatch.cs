namespace MoreMineLadders.Framework.Patches
{
	
	public static class CreateLadderDownPatch
	{
		
		private static bool Prefix(int x, int y)
		{
			return Hx != x || Hy != y;
		}

		
		public static int Hx = -1;

		
		public static int Hy = -1;
	}
}
