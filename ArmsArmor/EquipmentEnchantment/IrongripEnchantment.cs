using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Designers.Mechanics.EquipmentEnchants;
using Kingmaker.Localization;
using UnityEngine;

namespace ArmsArmor
{
	public class IrongripEnchantment {
		static BlueprintEquipmentEnchantment blueprint = null;

		static public BlueprintEquipmentEnchantment GetBlueprint() {
			if (!blueprint) {
				blueprint = ScriptableObject.CreateInstance<BlueprintEquipmentEnchantment>();
				Helpers.BlueprintItemEnchantmentEnchantName(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.IrongripEnchantment);
				Helpers.BlueprintItemEnchantmentDescription(blueprint) = new LocalizedString();
				Helpers.BlueprintItemEnchantmentPrefix(blueprint) = new LocalizedString();
				Helpers.BlueprintItemEnchantmentSuffix(blueprint) = new LocalizedString();
				Helpers.BlueprintItemEnchantmentIdentifyDC(blueprint) = 5;
				blueprint.ComponentsArray = new BlueprintComponent[] { GetComponent() };
				Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = CustomGuids.IrongripEnchantment;
				blueprint.name = "IrongripEnchantment";
				ResourcesLibrary.LibraryObject.BlueprintsByAssetId?.Add(blueprint.AssetGuid, blueprint);
				ResourcesLibrary.LibraryObject.GetAllBlueprints()?.Add(blueprint);
			}
			return blueprint;
		}

		static private AddUnitFactEquipment GetComponent() {
			var component = ScriptableObject.CreateInstance<AddUnitFactEquipment>();
			component.Blueprint = ReduceOversizedPenalty.GetBlueprint();
			component.name = "$AddUnitFactEquipment$c2b9d840-4018-4864-80d9-772080008921";
			return component;
		}
	}
}