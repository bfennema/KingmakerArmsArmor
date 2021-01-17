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
    public class TempleSword {
        static BlueprintWeaponType blueprint = null;
        static readonly public WeaponCategory WeaponCategoryTempleSword = WeaponCategory.ThrowingAxe + 1;

        static public BlueprintWeaponType GetBlueprint() {
            if (!blueprint) {
                blueprint = ScriptableObject.CreateInstance<BlueprintWeaponType>();
                Helpers.BlueprintWeaponTypeTypeNameText(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.TempleSword);
                Helpers.BlueprintWeaponTypeDefaultNameText(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.TempleSword);
                Helpers.BlueprintWeaponTypeDescriptionText(blueprint) = new LocalizedString();
                Helpers.BlueprintWeaponTypeMasterworkDescriptionText(blueprint) = new LocalizedString();
                Helpers.BlueprintWeaponTypeMagicDescriptionText(blueprint) = new LocalizedString();
                CopyFromBlueprint(blueprint, ExistingGuids.Sickle);
                Helpers.BlueprintWeaponTypeAttackRange(blueprint) = 5.Feet();
                Helpers.BlueprintWeaponTypeBaseDamage(blueprint) = new DiceFormula(1, DiceType.D8);
                Helpers.BlueprintWeaponTypeDamageType(blueprint) = new DamageTypeDescription { Type = DamageType.Physical };
                Helpers.BlueprintWeaponTypeCriticalRollEdge(blueprint) = 19;
                Helpers.BlueprintWeaponTypeCriticalModifier(blueprint) = DamageCriticalModifierType.X2;
                Helpers.BlueprintWeaponTypeFighterGroup(blueprint) = WeaponFighterGroup.BladesHeavy;
                Helpers.BlueprintWeaponTypeWeight(blueprint) = 3.0f;
                Helpers.BlueprintWeaponTypeIsLight(blueprint) = false;
                Helpers.BlueprintWeaponTypeIsMonk(blueprint) = true;
                blueprint.Category = WeaponCategoryTempleSword;
                Helpers.BlueprintWeaponTypeEnchantments(blueprint) = new BlueprintWeaponEnchantment[0];
                blueprint.ComponentsArray = null;
                Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = CustomGuids.TempleSword;
                blueprint.name = "TempleSword";
                ResourcesLibrary.LibraryObject.BlueprintsByAssetId?.Add(blueprint.AssetGuid, blueprint);
                ResourcesLibrary.LibraryObject.GetAllBlueprints()?.Add(blueprint);
            }
            return blueprint;
        }

        static public void CopyFromBlueprint(BlueprintWeaponType weapon, string guid) {
            var copyFromBlueprint = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>(guid);
            Helpers.BlueprintWeaponTypeIcon(weapon) = copyFromBlueprint.Icon;
            Helpers.BlueprintWeaponTypeVisualParameters(weapon) = copyFromBlueprint.VisualParameters;
            var model = weapon.VisualParameters.Model;
            var equipmentOffsets = model.GetComponent<EquipmentOffsets>();
            var locator = new GameObject();
            locator.transform.SetParent(model.transform);
            locator.transform.localPosition = new Vector3(0.0f, -0.10f, 0.025f);
            locator.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            locator.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            equipmentOffsets.IkTargetLeftHand = locator.transform;
        }

        static public void Init() {
            GetBlueprint();
            WeaponEntry entry = new WeaponEntry { Proficiency = WeaponCategoryTempleSword, Text = LocalizedStringHelper.GetLocalizedString(StringGuids.TempleSword) };
            var entries = LocalizedTexts.Instance.Stats.WeaponEntries.ToList();
            entries.Add(entry);
            LocalizedTexts.Instance.Stats.WeaponEntries = entries.ToArray();
        }

        static WeaponSubCategory[] GetSubCategories() {
            return new WeaponSubCategory[] {
                WeaponSubCategory.Melee,
                WeaponSubCategory.Metal,
                WeaponSubCategory.Monk,
                WeaponSubCategory.OneHandedSlashing,
                WeaponSubCategory.Exotic,
            };
        }

        [HarmonyLib.HarmonyPatch(typeof(WeaponCategoryExtension), "HasSubCategory")]
        private static class WeaponCategoryExtensionHasSubCategoryPatch {
            private static bool Prepare() {
                if (Main.ModSettings.TempleSword == false) {
                    return false;
                } else {
                    return true;
                }
            }
            private static void Postfix(WeaponCategory category, WeaponSubCategory subCategory, ref bool __result) {
                if (category == WeaponCategoryTempleSword) {
                    if (GetSubCategories().HasItem(subCategory)) {
                        __result = true;
                    }
                }
            }
        }

        [HarmonyLib.HarmonyPatch(typeof(WeaponCategoryExtension), "GetSubCategories")]
        private static class WeaponCategoryExtensionGetSubCategoriesPatch {
            private static bool Prepare() {
                if (Main.ModSettings.TempleSword == false) {
                    return false;
                } else {
                    return true;
                }
            }
            private static void Postfix(WeaponCategory category, ref WeaponSubCategory[] __result) {
                if (category == WeaponCategoryTempleSword) {
                    __result = GetSubCategories();
                }
            }
        }

        [HarmonyLib.HarmonyPatch(typeof(Enum), "ToString", new Type[] { })]
        private static class EnumToStringPatch {
            private static bool Prepare() {
                if (Main.ModSettings.TempleSword == false) {
                    return false;
                } else {
                    return true;
                }
            }
            private static bool Prefix(Enum __instance, ref string __result) {
                if (__instance is WeaponCategory category) {
                    if (category == WeaponCategoryTempleSword) {
                        __result = "TempleSword";
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
                if (Main.ModSettings.TempleSword == false) {
                    return false;
                } else {
                    return true;
                }
            }
            private static bool Prefix(Type enumType, string value, bool ignoreCase, ref object __result) {
                if (enumType == typeof(WeaponCategory)) {
                    if (ignoreCase && value.ToLower() == "templesword" || !ignoreCase && value == "TempleSword") {
                        __result = WeaponCategoryTempleSword;
                        return false;
                    }
                }
                return true;
            }
        }

        [HarmonyLib.HarmonyPatch(typeof(Enum), "GetValues", new Type[] { typeof(Type) })]
        private static class EnumGetValuesPatch {
            private static bool Prepare() {
                if (Main.ModSettings.TempleSword == false) {
                    return false;
                } else {
                    return true;
                }
            }
            static void Postfix(Type enumType, ref Array __result) {
                if (enumType == typeof(WeaponCategory)) {
                    __result = __result.OfType<WeaponCategory>().Append(WeaponCategoryTempleSword).ToArray();
                }
            }
        }

        [HarmonyLib.HarmonyPatch(typeof(UnitViewHandSlotData), "OwnerWeaponScale", HarmonyLib.MethodType.Getter)]
        private static class UnitViewHandSlotDataWeaponScalePatch {
            private static bool Prepare() {
                if (Main.ModSettings.TempleSword == false) {
                    return false;
                } else {
                    return true;
                }
            }
            private static void Postfix(UnitViewHandSlotData __instance, ref float __result) {
                if (__instance.VisibleItem is ItemEntityWeapon weapon && weapon.Blueprint.Type.AssetGuid == CustomGuids.TempleSword) {
                    __result *= 4.0f / 3.0f;
                }
            }
        }
    }
}