using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Localization;
using UnityEngine;

namespace ArmsArmor
{
	public class BashingEnchantment {
		static readonly string guid = "c39f0128372d43c39224c7b3af58e0db";
		static BlueprintArmorEnchantment blueprint = null;

		static public BlueprintArmorEnchantment GetBlueprint() {
			if (!blueprint) {
				blueprint = ScriptableObject.CreateInstance<BlueprintArmorEnchantment>();
				Helpers.BlueprintItemEnchantmentEnchantName(blueprint) = LocalizedStringHelper.GetLocalizedString("3178bb0c-f6ed-4e56-9877-e5edc03fbb5d");
				Helpers.BlueprintItemEnchantmentDescription(blueprint) = LocalizedStringHelper.GetLocalizedString("4ba52894-0155-48ac-9241-bab25Fa44e17");
				Helpers.BlueprintItemEnchantmentPrefix(blueprint) = new LocalizedString();
				Helpers.BlueprintItemEnchantmentSuffix(blueprint) = new LocalizedString();
				Helpers.BlueprintItemEnchantmentIdentifyDC(blueprint) = 5;
				blueprint.ComponentsArray = new BlueprintComponent[] { ScriptableObject.CreateInstance<BashingLogic>() };
				Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = guid;
				blueprint.name = "BashingEnchantment";
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