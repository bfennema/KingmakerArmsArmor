using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Enums;

namespace ArmsArmor
{
    public class GreaterSnapShotFeature {
        static BlueprintFeature blueprint = null;
        static private BlueprintFeature GetBlueprint() {
            if (!blueprint) {
                if (CallOfTheWild.IsActive) {
                    blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>(CallOfTheWildGuids.GreaterSnapShotFeature);
                    var AttackDamageBonusOnAoo = CallOfTheWild.assembly.GetType("CallOfTheWild.AooMechanics.AttackDamageBonusOnAoo");
                    foreach (var component in blueprint.ComponentsArray) {
                        if (component.GetType() == AttackDamageBonusOnAoo) {
                            var weapon_categories = HarmonyLib.AccessTools.Field(component.GetType(), "weapon_categories");
                            var category = (WeaponCategory[])weapon_categories.GetValue(component);
                            category = category.Concat(new WeaponCategory[] { OrcHornbow.WeaponCategoryOrcHornbow }).ToArray();
                            weapon_categories.SetValue(component, category);
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