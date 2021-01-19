using System.Collections.Generic;
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
        private class Template {
            public BlueprintItemWeapon blueprint = null;

            public Template(string assetGuid, string[] enchantmentGuid, string visualGuid, int value, string name) {
                blueprint = ScriptableObject.CreateInstance<BlueprintItemWeapon>();
                Helpers.BlueprintItemWeaponType(blueprint) = OrcHornbow.GetBlueprint();
                Helpers.BlueprintItemWeaponSize(blueprint) = Size.Medium;
                var enchantments = new List<BlueprintWeaponEnchantment>();
                foreach (var guid in enchantmentGuid) {
                    enchantments.Add(ResourcesLibrary.TryGetBlueprint<BlueprintWeaponEnchantment>(guid));
                }
                Helpers.BlueprintItemWeaponEnchantments(blueprint) = enchantments.ToArray();
                Helpers.BlueprintItemWeaponDamageType(blueprint) = new DamageTypeDescription { Type = DamageType.Physical, Physical = new DamageTypeDescription.PhysicalData { Form = PhysicalDamageForm.Piercing } };
                CopyFromBlueprint(blueprint, visualGuid);
                Helpers.BlueprintItemDisplayNameText(blueprint) = new LocalizedString();
                Helpers.BlueprintItemDescriptionText(blueprint) = new LocalizedString();
                Helpers.BlueprintItemFlavorText(blueprint) = new LocalizedString();
                Helpers.BlueprintItemNonIdentifiedNameText(blueprint) = new LocalizedString();
                Helpers.BlueprintItemNonIdentifiedDescriptionText(blueprint) = new LocalizedString();
                Helpers.BlueprintItemCost(blueprint) = value;
                blueprint.ComponentsArray = null;
                Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = assetGuid;
                blueprint.name = name;
                ResourcesLibrary.LibraryObject.BlueprintsByAssetId?.Add(blueprint.AssetGuid, blueprint);
                ResourcesLibrary.LibraryObject.GetAllBlueprints()?.Add(blueprint);
            }

            static public void CopyFromBlueprint(BlueprintItemWeapon weapon, string guid) {
                var copyFromBlueprint = ResourcesLibrary.TryGetBlueprint<BlueprintItemWeapon>(guid);
                Helpers.BlueprintItemIcon(weapon) = copyFromBlueprint.Icon;
                Helpers.BlueprintItemEquipmentHandVisualParameters(weapon) = copyFromBlueprint.VisualParameters;
            }
        }

        static private readonly Template[] weapons = {
            new Template(CustomGuids.StandardOrcHornbow, new string[0], ExistingGuids.StandardCompositeLongbow, 520, "StandardOrcHornbow"),
            new Template(CustomGuids.MasterworkOrcHornbow, new string[] { ExistingGuids.Masterwork }, ExistingGuids.CompositeLongbowPlus1, 820, "MasterworkOrcHornbow"),
            new Template(CustomGuids.OrcHornbowPlus1, new string[] { ExistingGuids.Enhancement1 }, ExistingGuids.CompositeLongbowPlus1, 2820, "OrcHornbowPlus1"),
            new Template(CustomGuids.OrcHornbowPlus2, new string[] { ExistingGuids.Enhancement2 }, ExistingGuids.CompositeLongbowPlus4, 8820, "OrcHornbowPlus2"),
            new Template(CustomGuids.OrcHornbowPlus3, new string[] { ExistingGuids.Enhancement3 }, ExistingGuids.CompositeLongbowPlus4, 18820, "OrcHornbowPlus3"),
            new Template(CustomGuids.OrcHornbowPlus4, new string[] { ExistingGuids.Enhancement4 }, ExistingGuids.CompositeLongbowPlus4, 32820, "OrcHornbowPlus4"),
            new Template(CustomGuids.OrcHornbowPlus5, new string[] { ExistingGuids.Enhancement5 }, ExistingGuids.CompositeLongbowPlus4, 50820, "OrcHornbowPlus5"),
        };

        static public BlueprintItemWeapon GetBlueprint(int index) {
            return weapons[index].blueprint;
        }

        static public void Init() {
        }
    }
}