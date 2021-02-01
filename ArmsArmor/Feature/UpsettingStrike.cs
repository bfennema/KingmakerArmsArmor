using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using UnityEngine;

namespace ArmsArmor
{
    public class UpsettingStrikeFeat {
        static BlueprintFeature blueprint = null;
        static public BlueprintFeature GetBlueprint() {
            if (!blueprint) {
                blueprint = ScriptableObject.CreateInstance<BlueprintFeature>();

                var prerequisiteProficiency = ScriptableObject.CreateInstance<PrerequisiteProficiency>();
                prerequisiteProficiency.ArmorProficiencies = new ArmorProficiencyGroup[] { ArmorProficiencyGroup.Buckler };
                prerequisiteProficiency.WeaponProficiencies = new WeaponCategory[0];
                prerequisiteProficiency.name = "$PrerequisiteProficiency$e1a5fd7b-1535-428b-9239-a10bc0cef5dd";

                var prerequisiteStatValue = ScriptableObject.CreateInstance<PrerequisiteStatValue>();
                prerequisiteStatValue.Stat = StatType.Dexterity;
                prerequisiteStatValue.Value = 15;
                prerequisiteStatValue.name = "$PrerequisiteStatValue$884e17db-6872-4d7f-85e6-ae262b00fcbf";

                var combatReflexes = ScriptableObject.CreateInstance<PrerequisiteFeature>();
                combatReflexes.Feature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>(ExistingGuids.CombatReflexes);
                combatReflexes.name = "$PrerequisiteFeature$9ba018a7-655d-4390-99c9-6f219519e864";

                var improvedShieldBash = ScriptableObject.CreateInstance<PrerequisiteFeature>();
                improvedShieldBash.Feature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>(ExistingGuids.ShieldBashFeature);
                improvedShieldBash.name = "$PrerequisiteFeature$ffdf74d3-e669-46b9-83bc-9390f1e322fb";

                var upsettingShieldStyle = ScriptableObject.CreateInstance<PrerequisiteFeature>();
                upsettingShieldStyle.Feature = UpsettingShieldStyleFeat.GetBlueprint();
                upsettingShieldStyle.name = "$PrerequisiteFeature$68c11f6a-7416-44ce-9937-29fc71bcf472";

                blueprint.Groups = new FeatureGroup[] { FeatureGroup.CombatFeat, FeatureGroup.Feat };
                blueprint.Ranks = 1;
                blueprint.IsClassFeature = true;
                Helpers.BlueprintUnitFactDisplayName(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.UpsettingStrike);
                Helpers.BlueprintUnitFactDescription(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.UpsettingStrikeDescription);
                CopyFromBlueprint(blueprint, ExistingGuids.DefensiveCombatTraining);
                blueprint.ComponentsArray = new BlueprintComponent[] { prerequisiteProficiency, prerequisiteStatValue, combatReflexes, improvedShieldBash, upsettingShieldStyle };
                Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = CustomGuids.UpsettingStrikeFeat;
                blueprint.name = "UpsettingStrikeFeat";
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