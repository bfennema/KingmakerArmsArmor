using Kingmaker.EntitySystem.Entities;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;

namespace ArmsArmor
{
    public class BashingFinishPatch {
        [HarmonyLib.HarmonyPatch(typeof(BashingFinish), "OnEventDidTrigger")]
        private static class BashingFinishOnEventDidTriggerPatch {
            private static bool Prefix(RuleAttackWithWeapon evt) {
                if (evt.AttackRoll.IsCriticalConfirmed && !evt.AttackRoll.FortificationNegatesCriticalHit && evt.Initiator.Body.SecondaryHand.HasShield && evt.Initiator.Body.SecondaryHand.HasWeapon) {
                    UnitEntityData unitEntityData = ContextActionMeleeAttack.SelectTarget(evt.Initiator, evt.Initiator.Body.SecondaryHand.Weapon.AttackRange.Meters, evt.Target.HPLeft <= 0, evt.Target);
                    if (unitEntityData != null) {
                        Rulebook.Trigger<RuleAttackWithWeapon>(new RuleAttackWithWeapon(evt.Initiator, unitEntityData, evt.Initiator.Body.SecondaryHand.Weapon, evt.AttackBonusPenalty)
                        {
                            Reason = evt,
                            AutoHit = false
                        });
                    }
                    return false;
                }
                return true;
            }
        }
    }
}