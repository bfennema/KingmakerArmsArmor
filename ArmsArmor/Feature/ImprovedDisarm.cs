using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;

namespace ArmsArmor
{
    public class ImprovedDisarm {
        static BlueprintFeature blueprint = null;
        static private BlueprintFeature GetBlueprint() {
            if (!blueprint) {
                blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>(ExistingGuids.ImprovedDisarm);
                if (Main.ModSettings.Disarm) {
                    if (!ProperFlanking20.IsActive) {
                        var disarmAction = ResourcesLibrary.TryGetBlueprint<BlueprintAbility>(ExistingGuids.DisarmAction);
                        for (int i = 0; i < blueprint.ComponentsArray.Length; i++) {
                            if (blueprint.ComponentsArray[i] is AddFacts component) {
                                if (component.Facts.Contains(disarmAction)) {
                                    var list = blueprint.ComponentsArray.ToList();
                                    list.Remove(component);
                                    blueprint.ComponentsArray = list.ToArray();
                                }
                                break;
                            }
                        }
                    }
                    Helpers.BlueprintUnitFactDisplayName(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.ImprovedDisarm);
                    Helpers.BlueprintUnitFactDescription(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.ImprovedDisarmDescription);
                }
            }
            return blueprint;
        }

        static public void Init() {
            GetBlueprint();
        }
    }
}