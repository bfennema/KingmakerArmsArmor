using System;
using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.UnitLogic.FactLogic;
using UnityEngine;

namespace ArmsArmor
{
    public class KiFocusBowZenArcherFeature {
        static BlueprintFeature blueprint = null;
        static private BlueprintFeature GetBlueprint() {
            if (!blueprint) {
                if (CallOfTheWild.IsActive) {
                    var features = new Helpers.AddParametrizedFeaturesData[] {
                        new Helpers.AddParametrizedFeaturesData() {
                            feature = ResourcesLibrary.TryGetBlueprint<BlueprintParametrizedFeature>(CallOfTheWildGuids.KiWeaponFeature),
                            category = OrcHornbow.WeaponCategoryOrcHornbow
                        }
                    };

                    var feature = ScriptableObject.CreateInstance<AddParametrizedFeatures>();
                    Helpers.AddParametrizedFeaturesFeatures(feature, features);
                    feature.name = "$AddParametrizedFeatures$124fcdd6-23e1-4222-80c1-c4acd08b0996";

                    blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>(CallOfTheWildGuids.KiFocusBowZenArcherFeature);
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