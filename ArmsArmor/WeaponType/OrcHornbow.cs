using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Blueprints.Root;
using Kingmaker.Blueprints.Root.Strings;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.Items;
using Kingmaker.Localization;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.Utility;
using Kingmaker.View.Equipment;
using UnityEngine;

namespace ArmsArmor
{
    public class OrcHornbow {
        static BlueprintWeaponType blueprint = null;
        static readonly public WeaponCategory WeaponCategoryOrcHornbow = TempleSword.WeaponCategoryTempleSword + 1;

        static public BlueprintWeaponType GetBlueprint() {
            if (!blueprint) {
                blueprint = ScriptableObject.CreateInstance<BlueprintWeaponType>();
                Helpers.BlueprintWeaponTypeTypeNameText(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.OrcHornbow);
                Helpers.BlueprintWeaponTypeDefaultNameText(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.OrcHornbow);
                Helpers.BlueprintWeaponTypeDescriptionText(blueprint) = new LocalizedString();
                Helpers.BlueprintWeaponTypeMasterworkDescriptionText(blueprint) = new LocalizedString();
                Helpers.BlueprintWeaponTypeMagicDescriptionText(blueprint) = new LocalizedString();
                CopyFromBlueprint(blueprint, ExistingGuids.CompositeLongbow);
                Helpers.BlueprintWeaponTypeAttackType(blueprint) = AttackType.Ranged;
                Helpers.BlueprintWeaponTypeAttackRange(blueprint) = 45.Feet();
                Helpers.BlueprintWeaponTypeBaseDamage(blueprint) = new DiceFormula(2, DiceType.D6);
                Helpers.BlueprintWeaponTypeDamageType(blueprint) = new DamageTypeDescription { Type = DamageType.Physical, Physical = new DamageTypeDescription.PhysicalData { Form = PhysicalDamageForm.Piercing } };
                Helpers.BlueprintWeaponTypeCriticalRollEdge(blueprint) = 20;
                Helpers.BlueprintWeaponTypeCriticalModifier(blueprint) = DamageCriticalModifierType.X3;
                Helpers.BlueprintWeaponTypeFighterGroup(blueprint) = WeaponFighterGroup.Bows;
                Helpers.BlueprintWeaponTypeWeight(blueprint) = 7.0f;
                Helpers.BlueprintWeaponTypeIsTwoHanded(blueprint) = true;
                Helpers.BlueprintWeaponTypeIsLight(blueprint) = false;
                Helpers.BlueprintWeaponTypeIsMonk(blueprint) = false;
                blueprint.Category = WeaponCategoryOrcHornbow;
                Helpers.BlueprintWeaponTypeEnchantments(blueprint) = new BlueprintWeaponEnchantment[] {
                    ResourcesLibrary.TryGetBlueprint<BlueprintWeaponEnchantment>(ExistingGuids.StrengthComposite),
                };
                blueprint.ComponentsArray = null;
                Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = CustomGuids.OrcHornbow;
                blueprint.name = "OrcHornbow";
                ResourcesLibrary.LibraryObject.BlueprintsByAssetId?.Add(blueprint.AssetGuid, blueprint);
                ResourcesLibrary.LibraryObject.GetAllBlueprints()?.Add(blueprint);
            }
            return blueprint;
        }

        static public void CopyFromBlueprint(BlueprintWeaponType weapon, string guid) {
            var copyFromBlueprint = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>(guid);
            Helpers.BlueprintWeaponTypeIcon(weapon) = copyFromBlueprint.Icon;
            Helpers.BlueprintWeaponTypeVisualParameters(weapon) = copyFromBlueprint.VisualParameters;
        }

        static public void Init() {
            GetBlueprint();
            WeaponEntry entry = new WeaponEntry { Proficiency = WeaponCategoryOrcHornbow, Text = LocalizedStringHelper.GetLocalizedString(StringGuids.OrcHornbow) };
            var entries = LocalizedTexts.Instance.Stats.WeaponEntries.ToList();
            entries.Add(entry);
            LocalizedTexts.Instance.Stats.WeaponEntries = entries.ToArray();
        }

        static WeaponSubCategory[] GetSubCategories() {
            return new WeaponSubCategory[] {
                WeaponSubCategory.Ranged,
                WeaponSubCategory.Metal,
                WeaponSubCategory.Exotic,
            };
        }

        [HarmonyLib.HarmonyPatch(typeof(WeaponCategoryExtension), "HasSubCategory")]
        private static class WeaponCategoryExtensionHasSubCategoryPatch {
            private static bool Prepare() {
                if (Main.ModSettings.OrcHornbow == false) {
                    return false;
                } else {
                    return true;
                }
            }
            private static void Postfix(WeaponCategory category, WeaponSubCategory subCategory, ref bool __result) {
                if (category == WeaponCategoryOrcHornbow) {
                    if (GetSubCategories().HasItem(subCategory)) {
                        __result = true;
                    }
                }
            }
        }

        [HarmonyLib.HarmonyPatch(typeof(WeaponCategoryExtension), "GetSubCategories")]
        private static class WeaponCategoryExtensionGetSubCategoriesPatch {
            private static bool Prepare() {
                if (Main.ModSettings.OrcHornbow == false) {
                    return false;
                } else {
                    return true;
                }
            }
            private static void Postfix(WeaponCategory category, ref WeaponSubCategory[] __result) {
                if (category == WeaponCategoryOrcHornbow) {
                    __result = GetSubCategories();
                }
            }
        }

        [HarmonyLib.HarmonyPatch(typeof(Enum), "ToString", new Type[] { })]
        private static class EnumToStringPatch {
            private static bool Prepare() {
                if (Main.ModSettings.OrcHornbow == false) {
                    return false;
                } else {
                    return true;
                }
            }
            private static bool Prefix(Enum __instance, ref string __result) {
                if (__instance is WeaponCategory category) {
                    if (category == WeaponCategoryOrcHornbow) {
                        __result = "OrcHornbow";
                        return false;
                    }
                }
                return true;
            }
        }

        //System.Type enumType, System.String value, System.Boolean ignoreCase, System.Enum+EnumResult& parseResult
        [HarmonyLib.HarmonyPatch(typeof(Enum), "Parse", new Type[] { typeof(Type), typeof(string), typeof(bool) })]
        private static class EnumParsePatch {
            private static bool Prepare() {
                if (Main.ModSettings.OrcHornbow == false) {
                    return false;
                } else {
                    return true;
                }
            }
            private static bool Prefix(Type enumType, string value, bool ignoreCase, ref object __result) {
                if (enumType == typeof(WeaponCategory)) {
                    if (ignoreCase && value.ToLower() == "orchornbow" || !ignoreCase && value == "OrcHornbow") {
                        __result = WeaponCategoryOrcHornbow;
                        return false;
                    }
                }
                return true;
            }
        }

        [HarmonyLib.HarmonyPatch]
        private static class EnumUtilsGetValuesWeaponCategoryPatch {
            private static bool Prepare() {
                if (Main.ModSettings.OrcHornbow == false) {
                    return false;
                } else {
                    return true;
                }
            }
            static MethodBase TargetMethod() {
                return HarmonyLib.AccessTools.Method(typeof(EnumUtils), "GetValues").MakeGenericMethod(typeof(WeaponCategory));
            }
            static void Postfix(ref IEnumerable<WeaponCategory> __result) {
                var list = __result.ToList();
                list.Add(WeaponCategoryOrcHornbow);
                __result = list;
            }
        }

        [HarmonyLib.HarmonyPatch(typeof(UnitViewHandSlotData), "OwnerWeaponScale", HarmonyLib.MethodType.Getter)]
        private static class UnitViewHandSlotDataWeaponScalePatch {
            private static bool Prepare() {
                if (Main.ModSettings.OrcHornbow == false) {
                    return false;
                } else {
                    return true;
                }
            }
            private static void Postfix(UnitViewHandSlotData __instance, ref float __result) {
                if (__instance.VisibleItem is ItemEntityWeapon weapon && weapon.Blueprint.Type.AssetGuid == CustomGuids.OrcHornbow) {
                    __result *= 4.0f / 3.0f;
                }
            }
        }
    }
}