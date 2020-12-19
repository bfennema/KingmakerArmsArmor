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
                Helpers.BlueprintUnitFactDisplayName(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.TwoHand);
                Helpers.BlueprintUnitFactDescription(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.TwoHandDescription);
                CopyFromBlueprint(blueprint, ExistingGuids.WeaponSpecialization);
                blueprint.DeactivateImmediately = true;
                blueprint.IsOnByDefault = true;
                Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = CustomGuids.TwoHandAbility;
                blueprint.name = "TwoHandAbility";
                ResourcesLibrary.LibraryObject.BlueprintsByAssetId?.Add(blueprint.AssetGuid, blueprint);
                ResourcesLibrary.LibraryObject.GetAllBlueprints()?.Add(blueprint);
            }
            return blueprint;
        }
        static public void Init() {
            GetBlueprint();
        }
        static public void CopyFromBlueprint(BlueprintActivatableAbility ability, string guid) {
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
                Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = CustomGuids.TwoHandBasicMechanics;
                blueprint.name = "TwoHandBasicMechanics";
                Helpers.BlueprintUnitFactDisplayName(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.TwoHand);

                ResourcesLibrary.LibraryObject.BlueprintsByAssetId?.Add(blueprint.AssetGuid, blueprint);
                ResourcesLibrary.LibraryObject.GetAllBlueprints()?.Add(blueprint);
            }
            return blueprint;
        }
    }
}