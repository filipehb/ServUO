namespace Server.Items
{
    public class BestialLegs : LeatherLegs
    {
        public override bool IsArtifact => true;
        public override int LabelNumber => 1151199;  // Bestial Leggings

        #region ISetItem Members
        public override SetItem SetID => SetItem.Bestial;
        public override int Pieces => 4;
        #endregion

        public override int BasePhysicalResistance => 4;
        public override int BaseFireResistance => 19;
        public override int BaseColdResistance => 5;
        public override int BasePoisonResistance => 5;
        public override int BaseEnergyResistance => 5;
        public override int InitMinHits => 125;
        public override int InitMaxHits => 125;

        [Constructable]
        public BestialLegs()
        {
            Hue = 2010;
            Weight = 4;
            StrRequirement = 20;
        }

        public BestialLegs(Serial serial) : base(serial)
        {
        }

        public override void OnAdded(object parent)
        {
            base.OnAdded(parent);

            if (parent is Mobile && !Deleted)
            {
                BestialSetHelper.OnAdded((Mobile)parent, this);
            }
        }

        public override void OnRemoved(object parent)
        {
            base.OnRemoved(parent);

            if (parent is Mobile && !Deleted)
            {
                BestialSetHelper.OnRemoved((Mobile)parent, this);
            }
        }

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
