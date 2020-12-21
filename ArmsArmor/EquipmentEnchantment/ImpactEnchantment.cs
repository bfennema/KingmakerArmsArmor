using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Localization;
using UnityEngine;

namespace ArmsArmor
{
	public class ImpactEnchantment {
		static BlueprintEquipmentEnchantment blueprint = null;

		static public BlueprintEquipmentEnchantment GetBlueprint() {
			if (!blueprint) {
				blueprint = ScriptableObject.CreateInstance<BlueprintEquipmentEnchantment>();
				Helpers.BlueprintItemEnchantmentEnchantName(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.ImpactEnchantment);
				Helpers.BlueprintItemEnchantmentDescription(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.ImpactEnchantmentDescription);
				Helpers.BlueprintItemEnchantmentPrefix(blueprint) = new LocalizedString();
				Helpers.BlueprintItemEnchantmentSuffix(blueprint) = new LocalizedString();
				Helpers.BlueprintItemEnchantmentIdentifyDC(blueprint) = 5;
				blueprint.ComponentsArray = new BlueprintComponent[] { ScriptableObject.CreateInstance<ImpactLogic>() };
				Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = CustomGuids.ImpactEnchantment;
				blueprint.name = "ImpactEnchantment";
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