using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;

namespace ArmsArmor
{
    public class DragonStyleBuff {
        static BlueprintBuff blueprint;

        static private BlueprintBuff GetBlueprint() {
            if (!blueprint) {
                blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintBuff>(ExistingGuids.DragonStyleBuff);
                Helpers.SetBlueprintBuffFlags(blueprint, 8);
                CopyFromBlueprint(blueprint, ExistingGuids.DragonStyleToggleAbility);
            }
            return blueprint;
        }

        static private void CopyFromBlueprint(BlueprintBuff ability, string guid) {
            var copyFromBlueprint = ResourcesLibrary.TryGetBlueprint<BlueprintActivatableAbility>(guid);
            Helpers.BlueprintUnitFactIcon(ability) = copyFromBlueprint.Icon;
        }

        static public void Init() {
            GetBlueprint();
        }
    }
}