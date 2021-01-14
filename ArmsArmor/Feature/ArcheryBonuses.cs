using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.FactLogic;
using UnityEngine;

namespace ArmsArmor
{
    public class ArcheryBonusesFeature {
        static BlueprintFeature blueprint = null;
        static public BlueprintFeature GetBlueprint() {
            if (!blueprint) {
                blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>(ExistingGuids.ArcheryBonuses);
                for (int i = 0; i < blueprint.ComponentsArray.Length; i++) {
                    if (blueprint.ComponentsArray[i] is WeaponGroupAttackBonus attack) {
                        var bonus = ScriptableObject.CreateInstance<WeaponGroupProficientAttackBonus>();
                        bonus.WeaponGroup = attack.WeaponGroup;
                        bonus.AttackBonus = attack.AttackBonus;
                        bonus.Descriptor = attack.Descriptor;
                        bonus.name = attack.name.Replace("WeaponGroupAttackBonus", "WeaponGroupProficientAttackBonus");
                        blueprint.ComponentsArray[i] = bonus;
                    } else if (blueprint.ComponentsArray[i] is WeaponGroupDamageBonus damage) {
                        var bonus = ScriptableObject.CreateInstance<WeaponGroupProficientDamageBonus>();
                        bonus.WeaponGroup = damage.WeaponGroup;
                        bonus.DamageBonus = damage.DamageBonus;
                        bonus.AdditionalValue = damage.AdditionalValue;
                        bonus.Descriptor = damage.Descriptor;
                        bonus.name = damage.name.Replace("WeaponGroupDamageBonus", "WeaponGroupProficientDamageBonus");
                        blueprint.ComponentsArray[i] = bonus;
                    } else if (blueprint.ComponentsArray[i] is AddFacts fact) {
                        fact.Facts = fact.Facts.Concat(new BlueprintUnitFact[] { OrcHornbowProficiencyBracersOfArchery.GetBlueprint() }).ToArray();
                    }
                }
            }
            return blueprint;
        }

        static public void Init() {
            GetBlueprint();
        }
    }
}