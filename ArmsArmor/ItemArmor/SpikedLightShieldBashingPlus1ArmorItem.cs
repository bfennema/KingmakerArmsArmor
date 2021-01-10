using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Enums;
using Kingmaker.Localization;
using UnityEngine;

namespace ArmsArmor
{
    public class SpikedLightShieldBashingPlus1ArmorItem {
        static BlueprintItemArmor blueprint = null;

        static public BlueprintItemArmor GetBlueprint() {
            if (!blueprint) {
                blueprint = ScriptableObject.CreateInstance<BlueprintItemArmor>();
                Helpers.BlueprintItemArmorType(blueprint) = ResourcesLibrary.TryGetBlueprint<BlueprintArmorType>(ExistingGuids.LightShieldType);
                Helpers.BlueprintItemArmorSize(blueprint) = Size.Medium;
                Helpers.BlueprintItemArmorEnchantments(blueprint) = new BlueprintArmorEnchantment[] {
                    ResourcesLibrary.TryGetBlueprint<BlueprintArmorEnchantment>(ExistingGuids.ShieldEnhancementBonus1),
                    BashingEnchantment.GetBlueprint()
                };
                Helpers.BlueprintItemArmorVisualParameters(blueprint) = new ArmorVisualParameters();
                Helpers.BlueprintItemDisplayNameText(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.SpikedLightShieldBashingPlus1);
                Helpers.BlueprintItemDescriptionText(blueprint) = new LocalizedString();
                Helpers.BlueprintItemFlavorText(blueprint) = new LocalizedString();
                Helpers.BlueprintItemNonIdentifiedNameText(blueprint) = new LocalizedString();
                Helpers.BlueprintItemNonIdentifiedDescriptionText(blueprint) = new LocalizedString();
                Helpers.BlueprintItemCost(blueprint) = 4170;
                Helpers.BlueprintItemWeight(blueprint) = 11.0f;
                Helpers.BlueprintItemInventoryPutSound(blueprint) = "ShieldPut";
                Helpers.BlueprintItemInventoryTakeSound(blueprint) = "ShieldTake";
                blueprint.ComponentsArray = null;
                Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = CustomGuids.SpikedLightShieldBashingPlus1ArmorItem;
                blueprint.name = "SpikedLightShieldBashingPlus1ArmorItem";
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