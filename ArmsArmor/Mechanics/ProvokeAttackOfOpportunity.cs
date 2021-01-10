using Kingmaker;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;

namespace ArmsArmor
{
    [ComponentName("Basic Mechanics proficiency")]
    [AllowedOn(typeof(BlueprintFeature))]
    public class ProvokeAttackOfOpportunity : RuleInitiatorLogicComponent<RuleCombatManeuver>
    {
        public override void OnEventAboutToTrigger(RuleCombatManeuver evt) {
            if (evt.Type == Type && !base.Owner.HasFact(Feature)) {
                Game.Instance.CombatEngagementController.ForceAttackOfOpportunity(evt.Target, evt.Initiator);
            }
        }

        public override void OnEventDidTrigger(RuleCombatManeuver rule) {
        }

        public BlueprintFeature Feature;
        public CombatManeuver Type = CombatManeuver.Trip;
    }
}
