// **********
// ServUO - PlayerMobileRacial.cs
// **********

using Server.Custom.Race;

namespace Server.Mobiles
{
	public partial class PlayerMobile
	{
		private double age;

		public double Age
		{
			get => age;
			set => age = value;
		}
	}
}