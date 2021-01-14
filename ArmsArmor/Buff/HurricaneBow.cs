using Kingmaker.Blueprints;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Buffs.Blueprints;

namespace ArmsArmor
{
    public class HurricaneBow {
        static BlueprintBuff blueprint;

        static private BlueprintBuff GetBlueprint() {
            if (!blueprint) {
                blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintBuff>(ExistingGuids.HurricaneBowBuff);
                if (Main.ModSettings.OrcHornbow == true) {
                    for (int i = 0; i < blueprint.ComponentsArray.Length; i++) {
                        if (blueprint.ComponentsArray[i] is RangedWeaponSizeChange component) {
                            component.WeaponTypes.Add(OrcHornbow.GetBlueprint());
                            break;
                        }
                    }
                }
            }
            return blueprint;
        }

        static public void Init() {
            GetBlueprint();
        }
    }
}