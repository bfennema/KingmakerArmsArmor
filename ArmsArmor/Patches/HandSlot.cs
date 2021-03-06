using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Items;
using Kingmaker.Items.Slots;
using Kingmaker.UnitLogic;

namespace ArmsArmor
{
    class HandSlotPatch {
        static public bool IsTwoHanded(ItemEntityWeapon weapon, UnitDescriptor owner) {
            if (weapon.Blueprint.Double ||
                ItemEntityWeaponPatch.IsTwoHanded(weapon, owner)) {
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

        [HarmonyLib.HarmonyPatch(typeof(HandSlot), "MaybeWeapon", HarmonyLib.MethodType.Getter)]
        private static class HandSlotMaybeWeaponPatch {
            static MethodInfo methodToFind;
            private static bool Prepare() {
                if (Main.ModSettings.UpsettingShieldStyle == false) {
                    return false;
                } else {
                    try {
                        methodToFind = HarmonyLib.AccessTools.Property(typeof(HandSlot), nameof(HandSlot.MaybeShield)).GetGetMethod();
                    }
                    catch (Exception ex) {
                        Main.ModEntry.Logger.Log($"Error Preparing: {ex.Message}");
                        return false;
                    }
                    return true;
                }
            }

            private static IEnumerable<HarmonyLib.CodeInstruction> Transpiler(IEnumerable<HarmonyLib.CodeInstruction> instructions, ILGenerator il) {
                foreach (var inst in instructions) {
                    if (inst.opcode == OpCodes.Call && inst.operand as MethodInfo == methodToFind) {
                        yield return new HarmonyLib.CodeInstruction(OpCodes.Call, new Func<HandSlot, ItemEntityShield>(MaybeShield).Method);
                    } else {
                        yield return inst;
                    }
                }
            }
        }

        private static ItemEntityShield MaybeShield(HandSlot slot) {
            var maybeShield = slot?.MaybeShield;
            if (maybeShield?.WeaponComponent != null) {
                if (maybeShield.Blueprint.Type.ProficiencyGroup == ArmorProficiencyGroup.Buckler) {
                    if (!slot.Owner.Buffs.HasFact(UpsettingShieldStyleBuff.GetBlueprint())) {
                        return null;
                    }
                }
            }
            return slot.MaybeShield;
        }
    }
}