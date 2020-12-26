using Kingmaker.Items;
using Kingmaker.Items.Slots;
using Kingmaker.UnitLogic;

namespace ArmsArmor
{
    class HandSlotPatch {
        static public bool IsTwoHanded(ItemEntityWeapon weapon, UnitDescriptor owner) {
            if ((weapon.Blueprint.IsTwoHanded && !Helpers.IsExoticTwoHandedMartialWeapon(weapon.Blueprint))
                || weapon.Blueprint.Double
                || (Helpers.IsExoticTwoHandedMartialWeapon(weapon.Blueprint)
                    && !owner.Proficiencies.Contains(weapon.Blueprint.Category))) {
                return true;
            } else {
                return false;
            }
        }

        [HarmonyLib.HarmonyPatch(typeof(HandSlot), "OnItemInserted")]
        private static class HandSlotOnItemInsertedPatch {
            private static bool Prepare() {
                if (Main.ModSettings.EquipWeaponWithoutProficiency == false) {
                    return false;
                } else {
                    return true;
                }
            }

            [HarmonyLib.HarmonyAfter(new string[] { "CallOfTheWild" })]
            private static bool Prefix(HandSlot __instance) {
                if (__instance.IsPrimaryHand) {
                    var weapon = __instance.MaybeItem as ItemEntityWeapon;
                    if (weapon != null && IsTwoHanded(weapon, __instance.Owner)) {
                        __instance.PairSlot.RemoveItem();
                    }
                } else {
                    var removePrimary = true;
                    var primaryHand = __instance.HandsEquipmentSet.PrimaryHand;
                    var primaryWeapon = primaryHand.MaybeItem as ItemEntityWeapon;
                    var secondaryWeapon = __instance.MaybeItem as ItemEntityWeapon;
                    if (primaryWeapon != null && IsTwoHanded(primaryWeapon, __instance.Owner)) {
                        removePrimary = primaryHand.RemoveItem();
                    }
                    if (secondaryWeapon != null && IsTwoHanded(secondaryWeapon, __instance.Owner)) {
                        __instance.RemoveItem();
                        if (removePrimary) {
                            __instance.PairSlot.InsertItem(secondaryWeapon);
                        } 
                    }
                }
                __instance.IsDirty = true;
                return false;
            }
        }
    }
}