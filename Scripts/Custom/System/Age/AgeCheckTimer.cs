// **********
// ServUO - AgeCheck.cs
// **********

using System;
using Server.Mobiles;
using Server.Network;

namespace Server.Custom.System.Age
{
	public class AgeCheckTimer : Timer
	{
		public AgeCheckTimer() : base(TimeSpan.FromHours(24), TimeSpan.FromHours(24))
		{
			this.Priority = TimerPriority.OneMinute;
		}

		public static void Initialize()
		{
			new AgeCheckTimer().Start();
		}

		protected override void OnTick()
		{
			CheckAge();
		}

		private void CheckAge()
		{
			var isGoingToDie = Utility.RandomBool();
			foreach (NetState state in NetState.Instances)
			{
				if (state.Mobile != null && state.Mobile.AccessLevel == AccessLevel.Player && state.Mobile.Alive && isGoingToDie &&
				    AgeUtils.IsLifeLimit(state.Mobile as PlayerMobile))
				{
					PlayerMobile playerMobile = state.Mobile as PlayerMobile;
					playerMobile.SendMessage(38, "Chegou sua hora...");
					playerMobile.SendMessage(38, AgeUtils.GenerateDeath());
					playerMobile.Kill();
				}
				else if (state.Mobile != null && state.Mobile.AccessLevel == AccessLevel.Player && state.Mobile.Alive &&
				         AgeUtils.AgeInMonths(state.Mobile.CreationTime) >= 5)
				{
					PlayerMobile playerMobile = state.Mobile as PlayerMobile;
					playerMobile.SendMessage(38, "Você sente que está chegando sua hora de partir deste mundo");
				}
			}
		}
	}
}