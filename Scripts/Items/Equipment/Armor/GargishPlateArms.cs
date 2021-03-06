namespace Server.Items
{
    public class GargishPlateArms : BaseArmor
    {
        [Constructable]
        public GargishPlateArms()
            : this(0)
        {
        }

        [Constructable]
        public GargishPlateArms(int hue)
            : base(0x308)
        {
            Weight = 5.0;
            Hue = hue;
        }

        public GargishPlateArms(Serial serial)
            : base(serial)
        {
        }

        public override int BasePhysicalResistance => 8;
        public override int BaseFireResistance => 6;
        public override int BaseColdResistance => 5;
        public override int BasePoisonResistance => 6;
        public override int BaseEnergyResistance => 5;

        public override int InitMinHits => 50;
        public override int InitMaxHits => 65;

        public override int StrReq => 80;

        public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
