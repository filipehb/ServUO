// **********
// ServUO - SCraftGump.cs
// **********

using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Gumps
{
	public class SCraftGump : Gump
	{
		private Mobile m;

		public SCraftGump()
			: base( 0, 0 )
		{
			Closable=false;
			Disposable=false;
			Dragable=false;
			Resizable=false;

			AddPage(0);

			AddBackground(143, 118, 496, 336, 9200);

            AddLabel(224, 146, 1280, @"Secondary Crafting Skill");
			AddLabel(229, 186, 0, @"Begging");
			AddLabel(229, 215, 0, @"Herding");
			AddLabel(229, 244, 0, @"Lumberjacking");
			AddLabel(229, 273, 0, @"Mining");
			AddLabel(377, 189, 0, @"Fishing");
			AddLabel(378, 216, 0, @"Camping");
            AddLabel(378, 243, 0, @"Cooking");

            AddButton(203, 215, 209, 208, 1, GumpButtonType.Reply, 0); //Herding
            AddButton(203, 186, 209, 208, 2, GumpButtonType.Reply, 0); //Begging
            AddButton(351, 216, 209, 208, 3, GumpButtonType.Reply, 0); //Camping
            AddButton(203, 244, 209, 208, 4, GumpButtonType.Reply, 0); //Lumberjacking
            AddButton(351, 189, 209, 208, 5, GumpButtonType.Reply, 0); //Fishing
            AddButton(202, 273, 209, 208, 6, GumpButtonType.Reply, 0); //Mining
            AddButton(351, 243, 209, 208, 7, GumpButtonType.Reply, 0); //Cooking

			AddImage(319, 176, 1418);
			AddImage(604, 416, 205);
            AddImage(604, 127, 203);
            AddImage(138, 128, 202);
            AddImage(178, 107, 201);
            AddImage(179, 416, 233);
            AddImage(138, 416, 204);
            AddImage(138, 107, 206);
            AddImage(605, 107, 207);

		}

        public override void OnResponse(NetState state, RelayInfo info)
        {
            Mobile m = state.Mobile;

            PlayerMobile pm = m as PlayerMobile;
            if (pm == null)
                return;

            switch (info.ButtonID)
            {
                case 1: //Herding
                    {
                        //Edit Starting Equiptment here
                        m.AddToBackpack(new ShepherdsCrook());

                        //Edit Skill Caps
                        m.Skills.Herding.Cap = 100;
                        m.Skills.Begging.Cap = 0;
                        m.Skills.Camping.Cap = 0;
                        m.Skills.Cooking.Cap = 0;
                        m.Skills.Fishing.Cap = 0;
                        m.Skills.Lumberjacking.Cap = 0;
                        m.Skills.Mining.Cap = 0;

                        //Edit Skill Values
                        m.Skills.Herding.Base = 20;
                        m.Skills.Begging.Base = 0;
                        m.Skills.Camping.Base = 0;
                        m.Skills.Cooking.Base = 0;
                        m.Skills.Fishing.Base = 0;
                        m.Skills.Lumberjacking.Base = 0;
                        m.Skills.Mining.Base = 0;

                        //Edit Teleport Location here
                        m.Location = new Point3D(896, 575, 0);
                        m.Frozen = false;
                        break;
                    }
                case 2: //Begging
                    {
                        //Edit Starting Equiptment here
                        //m.AddToBackpack(new ());

                        //Edit Skill Caps
                        m.Skills.Herding.Cap = 0;
                        m.Skills.Begging.Cap = 100;
                        m.Skills.Camping.Cap = 0;
                        m.Skills.Cooking.Cap = 0;
                        m.Skills.Fishing.Cap = 0;
                        m.Skills.Lumberjacking.Cap = 0;
                        m.Skills.Mining.Cap = 0;

                        //Edit Skill Values
                        m.Skills.Herding.Base = 0;
                        m.Skills.Begging.Base = 20;
                        m.Skills.Camping.Base = 0;
                        m.Skills.Cooking.Base = 0;
                        m.Skills.Fishing.Base = 0;
                        m.Skills.Lumberjacking.Base = 0;
                        m.Skills.Mining.Base = 0;

                        //Edit Teleport Location here
                        m.Location = new Point3D(896, 575, 0);
                        break;
                    }
                case 3: //Camping
                    {
                        //Edit Starting Equiptment here
                        m.AddToBackpack(new Bedroll());

                        //Edit Skill Caps
                        m.Skills.Herding.Cap = 0;
                        m.Skills.Begging.Cap = 0;
                        m.Skills.Camping.Cap = 1000;
                        m.Skills.Cooking.Cap = 0;
                        m.Skills.Fishing.Cap = 0;
                        m.Skills.Lumberjacking.Cap = 0;
                        m.Skills.Mining.Cap = 0;

                        //Edit Skill Values
                        m.Skills.Herding.Base = 0;
                        m.Skills.Begging.Base = 0;
                        m.Skills.Camping.Base = 20;
                        m.Skills.Cooking.Base = 0;
                        m.Skills.Fishing.Base = 0;
                        m.Skills.Lumberjacking.Base = 0;
                        m.Skills.Mining.Base = 0;

                        //Edit Teleport Location here
                        m.Location = new Point3D(896, 575, 0);
                        m.Frozen = false;
                        break;
                    }
                case 4: //Lumberjacking
                    {
                        //Edit Starting Equiptment here
                        m.AddToBackpack(new Hatchet());

                        //Edit Skill Caps
                        m.Skills.Herding.Cap = 0;
                        m.Skills.Begging.Cap = 0;
                        m.Skills.Camping.Cap = 0;
                        m.Skills.Cooking.Cap = 0;
                        m.Skills.Fishing.Cap = 0;
                        m.Skills.Lumberjacking.Cap = 100;
                        m.Skills.Mining.Cap = 0;

                        //Edit Skill Values
                        m.Skills.Herding.Base = 0;
                        m.Skills.Begging.Base = 0;
                        m.Skills.Camping.Base = 0;
                        m.Skills.Cooking.Base = 0;
                        m.Skills.Fishing.Base = 0;
                        m.Skills.Lumberjacking.Base = 20;
                        m.Skills.Mining.Base = 0;

                        //Edit Teleport Location here
                        m.Location = new Point3D(896, 575, 0);
                        m.Frozen = false;
                        break;
                    }
                case 5: //Fishing
                    {
                        //Edit Starting Equiptment here
                        m.AddToBackpack(new FishingPole());

                        //Edit Skill Caps
                        m.Skills.Herding.Cap = 0;
                        m.Skills.Begging.Cap = 0;
                        m.Skills.Camping.Cap = 0;
                        m.Skills.Cooking.Cap = 0;
                        m.Skills.Fishing.Cap = 100;
                        m.Skills.Lumberjacking.Cap = 0;
                        m.Skills.Mining.Cap = 0;

                        //Edit Skill Values
                        m.Skills.Herding.Base = 0;
                        m.Skills.Begging.Base = 0;
                        m.Skills.Camping.Base = 0;
                        m.Skills.Cooking.Base = 0;
                        m.Skills.Fishing.Base = 20;
                        m.Skills.Lumberjacking.Base = 0;
                        m.Skills.Mining.Base = 0;

                        //Edit Teleport Location here
                        m.Location = new Point3D(896, 575, 0);
                        m.Frozen = false;
                        break;
                    }
                case 6: //Mining
                    {
                        //Edit Starting Equiptment here
                        m.AddToBackpack(new Pickaxe());

                        //Edit Skill Caps
                        m.Skills.Herding.Cap = 0;
                        m.Skills.Begging.Cap = 0;
                        m.Skills.Camping.Cap = 0;
                        m.Skills.Cooking.Cap = 0;
                        m.Skills.Fishing.Cap = 0;
                        m.Skills.Lumberjacking.Cap = 0;
                        m.Skills.Mining.Cap = 100;

                        //Edit Skill Values
                        m.Skills.Herding.Base = 0;
                        m.Skills.Begging.Base = 0;
                        m.Skills.Camping.Base = 0;
                        m.Skills.Cooking.Base = 0;
                        m.Skills.Fishing.Base = 0;
                        m.Skills.Lumberjacking.Base = 0;
                        m.Skills.Mining.Base = 20;

                        //Edit Teleport Location here
                        m.Location = new Point3D(896, 575, 0);
                        m.Frozen = false;
                        break;
                    }
                case 7: //Cooking
                    {
                        //Edit Starting Equiptment here
                        m.AddToBackpack(new RollingPin());

                        //Edit Skill Caps
                        m.Skills.Herding.Cap = 0;
                        m.Skills.Begging.Cap = 0;
                        m.Skills.Camping.Cap = 0;
                        m.Skills.Cooking.Cap = 100;
                        m.Skills.Fishing.Cap = 0;
                        m.Skills.Lumberjacking.Cap = 0;
                        m.Skills.Mining.Cap = 0;

                        //Edit Skill Values
                        m.Skills.Herding.Base = 0;
                        m.Skills.Begging.Base = 0;
                        m.Skills.Camping.Base = 0;
                        m.Skills.Cooking.Base = 20;
                        m.Skills.Fishing.Base = 0;
                        m.Skills.Lumberjacking.Base = 0;
                        m.Skills.Mining.Base = 0;

                        //Edit Teleport Location here
                        m.Location = new Point3D(896, 575, 0);
                        m.Frozen = false;
                        break;
                    }
                
            }
        }
	}
}