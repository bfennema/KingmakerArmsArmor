using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using UnityEngine;

namespace ArmsArmor
{
    public class AspectOfTheFalcon {
        static BlueprintBuff blueprint;

        static private BlueprintBuff GetBlueprint() {
            if (!blueprint) {
                blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintBuff>(ExistingGuids.AspectOfTheFalconBuff);
                if (Main.ModSettings.OrcHornbow == true) {
                    var component = ScriptableObject.CreateInstance<WeaponTypeCriticalEdgeIncrease>();
                    component.WeaponType = OrcHornbow.GetBlueprint();
                    component.name = "$WeaponTypeCriticalEdgeIncrease$72fe0139-2e9b-4b38-aaad-b51847aa3f08";
                    blueprint.ComponentsArray = blueprint.ComponentsArray.Concat(new BlueprintComponent[] { component }).ToArray();
                }
            }
            return blueprint;
        }

        static public void Init() {
            GetBlueprint();
        }
    }
}