using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components.CasterCheckers;

namespace ArmsArmor
{
    public class TargetOfOpportunityAttackAbility {
        static BlueprintAbility blueprint = null;
        static private BlueprintAbility GetBlueprint() {
            if (!blueprint) {
                if (CallOfTheWild.IsActive) {
                    blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintAbility>(CallOfTheWildGuids.TargetOfOpportunityAttackAbility);
                    for (int i = 0; i < blueprint.ComponentsArray.Length; i++) {
                        if (blueprint.ComponentsArray[i] is AbilityCasterMainWeaponCheck component) {
                            component.Category = component.Category.Concat(new WeaponCategory[] { OrcHornbow.WeaponCategoryOrcHornbow }).ToArray();
                            break;
                        }
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