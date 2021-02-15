using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Facts;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;

namespace ArmsArmor
{
    [ComponentName("Basic Mechanics proficiency")]
    [AllowedOn(typeof(BlueprintFeature))]
    public class ProvokeAttackOfOpportunity : RuleInitiatorLogicComponent<RuleCombatManeuver>
    {
        public override void OnEventAboutToTrigger(RuleCombatManeuver evt) {
            if (evt.Type == Type && (evt.Reason?.Ability?.Blueprint == Ability || evt.Reason?.Rule is RuleCombatManeuver) && !base.Owner.HasFact(Feature)) {
                Helpers.ImmediateAttackOfOpportunity(evt.Target.CombatState, evt.Initiator);
            }
        }

        public override void OnEventDidTrigger(RuleCombatManeuver rule) {
        }

        public BlueprintFeature Feature;
        public BlueprintUnitFact Ability;
        public CombatManeuver Type = CombatManeuver.Trip;
    }
}
