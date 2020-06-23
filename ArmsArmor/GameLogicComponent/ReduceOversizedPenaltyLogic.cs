using System;
using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Designers.Mechanics.WeaponEnchants;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;

namespace ArmsArmor
{
    [AllowedOn(typeof(BlueprintEquipmentEnchantment))]
    public class ReduceOversizedPenaltyLogic : GameLogicComponent {
        public int reduction;

        [HarmonyLib.HarmonyPatch(typeof(WeaponImprovised), "OnEventAboutToTrigger", new Type[] { typeof(RuleCalculateAttackBonusWithoutTarget) })]
        private static class WeaponImprovisedOnEventAboutToTriggerPatch {
            private static bool Prefix(WeaponImprovised __instance, RuleCalculateAttackBonusWithoutTarget evt) {
                var fact = __instance.Owner.Owner.GetFact(ReduceOversizedPenalty.GetBlueprint());
                if (fact != null) {
                    var reduction = fact.SelectComponents<ReduceOversizedPenaltyLogic>().Max(logic => logic.reduction);
                    if (reduction < 4) {
                        evt.AddBonus(reduction - 4, __instance.Fact);
                    }
                    return false;
                }
                return true;
            }
        }

        [HarmonyLib.HarmonyPatch(typeof(WeaponOversized), "OnEventAboutToTrigger", new Type[] { typeof(RuleCalculateAttackBonusWithoutTarget) })]
        private static class WeaponOversizedOnEventAboutToTriggerPatch {
            private static bool Prefix(WeaponOversized __instance, RuleCalculateAttackBonusWithoutTarget evt) {
                var fact = __instance.Owner.Owner.GetFact(ReduceOversizedPenalty.GetBlueprint());
                if (fact != null) {
                    var reduction = fact.SelectComponents<ReduceOversizedPenaltyLogic>().Max(logic => logic.reduction);
                    if (reduction < 2) {
                        evt.AddBonus(reduction - 2, __instance.Fact);
                    }
                    return false;
                }
                return true;
            }
        }
    }
}