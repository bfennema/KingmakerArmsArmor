using Kingmaker.Achievements.Logic;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;

namespace ArmsArmor
{
    public class ZenArcherPatch
    {
        [HarmonyLib.HarmonyPatch(typeof(AchievementLogicZenArcher), "OnEventDidTrigger")]
        private static class AchievementLogicZenArcherOnEventDidTriggerPatch {
            private static bool Prepare() {
                if (Main.ModSettings.OrcHornbow == false) {
                    return false;
                } else {
                    return true;
                }
            }
            private static bool Prefix(AchievementLogicZenArcher __instance, RuleAttackWithWeapon evt) {
				if (!evt.Initiator.IsPlayerFaction) {
					return true;
				}
				if (!evt.AttackRoll.IsCriticalConfirmed || !evt.Initiator.Descriptor.State.HasCondition(UnitCondition.Blindness)) {
					return true;
				}
                if (evt.Weapon.Blueprint.Category == OrcHornbow.WeaponCategoryOrcHornbow) {
                    __instance.Entity.Unlock();
                    return false;
                }
                return true;
			}
        }
    }
}