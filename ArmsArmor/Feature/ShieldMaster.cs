using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.Mechanics.Components;
using UnityEngine;

namespace ArmsArmor
{
    public class ShieldMasterFeature
    {
        static readonly string guid = "dbec636d84482944f87435bd31522fcc";
        static BlueprintFeature blueprint = null;
        static public BlueprintFeature GetBlueprint() {
            if (!blueprint) {
                blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>(guid);
                for (int i = 0; i < blueprint.ComponentsArray.Length; i++) {
                    if (blueprint.ComponentsArray[i] is ShieldMaster component) {
                        var logic = ScriptableObject.CreateInstance<ShieldMasterLogic>();
                        logic.name = component.name.Replace("ShieldMaster", "ShieldMasterLogic");
                        blueprint.ComponentsArray[i] = logic;
                        break;
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