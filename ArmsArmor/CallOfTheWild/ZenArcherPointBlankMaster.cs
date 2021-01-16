using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.UnitLogic.FactLogic;
using UnityEngine;

namespace ArmsArmor
{
    public class ZenArcherPointBlankMasterFeature {
        static BlueprintFeature blueprint = null;
        static private BlueprintFeature GetBlueprint() {
            if (!blueprint) {
                if (CallOfTheWild.IsActive) {
                    var features = new Helpers.AddParametrizedFeaturesData[] {
                        new Helpers.AddParametrizedFeaturesData() {
                            feature = ResourcesLibrary.TryGetBlueprint<BlueprintParametrizedFeature>(ExistingGuids.PointBlankMaster),
                            category = OrcHornbow.WeaponCategoryOrcHornbow
                        }
                    };

                    var feature = ScriptableObject.CreateInstance<AddParametrizedFeatures>();
                    Helpers.AddParametrizedFeaturesFeatures(feature, features);
                    feature.name = "$AddParametrizedFeatures$34b57c54-2395-4577-98ba-34f31e92c48f";

                    blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>(CallOfTheWildGuids.ZenArcherPointBlankMasterFeature);
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