using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Localization;
using UnityEngine;

namespace ArmsArmor
{
	public class ImpactEnchantment {
		static readonly string guid = "cd60444c55544e6299cf13839d33fb18";
		static BlueprintEquipmentEnchantment blueprint = null;

		static public BlueprintEquipmentEnchantment GetBlueprint() {
			if (!blueprint) {
				blueprint = ScriptableObject.CreateInstance<BlueprintEquipmentEnchantment>();
				Helpers.BlueprintItemEnchantmentEnchantName(blueprint) = LocalizedStringHelper.GetLocalizedString("63a4211a-3130-41f1-a80e-a7fc45427642");
				Helpers.BlueprintItemEnchantmentDescription(blueprint) = LocalizedStringHelper.GetLocalizedString("3e48795f-ebf1-4e08-88e0-ab52eabf84b9");
				Helpers.BlueprintItemEnchantmentPrefix(blueprint) = new LocalizedString();
				Helpers.BlueprintItemEnchantmentSuffix(blueprint) = new LocalizedString();
				Helpers.BlueprintItemEnchantmentIdentifyDC(blueprint) = 5;
				blueprint.ComponentsArray = new BlueprintComponent[] { ScriptableObject.CreateInstance<ImpactLogic>() };
				Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = guid;
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