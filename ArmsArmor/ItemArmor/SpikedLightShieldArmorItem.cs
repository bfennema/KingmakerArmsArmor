using System;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Enums;
using Kingmaker.Localization;
using UnityEngine;

namespace ArmsArmor
{
	public class SpikedLightShieldArmorItem {
		static readonly string guid = "257976116c8f4f7aa92999bbe52fa2ea";
		static BlueprintItemArmor blueprint = null;

		static public BlueprintItemArmor GetBlueprint() {
			if (!blueprint) {
				blueprint = ScriptableObject.CreateInstance<BlueprintItemArmor>();
				Helpers.BlueprintItemArmorType(blueprint) = ResourcesLibrary.TryGetBlueprint<BlueprintArmorType>("d38e8ea23ce653c4582eb3e002555483");
				Helpers.BlueprintItemArmorSize(blueprint) = Size.Medium;
				Helpers.BlueprintItemArmorEnchantments(blueprint) = Array.Empty<BlueprintArmorEnchantment>();
				Helpers.BlueprintItemArmorVisualParameters(blueprint) = new ArmorVisualParameters();
				Helpers.BlueprintItemDisplayNameText(blueprint) = new LocalizedString();
				Helpers.BlueprintItemDescriptionText(blueprint) = new LocalizedString();
				Helpers.BlueprintItemFlavorText(blueprint) = new LocalizedString();
				Helpers.BlueprintItemNonIdentifiedNameText(blueprint) = new LocalizedString();
				Helpers.BlueprintItemNonIdentifiedDescriptionText(blueprint) = new LocalizedString();
				Helpers.BlueprintItemCost(blueprint) = 20;
				Helpers.BlueprintItemWeight(blueprint) = 11.0f;
				Helpers.BlueprintItemInventoryPutSound(blueprint) = "ShieldPut";
				Helpers.BlueprintItemInventoryTakeSound(blueprint) = "ShieldTake";
				blueprint.ComponentsArray = null;
				Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = guid;
				blueprint.name = "SpikedLightShieldArmorItem";
				ResourcesLibrary.LibraryObject.BlueprintsByAssetId?.Add(blueprint.AssetGuid, blueprint);
				ResourcesLibrary.LibraryObject.GetAllBlueprints()?.Add(blueprint);
			}
			return blueprint;
		}

		static public void Init() {
			GetBlueprint();
		}
	}
}