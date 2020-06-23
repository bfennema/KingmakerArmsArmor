using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.FactLogic;

namespace ArmsArmor
{
    public class ImprovedShieldBash
    {
        static readonly string guid = "121811173a614534e8720d7550aae253";
        static BlueprintFeature blueprint = null;
        static private BlueprintFeature GetBlueprint() {
            if (!blueprint) {
                blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>(guid);
                var shieldBashAbility = ResourcesLibrary.TryGetBlueprint<BlueprintActivatableAbility>("3bb6b76ed5b38ab4f957c7f923c23b68");
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
                Helpers.BlueprintUnitFactDisplayName(blueprint) = LocalizedStringHelper.GetLocalizedString("1d8c4846-774f-41d5-b5ec-17eac2651722");
                blueprint.name = "ImprovedShieldBashFeature";
            }
            return blueprint;
        }
        static public void Init() {
            GetBlueprint();
        }
    }
}