using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Enums;
using Kingmaker.Localization;
using UnityEngine;

namespace ArmsArmor
{
    public class SpikedLightShieldArmorItem {
        static BlueprintItemArmor blueprint = null;

        static public BlueprintItemArmor GetBlueprint() {
            if (!blueprint) {
                blueprint = ScriptableObject.CreateInstance<BlueprintItemArmor>();
                Helpers.BlueprintItemArmorType(blueprint) = ResourcesLibrary.TryGetBlueprint<BlueprintArmorType>(ExistingGuids.LightShieldType);
                Helpers.BlueprintItemArmorSize(blueprint) = Size.Medium;
                Helpers.BlueprintItemArmorEnchantments(blueprint) = new BlueprintArmorEnchantment[0];
                Helpers.BlueprintItemArmorVisualParameters(blueprint) = new ArmorVisualParameters();
                Helpers.BlueprintItemDisplayNameText(blueprint) = new LocalizedString();
                Helpers.BlueprintItemDescriptionText(blueprint) = new LocalizedString();
                Helpers.BlueprintItemFlavorText(blueprint) = new LocalizedString();
                Helpers.BlueprintItemNonIdentifiedNameText(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.SpikedLightShield);
                Helpers.BlueprintItemNonIdentifiedDescriptionText(blueprint) = new LocalizedString();
                Helpers.BlueprintItemCost(blueprint) = 20;
                Helpers.BlueprintItemWeight(blueprint) = 11.0f;
                Helpers.BlueprintItemInventoryPutSound(blueprint) = "ShieldPut";
                Helpers.BlueprintItemInventoryTakeSound(blueprint) = "ShieldTake";
                blueprint.ComponentsArray = null;
                Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = CustomGuids.SpikedLightShieldArmorItem;
                blueprint.name = "SpikedLightShieldArmorItem";
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