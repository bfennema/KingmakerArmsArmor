using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Shields;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Localization;
using UnityEngine;

namespace ArmsArmor
{
	public class SpikedLightShieldBashingPlus1 {
		static BlueprintItemShield blueprint = null;

		static public BlueprintItemShield GetBlueprint() {
			if (!blueprint) {
				blueprint = ScriptableObject.CreateInstance<BlueprintItemShield>();
				Helpers.BlueprintItemShieldArmorComponent(blueprint) = SpikedLightShieldBashingPlus1ArmorItem.GetBlueprint();
				Helpers.BlueprintItemShieldWeaponComponent(blueprint) = ResourcesLibrary.TryGetBlueprint<BlueprintItemWeapon>(ExistingGuids.StandardSpikedLightShield);
				CopyFromBlueprint(blueprint, ExistingGuids.VenomousLimbShieldItem);
				Helpers.BlueprintItemDisplayNameText(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.SpikedLightShieldBashingPlus1);
				Helpers.BlueprintItemDescriptionText(blueprint) = new LocalizedString();
				Helpers.BlueprintItemFlavorText(blueprint) = new LocalizedString();
				Helpers.BlueprintItemNonIdentifiedNameText(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.SpikedLightShield);
				Helpers.BlueprintItemNonIdentifiedDescriptionText(blueprint) = new LocalizedString();
				Helpers.BlueprintItemCost(blueprint) = 30;
				Helpers.BlueprintItemInventoryPutSound(blueprint) = "ShieldPut";
				Helpers.BlueprintItemInventoryTakeSound(blueprint) = "ShieldTake";
				blueprint.ComponentsArray = null;
				Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = CustomGuids.SpikedLightShieldBashingPlus1;
				blueprint.name = "SpikedLightShieldBashingPlus1";
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