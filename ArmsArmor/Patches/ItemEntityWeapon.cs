using System;
using System.Reflection;
using Kingmaker.Items;
using Kingmaker.UnitLogic;

namespace ArmsArmor
{
    class ItemEntityWeaponPatch {
        static Type UnitPartCanHold2hWeaponIn1h = null;
        static MethodInfo canBeUsedOn = null;
        static public bool IsTwoHanded(ItemEntityWeapon weapon, UnitDescriptor owner) {
            return (weapon.Blueprint.IsTwoHanded && !Helpers.IsExoticTwoHandedMartialWeapon(weapon.Blueprint))
                || (Helpers.IsExoticTwoHandedMartialWeapon(weapon.Blueprint) && !IsProficient(weapon, owner));
        }

        static public bool IsTwoHanded(ItemEntityWeapon weapon) {
            return IsTwoHanded(weapon, weapon.Owner);
        }

        static public bool IsProficient(ItemEntityWeapon weapon, UnitDescriptor owner) {
            if (Main.CallOfTheWild != null && UnitPartCanHold2hWeaponIn1h == null) {
                UnitPartCanHold2hWeaponIn1h = Main.CallOfTheWild.GetType("CallOfTheWild.HoldingItemsMechanics.UnitPartCanHold2hWeaponIn1h");
                canBeUsedOn = HarmonyLib.AccessTools.Method(UnitPartCanHold2hWeaponIn1h, "canBeUsedOn");
            }
            if (owner != null) {
                if (Main.CallOfTheWild != null) {
                    var parts = Helpers.UnitPartsManagerParts(Helpers.UnitDescriptorParts(owner));
                    return (bool)canBeUsedOn.Invoke(parts[UnitPartCanHold2hWeaponIn1h], new object[] { weapon });
                } else {
                    return owner.Proficiencies.Contains(weapon.Blueprint.Category);
                }
            } else {
                return true;
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
                if (__result == true && !IsTwoHanded(__instance)
                    && __instance.Owner != null && !__instance.Owner.Get<UnitPartTwoHand>().TwoHand) {
                    __result = false;
                }
            }
        }
    }
}