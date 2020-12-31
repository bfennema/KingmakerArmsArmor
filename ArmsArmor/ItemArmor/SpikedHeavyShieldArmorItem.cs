using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Enums;
using Kingmaker.Localization;
using UnityEngine;

namespace ArmsArmor
{
    public class SpikedHeavyShieldArmorItem {
        static BlueprintItemArmor blueprint = null;

        static public BlueprintItemArmor GetBlueprint() {
            if (!blueprint) {
                blueprint = ScriptableObject.CreateInstance<BlueprintItemArmor>();
                Helpers.BlueprintItemArmorType(blueprint) = ResourcesLibrary.TryGetBlueprint<BlueprintArmorType>(ExistingGuids.HeavyShieldType);
                Helpers.BlueprintItemArmorSize(blueprint) = Size.Medium;
                Helpers.BlueprintItemArmorEnchantments(blueprint) = new BlueprintArmorEnchantment[0];
                Helpers.BlueprintItemArmorVisualParameters(blueprint) = new ArmorVisualParameters();
                Helpers.BlueprintItemDisplayNameText(blueprint) = new LocalizedString();
                Helpers.BlueprintItemDescriptionText(blueprint) = new LocalizedString();
                Helpers.BlueprintItemFlavorText(blueprint) = new LocalizedString();
                Helpers.BlueprintItemNonIdentifiedNameText(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.SpikedHeavyShield);
                Helpers.BlueprintItemNonIdentifiedDescriptionText(blueprint) = new LocalizedString();
                Helpers.BlueprintItemCost(blueprint) = 30;
                Helpers.BlueprintItemWeight(blueprint) = 20.0f;
                Helpers.BlueprintItemInventoryPutSound(blueprint) = "ShieldPut";
                Helpers.BlueprintItemInventoryTakeSound(blueprint) = "ShieldTake";
                blueprint.ComponentsArray = null;
                Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = CustomGuids.SpikedHeavyShieldArmorItem;
                blueprint.name = "SpikedHeavyShieldArmorItem";
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