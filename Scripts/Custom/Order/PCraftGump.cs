// **********
// ServUO - PCraftGump.cs
// **********

using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Gumps
{
	public class PCraftGump : Gump
	{
		private Mobile m;

        public PCraftGump()
            : base(0, 0)
        {
            Closable = false;
            Disposable = false;
            Dragable = false;
            Resizable = false;

            AddPage(0);

            AddBackground(143, 118, 496, 336, 9200);

            AddLabel(231, 146, 1280, @"Primary Crafting Skill");
            AddLabel(229, 186, 0, @"Alchemy");
            AddLabel(229, 215, 0, @"Blacksmith");
            AddLabel(229, 244, 0, @"Carpentry");
            AddLabel(370, 189, 0, @"Fletching");
            AddLabel(229, 273, 0, @"Cartography");
            AddLabel(370, 217, 0, @"Inscribe");
            AddLabel(370, 244, 0, @"Tailoring");
            AddLabel(370, 271, 0, @"Tinkering");

            AddButton(203, 215, 209, 208, 1, GumpButtonType.Reply, 0); //Blacksmith
            AddButton(203, 186, 209, 208, 2, GumpButtonType.Reply, 0); //Alchemy
            AddButton(343, 244, 209, 208, 3, GumpButtonType.Reply, 0); //Tailoring
            AddButton(203, 244, 209, 208, 4, GumpButtonType.Reply, 0); //Carpentry
            AddButton(343, 189, 209, 208, 5, GumpButtonType.Reply, 0); //Fletching
            AddButton(343, 217, 209, 208, 6, GumpButtonType.Reply, 0); //Inscribe
            AddButton(202, 273, 209, 208, 7, GumpButtonType.Reply, 0); //Cartography
            AddButton(343, 271, 209, 208, 8, GumpButtonType.Reply, 0); //Tinkering

            AddImage(604, 127, 203);
            AddImage(138, 128, 202);
            AddImage(178, 107, 201);
            AddImage(179, 416, 233);
            AddImage(138, 416, 204);
            AddImage(138, 107, 206);
            AddImage(605, 107, 207);
            AddImage(314, 173, 1418);
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
                case 1: //Blacksmith
                    {

                        //Edit Starting Equiptment
                        m.AddToBackpack(new SmithHammer());

                        //Edit Skill Caps
                        m.Skills.Alchemy.Cap = 0;
                        m.Skills.Blacksmith.Cap = 100;
                        m.Skills.Carpentry.Cap = 0;
                        m.Skills.Cartography.Cap = 0;
                        m.Skills.Fletching.Cap = 0;
                        m.Skills.Inscribe.Cap = 0;
                        m.Skills.Tailoring.Cap = 0;
                        m.Skills.Tinkering.Cap = 0;

                        //Edit Skill Values 
                        m.Skills.Alchemy.Base = 0;
                        m.Skills.Blacksmith.Base = 20;
                        m.Skills.Carpentry.Base = 0;
                        m.Skills.Cartography.Base = 0;
                        m.Skills.Fletching.Base = 0;
                        m.Skills.Inscribe.Base = 0;
                        m.Skills.Tailoring.Base = 0;
                        m.Skills.Tinkering.Base = 0;

                        m.SendGump(new SCraftGump());
                        break;
                    }
                case 2: //Alchemy
                    {

                        //Edit Starting Equiptment
                        m.AddToBackpack(new MortarPestle());

                        //Edit Skill Caps
                        m.Skills.Alchemy.Cap = 100;
                        m.Skills.Blacksmith.Cap = 0;
                        m.Skills.Carpentry.Cap = 0;
                        m.Skills.Cartography.Cap = 0;
                        m.Skills.Fletching.Cap = 0;
                        m.Skills.Inscribe.Cap = 0;
                        m.Skills.Tailoring.Cap = 0;
                        m.Skills.Tinkering.Cap = 0;

                        //Edit Skill Values 
                        m.Skills.Alchemy.Base = 20;
                        m.Skills.Blacksmith.Base = 0;
                        m.Skills.Carpentry.Base = 0;
                        m.Skills.Cartography.Base = 0;
                        m.Skills.Fletching.Base = 0;
                        m.Skills.Inscribe.Base = 0;
                        m.Skills.Tailoring.Base = 0;
                        m.Skills.Tinkering.Base = 0;

                        m.SendGump(new SCraftGump());
                        break;
                    }
                case 3: //Tailoring
                    {

                        //Edit Starting Equiptment
                        m.AddToBackpack(new SewingKit());

                        //Edit Skill Caps
                        m.Skills.Alchemy.Cap = 0;
                        m.Skills.Blacksmith.Cap = 0;
                        m.Skills.Carpentry.Cap = 0;
                        m.Skills.Cartography.Cap = 0;
                        m.Skills.Fletching.Cap = 0;
                        m.Skills.Inscribe.Cap = 0;
                        m.Skills.Tailoring.Cap = 100;
                        m.Skills.Tinkering.Cap = 0;

                        //Edit Skill Values 
                        m.Skills.Alchemy.Base = 0;
                        m.Skills.Blacksmith.Base = 0;
                        m.Skills.Carpentry.Base = 0;
                        m.Skills.Cartography.Base = 0;
                        m.Skills.Fletching.Base = 0;
                        m.Skills.Inscribe.Base = 0;
                        m.Skills.Tailoring.Base = 20;
                        m.Skills.Tinkering.Base = 0;

                        m.SendGump(new SCraftGump());
                        break;
                    }
                case 4: //Carpentry
                    {

                        //Edit Starting Equiptment
                        m.AddToBackpack(new Saw());

                        //Edit Skill Caps
                        m.Skills.Alchemy.Cap = 0;
                        m.Skills.Blacksmith.Cap = 0;
                        m.Skills.Carpentry.Cap = 100;
                        m.Skills.Cartography.Cap = 0;
                        m.Skills.Fletching.Cap = 0;
                        m.Skills.Inscribe.Cap = 0;
                        m.Skills.Tailoring.Cap = 0;
                        m.Skills.Tinkering.Cap = 0;

                        //Edit Skill Values 
                        m.Skills.Alchemy.Base = 0;
                        m.Skills.Blacksmith.Base = 0;
                        m.Skills.Carpentry.Base = 20;
                        m.Skills.Cartography.Base = 0;
                        m.Skills.Fletching.Base = 0;
                        m.Skills.Inscribe.Base = 0;
                        m.Skills.Tailoring.Base = 0;
                        m.Skills.Tinkering.Base = 0;

                        m.SendGump(new SCraftGump());
                        break;
                    }
                case 5: //Fletching
                    {

                        //Edit Starting Equiptment
                        m.AddToBackpack(new FletcherTools());

                        //Edit Skill Caps
                        m.Skills.Alchemy.Cap = 0;
                        m.Skills.Blacksmith.Cap = 0;
                        m.Skills.Carpentry.Cap = 0;
                        m.Skills.Cartography.Cap = 0;
                        m.Skills.Fletching.Cap = 100;
                        m.Skills.Inscribe.Cap = 0;
                        m.Skills.Tailoring.Cap = 0;
                        m.Skills.Tinkering.Cap = 0;

                        //Edit Skill Values 
                        m.Skills.Alchemy.Base = 0;
                        m.Skills.Blacksmith.Base = 0;
                        m.Skills.Carpentry.Base = 0;
                        m.Skills.Cartography.Base = 0;
                        m.Skills.Fletching.Base = 20;
                        m.Skills.Inscribe.Base = 0;
                        m.Skills.Tailoring.Base = 0;
                        m.Skills.Tinkering.Base = 0;

                        m.SendGump(new SCraftGump());
                        break;
                    }
                case 6: //Inscribe
                    {

                        //Edit Starting Equiptment
                        m.AddToBackpack(new ScribesPen());

                        //Edit Skill Caps
                        m.Skills.Alchemy.Cap = 0;
                        m.Skills.Blacksmith.Cap = 0;
                        m.Skills.Carpentry.Cap = 0;
                        m.Skills.Cartography.Cap = 0;
                        m.Skills.Fletching.Cap = 0;
                        m.Skills.Inscribe.Cap = 100;
                        m.Skills.Tailoring.Cap = 0;
                        m.Skills.Tinkering.Cap = 0;

                        //Edit Skill Values 
                        m.Skills.Alchemy.Base = 0;
                        m.Skills.Blacksmith.Base = 0;
                        m.Skills.Carpentry.Base = 0;
                        m.Skills.Cartography.Base = 0;
                        m.Skills.Fletching.Base = 0;
                        m.Skills.Inscribe.Base = 20;
                        m.Skills.Tailoring.Base = 0;
                        m.Skills.Tinkering.Base = 0;

                        m.SendGump(new SCraftGump());
                        break;
                    }
                case 7: //Cartography
                    {

                        //Edit Starting Equiptment
                        m.AddToBackpack(new MapmakersPen());

                        //Edit Skill Caps
                        m.Skills.Alchemy.Cap = 0;
                        m.Skills.Blacksmith.Cap = 0;
                        m.Skills.Carpentry.Cap = 0;
                        m.Skills.Cartography.Cap = 100;
                        m.Skills.Fletching.Cap = 0;
                        m.Skills.Inscribe.Cap = 0;
                        m.Skills.Tailoring.Cap = 0;
                        m.Skills.Tinkering.Cap = 0;

                        //Edit Skill Values 
                        m.Skills.Alchemy.Base = 0;
                        m.Skills.Blacksmith.Base = 0;
                        m.Skills.Carpentry.Base = 0;
                        m.Skills.Cartography.Base = 20;
                        m.Skills.Fletching.Base = 0;
                        m.Skills.Inscribe.Base = 0;
                        m.Skills.Tailoring.Base = 0;
                        m.Skills.Tinkering.Base = 0;

                        m.SendGump(new SCraftGump());
                        break;
                    }
                case 8: //Tinkering
                    {

                        //Edit Starting Equiptment
                        m.AddToBackpack(new TinkerTools());

                        //Edit Skill Caps
                        m.Skills.Alchemy.Cap = 0;
                        m.Skills.Blacksmith.Cap = 0;
                        m.Skills.Carpentry.Cap = 0;
                        m.Skills.Cartography.Cap = 0;
                        m.Skills.Fletching.Cap = 0;
                        m.Skills.Inscribe.Cap = 0;
                        m.Skills.Tailoring.Cap = 0;
                        m.Skills.Tinkering.Cap = 100;

                        //Edit Skill Values 
                        m.Skills.Alchemy.Base = 0;
                        m.Skills.Blacksmith.Base = 0;
                        m.Skills.Carpentry.Base = 0;
                        m.Skills.Cartography.Base = 0;
                        m.Skills.Fletching.Base = 0;
                        m.Skills.Inscribe.Base = 0;
                        m.Skills.Tailoring.Base = 0;
                        m.Skills.Tinkering.Base = 20;

                        m.SendGump(new SCraftGump());
                        break;
                    }
            }
        }
	}
}