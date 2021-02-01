using System;
using Kingmaker;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.ElementsSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs;
using Kingmaker.UnitLogic.Mechanics;

namespace ArmsArmor
{
    [AllowedOn(typeof(BlueprintUnitFact))]
    [AllowMultipleComponents]
    public class MissProvokeAttackCaster : RuleInitiatorLogicComponent<RuleAttackRoll> {
        public int MissBy = 5;
        public ConditionsChecker Conditions;
        bool triggered = false;

        private MechanicsContext Context {
            get {
                return (base.Fact as Buff)?.Context ?? (base.Fact as Feature)?.Context;
            }
		}

		public override void OnEventAboutToTrigger(RuleAttackRoll evt) { }
        public override void OnEventDidTrigger(RuleAttackRoll evt) {
            if (!triggered && !evt.IsHit && evt.Weapon.Blueprint.IsMelee && evt.TargetAC - evt.Roll - evt.AttackBonus >= MissBy) {
				using (this.Context.GetDataScope(evt.Target)) {
                    if (this.Conditions.Check(null)) {
                        if (Context.MaybeCaster.CombatState.IsEngage(evt.Initiator)) {
                            Game.Instance.CombatEngagementController.ForceAttackOfOpportunity(Context.MaybeCaster, evt.Initiator);
                            triggered = true;
                        }
					}
				}
            }
        }
    }
}