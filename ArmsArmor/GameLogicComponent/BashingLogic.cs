using System;
using Kingmaker;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Blueprints.Items.Shields;
using Kingmaker.Items;
using Kingmaker.UnitLogic.Mechanics;

namespace ArmsArmor
{
    [ComponentName("Shield Armor Size Change")]
    public class BashingLogic : ArmorEnchantmentLogic {
        public void AddWeaponEnchantment(ItemEntityWeapon weapon, BlueprintItemEnchantment enchantment) {
            if (!weapon.HasEnchantment(BashingWeaponEnchantment.GetBlueprint())) {
                weapon.AddEnchantment(BashingWeaponEnchantment.GetBlueprint(), new MechanicsContext(Game.Instance.DefaultUnit, null, enchantment));
            }
        }

        [HarmonyLib.HarmonyPatch(typeof(ItemEntityShield), HarmonyLib.MethodType.Constructor, new Type[] { typeof(BlueprintItemShield) })]
        private static class ItemEntityShieldPatch {
            private static void Postfix(ItemEntityShield __instance) {
                if (__instance.WeaponComponent != null) {
                    foreach (var enchantment in __instance.ArmorComponent.Enchantments) {
                        foreach (var component in enchantment.Components) {
                            if (component is BashingLogic logic) {
                                logic.AddWeaponEnchantment(__instance.WeaponComponent, enchantment.Blueprint);
                                break;
                            }
                        }
                    }
                }
            }
        }

        [HarmonyLib.HarmonyPatch(typeof(ItemEntityShield), "PostLoad")]
        private static class ItemEntityShieldPostLoadPatch {
            private static void Postfix(ItemEntityShield __instance) {
                if (__instance.WeaponComponent != null) {
                    foreach (var enchantment in __instance.ArmorComponent.Enchantments) {
                        foreach (var component in enchantment.Components) {
                            if (component is BashingLogic logic) {
                                logic.AddWeaponEnchantment(__instance.WeaponComponent, enchantment.Blueprint);
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}