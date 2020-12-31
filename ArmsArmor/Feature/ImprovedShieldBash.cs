using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.FactLogic;

namespace ArmsArmor
{
    public class ImprovedShieldBash {
        static BlueprintFeature blueprint = null;
        static private BlueprintFeature GetBlueprint() {
            if (!blueprint) {
                blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>(ExistingGuids.ShieldBashFeature);
                var shieldBashAbility = ResourcesLibrary.TryGetBlueprint<BlueprintActivatableAbility>(ExistingGuids.ShieldBashAbility);
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
                Helpers.BlueprintUnitFactDisplayName(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.ImprovedShieldBash);
                Helpers.BlueprintUnitFactDescription(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.ImprovedShieldBashDescription);
                blueprint.name = "ImprovedShieldBashFeature";
            }
            return blueprint;
        }

        static public void Init() {
            GetBlueprint();
        }
    }
}