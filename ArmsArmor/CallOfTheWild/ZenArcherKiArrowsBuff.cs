using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Buffs.Blueprints;

namespace ArmsArmor
{
    public class ZenArcherKiArrowsBuff {
        static BlueprintBuff blueprint = null;
        static private BlueprintBuff GetBlueprint() {
            if (!blueprint) {
                if (CallOfTheWild.IsActive) {
                    blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintBuff>(CallOfTheWildGuids.ZenArcherKiArrowsBuff);
                    var ContextWeaponDamageDiceReplacementWeaponCategory = CallOfTheWild.assembly.GetType("CallOfTheWild.NewMechanics.ContextWeaponDamageDiceReplacementWeaponCategory");
                    foreach (var component in blueprint.ComponentsArray) {
                        if (component.GetType() == ContextWeaponDamageDiceReplacementWeaponCategory) {
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