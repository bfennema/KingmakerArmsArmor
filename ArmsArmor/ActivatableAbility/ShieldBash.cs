using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.ActivatableAbilities;

namespace ArmsArmor
{
    public class ShieldBashAbility {
        static BlueprintActivatableAbility blueprint;

        static public BlueprintActivatableAbility GetBlueprint() {
            if (!blueprint) {
                blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintActivatableAbility>(ExistingGuids.ShieldBashAbility);
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