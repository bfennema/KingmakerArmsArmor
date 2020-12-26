using System;
using Kingmaker.Items;
using Kingmaker.UnitLogic;
using static ArmsArmor.ItemEntityPatch;

namespace ArmsArmor
{
    class ItemEntityWeaponPatch {
        static public bool IsTwoHanded(ItemEntityWeapon weapon) {
            var blueprint = weapon.Blueprint;
            return (blueprint.IsTwoHanded && !Helpers.IsExoticTwoHandedMartialWeapon(blueprint))
                || (Helpers.IsExoticTwoHandedMartialWeapon(blueprint)
                    && (weapon.Wielder == null || !weapon.Wielder.Proficiencies.Contains(weapon.Blueprint.Category)));
        }

        [HarmonyLib.HarmonyPatch(typeof(ItemEntityWeapon), "CanBeEquippedInternal", new Type[] { typeof(UnitDescriptor) })]
        private static class ItemEntityWeaponCanBeEquippedInternalPatch {
            private static bool Prepare() {
                if (Main.ModSettings.EquipWeaponWithoutProficiency == false) {
                    return false;
                } else {
                    return true;
                }
            }
            private static void Postfix(ItemEntityWeapon __instance, UnitDescriptor owner, ref bool __result) {
                if (__result == false) {
                    __result = ItemEntityCanBeEquippedInternalReversePatch.CanBeEquippedInternal(__instance, owner);
                }
            }
        }

        [HarmonyLib.HarmonyPatch(typeof(ItemEntityWeapon), "HoldInTwoHands", HarmonyLib.MethodType.Getter)]
        private static class ItemEntityWeaponHoldInTwoHandsPatch {
            [HarmonyLib.HarmonyAfter(new string[] { "CallOfTheWild" })]
            private static void Postfix(ItemEntityWeapon __instance, ref bool __result) {
                if (__result == true && !IsTwoHanded(__instance)
                    && __instance.Wielder != null && !__instance.Wielder.Get<UnitPartTwoHand>().TwoHand) {
                    __result = false;
                }
            }
        }
    }
}