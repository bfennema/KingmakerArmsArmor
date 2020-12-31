using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Localization;
using UnityEngine;

namespace ArmsArmor
{
    public class BashingEnchantment {
        static BlueprintArmorEnchantment blueprint = null;

        static public BlueprintArmorEnchantment GetBlueprint() {
            if (!blueprint) {
                blueprint = ScriptableObject.CreateInstance<BlueprintArmorEnchantment>();
                Helpers.BlueprintItemEnchantmentEnchantName(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.BashingEnchantment);
                Helpers.BlueprintItemEnchantmentDescription(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.BashingEnchantmentDescription);
                Helpers.BlueprintItemEnchantmentPrefix(blueprint) = new LocalizedString();
                Helpers.BlueprintItemEnchantmentSuffix(blueprint) = new LocalizedString();
                Helpers.BlueprintItemEnchantmentIdentifyDC(blueprint) = 5;
                blueprint.ComponentsArray = new BlueprintComponent[] { ScriptableObject.CreateInstance<BashingLogic>() };
                Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = CustomGuids.BashingEnchantment;
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