using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.ElementsSystem;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using UnityEngine;

namespace ArmsArmor
{
    public class UpsettingShieldStyleBuff {
        static BlueprintBuff blueprint;

        static public BlueprintBuff GetBlueprint() {
            if (!blueprint) {
                blueprint = ScriptableObject.CreateInstance<BlueprintBuff>();
                Helpers.SetBlueprintBuffFlags(blueprint, 8);
                blueprint.IsClassFeature = true;
                blueprint.FxOnStart = new PrefabLink();
                blueprint.FxOnRemove = new PrefabLink();
                blueprint.ResourceAssetIds = new string[0];
                Helpers.BlueprintUnitFactDisplayName(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.UpsettingShieldStyle);
                Helpers.BlueprintUnitFactDescription(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.UpsettingShieldStyleDescription);
                CopyFromBlueprint(blueprint, ExistingGuids.DefensiveCombatTraining);
                var component = ScriptableObject.CreateInstance<AddInitiatorAttackWithWeaponBuff>();
                component.TargetBuff = UpsettingShieldStyleAttackBonusBuff.GetBlueprint();
                component.OnlyHit = true;
                component.name = "$AddInitiatorAttackWithWeaponBuff$e7adb14c-413d-440c-8c51-e36cb1b9038a";
                blueprint.ComponentsArray = new BlueprintComponent[] { component };
                Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = CustomGuids.UpsettingShieldStyleBuff;
                blueprint.name = "UpsettingShieldStyleBuff";
                ResourcesLibrary.LibraryObject.BlueprintsByAssetId?.Add(blueprint.AssetGuid, blueprint);
                ResourcesLibrary.LibraryObject.GetAllBlueprints()?.Add(blueprint);
            }
            return blueprint;
        }

        static private void CopyFromBlueprint(BlueprintBuff ability, string guid) {
            var copyFromBlueprint = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>(guid);
            Helpers.BlueprintUnitFactIcon(ability) = copyFromBlueprint.Icon;
        }
    }
}