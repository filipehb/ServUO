// **********
// ServUO - PlayerMobileOrder.cs
// **********

using Server.Custom.Order;
using Server.Gumps;

namespace Server.Mobiles
{
	public partial class PlayerMobile
	{
		private Orders _Order;

		public Orders Order
		{
			get => _Order;
			set => _Order = value;
		}
	}
}