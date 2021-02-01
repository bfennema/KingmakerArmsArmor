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
                //Helpers.SetBlueprintBuffFlags(blueprint, 2);
                blueprint.FxOnStart = new PrefabLink();
                blueprint.FxOnRemove = new PrefabLink();
                blueprint.Stacking = StackingType.Ignore;
                blueprint.ResourceAssetIds = new string[0];
                Helpers.BlueprintUnitFactDisplayName(blueprint) = new LocalizedString();
                Helpers.BlueprintUnitFactDescription(blueprint) = new LocalizedString();
                CopyFromBlueprint(blueprint, ExistingGuids.DefensiveCombatTraining);

                var condition1a = ScriptableObject.CreateInstance<ContextConditionIsCaster>();
                condition1a.name = "$ContextConditionIsCaster$e400a04f-a3d8-4212-93ff-88a08cfb1f29";
                var condition1b = ScriptableObject.CreateInstance<ContextConditionCasterHasFact>();
                condition1b.Fact = UpsettingVengeanceFeat.GetBlueprint();
                condition1b.Not = true;
                condition1b.name = "$ContextConditionCasterHasFact$758aca0d-21b7-4a84-9865-482c2e47c4f5";
                var component1 = ScriptableObject.CreateInstance<AttackBonusConditional>();
                component1.Bonus = new ContextValue { Value = -2 };
                component1.Conditions = new ConditionsChecker { Conditions = new Condition[] { condition1a, condition1b } };
                component1.name = "$AttackBonusConditional$a0a45462-8865-4d7e-bb2c-e9c86910fd16";

                var condition2a = ScriptableObject.CreateInstance<ContextConditionCasterHasFact>();
                condition2a.Fact = UpsettingVengeanceFeat.GetBlueprint();
                condition2a.name = "$ContextConditionCasterHasFact$86d7f23f-b3bc-4258-9493-d47da5387fab";
                var component2 = ScriptableObject.CreateInstance<AttackBonusConditional>();
                component2.Bonus = new ContextValue { Value = -2 };
                component2.Conditions = new ConditionsChecker { Conditions = new Condition[] { condition2a } };
                component2.name = "$AttackBonusConditional$a86b4b17-dd55-4fb8-b094-3a7611b0dce4";

                var condition3a = ScriptableObject.CreateInstance<ContextConditionIsCaster>();
                condition3a.name = "$ContextConditionIsCaster$5915fc9f-b79c-4646-b53b-ead002c84711";
                var condition3b = ScriptableObject.CreateInstance<ContextConditionCasterHasFact>();
                condition3b.Fact = UpsettingStrikeFeat.GetBlueprint();
                condition3b.name = "$ContextConditionCasterHasFact$12bcfc96-4f82-4e4f-bcff-3e3f169a7754";
                var condition3c = ScriptableObject.CreateInstance<ContextConditionCasterHasFact>();
                condition3c.Fact = UpsettingVengeanceFeat.GetBlueprint();
                condition3c.Not = true;
                condition3c.name = "$ContextConditionCasterHasFact$d2821111-7e60-4735-86ba-c014ddcd6dc5";
                var component3 = ScriptableObject.CreateInstance<MissProvokeAttackCaster>();
                component3.Conditions = new ConditionsChecker { Conditions = new Condition[] { condition3a, condition3b, condition3c } };
                component3.name = "$MissProvokeAttack$39b45413-6c08-4ee3-8492-ca923759e347";

                var condition4a = ScriptableObject.CreateInstance<ContextConditionCasterHasFact>();
                condition4a.Fact = UpsettingVengeanceFeat.GetBlueprint();
                condition4a.name = "$ContextConditionCasterHasFact$12a8f412-3885-41a9-b47a-99568f9ded4f";
                var component4 = ScriptableObject.CreateInstance<MissProvokeAttackCaster>();
                component4.Conditions = new ConditionsChecker { Conditions = new Condition[] { condition4a } };
                component4.name = "$MissProvokeAttack$53e122e4-c48c-42eb-ba8e-02a3b1bf2840";

                blueprint.ComponentsArray = new BlueprintComponent[] { component1, component2, component3, component4 };
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