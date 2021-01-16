using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.UnitLogic.FactLogic;
using UnityEngine;

namespace ArmsArmor
{
    public class ZenArcherPerfectStrikeFeature
    {
        static BlueprintFeature blueprint = null;
        static private BlueprintFeature GetBlueprint() {
            if (!blueprint) {
                if (CallOfTheWild.IsActive) {
                    var features = new Helpers.AddParametrizedFeaturesData[] {
                        new Helpers.AddParametrizedFeaturesData() {
                            feature = ResourcesLibrary.TryGetBlueprint<BlueprintParametrizedFeature>(CallOfTheWildGuids.PerfectStrikeUnlockerFeature),
                            category = OrcHornbow.WeaponCategoryOrcHornbow
                        }
                    };

                    var feature = ScriptableObject.CreateInstance<AddParametrizedFeatures>();
                    Helpers.AddParametrizedFeaturesFeatures(feature, features);
                    feature.name = "$AddParametrizedFeatures$a11164d3-031f-4b44-9c30-f33414dea5da";

                    blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>(CallOfTheWildGuids.ZenArcherPerfectStrikeFeature);
                    blueprint.ComponentsArray = blueprint.ComponentsArray.Concat(new BlueprintComponent[] { feature }).ToArray();
                }
            }
            return blueprint;
        }

        static public void Init() {
            GetBlueprint();
        }
    }
}