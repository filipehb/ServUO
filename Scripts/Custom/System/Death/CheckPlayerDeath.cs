// **********
// ServUO - CheckPlayerDeath.cs
// **********

using Server.Mobiles;
using NotImplementedException = System.NotImplementedException;

namespace Server.Custom.System.Death
{
	public class CheckPlayerDeath
	{
		public static void Initialize()
		{
			EventSink.PlayerDeath += OnDeath;
		}

		private static void OnDeath(PlayerDeathEventArgs e)
		{
			Mobile from = e.Mobile;
			PlayerMobile playerMobile = from as PlayerMobile;
			if (playerMobile != null && playerMobile.AccessLevel == AccessLevel.Player)
			{
				playerMobile.Frozen = true; //Deixa o player parado
				var playerMobileLocation = playerMobile.Location; //Salva a localização dele, antes de mover
				playerMobile.MoveToWorld(new Point3D(), Map.Felucca); //Move ele para algum outra região
				playerMobile.MoveToWorld(playerMobileLocation, Map.Felucca);
				playerMobile.Resurrect();
				playerMobile.Frozen = false;
			}
		}
	}
}