using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
    public class Abbein : BaseVendor
    {
        private readonly List<SBInfo> m_SBInfos = new List<SBInfo>();
        [Constructable]
        public Abbein()
            : base("the wise")
        {
            Name = "Elder Abbein";
        }

        public Abbein(Serial serial)
            : base(serial)
        {
        }

        public override bool CanTeach => false;
        public override bool IsInvulnerable => true;
        protected override List<SBInfo> SBInfos => m_SBInfos;
        public override void InitSBInfo()
        {
        }

        public override void InitBody()
        {
            InitStats(100, 100, 25);

            Female = true;
            Race = Race.Elf;

            Hue = 0x824D;
            HairItemID = 0x2FD1;
            HairHue = 0x321;
        }

        public override void InitOutfit()
        {
            SetWearable(new ElvenBoots(), 0x74B, 1);
			SetWearable(new FemaleElvenRobe(), 0x8A8, 1);
			SetWearable(new RoyalCirclet(), dropChance: 1);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}