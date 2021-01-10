using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;

namespace ArmsArmor
{
    public class ImprovedSunder {
        static BlueprintFeature blueprint = null;
        static private BlueprintFeature GetBlueprint() {
            if (!blueprint) {
                blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>(ExistingGuids.ImprovedSunder);
                var shieldBashAbility = ResourcesLibrary.TryGetBlueprint<BlueprintAbility>(ExistingGuids.SunderAction);
                for (int i = 0; i < blueprint.ComponentsArray.Length; i++) {
                    if (blueprint.ComponentsArray[i] is AddFacts component) {
                        if (component.Facts.Contains(shieldBashAbility)) {
                            var list = blueprint.ComponentsArray.ToList();
                            list.Remove(component);
                            blueprint.ComponentsArray = list.ToArray();
                        }
                        break;
                    }
                }
                Helpers.BlueprintUnitFactDescription(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.ImprovedSunderDescription);
            }
            return blueprint;
        }

        static public void Init() {
            GetBlueprint();
        }
    }
}