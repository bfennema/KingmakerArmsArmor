using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;

namespace ArmsArmor
{
    public class ImprovedTrip {
        static BlueprintFeature blueprint = null;
        static private BlueprintFeature GetBlueprint() {
            if (!blueprint) {
                blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>(ExistingGuids.ImprovedTrip);
                if (Main.ModSettings.Trip) {
                    var shieldBashAbility = ResourcesLibrary.TryGetBlueprint<BlueprintAbility>(ExistingGuids.TripAction);
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
                    Helpers.BlueprintUnitFactDisplayName(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.ImprovedTrip);
                    Helpers.BlueprintUnitFactDescription(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.ImprovedTripDescription);
                }
            }
            return blueprint;
        }

        static public void Init() {
            GetBlueprint();
        }
    }
}