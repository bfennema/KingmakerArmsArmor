using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.ElementsSystem;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using UnityEngine;

namespace ArmsArmor
{
    public class UpsettingShieldStyleAttackBonusBuff {
        static BlueprintBuff blueprint;

        static public BlueprintBuff GetBlueprint() {
            if (!blueprint) {
                blueprint = ScriptableObject.CreateInstance<BlueprintBuff>();
                Helpers.SetBlueprintBuffFlags(blueprint, 2);
                blueprint.FxOnStart = new PrefabLink();
                blueprint.FxOnRemove = new PrefabLink();
                blueprint.ResourceAssetIds = new string[0];
                Helpers.BlueprintUnitFactDisplayName(blueprint) = new LocalizedString();
                Helpers.BlueprintUnitFactDescription(blueprint) = new LocalizedString();
                CopyFromBlueprint(blueprint, ExistingGuids.DefensiveCombatTraining);
                var condition = ScriptableObject.CreateInstance<ContextConditionIsCaster>();
                condition.name = "$ContextConditionIsCaster$e400a04f-a3d8-4212-93ff-88a08cfb1f29";
                var component = ScriptableObject.CreateInstance<AttackBonusConditional>();
                component.Bonus = new ContextValue { Value = -2 };
                component.Conditions = new ConditionsChecker { Conditions = new Condition[] { condition } };
                component.name = "$AttackBonusConditional$a0a45462-8865-4d7e-bb2c-e9c86910fd16";
                blueprint.ComponentsArray = new BlueprintComponent[] { component };
                Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = CustomGuids.UpsettingShieldStyleAttackBonusBuff;
                blueprint.name = "UpsettingShieldStyleAttackBonusBuff";
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