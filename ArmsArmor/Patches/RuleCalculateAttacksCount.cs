using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Items;
using Kingmaker.Items.Slots;
using Kingmaker.RuleSystem.Rules;

namespace ArmsArmor
{
    public class RuleCalculateAttacksCountPatch {
        [HarmonyLib.HarmonyPatch(typeof(RuleCalculateAttacksCount), "OnTrigger")]
        private static class RuleCalculateAttacksCountOnTriggerPatch {
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
                    if (inst.opcode == OpCodes.Callvirt && inst.operand as MethodInfo == methodToFind) {
                        yield return new HarmonyLib.CodeInstruction(OpCodes.Call, new Func<HandSlot, ItemEntityShield>(MaybeShield).Method);
                    } else {
                        yield return inst;
                    }
                }
            }
        }

        [HarmonyLib.HarmonyPatch(typeof(RuleCalculateAttacksCount), "AddExtraAttacks")]
        private static class RuleCalculateAttacksCountAddExtraAttacksPatch {
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
                    if (inst.opcode == OpCodes.Callvirt && inst.operand as MethodInfo == methodToFind) {
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