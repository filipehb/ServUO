using System;
using Server;
using Server.Network;
using Server.Commands;
using Server.Items;
using Server.Mobiles;
using Server.Gumps;
using Server.Spells;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Server.Custom.Order;
using Server.Custom.Race;

namespace Server.Gumps
{
	public class OrderGump : Gump
	{
		private readonly RacesCustom _RaceCustom;
		private Mobile m;

		public OrderGump(PlayerMobile playerMobile, RacesCustom raceCustom)
			: base(0, 0)
		{
			_RaceCustom = raceCustom;

			Closable = false;
			Disposable = false;
			Dragable = false;
			Resizable = false;
			//TODO Implementar todas ordens
			AddPage(0);

			AddBackground(143, 118, 496, 336, 9200);

			AddLabel(229, 186, 0, @"Guerreiro");
			AddLabel(229, 215, 0, @"Gatuno");
			AddLabel(229, 244, 0, @"Mágico");
			AddLabel(229, 302, 0, @"Nobre");
			AddLabel(229, 273, 0, @"Artifice");
			AddLabel(229, 330, 0, @"Mestre da Sabedoria");
			AddLabel(229, 357, 0, @"Menestrel");
			AddLabel(253, 144, 1280, @"Escolha sua ordem");
			AddLabel(229, 384, 0, @"Barbaro");
			AddLabel(365, 187, 0, @"Navegante");

			AddButton(202, 215, 209, 208, (int)Orders.Guerreiro, GumpButtonType.Reply, 0);
			AddButton(202, 186, 209, 208, (int)Orders.Gatuno, GumpButtonType.Reply, 0);
			AddButton(202, 357, 209, 208, (int)Orders.Magico, GumpButtonType.Reply, 0);
			AddButton(202, 244, 209, 208, (int)Orders.Nobre, GumpButtonType.Reply, 0);
			AddButton(202, 302, 209, 208, (int)Orders.Artifice, GumpButtonType.Reply, 0);
			AddButton(202, 330, 209, 208, (int)Orders.MestreSabedoria, GumpButtonType.Reply, 0);
			AddButton(202, 273, 209, 208, (int)Orders.Menestrel, GumpButtonType.Reply, 0);
			AddButton(202, 384, 209, 208, (int)Orders.Barbaros, GumpButtonType.Reply, 0);
			AddButton(337, 187, 209, 208, (int)Orders.Navegante, GumpButtonType.Reply, 0);

			AddImage(604, 127, 203);
			AddImage(138, 128, 202);
			AddImage(178, 107, 201);
			AddImage(179, 416, 233);
			AddImage(138, 416, 204);
			AddImage(138, 107, 206);
			AddImage(605, 107, 207);
			AddImage(310, 175, 1418);
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
				case (int) Orders.Guerreiro: //Blackguard
					{
						//Edit Skill/Stat TOTAL cap here
						m.SkillsCap = 1200;
						m.StatCap = 375;

						//Edit Base Stats values here
						m.Str = 50;
						m.Dex = 10;
						m.Int = 20;

						//Edit Class Title here.  This is the title next to the players name above their head
						m.Title = ", the Blackguard";

						//Edit Starting Equiptment here
						m.AddToBackpack(new Broadsword());
						m.AddToBackpack(new Buckler());

						//Edit Skill Caps here
						m.Skills.Alchemy.Cap = 0;
						m.Skills.Anatomy.Cap = 100;
						m.Skills.AnimalLore.Cap = 0;
						m.Skills.AnimalTaming.Cap = 0;
						m.Skills.Archery.Cap = 0;
						m.Skills.ArmsLore.Cap = 0;
						m.Skills.Begging.Cap = 0;
						m.Skills.Blacksmith.Cap = 0;
						m.Skills.Bushido.Cap = 0;
						m.Skills.Camping.Cap = 0;
						m.Skills.Carpentry.Cap = 0;
						m.Skills.Cartography.Cap = 0;
						m.Skills.Chivalry.Cap = 0;
						m.Skills.Cooking.Cap = 0;
						m.Skills.DetectHidden.Cap = 0;
						m.Skills.Discordance.Cap = 0;
						m.Skills.EvalInt.Cap = 0;
						m.Skills.Fencing.Cap = 0;
						m.Skills.Fishing.Cap = 0;
						m.Skills.Fletching.Cap = 0;
						m.Skills.Focus.Cap = 100;
						m.Skills.Forensics.Cap = 0;
						m.Skills.Healing.Cap = 0;
						m.Skills.Herding.Cap = 0;
						m.Skills.Hiding.Cap = 0;
						m.Skills.Inscribe.Cap = 0;
						m.Skills.ItemID.Cap = 0;
						m.Skills.Lockpicking.Cap = 0;
						m.Skills.Lumberjacking.Cap = 0;
						m.Skills.Macing.Cap = 0;
						m.Skills.Magery.Cap = 0;
						m.Skills.MagicResist.Cap = 100;
						m.Skills.Meditation.Cap = 0;
						m.Skills.Mining.Cap = 0;
						m.Skills.Musicianship.Cap = 0;
						m.Skills.Necromancy.Cap = 120;
						m.Skills.Ninjitsu.Cap = 0;
						m.Skills.Parry.Cap = 100;
						m.Skills.Peacemaking.Cap = 0;
						m.Skills.Poisoning.Cap = 0;
						m.Skills.Provocation.Cap = 0;
						m.Skills.RemoveTrap.Cap = 0;
						m.Skills.Snooping.Cap = 0;
						m.Skills.Spellweaving.Cap = 0;
						m.Skills.SpiritSpeak.Cap = 0;
						m.Skills.Stealing.Cap = 0;
						m.Skills.Stealth.Cap = 0;
						m.Skills.Swords.Cap = 120;
						m.Skills.Tactics.Cap = 100;
						m.Skills.Tailoring.Cap = 0;
						m.Skills.TasteID.Cap = 0;
						m.Skills.Tinkering.Cap = 0;
						m.Skills.Tracking.Cap = 0;
						m.Skills.Veterinary.Cap = 0;
						m.Skills.Wrestling.Cap = 0;

						//Edit actual Skill Values here
						m.Skills.Alchemy.Base = 0;
						m.Skills.Anatomy.Base = 35;
						m.Skills.AnimalLore.Base = 0;
						m.Skills.AnimalTaming.Base = 0;
						m.Skills.Archery.Base = 0;
						m.Skills.ArmsLore.Base = 0;
						m.Skills.Begging.Base = 0;
						m.Skills.Blacksmith.Base = 0;
						m.Skills.Camping.Base = 0;
						m.Skills.Carpentry.Base = 0;
						m.Skills.Cartography.Base = 0;
						m.Skills.Cooking.Base = 0;
						m.Skills.DetectHidden.Base = 0;
						m.Skills.Discordance.Base = 0;
						m.Skills.EvalInt.Base = 0;
						m.Skills.Fishing.Base = 0;
						m.Skills.Fencing.Base = 0;
						m.Skills.Fletching.Base = 0;
						m.Skills.Focus.Base = 35;
						m.Skills.Forensics.Base = 0;
						m.Skills.Healing.Base = 0;
						m.Skills.Herding.Base = 0;
						m.Skills.Hiding.Base = 0;
						m.Skills.Inscribe.Base = 0;
						m.Skills.ItemID.Base = 0;
						m.Skills.Lockpicking.Base = 0;
						m.Skills.Lumberjacking.Base = 0;
						m.Skills.Macing.Base = 0;
						m.Skills.Magery.Base = 0;
						m.Skills.MagicResist.Base = 35;
						m.Skills.Meditation.Base = 0;
						m.Skills.Mining.Base = 0;
						m.Skills.Musicianship.Base = 0;
						m.Skills.Parry.Base = 35;
						m.Skills.Peacemaking.Base = 0;
						m.Skills.Poisoning.Base = 0;
						m.Skills.Provocation.Base = 0;
						m.Skills.RemoveTrap.Base = 0;
						m.Skills.Snooping.Base = 0;
						m.Skills.Spellweaving.Base = 0;
						m.Skills.SpiritSpeak.Base = 0;
						m.Skills.Stealing.Base = 0;
						m.Skills.Stealth.Base = 0;
						m.Skills.Swords.Base = 35;
						m.Skills.Tactics.Base = 35;
						m.Skills.Tailoring.Base = 0;
						m.Skills.TasteID.Base = 0;
						m.Skills.Tinkering.Base = 0;
						m.Skills.Tracking.Base = 0;
						m.Skills.Veterinary.Base = 0;
						m.Skills.Wrestling.Base = 0;
						m.Skills.Bushido.Base = 0;
						m.Skills.Ninjitsu.Base = 0;
						m.Skills.Chivalry.Base = 0;
						m.Skills.Necromancy.Base = 35;

						m.SendGump(new PCraftGump());
						break;
					}
				case (int) Orders.Gatuno: //Bard
					{
						//Edit Skill/Stat TOTAL cap here
						m.SkillsCap = 1200;
						m.StatCap = 225;

						//Edit Base Stats values here
						m.Str = 30;
						m.Dex = 20;
						m.Int = 30;

						//Edit Class Title here.  This is the title next to the players name above their head
						m.Title = ", the Bard";

						//Edit Starting Equiptment here
						m.AddToBackpack(new Kryss());
						m.AddToBackpack(new Buckler());
						m.AddToBackpack(new Lute());

						//Edit Skill Caps here
						m.Skills.Alchemy.Cap = 0;
						m.Skills.Anatomy.Cap = 0;
						m.Skills.AnimalLore.Cap = 0;
						m.Skills.AnimalTaming.Cap = 0;
						m.Skills.Archery.Cap = 0;
						m.Skills.ArmsLore.Cap = 0;
						m.Skills.Begging.Cap = 0;
						m.Skills.Blacksmith.Cap = 0;
						m.Skills.Bushido.Cap = 0;
						m.Skills.Camping.Cap = 0;
						m.Skills.Carpentry.Cap = 0;
						m.Skills.Cartography.Cap = 0;
						m.Skills.Chivalry.Cap = 0;
						m.Skills.Cooking.Cap = 0;
						m.Skills.DetectHidden.Cap = 0;
						m.Skills.Discordance.Cap = 100;
						m.Skills.EvalInt.Cap = 0;
						m.Skills.Fencing.Cap = 100;
						m.Skills.Fishing.Cap = 0;
						m.Skills.Fletching.Cap = 0;
						m.Skills.Focus.Cap = 0;
						m.Skills.Forensics.Cap = 0;
						m.Skills.Healing.Cap = 0;
						m.Skills.Herding.Cap = 0;
						m.Skills.Hiding.Cap = 0;
						m.Skills.Inscribe.Cap = 0;
						m.Skills.ItemID.Cap = 0;
						m.Skills.Lockpicking.Cap = 0;
						m.Skills.Lumberjacking.Cap = 0;
						m.Skills.Macing.Cap = 0;
						m.Skills.Magery.Cap = 0;
						m.Skills.MagicResist.Cap = 100;
						m.Skills.Meditation.Cap = 0;
						m.Skills.Mining.Cap = 0;
						m.Skills.Musicianship.Cap = 120;
						m.Skills.Necromancy.Cap = 0;
						m.Skills.Ninjitsu.Cap = 0;
						m.Skills.Parry.Cap = 0;
						m.Skills.Peacemaking.Cap = 100;
						m.Skills.Poisoning.Cap = 0;
						m.Skills.Provocation.Cap = 120;
						m.Skills.RemoveTrap.Cap = 0;
						m.Skills.Snooping.Cap = 0;
						m.Skills.Spellweaving.Cap = 0;
						m.Skills.SpiritSpeak.Cap = 0;
						m.Skills.Stealing.Cap = 0;
						m.Skills.Stealth.Cap = 0;
						m.Skills.Swords.Cap = 0;
						m.Skills.Tactics.Cap = 100;
						m.Skills.Tailoring.Cap = 0;
						m.Skills.TasteID.Cap = 0;
						m.Skills.Tinkering.Cap = 0;
						m.Skills.Tracking.Cap = 0;
						m.Skills.Veterinary.Cap = 0;
						m.Skills.Wrestling.Cap = 0;

						//Edit actual Skill Values here
						m.Skills.Alchemy.Base = 0;
						m.Skills.Anatomy.Base = 0;
						m.Skills.AnimalLore.Base = 0;
						m.Skills.AnimalTaming.Base = 0;
						m.Skills.Archery.Base = 0;
						m.Skills.ArmsLore.Base = 0;
						m.Skills.Begging.Base = 0;
						m.Skills.Blacksmith.Base = 0;
						m.Skills.Camping.Base = 0;
						m.Skills.Carpentry.Base = 0;
						m.Skills.Cartography.Base = 0;
						m.Skills.Cooking.Base = 0;
						m.Skills.DetectHidden.Base = 0;
						m.Skills.Discordance.Base = 35;
						m.Skills.EvalInt.Base = 0;
						m.Skills.Fishing.Base = 0;
						m.Skills.Fencing.Base = 35;
						m.Skills.Fletching.Base = 0;
						m.Skills.Focus.Base = 35;
						m.Skills.Forensics.Base = 0;
						m.Skills.Healing.Base = 0;
						m.Skills.Herding.Base = 0;
						m.Skills.Hiding.Base = 0;
						m.Skills.Inscribe.Base = 0;
						m.Skills.ItemID.Base = 0;
						m.Skills.Lockpicking.Base = 0;
						m.Skills.Lumberjacking.Base = 0;
						m.Skills.Macing.Base = 0;
						m.Skills.Magery.Base = 0;
						m.Skills.MagicResist.Base = 35;
						m.Skills.Meditation.Base = 0;
						m.Skills.Mining.Base = 0;
						m.Skills.Musicianship.Base = 35;
						m.Skills.Parry.Base = 0;
						m.Skills.Peacemaking.Base = 35;
						m.Skills.Poisoning.Base = 0;
						m.Skills.Provocation.Base = 35;
						m.Skills.RemoveTrap.Base = 0;
						m.Skills.Snooping.Base = 0;
						m.Skills.Spellweaving.Base = 0;
						m.Skills.SpiritSpeak.Base = 0;
						m.Skills.Stealing.Base = 0;
						m.Skills.Stealth.Base = 0;
						m.Skills.Swords.Base = 0;
						m.Skills.Tactics.Base = 35;
						m.Skills.Tailoring.Base = 0;
						m.Skills.TasteID.Base = 0;
						m.Skills.Tinkering.Base = 0;
						m.Skills.Tracking.Base = 0;
						m.Skills.Veterinary.Base = 0;
						m.Skills.Wrestling.Base = 0;
						m.Skills.Bushido.Base = 0;
						m.Skills.Ninjitsu.Base = 0;
						m.Skills.Chivalry.Base = 0;
						m.Skills.Necromancy.Base = 0;

						m.SendGump(new PCraftGump());
						break;
					}
				case (int) Orders.Magico: //Priest
					{
						//Edit Skill/Stat TOTAL cap here
						m.SkillsCap = 1200;
						m.StatCap = 375;

						//Edit Base Stats values here
						m.Str = 25;
						m.Dex = 10;
						m.Int = 45;

						//Edit Class Title here.  This is the title next to the players name above their head
						m.Title = ", the Priest";

						//Edit Starting Equiptment here
						m.AddToBackpack(new Mace());
						m.AddToBackpack(new Buckler());
						m.AddToBackpack(new Bandage(25));

						//Edit Skill Caps here
						m.Skills.Alchemy.Cap = 0;
						m.Skills.Anatomy.Cap = 100;
						m.Skills.AnimalLore.Cap = 0;
						m.Skills.AnimalTaming.Cap = 0;
						m.Skills.Archery.Cap = 0;
						m.Skills.ArmsLore.Cap = 0;
						m.Skills.Begging.Cap = 0;
						m.Skills.Blacksmith.Cap = 0;
						m.Skills.Bushido.Cap = 0;
						m.Skills.Camping.Cap = 0;
						m.Skills.Carpentry.Cap = 0;
						m.Skills.Cartography.Cap = 0;
						m.Skills.Chivalry.Cap = 0;
						m.Skills.Cooking.Cap = 0;
						m.Skills.DetectHidden.Cap = 0;
						m.Skills.Discordance.Cap = 0;
						m.Skills.EvalInt.Cap = 120;
						m.Skills.Fencing.Cap = 0;
						m.Skills.Fishing.Cap = 0;
						m.Skills.Fletching.Cap = 0;
						m.Skills.Focus.Cap = 100;
						m.Skills.Forensics.Cap = 0;
						m.Skills.Healing.Cap = 120;
						m.Skills.Herding.Cap = 0;
						m.Skills.Hiding.Cap = 0;
						m.Skills.Inscribe.Cap = 0;
						m.Skills.ItemID.Cap = 0;
						m.Skills.Lockpicking.Cap = 0;
						m.Skills.Lumberjacking.Cap = 0;
						m.Skills.Macing.Cap = 100;
						m.Skills.Magery.Cap = 0;
						m.Skills.MagicResist.Cap = 100;
						m.Skills.Meditation.Cap = 0;
						m.Skills.Mining.Cap = 0;
						m.Skills.Musicianship.Cap = 0;
						m.Skills.Necromancy.Cap = 0;
						m.Skills.Ninjitsu.Cap = 0;
						m.Skills.Parry.Cap = 0;
						m.Skills.Peacemaking.Cap = 0;
						m.Skills.Poisoning.Cap = 0;
						m.Skills.Provocation.Cap = 0;
						m.Skills.RemoveTrap.Cap = 0;
						m.Skills.Snooping.Cap = 0;
						m.Skills.Spellweaving.Cap = 0;
						m.Skills.SpiritSpeak.Cap = 100;
						m.Skills.Stealing.Cap = 0;
						m.Skills.Stealth.Cap = 0;
						m.Skills.Swords.Cap = 0;
						m.Skills.Tactics.Cap = 0;
						m.Skills.Tailoring.Cap = 0;
						m.Skills.TasteID.Cap = 0;
						m.Skills.Tinkering.Cap = 0;
						m.Skills.Tracking.Cap = 0;
						m.Skills.Veterinary.Cap = 0;
						m.Skills.Wrestling.Cap = 0;

						//Edit actual Skill Values here
						m.Skills.Alchemy.Base = 0;
						m.Skills.Anatomy.Base = 35;
						m.Skills.AnimalLore.Base = 0;
						m.Skills.AnimalTaming.Base = 0;
						m.Skills.Archery.Base = 0;
						m.Skills.ArmsLore.Base = 0;
						m.Skills.Begging.Base = 0;
						m.Skills.Blacksmith.Base = 0;
						m.Skills.Camping.Base = 0;
						m.Skills.Carpentry.Base = 0;
						m.Skills.Cartography.Base = 0;
						m.Skills.Cooking.Base = 0;
						m.Skills.DetectHidden.Base = 0;
						m.Skills.Discordance.Base = 0;
						m.Skills.EvalInt.Base = 35;
						m.Skills.Fishing.Base = 0;
						m.Skills.Fencing.Base = 0;
						m.Skills.Fletching.Base = 0;
						m.Skills.Focus.Base = 35;
						m.Skills.Forensics.Base = 0;
						m.Skills.Healing.Base = 35;
						m.Skills.Herding.Base = 0;
						m.Skills.Hiding.Base = 0;
						m.Skills.Inscribe.Base = 0;
						m.Skills.ItemID.Base = 0;
						m.Skills.Lockpicking.Base = 0;
						m.Skills.Lumberjacking.Base = 0;
						m.Skills.Macing.Base = 35;
						m.Skills.Magery.Base = 0;
						m.Skills.MagicResist.Base = 35;
						m.Skills.Meditation.Base = 0;
						m.Skills.Mining.Base = 0;
						m.Skills.Musicianship.Base = 0;
						m.Skills.Parry.Base = 0;
						m.Skills.Peacemaking.Base = 0;
						m.Skills.Poisoning.Base = 0;
						m.Skills.Provocation.Base = 0;
						m.Skills.RemoveTrap.Base = 0;
						m.Skills.Snooping.Base = 0;
						m.Skills.Spellweaving.Base = 0;
						m.Skills.SpiritSpeak.Base = 35;
						m.Skills.Stealing.Base = 0;
						m.Skills.Stealth.Base = 0;
						m.Skills.Swords.Base = 0;
						m.Skills.Tactics.Base = 0;
						m.Skills.Tailoring.Base = 0;
						m.Skills.TasteID.Base = 0;
						m.Skills.Tinkering.Base = 0;
						m.Skills.Tracking.Base = 0;
						m.Skills.Veterinary.Base = 0;
						m.Skills.Wrestling.Base = 0;
						m.Skills.Bushido.Base = 0;
						m.Skills.Ninjitsu.Base = 0;
						m.Skills.Chivalry.Base = 0;
						m.Skills.Necromancy.Base = 0;

						m.SendGump(new PCraftGump());
						break;
					}
				case (int) Orders.Nobre: //Druid
					{
						//Edit Skill/Stat TOTAL cap here
						m.SkillsCap = 1200;
						m.StatCap = 225;

						//Edit Base Stats values here
						m.Str = 30;
						m.Dex = 20;
						m.Int = 30;

						//Edit Class Title here.  This is the title next to the players name above their head
						m.Title = ", the Druid";

						//Edit Starting Equiptment here
						m.AddToBackpack(new QuarterStaff());
						m.AddToBackpack(new Bandage(25));

						//Edit Skill Caps here
						m.Skills.Alchemy.Cap = 0;
						m.Skills.Anatomy.Cap = 100;
						m.Skills.AnimalLore.Cap = 0;
						m.Skills.AnimalTaming.Cap = 0;
						m.Skills.Archery.Cap = 0;
						m.Skills.ArmsLore.Cap = 0;
						m.Skills.Begging.Cap = 0;
						m.Skills.Blacksmith.Cap = 0;
						m.Skills.Bushido.Cap = 0;
						m.Skills.Camping.Cap = 0;
						m.Skills.Carpentry.Cap = 0;
						m.Skills.Cartography.Cap = 0;
						m.Skills.Chivalry.Cap = 0;
						m.Skills.Cooking.Cap = 0;
						m.Skills.DetectHidden.Cap = 0;
						m.Skills.Discordance.Cap = 0;
						m.Skills.EvalInt.Cap = 0;
						m.Skills.Fencing.Cap = 0;
						m.Skills.Fishing.Cap = 0;
						m.Skills.Fletching.Cap = 0;
						m.Skills.Focus.Cap = 100;
						m.Skills.Forensics.Cap = 0;
						m.Skills.Healing.Cap = 120;
						m.Skills.Herding.Cap = 0;
						m.Skills.Hiding.Cap = 0;
						m.Skills.Inscribe.Cap = 0;
						m.Skills.ItemID.Cap = 0;
						m.Skills.Lockpicking.Cap = 0;
						m.Skills.Lumberjacking.Cap = 0;
						m.Skills.Macing.Cap = 100;
						m.Skills.Magery.Cap = 0;
						m.Skills.MagicResist.Cap = 100;
						m.Skills.Meditation.Cap = 0;
						m.Skills.Mining.Cap = 0;
						m.Skills.Musicianship.Cap = 0;
						m.Skills.Necromancy.Cap = 0;
						m.Skills.Ninjitsu.Cap = 0;
						m.Skills.Parry.Cap = 0;
						m.Skills.Peacemaking.Cap = 0;
						m.Skills.Poisoning.Cap = 0;
						m.Skills.Provocation.Cap = 0;
						m.Skills.RemoveTrap.Cap = 0;
						m.Skills.Snooping.Cap = 0;
						m.Skills.Spellweaving.Cap = 0;
						m.Skills.SpiritSpeak.Cap = 0;
						m.Skills.Stealing.Cap = 0;
						m.Skills.Stealth.Cap = 0;
						m.Skills.Swords.Cap = 0;
						m.Skills.Tactics.Cap = 100;
						m.Skills.Tailoring.Cap = 0;
						m.Skills.TasteID.Cap = 0;
						m.Skills.Tinkering.Cap = 0;
						m.Skills.Tracking.Cap = 0;
						m.Skills.Veterinary.Cap = 120;
						m.Skills.Wrestling.Cap = 0;

						//Edit actual Skill Values here
						m.Skills.Alchemy.Base = 0;
						m.Skills.Anatomy.Base = 35;
						m.Skills.AnimalLore.Base = 0;
						m.Skills.AnimalTaming.Base = 0;
						m.Skills.Archery.Base = 0;
						m.Skills.ArmsLore.Base = 0;
						m.Skills.Begging.Base = 0;
						m.Skills.Blacksmith.Base = 0;
						m.Skills.Camping.Base = 0;
						m.Skills.Carpentry.Base = 0;
						m.Skills.Cartography.Base = 0;
						m.Skills.Cooking.Base = 0;
						m.Skills.DetectHidden.Base = 0;
						m.Skills.Discordance.Base = 0;
						m.Skills.EvalInt.Base = 0;
						m.Skills.Fishing.Base = 0;
						m.Skills.Fencing.Base = 0;
						m.Skills.Fletching.Base = 0;
						m.Skills.Focus.Base = 35;
						m.Skills.Forensics.Base = 0;
						m.Skills.Healing.Base = 35;
						m.Skills.Herding.Base = 0;
						m.Skills.Hiding.Base = 0;
						m.Skills.Inscribe.Base = 0;
						m.Skills.ItemID.Base = 0;
						m.Skills.Lockpicking.Base = 0;
						m.Skills.Lumberjacking.Base = 0;
						m.Skills.Macing.Base = 35;
						m.Skills.Magery.Base = 0;
						m.Skills.MagicResist.Base = 35;
						m.Skills.Meditation.Base = 0;
						m.Skills.Mining.Base = 0;
						m.Skills.Musicianship.Base = 0;
						m.Skills.Parry.Base = 0;
						m.Skills.Peacemaking.Base = 0;
						m.Skills.Poisoning.Base = 0;
						m.Skills.Provocation.Base = 0;
						m.Skills.RemoveTrap.Base = 0;
						m.Skills.Snooping.Base = 0;
						m.Skills.Spellweaving.Base = 0;
						m.Skills.SpiritSpeak.Base = 0;
						m.Skills.Stealing.Base = 0;
						m.Skills.Stealth.Base = 0;
						m.Skills.Swords.Base = 0;
						m.Skills.Tactics.Base = 35;
						m.Skills.Tailoring.Base = 0;
						m.Skills.TasteID.Base = 0;
						m.Skills.Tinkering.Base = 0;
						m.Skills.Tracking.Base = 0;
						m.Skills.Veterinary.Base = 35;
						m.Skills.Wrestling.Base = 0;
						m.Skills.Bushido.Base = 0;
						m.Skills.Ninjitsu.Base = 0;
						m.Skills.Chivalry.Base = 0;
						m.Skills.Necromancy.Base = 0;

						m.SendGump(new PCraftGump());
						break;
					}
				case (int) Orders.Artifice: //Monk
					{
						//Edit Skill/Stat TOTAL cap here
						m.SkillsCap = 1200;
						m.StatCap = 225;

						//Edit Base Stats values here
						m.Str = 20;
						m.Dex = 50;
						m.Int = 10;

						//Edit Class Title here.  This is the title next to the players name above their head
						m.Title = ", the Monk";

						//Edit Starting Equiptment here
						m.AddToBackpack(new Bandage(25));

						//Edit Skill Caps here
						m.Skills.Alchemy.Cap = 0;
						m.Skills.Anatomy.Cap = 100;
						m.Skills.AnimalLore.Cap = 0;
						m.Skills.AnimalTaming.Cap = 0;
						m.Skills.Archery.Cap = 0;
						m.Skills.ArmsLore.Cap = 0;
						m.Skills.Begging.Cap = 0;
						m.Skills.Blacksmith.Cap = 0;
						m.Skills.Bushido.Cap = 0;
						m.Skills.Camping.Cap = 0;
						m.Skills.Carpentry.Cap = 0;
						m.Skills.Cartography.Cap = 0;
						m.Skills.Chivalry.Cap = 0;
						m.Skills.Cooking.Cap = 0;
						m.Skills.DetectHidden.Cap = 0;
						m.Skills.Discordance.Cap = 0;
						m.Skills.EvalInt.Cap = 0;
						m.Skills.Fencing.Cap = 0;
						m.Skills.Fishing.Cap = 0;
						m.Skills.Fletching.Cap = 0;
						m.Skills.Focus.Cap = 0;
						m.Skills.Forensics.Cap = 0;
						m.Skills.Healing.Cap = 120;
						m.Skills.Herding.Cap = 0;
						m.Skills.Hiding.Cap = 0;
						m.Skills.Inscribe.Cap = 0;
						m.Skills.ItemID.Cap = 0;
						m.Skills.Lockpicking.Cap = 0;
						m.Skills.Lumberjacking.Cap = 0;
						m.Skills.Macing.Cap = 0;
						m.Skills.Magery.Cap = 0;
						m.Skills.MagicResist.Cap = 100;
						m.Skills.Meditation.Cap = 0;
						m.Skills.Mining.Cap = 0;
						m.Skills.Musicianship.Cap = 0;
						m.Skills.Necromancy.Cap = 0;
						m.Skills.Ninjitsu.Cap = 0;
						m.Skills.Parry.Cap = 100;
						m.Skills.Peacemaking.Cap = 0;
						m.Skills.Poisoning.Cap = 0;
						m.Skills.Provocation.Cap = 0;
						m.Skills.RemoveTrap.Cap = 0;
						m.Skills.Snooping.Cap = 0;
						m.Skills.Spellweaving.Cap = 0;
						m.Skills.SpiritSpeak.Cap = 100;
						m.Skills.Stealing.Cap = 0;
						m.Skills.Stealth.Cap = 0;
						m.Skills.Swords.Cap = 0;
						m.Skills.Tactics.Cap = 100;
						m.Skills.Tailoring.Cap = 0;
						m.Skills.TasteID.Cap = 0;
						m.Skills.Tinkering.Cap = 0;
						m.Skills.Tracking.Cap = 0;
						m.Skills.Veterinary.Cap = 0;
						m.Skills.Wrestling.Cap = 120;

						//Edit actual Skill Values here
						m.Skills.Alchemy.Base = 0;
						m.Skills.Anatomy.Base = 35;
						m.Skills.AnimalLore.Base = 0;
						m.Skills.AnimalTaming.Base = 0;
						m.Skills.Archery.Base = 0;
						m.Skills.ArmsLore.Base = 0;
						m.Skills.Begging.Base = 0;
						m.Skills.Blacksmith.Base = 0;
						m.Skills.Camping.Base = 0;
						m.Skills.Carpentry.Base = 0;
						m.Skills.Cartography.Base = 0;
						m.Skills.Cooking.Base = 0;
						m.Skills.DetectHidden.Base = 0;
						m.Skills.Discordance.Base = 0;
						m.Skills.EvalInt.Base = 0;
						m.Skills.Fishing.Base = 0;
						m.Skills.Fencing.Base = 0;
						m.Skills.Fletching.Base = 0;
						m.Skills.Focus.Base = 0;
						m.Skills.Forensics.Base = 0;
						m.Skills.Healing.Base = 35;
						m.Skills.Herding.Base = 0;
						m.Skills.Hiding.Base = 0;
						m.Skills.Inscribe.Base = 0;
						m.Skills.ItemID.Base = 0;
						m.Skills.Lockpicking.Base = 0;
						m.Skills.Lumberjacking.Base = 0;
						m.Skills.Macing.Base = 0;
						m.Skills.Magery.Base = 0;
						m.Skills.MagicResist.Base = 35;
						m.Skills.Meditation.Base = 0;
						m.Skills.Mining.Base = 0;
						m.Skills.Musicianship.Base = 0;
						m.Skills.Parry.Base = 35;
						m.Skills.Peacemaking.Base = 0;
						m.Skills.Poisoning.Base = 0;
						m.Skills.Provocation.Base = 0;
						m.Skills.RemoveTrap.Base = 0;
						m.Skills.Snooping.Base = 0;
						m.Skills.Spellweaving.Base = 0;
						m.Skills.SpiritSpeak.Base = 35;
						m.Skills.Stealing.Base = 0;
						m.Skills.Stealth.Base = 0;
						m.Skills.Swords.Base = 0;
						m.Skills.Tactics.Base = 35;
						m.Skills.Tailoring.Base = 0;
						m.Skills.TasteID.Base = 0;
						m.Skills.Tinkering.Base = 0;
						m.Skills.Tracking.Base = 0;
						m.Skills.Veterinary.Base = 0;
						m.Skills.Wrestling.Base = 35;
						m.Skills.Bushido.Base = 0;
						m.Skills.Ninjitsu.Base = 0;
						m.Skills.Chivalry.Base = 0;
						m.Skills.Necromancy.Base = 0;

						m.SendGump(new PCraftGump());
						break;
					}
				case (int) Orders.MestreSabedoria: //Paladin
					{
						//Edit Skill/Stat TOTAL cap here
						m.SkillsCap = 1200;
						m.StatCap = 225;

						//Edit Base Stats values here
						m.Str = 50;
						m.Dex = 10;
						m.Int = 20;

						//Edit Class Title here.  This is the title next to the players name above their head
						m.Title = ", the Paladin";

						//Edit Starting Equiptment here
						m.AddToBackpack(new Broadsword());
						m.AddToBackpack(new Buckler());
						m.AddToBackpack(new Bandage(25));
						m.AddToBackpack(new BookOfChivalry((UInt64)0x3FF));

						//Edit Skill Caps here
						m.Skills.Alchemy.Cap = 0;
						m.Skills.Anatomy.Cap = 100;
						m.Skills.AnimalLore.Cap = 0;
						m.Skills.AnimalTaming.Cap = 0;
						m.Skills.Archery.Cap = 0;
						m.Skills.ArmsLore.Cap = 0;
						m.Skills.Begging.Cap = 0;
						m.Skills.Blacksmith.Cap = 0;
						m.Skills.Bushido.Cap = 0;
						m.Skills.Camping.Cap = 0;
						m.Skills.Carpentry.Cap = 0;
						m.Skills.Cartography.Cap = 0;
						m.Skills.Chivalry.Cap = 120;
						m.Skills.Cooking.Cap = 0;
						m.Skills.DetectHidden.Cap = 0;
						m.Skills.Discordance.Cap = 0;
						m.Skills.EvalInt.Cap = 0;
						m.Skills.Fencing.Cap = 0;
						m.Skills.Fishing.Cap = 0;
						m.Skills.Fletching.Cap = 0;
						m.Skills.Focus.Cap = 100;
						m.Skills.Forensics.Cap = 0;
						m.Skills.Healing.Cap = 100;
						m.Skills.Herding.Cap = 0;
						m.Skills.Hiding.Cap = 0;
						m.Skills.Inscribe.Cap = 0;
						m.Skills.ItemID.Cap = 0;
						m.Skills.Lockpicking.Cap = 0;
						m.Skills.Lumberjacking.Cap = 0;
						m.Skills.Macing.Cap = 0;
						m.Skills.Magery.Cap = 0;
						m.Skills.MagicResist.Cap = 100;
						m.Skills.Meditation.Cap = 0;
						m.Skills.Mining.Cap = 0;
						m.Skills.Musicianship.Cap = 0;
						m.Skills.Necromancy.Cap = 0;
						m.Skills.Ninjitsu.Cap = 0;
						m.Skills.Parry.Cap = 0;
						m.Skills.Peacemaking.Cap = 0;
						m.Skills.Poisoning.Cap = 0;
						m.Skills.Provocation.Cap = 0;
						m.Skills.RemoveTrap.Cap = 0;
						m.Skills.Snooping.Cap = 0;
						m.Skills.Spellweaving.Cap = 0;
						m.Skills.SpiritSpeak.Cap = 0;
						m.Skills.Stealing.Cap = 0;
						m.Skills.Stealth.Cap = 0;
						m.Skills.Swords.Cap = 120;
						m.Skills.Tactics.Cap = 100;
						m.Skills.Tailoring.Cap = 0;
						m.Skills.TasteID.Cap = 0;
						m.Skills.Tinkering.Cap = 0;
						m.Skills.Tracking.Cap = 0;
						m.Skills.Veterinary.Cap = 0;
						m.Skills.Wrestling.Cap = 0;

						//Edit actual Skill Values here
						m.Skills.Alchemy.Base = 0;
						m.Skills.Anatomy.Base = 35;
						m.Skills.AnimalLore.Base = 0;
						m.Skills.AnimalTaming.Base = 0;
						m.Skills.Archery.Base = 0;
						m.Skills.ArmsLore.Base = 0;
						m.Skills.Begging.Base = 0;
						m.Skills.Blacksmith.Base = 0;
						m.Skills.Camping.Base = 0;
						m.Skills.Carpentry.Base = 0;
						m.Skills.Cartography.Base = 0;
						m.Skills.Cooking.Base = 0;
						m.Skills.DetectHidden.Base = 0;
						m.Skills.Discordance.Base = 0;
						m.Skills.EvalInt.Base = 0;
						m.Skills.Fishing.Base = 0;
						m.Skills.Fencing.Base = 0;
						m.Skills.Fletching.Base = 0;
						m.Skills.Focus.Base = 35;
						m.Skills.Forensics.Base = 0;
						m.Skills.Healing.Base = 35;
						m.Skills.Herding.Base = 0;
						m.Skills.Hiding.Base = 0;
						m.Skills.Inscribe.Base = 0;
						m.Skills.ItemID.Base = 0;
						m.Skills.Lockpicking.Base = 0;
						m.Skills.Lumberjacking.Base = 0;
						m.Skills.Macing.Base = 0;
						m.Skills.Magery.Base = 0;
						m.Skills.MagicResist.Base = 35;
						m.Skills.Meditation.Base = 0;
						m.Skills.Mining.Base = 0;
						m.Skills.Musicianship.Base = 0;
						m.Skills.Parry.Base = 0;
						m.Skills.Peacemaking.Base = 0;
						m.Skills.Poisoning.Base = 0;
						m.Skills.Provocation.Base = 0;
						m.Skills.RemoveTrap.Base = 0;
						m.Skills.Snooping.Base = 0;
						m.Skills.Spellweaving.Base = 0;
						m.Skills.SpiritSpeak.Base = 0;
						m.Skills.Stealing.Base = 0;
						m.Skills.Stealth.Base = 0;
						m.Skills.Swords.Base = 35;
						m.Skills.Tactics.Base = 35;
						m.Skills.Tailoring.Base = 0;
						m.Skills.TasteID.Base = 0;
						m.Skills.Tinkering.Base = 0;
						m.Skills.Tracking.Base = 0;
						m.Skills.Veterinary.Base = 0;
						m.Skills.Wrestling.Base = 0;
						m.Skills.Bushido.Base = 0;
						m.Skills.Ninjitsu.Base = 0;
						m.Skills.Chivalry.Base = 35;
						m.Skills.Necromancy.Base = 0;

						m.SendGump(new PCraftGump());
						break;
					}
				case (int) Orders.Menestrel: //Mage
					{
						//Edit Skill/Stat TOTAL cap here
						m.SkillsCap = 1200;
						m.StatCap = 225;

						//Edit Base Stats values here
						m.Str = 20;
						m.Dex = 10;
						m.Int = 50;

						//Edit Class Title here.  This is the title next to the players name above their head
						m.Title = ", the Mage";

						//Edit Starting Equiptment here
						m.AddToBackpack(new QuarterStaff());
						m.AddToBackpack(new Spellbook((ulong)0x382A8C38));

						//Edit Skill Caps here
						m.Skills.Alchemy.Cap = 0;
						m.Skills.Anatomy.Cap = 0;
						m.Skills.AnimalLore.Cap = 0;
						m.Skills.AnimalTaming.Cap = 0;
						m.Skills.Archery.Cap = 0;
						m.Skills.ArmsLore.Cap = 0;
						m.Skills.Begging.Cap = 0;
						m.Skills.Blacksmith.Cap = 0;
						m.Skills.Bushido.Cap = 0;
						m.Skills.Camping.Cap = 0;
						m.Skills.Carpentry.Cap = 0;
						m.Skills.Cartography.Cap = 0;
						m.Skills.Chivalry.Cap = 0;
						m.Skills.Cooking.Cap = 0;
						m.Skills.DetectHidden.Cap = 0;
						m.Skills.Discordance.Cap = 0;
						m.Skills.EvalInt.Cap = 120;
						m.Skills.Fencing.Cap = 0;
						m.Skills.Fishing.Cap = 0;
						m.Skills.Fletching.Cap = 0;
						m.Skills.Focus.Cap = 100;
						m.Skills.Forensics.Cap = 0;
						m.Skills.Healing.Cap = 0;
						m.Skills.Herding.Cap = 0;
						m.Skills.Hiding.Cap = 0;
						m.Skills.Inscribe.Cap = 0;
						m.Skills.ItemID.Cap = 0;
						m.Skills.Lockpicking.Cap = 0;
						m.Skills.Lumberjacking.Cap = 0;
						m.Skills.Macing.Cap = 100;
						m.Skills.Magery.Cap = 120;
						m.Skills.MagicResist.Cap = 100;
						m.Skills.Meditation.Cap = 100;
						m.Skills.Mining.Cap = 0;
						m.Skills.Musicianship.Cap = 0;
						m.Skills.Necromancy.Cap = 0;
						m.Skills.Ninjitsu.Cap = 0;
						m.Skills.Parry.Cap = 0;
						m.Skills.Peacemaking.Cap = 0;
						m.Skills.Poisoning.Cap = 0;
						m.Skills.Provocation.Cap = 0;
						m.Skills.RemoveTrap.Cap = 0;
						m.Skills.Snooping.Cap = 0;
						m.Skills.Spellweaving.Cap = 0;
						m.Skills.SpiritSpeak.Cap = 100;
						m.Skills.Stealing.Cap = 0;
						m.Skills.Stealth.Cap = 0;
						m.Skills.Swords.Cap = 0;
						m.Skills.Tactics.Cap = 0;
						m.Skills.Tailoring.Cap = 0;
						m.Skills.TasteID.Cap = 0;
						m.Skills.Tinkering.Cap = 0;
						m.Skills.Tracking.Cap = 0;
						m.Skills.Veterinary.Cap = 0;
						m.Skills.Wrestling.Cap = 0;

						//Edit actual Skill Values here
						m.Skills.Alchemy.Base = 0;
						m.Skills.Anatomy.Base = 0;
						m.Skills.AnimalLore.Base = 0;
						m.Skills.AnimalTaming.Base = 0;
						m.Skills.Archery.Base = 0;
						m.Skills.ArmsLore.Base = 0;
						m.Skills.Begging.Base = 0;
						m.Skills.Blacksmith.Base = 0;
						m.Skills.Camping.Base = 0;
						m.Skills.Carpentry.Base = 0;
						m.Skills.Cartography.Base = 0;
						m.Skills.Cooking.Base = 0;
						m.Skills.DetectHidden.Base = 0;
						m.Skills.Discordance.Base = 0;
						m.Skills.EvalInt.Base = 35;
						m.Skills.Fishing.Base = 0;
						m.Skills.Fencing.Base = 0;
						m.Skills.Fletching.Base = 0;
						m.Skills.Focus.Base = 35;
						m.Skills.Forensics.Base = 0;
						m.Skills.Healing.Base = 0;
						m.Skills.Herding.Base = 0;
						m.Skills.Hiding.Base = 0;
						m.Skills.Inscribe.Base = 0;
						m.Skills.ItemID.Base = 0;
						m.Skills.Lockpicking.Base = 0;
						m.Skills.Lumberjacking.Base = 0;
						m.Skills.Macing.Base = 35;
						m.Skills.Magery.Base = 35;
						m.Skills.MagicResist.Base = 35;
						m.Skills.Meditation.Base = 35;
						m.Skills.Mining.Base = 0;
						m.Skills.Musicianship.Base = 0;
						m.Skills.Parry.Base = 0;
						m.Skills.Peacemaking.Base = 0;
						m.Skills.Poisoning.Base = 0;
						m.Skills.Provocation.Base = 0;
						m.Skills.RemoveTrap.Base = 0;
						m.Skills.Snooping.Base = 0;
						m.Skills.Spellweaving.Base = 0;
						m.Skills.SpiritSpeak.Base = 35;
						m.Skills.Stealing.Base = 0;
						m.Skills.Stealth.Base = 0;
						m.Skills.Swords.Base = 0;
						m.Skills.Tactics.Base = 0;
						m.Skills.Tailoring.Base = 0;
						m.Skills.TasteID.Base = 0;
						m.Skills.Tinkering.Base = 0;
						m.Skills.Tracking.Base = 0;
						m.Skills.Veterinary.Base = 0;
						m.Skills.Wrestling.Base = 0;
						m.Skills.Bushido.Base = 0;
						m.Skills.Ninjitsu.Base = 0;
						m.Skills.Chivalry.Base = 0;
						m.Skills.Necromancy.Base = 0;

						m.SendGump(new PCraftGump());
						break;
					}
				case (int) Orders.Barbaros: //Ranger
					{
						//Edit Skill/Stat TOTAL cap here
						m.SkillsCap = 1200;
						m.StatCap = 225;

						//Edit Base Stats values here
						m.Str = 30;
						m.Dex = 40;
						m.Int = 10;

						//Edit Class Title here.  This is the title next to the players name above their head
						m.Title = ", the Ranger";

						//Edit Starting Equiptment here
						m.AddToBackpack(new Arrow(50));
						m.AddToBackpack(new Bow());
						m.AddToBackpack(new Daisho());

						//Edit Skill Caps here
						m.Skills.Alchemy.Cap = 0;
						m.Skills.Anatomy.Cap = 100;
						m.Skills.AnimalLore.Cap = 100;
						m.Skills.AnimalTaming.Cap = 120;
						m.Skills.Archery.Cap = 120;
						m.Skills.ArmsLore.Cap = 0;
						m.Skills.Begging.Cap = 0;
						m.Skills.Blacksmith.Cap = 0;
						m.Skills.Bushido.Cap = 0;
						m.Skills.Camping.Cap = 0;
						m.Skills.Carpentry.Cap = 0;
						m.Skills.Cartography.Cap = 0;
						m.Skills.Chivalry.Cap = 0;
						m.Skills.Cooking.Cap = 0;
						m.Skills.DetectHidden.Cap = 0;
						m.Skills.Discordance.Cap = 0;
						m.Skills.EvalInt.Cap = 0;
						m.Skills.Fencing.Cap = 0;
						m.Skills.Fishing.Cap = 0;
						m.Skills.Fletching.Cap = 0;
						m.Skills.Focus.Cap = 0;
						m.Skills.Forensics.Cap = 0;
						m.Skills.Healing.Cap = 0;
						m.Skills.Herding.Cap = 0;
						m.Skills.Hiding.Cap = 0;
						m.Skills.Inscribe.Cap = 0;
						m.Skills.ItemID.Cap = 0;
						m.Skills.Lockpicking.Cap = 0;
						m.Skills.Lumberjacking.Cap = 0;
						m.Skills.Macing.Cap = 0;
						m.Skills.Magery.Cap = 0;
						m.Skills.MagicResist.Cap = 0;
						m.Skills.Meditation.Cap = 0;
						m.Skills.Mining.Cap = 0;
						m.Skills.Musicianship.Cap = 0;
						m.Skills.Necromancy.Cap = 0;
						m.Skills.Ninjitsu.Cap = 0;
						m.Skills.Parry.Cap = 0;
						m.Skills.Peacemaking.Cap = 0;
						m.Skills.Poisoning.Cap = 0;
						m.Skills.Provocation.Cap = 0;
						m.Skills.RemoveTrap.Cap = 0;
						m.Skills.Snooping.Cap = 0;
						m.Skills.Spellweaving.Cap = 0;
						m.Skills.SpiritSpeak.Cap = 0;
						m.Skills.Stealing.Cap = 0;
						m.Skills.Stealth.Cap = 0;
						m.Skills.Swords.Cap = 100;
						m.Skills.Tactics.Cap = 0;
						m.Skills.Tailoring.Cap = 0;
						m.Skills.TasteID.Cap = 0;
						m.Skills.Tinkering.Cap = 0;
						m.Skills.Tracking.Cap = 100;
						m.Skills.Veterinary.Cap = 100;
						m.Skills.Wrestling.Cap = 0;

						//Edit actual Skill Values here
						m.Skills.Alchemy.Base = 0;
						m.Skills.Anatomy.Base = 35;
						m.Skills.AnimalLore.Base = 35;
						m.Skills.AnimalTaming.Base = 35;
						m.Skills.Archery.Base = 35;
						m.Skills.ArmsLore.Base = 0;
						m.Skills.Begging.Base = 0;
						m.Skills.Blacksmith.Base = 0;
						m.Skills.Camping.Base = 0;
						m.Skills.Carpentry.Base = 0;
						m.Skills.Cartography.Base = 0;
						m.Skills.Cooking.Base = 0;
						m.Skills.DetectHidden.Base = 0;
						m.Skills.Discordance.Base = 0;
						m.Skills.EvalInt.Base = 0;
						m.Skills.Fishing.Base = 0;
						m.Skills.Fencing.Base = 0;
						m.Skills.Fletching.Base = 0;
						m.Skills.Focus.Base = 0;
						m.Skills.Forensics.Base = 0;
						m.Skills.Healing.Base = 0;
						m.Skills.Herding.Base = 0;
						m.Skills.Hiding.Base = 0;
						m.Skills.Inscribe.Base = 0;
						m.Skills.ItemID.Base = 0;
						m.Skills.Lockpicking.Base = 0;
						m.Skills.Lumberjacking.Base = 0;
						m.Skills.Macing.Base = 0;
						m.Skills.Magery.Base = 0;
						m.Skills.MagicResist.Base = 0;
						m.Skills.Meditation.Base = 0;
						m.Skills.Mining.Base = 0;
						m.Skills.Musicianship.Base = 0;
						m.Skills.Parry.Base = 0;
						m.Skills.Peacemaking.Base = 0;
						m.Skills.Poisoning.Base = 0;
						m.Skills.Provocation.Base = 0;
						m.Skills.RemoveTrap.Base = 0;
						m.Skills.Snooping.Base = 0;
						m.Skills.Spellweaving.Base = 0;
						m.Skills.SpiritSpeak.Base = 0;
						m.Skills.Stealing.Base = 0;
						m.Skills.Stealth.Base = 0;
						m.Skills.Swords.Base = 35;
						m.Skills.Tactics.Base = 0;
						m.Skills.Tailoring.Base = 0;
						m.Skills.TasteID.Base = 0;
						m.Skills.Tinkering.Base = 0;
						m.Skills.Tracking.Base = 35;
						m.Skills.Veterinary.Base = 35;
						m.Skills.Wrestling.Base = 0;
						m.Skills.Bushido.Base = 0;
						m.Skills.Ninjitsu.Base = 0;
						m.Skills.Chivalry.Base = 0;
						m.Skills.Necromancy.Base = 0;

						m.SendGump(new PCraftGump());
						break;
					}
				case (int) Orders.Navegante: //Rogue
					{
						//Edit Skill/Stat TOTAL cap here
						m.SkillsCap = 1200;
						m.StatCap = 225;

						//Edit Base Stats values here
						m.Str = 30;
						m.Dex = 40;
						m.Int = 10;

						//Edit Class Title here.  This is the title next to the players name above their head
						m.Title = ", the Rogue";

						//Edit Starting Equiptment here
						m.AddToBackpack(new Lockpick(25));
						m.AddToBackpack(new Sai());
						m.AddToBackpack(new BookOfNinjitsu());

						//Edit Skill Caps here
						m.Skills.Alchemy.Cap = 0;
						m.Skills.Anatomy.Cap = 0;
						m.Skills.AnimalLore.Cap = 0;
						m.Skills.AnimalTaming.Cap = 0;
						m.Skills.Archery.Cap = 0;
						m.Skills.ArmsLore.Cap = 0;
						m.Skills.Begging.Cap = 0;
						m.Skills.Blacksmith.Cap = 0;
						m.Skills.Bushido.Cap = 0;
						m.Skills.Camping.Cap = 0;
						m.Skills.Carpentry.Cap = 0;
						m.Skills.Cartography.Cap = 0;
						m.Skills.Chivalry.Cap = 0;
						m.Skills.Cooking.Cap = 0;
						m.Skills.DetectHidden.Cap = 0;
						m.Skills.Discordance.Cap = 0;
						m.Skills.EvalInt.Cap = 0;
						m.Skills.Fencing.Cap = 100;
						m.Skills.Fishing.Cap = 0;
						m.Skills.Fletching.Cap = 0;
						m.Skills.Focus.Cap = 0;
						m.Skills.Forensics.Cap = 0;
						m.Skills.Healing.Cap = 0;
						m.Skills.Herding.Cap = 0;
						m.Skills.Hiding.Cap = 100;
						m.Skills.Inscribe.Cap = 0;
						m.Skills.ItemID.Cap = 0;
						m.Skills.Lockpicking.Cap = 100;
						m.Skills.Lumberjacking.Cap = 0;
						m.Skills.Macing.Cap = 0;
						m.Skills.Magery.Cap = 0;
						m.Skills.MagicResist.Cap = 0;
						m.Skills.Meditation.Cap = 0;
						m.Skills.Mining.Cap = 0;
						m.Skills.Musicianship.Cap = 0;
						m.Skills.Necromancy.Cap = 0;
						m.Skills.Ninjitsu.Cap = 100;
						m.Skills.Parry.Cap = 0;
						m.Skills.Peacemaking.Cap = 0;
						m.Skills.Poisoning.Cap = 100;
						m.Skills.Provocation.Cap = 0;
						m.Skills.RemoveTrap.Cap = 100;
						m.Skills.Snooping.Cap = 100;
						m.Skills.Spellweaving.Cap = 0;
						m.Skills.SpiritSpeak.Cap = 0;
						m.Skills.Stealing.Cap = 100;
						m.Skills.Stealth.Cap = 100;
						m.Skills.Swords.Cap = 0;
						m.Skills.Tactics.Cap = 0;
						m.Skills.Tailoring.Cap = 0;
						m.Skills.TasteID.Cap = 0;
						m.Skills.Tinkering.Cap = 0;
						m.Skills.Tracking.Cap = 0;
						m.Skills.Veterinary.Cap = 0;
						m.Skills.Wrestling.Cap = 0;

						//Edit actual Skill Values here
						m.Skills.Alchemy.Base = 0;
						m.Skills.Anatomy.Base = 0;
						m.Skills.AnimalLore.Base = 0;
						m.Skills.AnimalTaming.Base = 0;
						m.Skills.Archery.Base = 0;
						m.Skills.ArmsLore.Base = 0;
						m.Skills.Begging.Base = 0;
						m.Skills.Blacksmith.Base = 0;
						m.Skills.Camping.Base = 0;
						m.Skills.Carpentry.Base = 0;
						m.Skills.Cartography.Base = 0;
						m.Skills.Cooking.Base = 0;
						m.Skills.DetectHidden.Base = 0;
						m.Skills.Discordance.Base = 0;
						m.Skills.EvalInt.Base = 0;
						m.Skills.Fishing.Base = 0;
						m.Skills.Fencing.Base = 35;
						m.Skills.Fletching.Base = 0;
						m.Skills.Focus.Base = 0;
						m.Skills.Forensics.Base = 0;
						m.Skills.Healing.Base = 0;
						m.Skills.Herding.Base = 0;
						m.Skills.Hiding.Base = 35;
						m.Skills.Inscribe.Base = 0;
						m.Skills.ItemID.Base = 0;
						m.Skills.Lockpicking.Base = 35;
						m.Skills.Lumberjacking.Base = 0;
						m.Skills.Macing.Base = 0;
						m.Skills.Magery.Base = 0;
						m.Skills.MagicResist.Base = 0;
						m.Skills.Meditation.Base = 0;
						m.Skills.Mining.Base = 0;
						m.Skills.Musicianship.Base = 0;
						m.Skills.Parry.Base = 0;
						m.Skills.Peacemaking.Base = 0;
						m.Skills.Poisoning.Base = 35;
						m.Skills.Provocation.Base = 0;
						m.Skills.RemoveTrap.Base = 35;
						m.Skills.Snooping.Base = 35;
						m.Skills.Spellweaving.Base = 0;
						m.Skills.SpiritSpeak.Base = 0;
						m.Skills.Stealing.Base = 35;
						m.Skills.Stealth.Base = 35;
						m.Skills.Swords.Base = 0;
						m.Skills.Tactics.Base = 0;
						m.Skills.Tailoring.Base = 0;
						m.Skills.TasteID.Base = 0;
						m.Skills.Tinkering.Base = 0;
						m.Skills.Tracking.Base = 0;
						m.Skills.Veterinary.Base = 0;
						m.Skills.Wrestling.Base = 0;
						m.Skills.Bushido.Base = 0;
						m.Skills.Ninjitsu.Base = 35;
						m.Skills.Chivalry.Base = 0;
						m.Skills.Necromancy.Base = 0;

						m.SendGump(new PCraftGump());
						break;
					}
			}
		}
	}
}