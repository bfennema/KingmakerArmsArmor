using System;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Enums;
using Kingmaker.Localization;
using UnityEngine;

namespace ArmsArmor
{
	public class SpikedHeavyShieldArmorItem {
		static readonly string guid = "3179076cd62f41e1ab99a9d40375e496";
		static BlueprintItemArmor blueprint = null;

		static public BlueprintItemArmor GetBlueprint() {
			if (!blueprint) {
				blueprint = ScriptableObject.CreateInstance<BlueprintItemArmor>();
				Helpers.BlueprintItemArmorType(blueprint) = ResourcesLibrary.TryGetBlueprint<BlueprintArmorType>("d1b05b901bab9524388ebfa0435902a6");
				Helpers.BlueprintItemArmorSize(blueprint) = Size.Medium;
				Helpers.BlueprintItemArmorEnchantments(blueprint) = Array.Empty<BlueprintArmorEnchantment>();
				Helpers.BlueprintItemArmorVisualParameters(blueprint) = new ArmorVisualParameters();
				Helpers.BlueprintItemDisplayNameText(blueprint) = new LocalizedString();
				Helpers.BlueprintItemDescriptionText(blueprint) = new LocalizedString();
				Helpers.BlueprintItemFlavorText(blueprint) = new LocalizedString();
				Helpers.BlueprintItemNonIdentifiedNameText(blueprint) = new LocalizedString();
				Helpers.BlueprintItemNonIdentifiedDescriptionText(blueprint) = new LocalizedString();
				Helpers.BlueprintItemCost(blueprint) = 30;
				Helpers.BlueprintItemWeight(blueprint) = 20.0f;
				Helpers.BlueprintItemInventoryPutSound(blueprint) = "ShieldPut";
				Helpers.BlueprintItemInventoryTakeSound(blueprint) = "ShieldTake";
				blueprint.ComponentsArray = null;
				Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = guid;
				blueprint.name = "SpikedHeavyShieldArmorItem";
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