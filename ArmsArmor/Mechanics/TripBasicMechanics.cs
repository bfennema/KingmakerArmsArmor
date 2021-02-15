using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Facts;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using UnityEngine;

namespace ArmsArmor
{
    public class TripBasicMechanics {
        static BlueprintFeature blueprint = null;
        static public BlueprintFeature GetBlueprint() {
            if (!blueprint) {
                blueprint = ScriptableObject.CreateInstance<BlueprintFeature>();
                blueprint.Ranks = 1;
                blueprint.IsClassFeature = true;
                blueprint.HideInUI = true;
                var ability = ResourcesLibrary.TryGetBlueprint<BlueprintAbility>(ExistingGuids.TripAction);
                var component1 = ScriptableObject.CreateInstance<AddFacts>();
                component1.Facts = new BlueprintUnitFact[] { ability };
                component1.name = "$AddFacts$f709c34f-e410-452a-b4f3-a03a57968257";
                var component2 = ScriptableObject.CreateInstance<ProvokeAttackOfOpportunity>();
                component2.Type = CombatManeuver.Trip;
                component2.Feature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>(ExistingGuids.ImprovedTrip);
                component2.Ability = ability;
                component2.name = "$ProvokeAttackOfOpportunity$596c260b-4309-4c94-a5d6-ee0127d1cd1b";
                blueprint.ComponentsArray = new BlueprintComponent[] { component1, component2 };
                Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = CustomGuids.TripBasicMechanics;
                blueprint.name = "TripBasicMechanics";
                Helpers.BlueprintUnitFactDisplayName(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.TripFeature);
                Helpers.BlueprintUnitFactDescription(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.TripDescription);

                ResourcesLibrary.LibraryObject.BlueprintsByAssetId?.Add(blueprint.AssetGuid, blueprint);
                ResourcesLibrary.LibraryObject.GetAllBlueprints()?.Add(blueprint);
            }
            return blueprint;
        }

        static public void AddComponent(BlueprintComponent component) {
            var list = blueprint.ComponentsArray.ToList();
            list.Add(component);
            blueprint.ComponentsArray = list.ToArray();
        }
    }
}