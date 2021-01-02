using Kingmaker.Blueprints.Root.Strings;
using Kingmaker.Items;
using Kingmaker.UI.Common;

namespace ArmsArmor
{
    class UIUtilityItemPatch {
        [HarmonyLib.HarmonyPatch(typeof(UIUtilityItem), "GetHandUse")]
        private static class UIUtilityItemGetHandUsePatch {
            private static bool Prepare() {
                if (Main.ModSettings.EquipWeaponWithoutProficiency == false) {
                    return false;
                } else {
                    return true;
                }
            }
            private static void Postfix(ItemEntity item, ref string __result) {
                if (item is ItemEntityWeapon weapon && ItemEntityWeaponPatch.IsTwoHanded(weapon, weapon.Owner)) {
                    __result = UIStrings.Instance.Tooltips.TwoHanded;
                }
            }
        }
    }
}