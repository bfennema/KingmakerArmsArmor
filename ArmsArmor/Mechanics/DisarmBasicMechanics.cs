using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Facts;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using UnityEngine;

namespace ArmsArmor
{
    public class DisarmBasicMechanics {
        static BlueprintFeature blueprint = null;
        static public BlueprintFeature GetBlueprint() {
            if (!blueprint) {
                blueprint = ScriptableObject.CreateInstance<BlueprintFeature>();
                blueprint.Ranks = 1;
                blueprint.IsClassFeature = true;
                blueprint.HideInUI = true;
                var component1 = ScriptableObject.CreateInstance<AddFacts>();
                component1.Facts = new BlueprintUnitFact[] { ResourcesLibrary.TryGetBlueprint<BlueprintAbility>(ExistingGuids.DisarmAction) };
                component1.name = "$AddFacts$54e57c6b-8f0e-4457-bc0a-a7294a272493";
                var component2 = ScriptableObject.CreateInstance<ProvokeAttackOfOpportunity>();
                component2.Type = CombatManeuver.Disarm;
                component2.Feature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>(ExistingGuids.ImprovedDisarm);
                component2.name = "$Disarm$047e3c6d-47dc-4ab6-8a2d-5f7e53addf29";
                blueprint.ComponentsArray = new BlueprintComponent[] { component1, component2 };
                Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = CustomGuids.DisarmBasicMechanics;
                blueprint.name = "DisarmBasicMechanics";
                Helpers.BlueprintUnitFactDisplayName(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.Disarm);
                Helpers.BlueprintUnitFactDescription(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.DisarmDescription);

                ResourcesLibrary.LibraryObject.BlueprintsByAssetId?.Add(blueprint.AssetGuid, blueprint);
                ResourcesLibrary.LibraryObject.GetAllBlueprints()?.Add(blueprint);
            }
            return blueprint;
        }
    }
}