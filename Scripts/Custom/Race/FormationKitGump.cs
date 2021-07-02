// **********
// ServUO - SubRaceGump.cs
// **********

using Server.Custom.Race;
using Server.Mobiles;
using Server.Network;

namespace Server.Gumps
{
	public class FormationKitGump : Gump
	{
		private readonly PlayerMobile _M;
		private readonly RacesCustom _RaceCustom;

		public FormationKitGump(PlayerMobile m, RacesCustom raceCustom)
			: base(0, 0)
		{
			_M = m;
			_RaceCustom = raceCustom;

			Closable = false;
			Disposable = false;
			Dragable = false;
			Resizable = false;

			AddPage(0);

			AddBackground(143, 117, 496, 336, 9200);

			switch (_RaceCustom)
			{
				case RacesCustom.Anao:
					{
						AddLabel(263, 154, 1280, @"Selecao de kits de formacao");
						AddLabel(248, 193, 0, @"Anao da colonia de Balin");
						AddLabel(251, 240, 0, @"Anao das Montanhas Azuis");
						AddLabel(251, 281, 0, @"Anao de Erebor");
						AddLabel(251, 365, 0, @"Anao das Colinas de Ferro");
						AddLabel(252, 322, 0, @"Anao Errante");
					}
					break;
				case RacesCustom.Hobbit:
					{
						AddLabel(263, 154, 1280, @"Selecao de kits de formacao");
						AddLabel(248, 193, 0, @"Bolseiro (Cascalva)");
						AddLabel(251, 240, 0, @"Bolger (Cascalva)");
						AddLabel(251, 281, 0, @"Bradebuque (Cascalva)");
						AddLabel(251, 365, 0, @"Cotton (Pe-Peludo)");
						AddLabel(252, 322, 0, @"Proudfoot (Pe-Peludo)");
						AddLabel(252, 322, 0, @"Tuk (Cascalva)");

						AddButton(225, 240, 209, 208, (int)RacesCustom.Humano, GumpButtonType.Reply, 0);
						AddButton(225, 281, 209, 208, (int)RacesCustom.Elfo, GumpButtonType.Reply, 0);
						AddButton(225, 194, 209, 208, (int)RacesCustom.Anao, GumpButtonType.Reply, 0);
						AddButton(226, 322, 209, 208, (int)RacesCustom.Hobbit, GumpButtonType.Reply, 0);
						AddButton(225, 364, 209, 208, (int)RacesCustom.Orc, GumpButtonType.Reply, 0);

						AddImage(604, 127, 203);
						AddImage(138, 128, 202);
						AddImage(178, 107, 201);
						AddImage(179, 416, 233);
						AddImage(138, 416, 204);
						AddImage(138, 107, 206);
						AddImage(605, 107, 207);
						AddImage(316, 177, 1418);
						AddImage(604, 416, 205);
					}
					break;
				case RacesCustom.Humano:
					{
						AddLabel(263, 154, 1280, @"Selecao de kits de formacao");
						AddLabel(248, 193, 0, @"Beorning (Homem Medio)");
						AddLabel(251, 240, 0, @"Terra-Pardense (Homem Medio)");
						AddLabel(251, 281, 0, @"Tribo Oriental (Oriental)");
						AddLabel(251, 365, 0, @"Tribo Sulista (Sulista)");
						AddLabel(252, 322, 0, @"Homem de Bri (Homem Medio)");
						AddLabel(252, 322, 0, @"Homem de Vale (Homem Medio)");
						AddLabel(252, 322, 0, @"Homem de Gondor (Homem Medio)");
						AddLabel(252, 322, 0, @"Homem de Minas Tirith (Dunadan)");
						AddLabel(252, 322, 0, @"Cavaleiro de Rohan (Homem Medio)");
					}
					break;
				case RacesCustom.Elfo:
					{
						AddLabel(263, 154, 1280, @"Selecao de kits de formacao");
						AddLabel(248, 193, 0, @"Elfo dos Portos Cinzentos (Sinda)");
						AddLabel(251, 240, 0, @"Elfo de Lorien (Noldo)");
						AddLabel(251, 281, 0, @"Elfo de Lorien (Silvestre)");
						AddLabel(251, 365, 0, @"Elfo da Floresta das Trevas");
						AddLabel(252, 322, 0, @"Elfo da Floresta das Trevas (Silvestre)");
						AddLabel(252, 322, 0, @"Elfo de Valfenda (Noldo)");
						AddLabel(252, 322, 0, @"Elfo de Valfenda (Sinda)");
						AddLabel(252, 322, 0, @"Elfo dos Grupos Errantes (Noldo)");
					}
					break;
				case RacesCustom.Orc:
					{
					}
					break;
			}
		}

		public override void OnResponse(NetState state, RelayInfo info)
		{
			Mobile m = state.Mobile;

			PlayerMobile pm = m as PlayerMobile;
			if (pm == null)
				return;

			switch (info.ButtonID)
			{
				//TODO Implementar todos os kits
				case 1:
					{
						m.Hue = 670;
						m.SendGump(new OrderGump(pm, RacesCustom.Humano));
						break;
					}
				case 2:
					{
						m.Hue = 2104;
						m.SendGump(new OrderGump(pm, RacesCustom.Elfo));
						break;
					}
				case 3:
					{
						m.SendGump(new OrderGump(pm, RacesCustom.Anao));
						break;
					}
				case 4:
					{
						m.Hue = 1816;
						m.SendGump(new OrderGump(pm, RacesCustom.Hobbit));
						break;
					}
				case 5:
					{
						m.Hue = 2009;
						m.SendGump(new OrderGump(pm, RacesCustom.Orc));
						break;
					}
				case 6:
					{
						m.Hue = 670;
						m.SendGump(new OrderGump(pm, RacesCustom.Humano));
						break;
					}
				case 7:
					{
						m.Hue = 2104;
						m.SendGump(new OrderGump(pm, RacesCustom.Elfo));
						break;
					}
				case 8:
					{
						m.SendGump(new OrderGump(pm, RacesCustom.Anao));
						break;
					}
				case 9:
					{
						m.Hue = 1816;
						m.SendGump(new OrderGump(pm, RacesCustom.Hobbit));
						break;
					}
				case 10:
					{
						m.Hue = 2009;
						m.SendGump(new OrderGump(pm, RacesCustom.Orc));
						break;
					}
			}
		}
	}
}