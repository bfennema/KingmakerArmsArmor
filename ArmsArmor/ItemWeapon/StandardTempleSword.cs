using System.Collections.Generic;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.RuleSystem.Rules.Damage;
using UnityEngine;

namespace ArmsArmor
{
    public class StandardTempleSword {
        private class Template {
            public BlueprintItemWeapon blueprint = null;

            public Template(string assetGuid, string[] enchantmentGuid, string visualGuid, int value, string name) {
                blueprint = ScriptableObject.CreateInstance<BlueprintItemWeapon>();
                Helpers.BlueprintItemWeaponType(blueprint) = TempleSword.GetBlueprint();
                Helpers.BlueprintItemWeaponSize(blueprint) = Size.Medium;
                var enchantments = new List<BlueprintWeaponEnchantment>();
                foreach (var guid in enchantmentGuid) {
                    enchantments.Add(ResourcesLibrary.TryGetBlueprint<BlueprintWeaponEnchantment>(guid));
                }
                Helpers.BlueprintItemWeaponEnchantments(blueprint) = enchantments.ToArray();
                Helpers.BlueprintItemWeaponDamageType(blueprint) = new DamageTypeDescription { Type = DamageType.Physical };
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
            new Template(CustomGuids.StandardTempleSword, new string[0], ExistingGuids.StandardSickle, 30, "StandardTempleSword"),
            new Template(CustomGuids.MasterworkTempleSword, new string[] { ExistingGuids.Masterwork }, ExistingGuids.SicklePlus2, 330, "MasterworkTempleSword"),
            new Template(CustomGuids.TempleSwordPlus1, new string[] { ExistingGuids.Enhancement1 }, ExistingGuids.SicklePlus2, 2330, "TempleSwordPlus1"),
            new Template(CustomGuids.TempleSwordPlus2, new string[] { ExistingGuids.Enhancement2 }, ExistingGuids.SicklePlus3, 8330, "TempleSwordPlus2"),
            new Template(CustomGuids.TempleSwordPlus3, new string[] { ExistingGuids.Enhancement3 }, ExistingGuids.SicklePlus3, 18330, "TempleSwordPlus3"),
            new Template(CustomGuids.TempleSwordPlus4, new string[] { ExistingGuids.Enhancement4 }, ExistingGuids.SicklePlus3, 32330, "TempleSwordPlus4"),
            new Template(CustomGuids.TempleSwordPlus5, new string[] { ExistingGuids.Enhancement5 }, ExistingGuids.SicklePlus3, 50330, "TempleSwordPlus5"),
        };

        static public BlueprintItemWeapon GetBlueprint() {
            return weapons[0].blueprint;
        }

        static public void Init() {
        }
    }
}