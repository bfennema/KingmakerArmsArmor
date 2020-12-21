using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Localization;
using UnityEngine;

namespace ArmsArmor
{
	public class BashingWeaponEnchantment {
		static BlueprintWeaponEnchantment blueprint = null;

		static public BlueprintWeaponEnchantment GetBlueprint() {
			if (!blueprint) {
				blueprint = ScriptableObject.CreateInstance<BlueprintWeaponEnchantment>();
				Helpers.BlueprintItemEnchantmentEnchantName(blueprint) = new LocalizedString();
				Helpers.BlueprintItemEnchantmentDescription(blueprint) = new LocalizedString();
				Helpers.BlueprintItemEnchantmentPrefix(blueprint) = new LocalizedString();
				Helpers.BlueprintItemEnchantmentSuffix(blueprint) = new LocalizedString();
				Helpers.BlueprintItemEnchantmentIdentifyDC(blueprint) = 5;
				var logic = ScriptableObject.CreateInstance<BashingWeaponLogic>();
				logic.shieldMaster = ShieldMasterFeature.GetBlueprint();
				blueprint.ComponentsArray = new BlueprintComponent[] { logic };
				Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = CustomGuids.BashingWeaponEnchantment;
				blueprint.name = "BashingWeaponEnchantment";
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