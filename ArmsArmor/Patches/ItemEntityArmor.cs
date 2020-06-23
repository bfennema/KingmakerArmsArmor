using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Designers.Mechanics.EquipmentEnchants;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Items;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using static ArmsArmor.ItemEntityPatch;

namespace ArmsArmor
{
    class ItemEntityArmorPatch {
        [HarmonyLib.HarmonyPatch(typeof(ItemEntityArmor), "RecalculateStats")]
        private static class ItemEntityArmorRecalculateStats {
            static MethodInfo methodToFind;
            static MethodInfo methodToReplace;
            static HarmonyLib.FastInvokeHandler methodToInvoke;
            static BlueprintArmorEnchantment towerShieldEnchantment;
            private static bool Prepare() {
                try {
                    methodToFind = HarmonyLib.AccessTools.Property(typeof(RuleCalculateArmorCheckPenalty), nameof(RuleCalculateArmorCheckPenalty.Penalty)).GetGetMethod();
                    methodToReplace = HarmonyLib.AccessTools.Method(typeof(ItemEntityArmor), "AddModifier", new Type[] { typeof(ModifiableValueSkill), typeof(int) });
                    methodToInvoke = HarmonyLib.MethodInvoker.GetHandler(methodToReplace);
                }
                catch (Exception ex) {
                    Main.ModEntry.Logger.Log($"Error Preparing: {ex.Message}");
                    return false;
                }
                return true;
            }
            private static IEnumerable<HarmonyLib.CodeInstruction> Transpiler(IEnumerable<HarmonyLib.CodeInstruction> instructions) {
                bool found = false;
                foreach (var inst in instructions) {
                    if (inst.opcode == OpCodes.Callvirt && inst.operand as MethodInfo == methodToFind) {
                        found = true;
                        yield return inst;
                    } else if (found == true && inst.opcode == OpCodes.Call && inst.operand as MethodInfo == methodToReplace) {
                        found = false;
                        yield return new HarmonyLib.CodeInstruction(OpCodes.Call, new Action<ItemEntityArmor, ModifiableValueSkill, int>(AddModifier).Method);
                    } else {
                        yield return inst;
                    }
                }
            }
            private static void AddModifier(ItemEntityArmor armor, ModifiableValueSkill skill, int penalty) {
                if (!towerShieldEnchantment) {
                    towerShieldEnchantment = ResourcesLibrary.TryGetBlueprint<BlueprintArmorEnchantment>("f6b1f4378dd64044db145a1c2afa589f");
                }
                methodToInvoke.Invoke(armor, new object[] { skill, penalty });
                if (armor.Wielder.IsPlayerFaction
                    && !armor.Wielder.Body.IsPolymorphed
                    && !armor.Wielder.Proficiencies.Contains(armor.Blueprint.ProficiencyGroup)) {
                    var adj = 0;
                    if (armor.Blueprint.ProficiencyGroup == ArmorProficiencyGroup.TowerShield && armor.Blueprint.Enchantments.Contains(towerShieldEnchantment)) {
                        var component = towerShieldEnchantment.GetComponent<AddStatBonusEquipment>();
                        if (component != null && component.Descriptor == ModifierDescriptor.Shield && component.Stat == StatType.AdditionalAttackBonus) {
                            adj = component.Value;
                        }
                    }
                    methodToInvoke.Invoke(armor, new object[] { armor.Wielder.Stats.AdditionalAttackBonus, penalty + adj});
                    methodToInvoke.Invoke(armor, new object[] { armor.Wielder.Stats.Initiative, penalty });
                }
            }
        }

        [HarmonyLib.HarmonyPatch(typeof(ItemEntityArmor), "CanBeEquippedInternal", new Type[] { typeof(UnitDescriptor) })]
        private static class ItemEntityArmorCanBeEquippedInternalPatch {
            private static bool Prepare() {
                if (Main.ModSettings.EquipArmorWithoutProficiency == false) {
                    return false;
                } else {
                    return true;
                }
            }
            private static void Postfix(ItemEntityArmor __instance, UnitDescriptor owner, ref bool __result) {
                if (__result == false) {
                    __result = ItemEntityCanBeEquippedInternalReversePatch.CanBeEquippedInternal(__instance, owner);
                }
            }
        }
    }
}