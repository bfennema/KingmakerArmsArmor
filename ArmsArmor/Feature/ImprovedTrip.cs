using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.FactLogic;

namespace ArmsArmor
{
    public class ImprovedTrip {
        static BlueprintFeature blueprint = null;
        static private BlueprintFeature GetBlueprint() {
            if (!blueprint) {
                blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>(ExistingGuids.ImprovedTrip);
                if (Main.ModSettings.Trip) {
                    var tripAction = ResourcesLibrary.TryGetBlueprint<BlueprintAbility>(ExistingGuids.TripAction);
                    BlueprintActivatableAbility tripActionToggleAbility = null;
                    if (ProperFlanking20.IsActive) {
                        tripActionToggleAbility = ResourcesLibrary.TryGetBlueprint<BlueprintActivatableAbility>(ProperFlanking20Guids.TripActionToggleAbility);
                    }
                    var components = blueprint.ComponentsArray.ToList();
                    for (int i = 0; i < blueprint.ComponentsArray.Length; i++) {
                        if (blueprint.ComponentsArray[i] is AddFacts component) {
                            if (component.Facts.Contains(tripAction)) {
                                components.Remove(component);
                            }
                            if (tripActionToggleAbility && component.Facts.Contains(tripActionToggleAbility)) {
                                tripActionToggleAbility.IsOnByDefault = false;
                                TripBasicMechanics.AddComponent(component);
                                components.Remove(component);
                            }
                        }
                    }
                    blueprint.ComponentsArray = components.ToArray();
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