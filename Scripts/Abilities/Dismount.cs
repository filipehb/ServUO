using System;
using Server.Mobiles;
using Server.Spells.Ninjitsu;

namespace Server.Items
{
    /// <summary>
    /// Perfect for the foot-soldier, the Dismount special attack can unseat a mounted opponent.
    /// The fighter using this ability must be on his own two feet and not in the saddle of a steed
    /// (with one exception: players may use a lance to dismount other players while mounted).
    /// If it works, the target will be knocked off his own mount and will take some extra damage from the fall!
    /// </summary>
    public class Dismount : WeaponAbility
    {
        public override int BaseMana => 25;

        public override bool Validate(Mobile from)
        {
            if (!base.Validate(from))
                return false;

            if ((from.Mounted || from.Flying) && !(from.Weapon is Lance) && !(from.Weapon is GargishLance))
            {
                from.SendLocalizedMessage(1061283); // You cannot perform that attack while mounted or flying!
                return false;
            }

            return true;
        }

        public override void OnHit(Mobile attacker, Mobile defender, int damage)
        {
            if (!Validate(attacker))
                return;

            if (defender is ChaosDragoon || defender is ChaosDragoonElite)
                return;

            ClearCurrentAbility(attacker);

            if (CheckMountedNoLance(attacker, defender))
            {
                attacker.SendLocalizedMessage(1060089); // You fail to execute your special move
                return;
            }

            IMount mount = defender.Mount;

            if (mount == null && !defender.Flying && !AnimalForm.UnderTransformation(defender))
            {
                attacker.SendLocalizedMessage(1060848); // This attack only works on mounted or flying targets
                return;
            }

            if (!CheckMana(attacker, true))
            {
                return;
            }

            if (attacker is LesserHiryu && 0.8 >= Utility.RandomDouble())
            {
                return; //Lesser Hiryu have an 80% chance of missing this attack
            }

            defender.PlaySound(0x140);
            defender.FixedParticles(0x3728, 10, 15, 9955, EffectLayer.Waist);

            int delay = attacker.Weapon is BaseRanged ? 8 : 10;

            DoDismount(attacker, defender, mount, delay);

            if (!attacker.Mounted)
            {
                AOS.Damage(defender, attacker, Utility.RandomMinMax(15, 25), 100, 0, 0, 0, 0);
            }
        }

        public static void DoDismount(Mobile attacker, Mobile defender, IMount mount, int delay, BlockMountType type = BlockMountType.Dazed)
        {
            attacker.SendLocalizedMessage(1060082); // The force of your attack has dislodged them from their mount!

            if (defender is PlayerMobile)
            {
                if (AnimalForm.UnderTransformation(defender))
                {
                    defender.SendLocalizedMessage(1114066, attacker.Name); // ~1_NAME~ knocked you out of animal form!
                }
                else if (defender.Flying)
                {
                    defender.SendLocalizedMessage(1113590, attacker.Name); // You have been grounded by ~1_NAME~!
                }
                else if (defender.Mounted)
                {
                    defender.SendLocalizedMessage(1060083); // You fall off of your mount and take damage!
                }

                ((PlayerMobile)defender).SetMountBlock(type, TimeSpan.FromSeconds(delay), true);
            }
            else if (mount != null)
            {
                mount.Rider = null;
            }

            if (attacker is PlayerMobile)
            {
                ((PlayerMobile)attacker).SetMountBlock(BlockMountType.DismountRecovery, TimeSpan.FromSeconds(attacker.Weapon is BaseRanged ? 8 : 10), false);
            }
            else if (attacker is BaseCreature)
            {
                BaseCreature bc = attacker as BaseCreature;

                if (bc.ControlMaster is PlayerMobile)
                {
                    PlayerMobile pm = bc.ControlMaster as PlayerMobile;

                    pm.SetMountBlock(BlockMountType.DismountRecovery, TimeSpan.FromSeconds(delay), false);
                }
            }
        }

        private bool CheckMountedNoLance(Mobile attacker, Mobile defender)
        {
            if (!attacker.Mounted && !attacker.Flying)
                return false;

            if ((attacker.Weapon is Lance || attacker.Weapon is GargishLance) && (defender.Weapon is Lance || defender.Weapon is GargishLance))
            {
                return false;
            }

            return true;
        }
    }
}
