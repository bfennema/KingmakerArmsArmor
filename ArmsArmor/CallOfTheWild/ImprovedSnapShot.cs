using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Enums;
using UnityEngine;

namespace ArmsArmor
{
    public class ImprovedSnapShotFeature {
        static BlueprintFeature blueprint = null;
        static private BlueprintFeature GetBlueprint() {
            if (!blueprint) {
                if (CallOfTheWild.IsActive) {
                    blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>(CallOfTheWildGuids.ImprovedSnapShotFeature);
                    var AooWithRangedWeapon = CallOfTheWild.assembly.GetType("CallOfTheWild.AooMechanics.AooWithRangedWeapon");
                    foreach (var component in blueprint.ComponentsArray) {
                        if (component.GetType() == AooWithRangedWeapon) {
                            var weapon_categories = HarmonyLib.AccessTools.Field(component.GetType(), "weapon_categories");
                            var category = (WeaponCategory[])weapon_categories.GetValue(component);
                            category = category.Concat(new WeaponCategory[] { OrcHornbow.WeaponCategoryOrcHornbow }).ToArray();
                            weapon_categories.SetValue(component, category);
                        }
                    }

                    var feature = ScriptableObject.CreateInstance<PrerequisiteParametrizedFeature>();
                    feature.Feature = ResourcesLibrary.TryGetBlueprint<BlueprintParametrizedFeature>(ExistingGuids.WeaponFocus);
                    feature.ParameterType = FeatureParameterType.WeaponCategory;
                    feature.WeaponCategory = OrcHornbow.WeaponCategoryOrcHornbow;
                    feature.Group = Prerequisite.GroupType.Any;
                    feature.name = "$PrerequisiteParametrizedFeature$d0a32034-1d41-4442-b1c9-d93cf17abf3f";

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