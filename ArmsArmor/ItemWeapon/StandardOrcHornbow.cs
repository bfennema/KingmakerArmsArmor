using System;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.Localization;
using Kingmaker.RuleSystem.Rules.Damage;
using UnityEngine;

namespace ArmsArmor
{
    public class StandardOrcHornbow {
        static BlueprintItemWeapon blueprint = null;

        static public BlueprintItemWeapon GetBlueprint() {
            if (!blueprint) {
                blueprint = ScriptableObject.CreateInstance<BlueprintItemWeapon>();
                Helpers.BlueprintItemWeaponType(blueprint) = OrcHornbow.GetBlueprint();
                Helpers.BlueprintItemWeaponSize(blueprint) = Size.Medium;
                Helpers.BlueprintItemWeaponEnchantments(blueprint) = Array.Empty<BlueprintWeaponEnchantment>();
                Helpers.BlueprintItemWeaponDamageType(blueprint) = new DamageTypeDescription { Type = DamageType.Physical, Physical = new DamageTypeDescription.PhysicalData { Form = PhysicalDamageForm.Piercing } };
                CopyFromBlueprint(blueprint, ExistingGuids.StandardCompositeLongbow);
                Helpers.BlueprintItemDisplayNameText(blueprint) = new LocalizedString();
                Helpers.BlueprintItemDescriptionText(blueprint) = new LocalizedString();
                Helpers.BlueprintItemFlavorText(blueprint) = new LocalizedString();
                Helpers.BlueprintItemNonIdentifiedNameText(blueprint) = new LocalizedString();
                Helpers.BlueprintItemNonIdentifiedDescriptionText(blueprint) = new LocalizedString();
                Helpers.BlueprintItemCost(blueprint) = 520;
                blueprint.ComponentsArray = null;
                Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = CustomGuids.StandardOrcHornbow;
                blueprint.name = "StandardOrcHornbow";
                ResourcesLibrary.LibraryObject.BlueprintsByAssetId?.Add(blueprint.AssetGuid, blueprint);
                ResourcesLibrary.LibraryObject.GetAllBlueprints()?.Add(blueprint);
            }
            return blueprint;
        }
        static public void CopyFromBlueprint(BlueprintItemWeapon weapon, string guid) {
            var copyFromBlueprint = ResourcesLibrary.TryGetBlueprint<BlueprintItemWeapon>(guid);
            Helpers.BlueprintItemEquipmentHandVisualParameters(weapon) = copyFromBlueprint.VisualParameters;
        }

        static public void Init() {
            GetBlueprint();
        }
    }
}