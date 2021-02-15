using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.FactLogic;

namespace ArmsArmor
{
    public class ImprovedDisarm {
        static BlueprintFeature blueprint = null;
        static private BlueprintFeature GetBlueprint() {
            if (!blueprint) {
                blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>(ExistingGuids.ImprovedDisarm);
                if (Main.ModSettings.Disarm) {
                    var disarmAction = ResourcesLibrary.TryGetBlueprint<BlueprintAbility>(ExistingGuids.DisarmAction);
                    BlueprintActivatableAbility disarmActionToggleAbility = null;
                    if (ProperFlanking20.IsActive) {
                        disarmActionToggleAbility = ResourcesLibrary.TryGetBlueprint<BlueprintActivatableAbility>(ProperFlanking20Guids.DisarmActionToggleAbility);
                    }
                    var components = blueprint.ComponentsArray.ToList();
                    for (int i = 0; i < blueprint.ComponentsArray.Length; i++) {
                        if (blueprint.ComponentsArray[i] is AddFacts component) {
                            if (component.Facts.Contains(disarmAction)) {
                                components.Remove(component);
                            }
                            if (disarmActionToggleAbility && component.Facts.Contains(disarmActionToggleAbility)) {
                                disarmActionToggleAbility.IsOnByDefault = false;
                                DisarmBasicMechanics.AddComponent(component);
                                components.Remove(component);
                            }
                        }
                    }
                    blueprint.ComponentsArray = components.ToArray();
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