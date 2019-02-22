namespace MoreMineLadders.Framework
{
	
	public class MoreMineLaddersConfig
	{
		
		public bool Enabled { get; set; } = true;

		
		public bool AffectedByLuck { get; set; }

        
        public float DropLadderChance { get; set; } = 0.1f;
	}
}
