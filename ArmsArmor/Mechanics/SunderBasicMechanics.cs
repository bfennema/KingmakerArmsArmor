using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Facts;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using UnityEngine;

namespace ArmsArmor
{
    public class SunderBasicMechanics {
        static BlueprintFeature blueprint = null;
        static public BlueprintFeature GetBlueprint() {
            if (!blueprint) {
                blueprint = ScriptableObject.CreateInstance<BlueprintFeature>();
                blueprint.Ranks = 1;
                blueprint.IsClassFeature = true;
                blueprint.HideInUI = true;
                var ability = ResourcesLibrary.TryGetBlueprint<BlueprintAbility>(ExistingGuids.SunderArmorAction);
                var component1 = ScriptableObject.CreateInstance<AddFacts>();
                component1.Facts = new BlueprintUnitFact[] { ability };
                component1.name = "$AddFacts$2b7aa3c7-6929-4bb8-af2b-ac40e3c38308";
                var component2 = ScriptableObject.CreateInstance<ProvokeAttackOfOpportunity>();
                component2.Type = CombatManeuver.SunderArmor;
                component2.Feature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>(ExistingGuids.ImprovedSunderArmor);
                component2.Ability = ability;
                component2.name = "$ProvokeAttackOfOpportunity$c1786713-3d3d-4cd3-979b-d4d2fb5fd778";
                blueprint.ComponentsArray = new BlueprintComponent[] { component1, component2 };
                Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = CustomGuids.SunderBasicMechanics;
                blueprint.name = "SunderBasicMechanics";
                Helpers.BlueprintUnitFactDisplayName(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.SunderArmorFeature);
                Helpers.BlueprintUnitFactDescription(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.SunderArmorDescription);

                ResourcesLibrary.LibraryObject.BlueprintsByAssetId?.Add(blueprint.AssetGuid, blueprint);
                ResourcesLibrary.LibraryObject.GetAllBlueprints()?.Add(blueprint);
            }
            return blueprint;
        }
    }
}