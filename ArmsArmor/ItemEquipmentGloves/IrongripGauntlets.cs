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
		static BlueprintItemEquipmentGloves blueprint = null;

		static public BlueprintItemEquipmentGloves GetBlueprint() {
			if (!blueprint) {
				blueprint = ScriptableObject.CreateInstance<BlueprintItemEquipmentGloves>();
				Helpers.BlueprintItemEquipmentSimpleEnchantments(blueprint) = new BlueprintEquipmentEnchantment[] { IrongripEnchantment.GetBlueprint() };
				Helpers.BlueprintItemEquipmentSimpleInventoryEquipSound(blueprint) = "CommonPut";
				Helpers.BlueprintItemEquipmentEquipmentEntity(blueprint) = ResourcesLibrary.TryGetBlueprint<KingmakerEquipmentEntity>(ExistingGuids.KEE_Gloves_NumerianGlow);
				Helpers.BlueprintItemDisplayNameText(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.IrongripGauntlets);
				Helpers.BlueprintItemDescriptionText(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.IrongripGauntletsDescription);
				Helpers.BlueprintItemFlavorText(blueprint) = new LocalizedString();
				Helpers.BlueprintItemNonIdentifiedNameText(blueprint) = new LocalizedString();
				Helpers.BlueprintItemNonIdentifiedDescriptionText(blueprint) = new LocalizedString();
				CopyFromBlueprint(blueprint, ExistingGuids.Artifact_StarGauntletItem);
				Helpers.BlueprintItemCost(blueprint) = 4000;
				Helpers.BlueprintItemWeight(blueprint) = 2.0f;
				Helpers.BlueprintItemInventoryPutSound(blueprint) = "CommonPut";
				Helpers.BlueprintItemInventoryTakeSound(blueprint) = "CommonTake";
				blueprint.ComponentsArray = null;
				Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = CustomGuids.IrongripGauntlets;
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