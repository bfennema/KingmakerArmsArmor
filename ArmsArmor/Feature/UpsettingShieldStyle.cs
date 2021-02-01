using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.FactLogic;
using UnityEngine;

namespace ArmsArmor
{
    public class UpsettingShieldStyleFeat {
        static BlueprintFeature blueprint = null;
        static public BlueprintFeature GetBlueprint() {
            if (!blueprint) {
                blueprint = ScriptableObject.CreateInstance<BlueprintFeature>();

                var prerequisiteProficiency = ScriptableObject.CreateInstance<PrerequisiteProficiency>();
                prerequisiteProficiency.ArmorProficiencies = new ArmorProficiencyGroup[] { ArmorProficiencyGroup.Buckler };
                prerequisiteProficiency.WeaponProficiencies = new WeaponCategory[0];
                prerequisiteProficiency.name = "$PrerequisiteProficiency$b5daa281-0571-454a-bfaf-a3742843f656";

                var prerequisiteStatValue = ScriptableObject.CreateInstance<PrerequisiteStatValue>();
                prerequisiteStatValue.Stat = StatType.Dexterity;
                prerequisiteStatValue.Value = 13;
                prerequisiteStatValue.name = "$PrerequisiteStatValue$21b1d4f9-e080-4008-aebf-a4d027ba9a1a";

                var addFacts = ScriptableObject.CreateInstance<AddFacts>();
                addFacts.Facts = new BlueprintUnitFact[] { UpsettingShieldStyleToggleAbility.GetBlueprint() };
                addFacts.name = "$AddFacts$abf99725-603a-421a-a503-8db7c7e69f8c";

                blueprint.Groups = new FeatureGroup[] { FeatureGroup.CombatFeat, FeatureGroup.StyleFeat, FeatureGroup.Feat };
                blueprint.Ranks = 1;
                blueprint.IsClassFeature = true;
                Helpers.BlueprintUnitFactDisplayName(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.UpsettingShieldStyle);
                Helpers.BlueprintUnitFactDescription(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.UpsettingShieldStyleDescription);
                CopyFromBlueprint(blueprint, ExistingGuids.DefensiveCombatTraining);
                blueprint.ComponentsArray = new BlueprintComponent[] { prerequisiteProficiency, prerequisiteStatValue, addFacts };
                Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = CustomGuids.UpsettingShieldStyleFeat;
                blueprint.name = "UpsettingShieldStyleFeat";
                ResourcesLibrary.LibraryObject.BlueprintsByAssetId?.Add(blueprint.AssetGuid, blueprint);
                ResourcesLibrary.LibraryObject.GetAllBlueprints()?.Add(blueprint);
            }
            return blueprint;
        }

        static public void CopyFromBlueprint(BlueprintFeature feature, string guid) {
            var copyFromBlueprint = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>(guid);
            Helpers.BlueprintUnitFactIcon(feature) = copyFromBlueprint.Icon;
        }
    }
}