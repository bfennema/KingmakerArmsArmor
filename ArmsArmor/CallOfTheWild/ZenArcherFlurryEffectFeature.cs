using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Enums;

namespace ArmsArmor
{
    public class ZenArcherFlurryEffectFeature {
        static BlueprintFeature blueprint = null;
        static private BlueprintFeature GetBlueprint() {
            if (!blueprint) {
                if (CallOfTheWild.IsActive) {
                    blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>(CallOfTheWildGuids.ZenArcherFlurryEffectFeature);
                    var BuffExtraAttackCategorySpecific = CallOfTheWild.assembly.GetType("CallOfTheWild.NewMechanics.BuffExtraAttackCategorySpecific");
                    foreach (var component in blueprint.ComponentsArray) {
                        if (component.GetType() == BuffExtraAttackCategorySpecific) {
                            var categories = HarmonyLib.AccessTools.Field(component.GetType(), "categories");
                            var category = (WeaponCategory[])categories.GetValue(component);
                            category = category.Concat(new WeaponCategory[] { OrcHornbow.WeaponCategoryOrcHornbow }).ToArray();
                            categories.SetValue(component, category);
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