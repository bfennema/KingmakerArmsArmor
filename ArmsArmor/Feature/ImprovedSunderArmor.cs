using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.FactLogic;

namespace ArmsArmor
{
    public class ImprovedSunderArmor {
        static BlueprintFeature blueprint = null;
        static private BlueprintFeature GetBlueprint() {
            if (!blueprint) {
                blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>(ExistingGuids.ImprovedSunderArmor);
                if (Main.ModSettings.Sunder) {
                    var sunderArmorAction = ResourcesLibrary.TryGetBlueprint<BlueprintAbility>(ExistingGuids.SunderArmorAction);
                    BlueprintActivatableAbility sunderActionToggleAbility = null;
                    if (ProperFlanking20.IsActive) {
                        sunderActionToggleAbility = ResourcesLibrary.TryGetBlueprint<BlueprintActivatableAbility>(ProperFlanking20Guids.SunderActionToggleAbility);
                    }
                    var components = blueprint.ComponentsArray.ToList();
                    for (int i = 0; i < blueprint.ComponentsArray.Length; i++) {
                        if (blueprint.ComponentsArray[i] is AddFacts component) {
                            if (component.Facts.Contains(sunderArmorAction)) {
                                components.Remove(component);
                            }
                            if (sunderActionToggleAbility && component.Facts.Contains(sunderActionToggleAbility)) {
                                sunderActionToggleAbility.IsOnByDefault = false;
                                SunderArmorBasicMechanics.AddComponent(component);
                                components.Remove(component);
                            }
                        }
                    }
                    blueprint.ComponentsArray = components.ToArray();
                    Helpers.BlueprintUnitFactDisplayName(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.ImprovedSunderArmor);
                    Helpers.BlueprintUnitFactDescription(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.ImprovedSunderArmorDescription);
                }
            }
            return blueprint;
        }

        static public void Init() {
            GetBlueprint();
        }
    }
}