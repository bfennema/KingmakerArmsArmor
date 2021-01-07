using System;
using Kingmaker.Items;
using Kingmaker.UnitLogic;

namespace ArmsArmor
{
    class ItemEntityWeaponPatch {
        static public bool IsTwoHanded(ItemEntityWeapon weapon, UnitDescriptor owner) {
            if (owner != null && weapon.Blueprint.IsTwoHanded && CallOfTheWild.IsActive) {
                return !CallOfTheWild.canBeUsedOn(owner, weapon);
            } else {
                if (owner != null && Helpers.IsExoticTwoHandedMartialWeapon(weapon.Blueprint)) {
                    return !owner.Proficiencies.Contains(weapon.Blueprint.Category);
                } else {
                    return weapon.Blueprint.IsTwoHanded;
                }
            }
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
                    __result = ItemEntityPatch.ItemEntityCanBeEquippedInternalReversePatch.CanBeEquippedInternal(__instance, owner);
                }
            }
        }

        [HarmonyLib.HarmonyPatch(typeof(ItemEntityWeapon), "HoldInTwoHands", HarmonyLib.MethodType.Getter)]
        private static class ItemEntityWeaponHoldInTwoHandsPatch {
            [HarmonyLib.HarmonyAfter(new string[] { "CallOfTheWild" })]
            private static void Postfix(ItemEntityWeapon __instance, ref bool __result) {
                var wielder = __instance.Wielder;
                var unitPartTwoHand = (wielder != null) ? wielder.Get<UnitPartTwoHand>() : null;
                if (__result == true && !IsTwoHanded(__instance, wielder) && !(unitPartTwoHand && unitPartTwoHand.TwoHand)) {
                    __result = false;
                }
            }
        }
    }
}