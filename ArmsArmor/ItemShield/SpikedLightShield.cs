using System;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Shields;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Localization;
using UnityEngine;

namespace ArmsArmor
{
	public class SpikedLightShield {
		static readonly string guid = "0c87000706cb41789657938773e1b279";
		static BlueprintItemShield blueprint = null;

		static public BlueprintItemShield GetBlueprint() {
			if (!blueprint) {
				blueprint = ScriptableObject.CreateInstance<BlueprintItemShield>();
				Helpers.BlueprintItemShieldArmorComponent(blueprint) = SpikedLightShieldArmorItem.GetBlueprint();
				Helpers.BlueprintItemShieldWeaponComponent(blueprint) = ResourcesLibrary.TryGetBlueprint<BlueprintItemWeapon>("b12650bdb547d7e499cdc29e913088cb");
				CopyFromBlueprint(blueprint, "5f7e85634b80177428370151feb2116b");
				Helpers.BlueprintItemDisplayNameText(blueprint) = LocalizedStringHelper.GetLocalizedString("7aa87bff-84b7-4337-9ad2-c1f6268fae0e");
				Helpers.BlueprintItemDescriptionText(blueprint) = new LocalizedString();
				Helpers.BlueprintItemFlavorText(blueprint) = new LocalizedString();
				Helpers.BlueprintItemNonIdentifiedNameText(blueprint) = LocalizedStringHelper.GetLocalizedString("7aa87bff-84b7-4337-9ad2-c1f6268fae0e");
				Helpers.BlueprintItemNonIdentifiedDescriptionText(blueprint) = new LocalizedString();
				Helpers.BlueprintItemCost(blueprint) = 20;
				Helpers.BlueprintItemInventoryPutSound(blueprint) = "ShieldPut";
				Helpers.BlueprintItemInventoryTakeSound(blueprint) = "ShieldTake";
				blueprint.ComponentsArray = null;
				Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = guid;
				blueprint.name = "SpikedLightShield";
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