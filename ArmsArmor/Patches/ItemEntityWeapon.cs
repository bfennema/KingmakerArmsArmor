using System;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;
using Kingmaker.Items;
using Kingmaker.UnitLogic;
using static ArmsArmor.ItemEntityPatch;

namespace ArmsArmor
{
    [HarmonyLib.HarmonyPatch]
    public class ItemEntityWeaponCanBeEquippedInternalReversePatch
    {
        [HarmonyLib.HarmonyReversePatch]
        [HarmonyLib.HarmonyPatch(typeof(ItemEntityWeapon), "CanBeEquippedInternal", new Type[] { typeof(UnitDescriptor) })]
        public static bool CanBeEquippedInternal(ItemEntityWeapon __instance, UnitDescriptor owner) {
            // its a stub so it has no initial content
            throw new NotImplementedException("It's a stub");
        }
    }

    class ItemEntityWeaponPatch {
        static public bool IsExoticTwoHandedMartialWeapon(BlueprintItemWeapon weapon) {
            return weapon.Category == WeaponCategory.BastardSword
                || weapon.Category == WeaponCategory.DwarvenWaraxe
                || weapon.Category == WeaponCategory.Estoc
                || weapon.Category == WeaponCategory.DuelingSword;
        }

        static public bool IsTwoHanded(ItemEntityWeapon weapon) {
            var blueprint = weapon.Blueprint;
            return blueprint.IsTwoHanded
                || (IsExoticTwoHandedMartialWeapon(blueprint)
                    && !ItemEntityWeaponCanBeEquippedInternalReversePatch.CanBeEquippedInternal(weapon, weapon.Owner));
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
                var blueprint = __instance.Blueprint;
                if (__result == false && !(IsExoticTwoHandedMartialWeapon(blueprint) && blueprint.IsTwoHanded)) {
                    __result = ItemEntityCanBeEquippedInternalReversePatch.CanBeEquippedInternal(__instance, owner);
                }
            }
        }

        [HarmonyLib.HarmonyPatch(typeof(ItemEntityWeapon), "HoldInTwoHands", HarmonyLib.MethodType.Getter)]
        private static class ItemEntityWeaponHoldInTwoHandsPatch {
            private static void Postfix(ItemEntityWeapon __instance, ref bool __result) {
                if (__result == true && !IsTwoHanded(__instance)
                    && __instance.Wielder != null && !__instance.Wielder.Get<UnitPartTwoHand>().TwoHand) {
                    __result = false;
                }
            }
        }
    }
}