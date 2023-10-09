using Reward = Server.Engines.Quests.BaseReward;

namespace Server.Items
{
    public class BaseRewardBag : Bag
    {
        public BaseRewardBag()
        {
            Hue = Reward.RewardBagHue();

            while (Items.Count < ItemAmount)
            {
                if (0.05 > Utility.RandomDouble()) // check
                    DropItem(Loot.RandomTalisman());
                else
                {
                    switch (Utility.Random(4))
                    {
                        case 0:
                            DropItem(Reward.Armor());
                            break;
                        case 1:
                            DropItem(Reward.RangedWeapon());
                            break;
                        case 2:
                            DropItem(Reward.Weapon());
                            break;
                        case 3:
                            DropItem(Reward.Jewlery());
                            break;
                    }
                }
            }
        }

        public BaseRewardBag(Serial serial)
            : base(serial)
        {
        }

        public virtual int ItemAmount => 0;
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

    public class SmallTrinketBag : BaseRewardBag
    {
        [Constructable]
        public SmallTrinketBag()
        {
        }

        public SmallTrinketBag(Serial serial)
            : base(serial)
        {
        }

        public override int ItemAmount => 1;
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

    public class TrinketBag : BaseRewardBag
    {
        [Constructable]
        public TrinketBag()
        {
        }

        public TrinketBag(Serial serial)
            : base(serial)
        {
        }

        public override int ItemAmount => 2;
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

    public class TreasureBag : BaseRewardBag
    {
        [Constructable]
        public TreasureBag()
        {
        }

        public TreasureBag(Serial serial)
            : base(serial)
        {
        }

        public override int ItemAmount => 3;
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

    public class LargeTreasureBag : BaseRewardBag
    {
        [Constructable]
        public LargeTreasureBag()
        {
        }

        public LargeTreasureBag(Serial serial)
            : base(serial)
        {
        }

        public override int ItemAmount => 4;
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