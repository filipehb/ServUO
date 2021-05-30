// **********
// ServUO - PlayerMobileRacial.cs
// **********

using Server.Custom.Race;

namespace Server.Mobiles
{
	public partial class PlayerMobile
	{
		private RacesCustom _RaceCustom;

		public RacesCustom RaceCustom
		{
			get => _RaceCustom;
			set => _RaceCustom = value;
		}
	}
}