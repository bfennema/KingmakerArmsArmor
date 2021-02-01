using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using UnityEngine;

namespace ArmsArmor
{
    public class UpsettingVengeanceFeat {
        static BlueprintFeature blueprint = null;
        static public BlueprintFeature GetBlueprint() {
            if (!blueprint) {
                blueprint = ScriptableObject.CreateInstance<BlueprintFeature>();

                var prerequisiteProficiency = ScriptableObject.CreateInstance<PrerequisiteProficiency>();
                prerequisiteProficiency.ArmorProficiencies = new ArmorProficiencyGroup[] { ArmorProficiencyGroup.Buckler };
                prerequisiteProficiency.WeaponProficiencies = new WeaponCategory[0];
                prerequisiteProficiency.name = "$PrerequisiteProficiency$95fc3e64-b2ee-4b0b-8d77-7abb62a9dd0f";

                var prerequisiteStatValue = ScriptableObject.CreateInstance<PrerequisiteStatValue>();
                prerequisiteStatValue.Stat = StatType.Dexterity;
                prerequisiteStatValue.Value = 13;
                prerequisiteStatValue.name = "$PrerequisiteStatValue$1546fb18-bc42-4276-b4d3-cce95d87124e";

                var combatReflexes = ScriptableObject.CreateInstance<PrerequisiteFeature>();
                combatReflexes.Feature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>(ExistingGuids.CombatReflexes);
                combatReflexes.name = "$PrerequisiteFeature$1856947b-db91-4441-a2eb-378c04e28744";

                var improvedShieldBash = ScriptableObject.CreateInstance<PrerequisiteFeature>();
                improvedShieldBash.Feature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>(ExistingGuids.ShieldBashFeature);
                improvedShieldBash.name = "$PrerequisiteFeature$a4930575-8fc3-4b0d-9e64-17b772f15198";

                var upsettingShieldStyle = ScriptableObject.CreateInstance<PrerequisiteFeature>();
                upsettingShieldStyle.Feature = UpsettingShieldStyleFeat.GetBlueprint();
                upsettingShieldStyle.name = "$PrerequisiteFeature$bd1bf62b-bff5-4a50-960b-2b0ab7f537b2";

                var upsettingStrike = ScriptableObject.CreateInstance<PrerequisiteFeature>();
                upsettingStrike.Feature = UpsettingStrikeFeat.GetBlueprint();
                upsettingStrike.name = "$PrerequisiteFeature$81d5206d-973b-4143-ac92-7b4a73a5df2d";

                blueprint.Groups = new FeatureGroup[] { FeatureGroup.CombatFeat, FeatureGroup.Feat };
                blueprint.Ranks = 1;
                blueprint.IsClassFeature = true;
                Helpers.BlueprintUnitFactDisplayName(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.UpsettingVengeance);
                Helpers.BlueprintUnitFactDescription(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.UpsettingVengeanceDescription);
                CopyFromBlueprint(blueprint, ExistingGuids.DefensiveCombatTraining);
                blueprint.ComponentsArray = new BlueprintComponent[] { prerequisiteProficiency, prerequisiteStatValue, combatReflexes, improvedShieldBash, upsettingShieldStyle, upsettingStrike };
                Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = CustomGuids.UpsettingVengeanceFeat;
                blueprint.name = "UpsettingVengeanceFeat";
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