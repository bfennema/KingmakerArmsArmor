using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.Localization;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.Utility;
using UnityEngine;

namespace ArmsArmor
{
    public class WeaponBuckler {
        static BlueprintWeaponType blueprint = null;

        static public BlueprintWeaponType GetBlueprint() {
            if (!blueprint) {
                blueprint = ScriptableObject.CreateInstance<BlueprintWeaponType>();
                Helpers.BlueprintWeaponTypeTypeNameText(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.Buckler);
                Helpers.BlueprintWeaponTypeDefaultNameText(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.Buckler);
                Helpers.BlueprintWeaponTypeDescriptionText(blueprint) = new LocalizedString();
                Helpers.BlueprintWeaponTypeMasterworkDescriptionText(blueprint) = new LocalizedString();
                Helpers.BlueprintWeaponTypeMagicDescriptionText(blueprint) = new LocalizedString();
                CopyFromBlueprint(blueprint, ExistingGuids.WeaponLightShield);
                Helpers.BlueprintWeaponTypeAttackRange(blueprint) = 5.Feet();
                Helpers.BlueprintWeaponTypeBaseDamage(blueprint) = new DiceFormula(1, DiceType.D3);
                Helpers.BlueprintWeaponTypeDamageType(blueprint) = new DamageTypeDescription { Type = DamageType.Physical, Physical = new DamageTypeDescription.PhysicalData { Form = PhysicalDamageForm.Bludgeoning } };
                Helpers.BlueprintWeaponTypeCriticalRollEdge(blueprint) = 20;
                Helpers.BlueprintWeaponTypeCriticalModifier(blueprint) = DamageCriticalModifierType.X2;
                Helpers.BlueprintWeaponTypeFighterGroup(blueprint) = WeaponFighterGroup.Close;
                Helpers.BlueprintWeaponTypeWeight(blueprint) = 5.0f;
                Helpers.BlueprintWeaponTypeIsTwoHanded(blueprint) = false;
                Helpers.BlueprintWeaponTypeIsLight(blueprint) = true;
                Helpers.BlueprintWeaponTypeIsMonk(blueprint) = false;
                blueprint.Category = WeaponCategory.WeaponLightShield;
                Helpers.BlueprintWeaponTypeEnchantments(blueprint) = new BlueprintWeaponEnchantment[0];
                blueprint.ComponentsArray = null;
                Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = CustomGuids.WeaponBuckler;
                blueprint.name = "WeaponBuckler";
                ResourcesLibrary.LibraryObject.BlueprintsByAssetId?.Add(blueprint.AssetGuid, blueprint);
                ResourcesLibrary.LibraryObject.GetAllBlueprints()?.Add(blueprint);
            }
            return blueprint;
        }

        static public void CopyFromBlueprint(BlueprintWeaponType weapon, string guid) {
            var copyFromBlueprint = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>(guid);
            Helpers.BlueprintWeaponTypeIcon(weapon) = copyFromBlueprint.Icon;
            Helpers.BlueprintWeaponTypeVisualParameters(weapon) = copyFromBlueprint.VisualParameters;
        }
    }
}