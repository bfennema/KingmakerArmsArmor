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
		static readonly string guid = "ac6146fda25146e8b0f181cbdd8ae34d";
		static BlueprintWeaponType blueprint = null;
		static readonly public WeaponCategory WeaponCategoryTempleSword = WeaponCategory.ThrowingAxe + 1;

		static public BlueprintWeaponType GetBlueprint() {
			if (!blueprint) {
				blueprint = ScriptableObject.CreateInstance<BlueprintWeaponType>();
				Helpers.BlueprintWeaponTypeTypeNameText(blueprint) = LocalizedStringHelper.GetLocalizedString("5f26093f-af20-4c9f-99f3-b05f857f82bb");
				Helpers.BlueprintWeaponTypeDefaultNameText(blueprint) = LocalizedStringHelper.GetLocalizedString("5f26093f-af20-4c9f-99f3-b05f857f82bb");
				Helpers.BlueprintWeaponTypeDescriptionText(blueprint) = new LocalizedString();
				Helpers.BlueprintWeaponTypeMasterworkDescriptionText(blueprint) = new LocalizedString();
				Helpers.BlueprintWeaponTypeMagicDescriptionText(blueprint) = new LocalizedString();
				CopyFromBlueprint(blueprint, "ec2da496c7936e14c9a28ce616a6b4cd");
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
				Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = guid;
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
			WeaponEntry entry = new WeaponEntry { Proficiency = WeaponCategoryTempleSword, Text = LocalizedStringHelper.GetLocalizedString("5f26093f-af20-4c9f-99f3-b05f857f82bb") };
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
			private static void Postfix(WeaponCategory category, WeaponSubCategory subCategory, ref bool __result) {
				if (category == WeaponCategory.ThrowingAxe + 1) {
					if (GetSubCategories().HasItem(subCategory)) {
						__result = true;
					}
				}
			}
		}

		[HarmonyLib.HarmonyPatch(typeof(WeaponCategoryExtension), "GetSubCategories")]
		private static class WeaponCategoryExtensionGetSubCategoriesPatch {
			private static void Postfix(WeaponCategory category, ref WeaponSubCategory[] __result) {
				if (category == WeaponCategoryTempleSword) {
					__result = GetSubCategories();
				}
			}
		}

		[HarmonyLib.HarmonyPatch(typeof(Enum), "ToString", new Type[] { })]
		private static class EnumToStringPatch {
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

		[HarmonyLib.HarmonyPatch]
		private static class EnumUtilsGetValuesWeaponCategoryPatch {
			static MethodBase TargetMethod() {
				return HarmonyLib.AccessTools.Method(typeof(EnumUtils), "GetValues").MakeGenericMethod(typeof(WeaponCategory));
			}
			static void Postfix(ref IEnumerable<WeaponCategory> __result) {
				var list = __result.ToList();
				list.Add(WeaponCategoryTempleSword);
				__result = list;
			}
		}

		[HarmonyLib.HarmonyPatch(typeof(UnitViewHandSlotData), "OwnerWeaponScale", HarmonyLib.MethodType.Getter)]
		private static class UnitViewHandSlotDataWeaponScalePatch {
			private static void Postfix(UnitViewHandSlotData __instance, ref float __result) {
				if (__instance.VisibleItem is ItemEntityWeapon weapon && weapon.Blueprint.Type.AssetGuid == guid) {
					__result *= 4.0f / 3.0f;
				}
			}
		}
	}
}