using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.ActivatableAbilities;

namespace ArmsArmor
{
    public class RapidShotAbility {
        static BlueprintActivatableAbility blueprint;

        static private BlueprintActivatableAbility GetBlueprint() {
            if (!blueprint) {
                blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintActivatableAbility>(ExistingGuids.RapidShotToggleAbility);
                blueprint.DeactivateImmediately = true;
            }
            return blueprint;
        }
        static public void Init() {
            GetBlueprint();
        }
    }
}