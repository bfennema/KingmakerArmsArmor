using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.ActivatableAbilities;

namespace ArmsArmor
{
    public class RapidShotAbility {
        static readonly string guid = "90a77bfe25ec2e14caf8bd5cde9febf2";
        static BlueprintActivatableAbility blueprint;

        static private BlueprintActivatableAbility GetBlueprint() {
            if (!blueprint) {
                blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintActivatableAbility>(guid);
                blueprint.DeactivateImmediately = true;
            }
            return blueprint;
        }
        static public void Init() {
            GetBlueprint();
        }
    }
}