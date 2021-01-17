#if !PATCH21
using Kingmaker.Blueprints;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using UnityEngine;

namespace ArmsArmor
{
    public class RapidShotBuff {
        static BlueprintBuff blueprint;

		static private BlueprintBuff GetBlueprint() {
            if (!blueprint) {
                blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintBuff>(ExistingGuids.RapidShotBuff);
                for (int i = 0; i < blueprint.ComponentsArray.Length; i++) {
                    if (blueprint.ComponentsArray[i] is WeaponParametersAttackBonus component) {
                        var logic = ScriptableObject.CreateInstance<WeaponParametersAttackBonusLogic>();
                        logic.name = component.name.Replace("WeaponParametersAttackBonus", "WeaponParametersAttackBonusLogic");
                        logic.OnlyFinessable = component.OnlyFinessable;
                        logic.Ranged = component.Ranged;
                        logic.OnlyTwoHanded = component.OnlyTwoHanded;
                        logic.AttackBonus = component.AttackBonus;
                        logic.ScaleByBasicAttackBonus = component.ScaleByBasicAttackBonus;
                        logic.OnlyForFullAttack = true;
                        blueprint.ComponentsArray[i] = logic;
                        break;
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
#endif