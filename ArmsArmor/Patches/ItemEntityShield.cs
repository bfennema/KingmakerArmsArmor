using System;
using Kingmaker.Items;
using Kingmaker.UnitLogic;
using static ArmsArmor.ItemEntityPatch;

namespace ArmsArmor
{
    class ItemEntityShieldPatch {
        [HarmonyLib.HarmonyPatch(typeof(ItemEntityShield), "CanBeEquippedInternal", new Type[] { typeof(UnitDescriptor) })]
        private static class ItemEntityShieldCanBeEquippedInternalPatch {
            private static bool Prepare() {
                if (Main.ModSettings.EquipShieldWithoutProficiency == false) {
                    return false;
                } else {
                    return true;
                }
            }
            private static void Postfix(ItemEntityShield __instance, UnitDescriptor owner, ref bool __result) {
                if (__result == false) {
                    __result = ItemEntityCanBeEquippedInternalReversePatch.CanBeEquippedInternal(__instance, owner);
                }
            }
        }
    }
}