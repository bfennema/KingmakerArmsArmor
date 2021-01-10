using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Shields;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Localization;
using UnityEngine;

namespace ArmsArmor
{
    public class SpikedHeavyShieldBashingPlus1 {
        static BlueprintItemShield blueprint = null;

        static public BlueprintItemShield GetBlueprint() {
            if (!blueprint) {
                blueprint = ScriptableObject.CreateInstance<BlueprintItemShield>();
                Helpers.BlueprintItemShieldArmorComponent(blueprint) = SpikedHeavyShieldBashingPlus1ArmorItem.GetBlueprint();
                Helpers.BlueprintItemShieldWeaponComponent(blueprint) = ResourcesLibrary.TryGetBlueprint<BlueprintItemWeapon>(ExistingGuids.StandardSpikedHeavyShield);
                CopyFromBlueprint(blueprint, ExistingGuids.WildGuardianShieldItem);
                Helpers.BlueprintItemDisplayNameText(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.SpikedHeavyShieldBashingPlus1);
                Helpers.BlueprintItemDescriptionText(blueprint) = new LocalizedString();
                Helpers.BlueprintItemFlavorText(blueprint) = new LocalizedString();
                Helpers.BlueprintItemNonIdentifiedNameText(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.SpikedHeavyShield);
                Helpers.BlueprintItemNonIdentifiedDescriptionText(blueprint) = new LocalizedString();
                Helpers.BlueprintItemCost(blueprint) = 4180;
                Helpers.BlueprintItemInventoryPutSound(blueprint) = "ShieldPut";
                Helpers.BlueprintItemInventoryTakeSound(blueprint) = "ShieldTake";
                blueprint.ComponentsArray = null;
                Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = CustomGuids.SpikedHeavyShieldBashingPlus1;
                blueprint.name = "SpikedHeavyShieldBashingPlus1";
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