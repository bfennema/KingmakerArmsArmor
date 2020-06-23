using Kingmaker.Items;
using Kingmaker.UI.ServiceWindow;
using UnityEngine;

namespace ArmsArmor
{
    class EquipSlotPatch {
        [HarmonyLib.HarmonyPatch(typeof(EquipSlot), "SetFakeItem")]
        private static class EquipSlotSetFakeItemPatch {
            private static bool Prepare() {
                if (Main.ModSettings.EquipWeaponWithoutProficiency == false) {
                    return false;
                } else {
                    return true;
                }
            }
            private static void Postfix(EquipSlot __instance, ItemEntityWeapon weapon) {
				if (__instance.HasItem) {
					return;
				}
				if (weapon != null) {
                    if (ItemEntityWeaponPatch.IsExoticTwoHandedMartialWeapon(weapon.Blueprint)
					    && !ItemEntityWeaponCanBeEquippedInternalReversePatch.CanBeEquippedInternal(weapon, weapon.Owner)) {
                        Color color = __instance.ItemImage.color;
                        color.a = 0.5f;
						__instance.ItemImage.sprite = weapon.Blueprint.Icon;
                        Helpers.EquipSlotTypeIcon(__instance).gameObject.SetActive(false);
                        __instance.ItemImage.color = color;
                    }
				}
            }
        }
    }
}