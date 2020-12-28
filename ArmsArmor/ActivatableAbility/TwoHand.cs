using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Facts;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.FactLogic;
using UnityEngine;

namespace ArmsArmor
{
    public class TwoHandAbility {
        static BlueprintActivatableAbility blueprint;

        static public BlueprintActivatableAbility GetBlueprint() {
            if (!blueprint) {
                blueprint = ScriptableObject.CreateInstance<BlueprintActivatableAbility>();
                blueprint.Buff = TwoHandBuff.GetBlueprint();
                blueprint.WeightInGroup = 1;
                blueprint.IsOnByDefault = true;
                blueprint.DeactivateImmediately = true;
                blueprint.ActionBarAutoFillIgnored = false;
                blueprint.ResourceAssetIds = new string[0];
                Helpers.BlueprintUnitFactDisplayName(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.TwoHand);
                Helpers.BlueprintUnitFactDescription(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.TwoHandDescription);
                CopyFromBlueprint(blueprint, ExistingGuids.WeaponSpecialization);
                blueprint.ComponentsArray = new BlueprintComponent[0];
                Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = CustomGuids.TwoHandAbility;
                blueprint.name = "TwoHandAbility";
                ResourcesLibrary.LibraryObject.BlueprintsByAssetId?.Add(blueprint.AssetGuid, blueprint);
                ResourcesLibrary.LibraryObject.GetAllBlueprints()?.Add(blueprint);
            }
            return blueprint;
        }

        static private void CopyFromBlueprint(BlueprintActivatableAbility ability, string guid) {
            var copyFromBlueprint = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>(guid);
            Helpers.BlueprintUnitFactIcon(ability) = copyFromBlueprint.Icon;
        }
    }

    public class TwoHandBasicMechanics {
        static BlueprintFeature blueprint = null;
        static public BlueprintFeature GetBlueprint() {
            if (!blueprint) {
                blueprint = ScriptableObject.CreateInstance<BlueprintFeature>();
                blueprint.Ranks = 1;
                blueprint.IsClassFeature = true;
                blueprint.HideInUI = true;
                var component = ScriptableObject.CreateInstance<AddFacts>();
                component.Facts = new BlueprintUnitFact[] { TwoHandAbility.GetBlueprint() };
                component.name = "$AddFacts$b577e2ef-9aac-4be5-b59a-08ee40fb61f7";
                blueprint.ComponentsArray = new BlueprintComponent[] { component };
                Helpers.BlueprintUnitFactDisplayName(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.TwoHand);
                Helpers.BlueprintUnitFactDescription(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.TwoHandDescription);
                CopyFromBlueprint(blueprint, ExistingGuids.WeaponSpecialization);
                Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = CustomGuids.TwoHandBasicMechanics;
                blueprint.name = "TwoHandBasicMechanics";
                ResourcesLibrary.LibraryObject.BlueprintsByAssetId?.Add(blueprint.AssetGuid, blueprint);
                ResourcesLibrary.LibraryObject.GetAllBlueprints()?.Add(blueprint);
            }
            return blueprint;
        }

        static private void CopyFromBlueprint(BlueprintFeature feature, string guid) {
            var copyFromBlueprint = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>(guid);
            Helpers.BlueprintUnitFactIcon(feature) = copyFromBlueprint.Icon;
        }
    }
}