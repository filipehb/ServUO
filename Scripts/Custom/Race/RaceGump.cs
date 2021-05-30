using System;
using Server;
using Server.Network;
using Server.Commands;
using Server.Items;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Server.Custom.Race;
using Server.Mobiles;

namespace Server.Gumps
{
    public class RaceGump : Gump
    {

        public RaceGump(Mobile m)
            : base(0, 0)
        {

            Closable = false;
            Disposable = false;
            Dragable = false;
            Resizable = false;

            AddPage(0);

            AddBackground(143, 117, 496, 336, 9200);

            AddLabel(263, 154, 1280, @"Seleção de raça");
            AddLabel(248, 193, 0, @"Humano");
            AddLabel(251, 240, 0, @"Elfo");
            AddLabel(251, 281, 0, @"Anão");
            AddLabel(251, 365, 0, @"Hobbit");
            //AddLabel(252, 322, 0, @"Orc"); Removido no momento

            AddButton(225, 240, 209, 208, (int) RacesCustom.Humano, GumpButtonType.Reply, 0);
            AddButton(225, 281, 209, 208, (int) RacesCustom.Elfo, GumpButtonType.Reply, 0);
            AddButton(225, 194, 209, 208, (int) RacesCustom.Anao, GumpButtonType.Reply, 0);
            AddButton(226, 322, 209, 208, (int) RacesCustom.Hobbit, GumpButtonType.Reply, 0);
            //AddButton(225, 364, 209, 208, (int) Races.Orc, GumpButtonType.Reply, 0);

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

        public override void OnResponse(NetState state, RelayInfo info) 
        {
            Mobile m = state.Mobile;
            
            PlayerMobile pm = m as PlayerMobile;
            if (pm == null)
                return;

            switch (info.ButtonID)
            {
                case (int) RacesCustom.Humano:
                {
                    m.Hue = 670;
                    m.SendGump(new FormationKitGump(pm, RacesCustom.Humano));
                    break;
                }
                case (int) RacesCustom.Elfo:
                {
                    m.Hue = 2104;
                    m.SendGump(new FormationKitGump(pm, RacesCustom.Elfo));
                    break;
                }
                case (int) RacesCustom.Anao:
                {
                    m.SendGump(new FormationKitGump(pm, RacesCustom.Anao));
                    break;
                }
                case (int) RacesCustom.Hobbit:
                {
                    m.Hue = 1816;
                    m.SendGump(new FormationKitGump(pm, RacesCustom.Hobbit));
                    break;
                }
                case (int) RacesCustom.Orc:
                {
                    m.Hue = 2009;
                    m.SendGump(new FormationKitGump(pm, RacesCustom.Orc));
                    break;
                }
            }
        }
    }
}