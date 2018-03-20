using System;
using Server;
using Server.Spells.Mysticism;
using Server.Targeting;
using Server.Spells;

namespace Server.Mobiles
{
	public class MysticAI : MageAI
	{
		public override SkillName CastSkill { get { return SkillName.Mysticism; } }
        public override bool UsesMagery { get { return m_Mobile.Skills[SkillName.Magery].Base >= 20.0 && !m_Mobile.Controlled; } }

		public MysticAI(BaseCreature m)
            : base(m)
        {
        }
		
		public override Spell GetRandomDamageSpell()
		{
            if (UsesMagery && 0.5 > Utility.RandomDouble())
            {
                return base.GetRandomDamageSpell();
            }
            else
            {
                int mana = m_Mobile.Mana;
                int select = 1;

                if (mana >= 50)
                    select = 5;
                else if (mana >= 20)
                    select = 3;
                else if (mana >= 9)
                    select = 2;

                switch (Utility.Random(select))
                {
                    case 0: return new NetherBoltSpell(m_Mobile, null);
                    case 1: return new EagleStrikeSpell(m_Mobile, null);
                    case 2: return new BombardSpell(m_Mobile, null);
                    case 3: return new HailStormSpell(m_Mobile, null);
                    case 4: return new NetherCycloneSpell(m_Mobile, null);
                }
            }
            return null;
		}
		
		public override Spell GetRandomCurseSpell()
		{
            if (UsesMagery && 0.5 > Utility.RandomDouble())
            {
                return base.GetRandomCurseSpell();
            }
            else
            {
                int mana = m_Mobile.Mana;
                int select = 1;

                if (mana >= 40)
                    select = 4;
                else if (mana >= 14)
                    select = 3;
                else if (mana >= 8)
                    select = 2;

                switch (Utility.Random(select))
                {
                    case 0: return new PurgeMagicSpell(m_Mobile, null);
                    case 1: return new SleepSpell(m_Mobile, null);
                    case 2: return new MassSleepSpell(m_Mobile, null);
                    case 3: return new SpellPlagueSpell(m_Mobile, null);
                }
            }

            return null;
		}
		
		public override Spell GetHealSpell()
		{
            if (UsesMagery && 0.5 > Utility.RandomDouble())
            {
                return base.GetHealSpell();
            }
            else
            {
                if (m_Mobile.Mana >= 20)
                    return new CleansingWindsSpell(m_Mobile, null);
            }

			return null;
		}
		
		protected override bool ProcessTarget()
		{
			Target t = m_Mobile.Target;
			
			if(t is MysticSpell.MysticSpellTarget && ((MysticSpell.MysticSpellTarget)t).Owner is HailStormSpell)
			{
                if (m_Mobile.Combatant != null && m_Mobile.InRange(m_Mobile.Combatant.Location, 8))
				{
					t.Invoke(m_Mobile, m_Mobile.Combatant);
				}
				else
					t.Invoke(m_Mobile, m_Mobile);
					
				return true;
			}
			
			return base.ProcessTarget();
		}
	}
}