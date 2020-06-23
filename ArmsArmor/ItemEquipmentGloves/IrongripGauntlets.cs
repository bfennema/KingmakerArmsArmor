using System;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.Localization;
using Kingmaker.Visual.CharacterSystem;
using UnityEngine;

namespace ArmsArmor
{
	public class IrongripGauntlets {
		static readonly string guid = "5273400217e54e9fbe4f9a4b3cadd861";
		static BlueprintItemEquipmentGloves blueprint = null;

		static public BlueprintItemEquipmentGloves GetBlueprint() {
			if (!blueprint) {
				blueprint = ScriptableObject.CreateInstance<BlueprintItemEquipmentGloves>();
				Helpers.BlueprintItemEquipmentSimpleEnchantments(blueprint) = new BlueprintEquipmentEnchantment[] { IrongripEnchantment.GetBlueprint() };
				Helpers.BlueprintItemEquipmentSimpleInventoryEquipSound(blueprint) = "CommonPut";
				Helpers.BlueprintItemEquipmentEquipmentEntity(blueprint) = ResourcesLibrary.TryGetBlueprint<KingmakerEquipmentEntity>("95e0d5fb2c42e5642b1f2ada94e4e43e");
				Helpers.BlueprintItemDisplayNameText(blueprint) = LocalizedStringHelper.GetLocalizedString("8213446b-b0f4-47a2-b1f8-a4048fd99568");
				Helpers.BlueprintItemDescriptionText(blueprint) = LocalizedStringHelper.GetLocalizedString("490bfc6d-3898-40d7-88ab-f741f12ec4e4");
				Helpers.BlueprintItemFlavorText(blueprint) = new LocalizedString();
				Helpers.BlueprintItemNonIdentifiedNameText(blueprint) = new LocalizedString();
				Helpers.BlueprintItemNonIdentifiedDescriptionText(blueprint) = new LocalizedString();
				CopyFromBlueprint(blueprint, "ad58b472fa90da84bafe3d4e5ad2c368");
				Helpers.BlueprintItemCost(blueprint) = 4000;
				Helpers.BlueprintItemWeight(blueprint) = 2.0f;
				Helpers.BlueprintItemInventoryPutSound(blueprint) = "CommonPut";
				Helpers.BlueprintItemInventoryTakeSound(blueprint) = "CommonTake";
				blueprint.ComponentsArray = null;
				Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = guid;
				blueprint.name = "IrongripGauntlets";
				ResourcesLibrary.LibraryObject.BlueprintsByAssetId?.Add(blueprint.AssetGuid, blueprint);
				ResourcesLibrary.LibraryObject.GetAllBlueprints()?.Add(blueprint);
			}
			return blueprint;
		}

		static public void CopyFromBlueprint(BlueprintItemEquipmentGloves gloves, string guid) {
			var copyFromBlueprint = ResourcesLibrary.TryGetBlueprint<BlueprintItemEquipmentGloves>(guid);
			Helpers.BlueprintItemIcon(gloves) = copyFromBlueprint.Icon;
		}

		static public void Init() {
			GetBlueprint();
		}
	}
}