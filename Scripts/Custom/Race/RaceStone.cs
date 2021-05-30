using System;
using Server.Items;
using Server.Gumps;

namespace Server.Items
{
	public class RaceStone : Item
	{
		public override string DefaultName
		{
			get { return "Pedra de seleção"; }
		}

		[Constructable]
		public RaceStone() : base( 0xED4 )
		{
			Movable = false;
			Hue = 0x2D1;
		}

		public override void OnDoubleClick( Mobile from )
		{
			from.Frozen = true;
			from.SendGump(new RaceGump(from));
		}

		public RaceStone( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}