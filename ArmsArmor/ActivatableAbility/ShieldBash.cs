using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.ActivatableAbilities;

namespace ArmsArmor
{
    public class ShieldBashAbility {
        static readonly string guid = "3bb6b76ed5b38ab4f957c7f923c23b68";
        static BlueprintActivatableAbility blueprint;

        static public BlueprintActivatableAbility GetBlueprint() {
            if (!blueprint) {
                blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintActivatableAbility>(guid);
                blueprint.DeactivateImmediately = true;
                blueprint.IsOnByDefault = false;
            }
            return blueprint;
        }
        static public void Init() {
            GetBlueprint();
        }
    }
}