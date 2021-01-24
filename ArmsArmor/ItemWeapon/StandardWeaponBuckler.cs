using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Blueprints.Items.Shields;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.RuleSystem.Rules.Damage;
using UnityEngine;

namespace ArmsArmor
{
    public class StandardWeaponBuckler {
        static BlueprintItemWeapon blueprint = null;

        static public BlueprintItemWeapon GetBlueprint() {
            if (!blueprint) {
                blueprint = ScriptableObject.CreateInstance<BlueprintItemWeapon>();
                Helpers.BlueprintItemWeaponType(blueprint) = WeaponBuckler.GetBlueprint();
                Helpers.BlueprintItemWeaponSize(blueprint) = Size.Medium;
                Helpers.BlueprintItemWeaponEnchantments(blueprint) = new BlueprintWeaponEnchantment[0];
                Helpers.BlueprintItemWeaponDamageType(blueprint) = new DamageTypeDescription { Type = DamageType.Physical };
                CopyFromBlueprint(blueprint, ExistingGuids.StandardWeaponLightShield);
                Helpers.BlueprintItemDisplayNameText(blueprint) = new LocalizedString();
                Helpers.BlueprintItemDescriptionText(blueprint) = new LocalizedString();
                Helpers.BlueprintItemFlavorText(blueprint) = new LocalizedString();
                Helpers.BlueprintItemNonIdentifiedNameText(blueprint) = new LocalizedString();
                Helpers.BlueprintItemNonIdentifiedDescriptionText(blueprint) = new LocalizedString();
                Helpers.BlueprintItemCost(blueprint) = 5;
                Helpers.BlueprintItemInventoryPutSound(blueprint) = "";
                Helpers.BlueprintItemInventoryTakeSound(blueprint) = "";
                blueprint.ComponentsArray = null;
                Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = CustomGuids.StandardWeaponBuckler;
                blueprint.name = "StandardWeaponBuckler";
                ResourcesLibrary.LibraryObject.BlueprintsByAssetId?.Add(blueprint.AssetGuid, blueprint);
                ResourcesLibrary.LibraryObject.GetAllBlueprints()?.Add(blueprint);
            }
            return blueprint;
        }

        static public void CopyFromBlueprint(BlueprintItemWeapon weapon, string guid) {
            var copyFromBlueprint = ResourcesLibrary.TryGetBlueprint<BlueprintItemWeapon>(guid);
            Helpers.BlueprintItemIcon(weapon) = copyFromBlueprint.Icon;
            Helpers.BlueprintItemEquipmentHandVisualParameters(weapon) = copyFromBlueprint.VisualParameters;
        }

        static public void Init() {
            var weapon = GetBlueprint();
            var blueprints = ResourcesLibrary.LibraryObject.GetAllBlueprints().OfType<BlueprintItemShield>().Where(b => b.Type.ProficiencyGroup == ArmorProficiencyGroup.Buckler);
            foreach (var buckler in blueprints) {
                Helpers.BlueprintItemShieldWeaponComponent(buckler) = weapon;
            }
        }
    }
}
