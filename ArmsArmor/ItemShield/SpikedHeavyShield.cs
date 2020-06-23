using System;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Shields;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Localization;
using UnityEngine;

namespace ArmsArmor
{
	public class SpikedHeavyShield {
		static readonly string guid = "3776ede5b48a48d7975adf32e6e09f7f";
		static BlueprintItemShield blueprint = null;

		static public BlueprintItemShield GetBlueprint() {
			if (!blueprint) {
				blueprint = ScriptableObject.CreateInstance<BlueprintItemShield>();
				Helpers.BlueprintItemShieldArmorComponent(blueprint) = SpikedHeavyShieldArmorItem.GetBlueprint();
				Helpers.BlueprintItemShieldWeaponComponent(blueprint) = ResourcesLibrary.TryGetBlueprint<BlueprintItemWeapon>("7c8f6712c444cf446a4bd3b8b717cb5c");
				CopyFromBlueprint(blueprint, "05d8f2e20b09a3d43871d76424c195c6");
				Helpers.BlueprintItemDisplayNameText(blueprint) = LocalizedStringHelper.GetLocalizedString("3fa879e0-17e0-4d65-90b5-05c44e28a09c");
				Helpers.BlueprintItemDescriptionText(blueprint) = new LocalizedString();
				Helpers.BlueprintItemFlavorText(blueprint) = new LocalizedString();
				Helpers.BlueprintItemNonIdentifiedNameText(blueprint) = LocalizedStringHelper.GetLocalizedString("3fa879e0-17e0-4d65-90b5-05c44e28a09c");
				Helpers.BlueprintItemNonIdentifiedDescriptionText(blueprint) = new LocalizedString();
				Helpers.BlueprintItemCost(blueprint) = 30;
				Helpers.BlueprintItemInventoryPutSound(blueprint) = "ShieldPut";
				Helpers.BlueprintItemInventoryTakeSound(blueprint) = "ShieldTake";
				blueprint.ComponentsArray = null;
				Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = guid;
				blueprint.name = "SpikedHeavyShield";
				ResourcesLibrary.LibraryObject.BlueprintsByAssetId?.Add(blueprint.AssetGuid, blueprint);
				ResourcesLibrary.LibraryObject.GetAllBlueprints()?.Add(blueprint);
			}
			return blueprint;
		}

		static public void CopyFromBlueprint(BlueprintItemShield shield, string guid) {
			var copyFromBlueprint = ResourcesLibrary.TryGetBlueprint<BlueprintItemShield>(guid);
			Helpers.BlueprintItemIcon(shield) = copyFromBlueprint.Icon;
			Helpers.BlueprintItemEquipmentHandVisualParameters(shield) = copyFromBlueprint.VisualParameters;
		}

		static public void Init() {
			GetBlueprint();
		}
	}
}