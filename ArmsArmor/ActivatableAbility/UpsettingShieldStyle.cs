using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Commands.Base;
using UnityEngine;

namespace ArmsArmor
{
    public class UpsettingShieldStyleToggleAbility {
        static BlueprintActivatableAbility blueprint;

        static public BlueprintActivatableAbility GetBlueprint() {
            if (!blueprint) {
                blueprint = ScriptableObject.CreateInstance<BlueprintActivatableAbility>();
                Helpers.BlueprintActivatableAbilityActivateWithUnitCommand(blueprint) = UnitCommand.CommandType.Swift;
                blueprint.Buff = UpsettingShieldStyleBuff.GetBlueprint();
                blueprint.Group = ActivatableAbilityGroup.CombatStyle;
                blueprint.WeightInGroup = 1;
                blueprint.IsOnByDefault = true;
                blueprint.ActionBarAutoFillIgnored = false;
                blueprint.ResourceAssetIds = new string[0];
                Helpers.BlueprintUnitFactDisplayName(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.UpsettingShieldStyle);
                Helpers.BlueprintUnitFactDescription(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.UpsettingShieldStyleDescription);
                CopyFromBlueprint(blueprint, ExistingGuids.DefensiveCombatTraining);
                blueprint.ComponentsArray = new BlueprintComponent[0];
                Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = CustomGuids.UpsettingShieldStyleAbility;
                blueprint.name = "UpsettingShieldStyleToggleAbility";
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
}