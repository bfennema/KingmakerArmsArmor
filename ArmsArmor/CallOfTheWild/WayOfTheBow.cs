using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.FactLogic;
using UnityEngine;

namespace ArmsArmor
{
    public class WayOfTheBowFeature {
        static BlueprintFeatureSelection blueprint = null;
        static private BlueprintFeatureSelection GetBlueprint() {
            if (!blueprint) {
                if (CallOfTheWild.IsActive) {
                    blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintFeatureSelection>(CallOfTheWildGuids.WayOfTheBowFeature);

                    var specializationFeature = ScriptableObject.CreateInstance<AddParametrizedFeatures>();
                    Helpers.AddParametrizedFeaturesFeatures(specializationFeature,
                        new Helpers.AddParametrizedFeaturesData[] {
                            new Helpers.AddParametrizedFeaturesData() {
                                feature = ResourcesLibrary.TryGetBlueprint<BlueprintParametrizedFeature>(ExistingGuids.WeaponSpecialization),
                                category = OrcHornbow.WeaponCategoryOrcHornbow
                            }
                        });
                    specializationFeature.name = "$AddParametrizedFeatures$264286aa-3e07-4640-b56b-17b28f08b9d0";

                    var specialization = ScriptableObject.CreateInstance<BlueprintFeature>();
                    Helpers.BlueprintUnitFactDisplayName(specialization) = LocalizedStringHelper.GetLocalizedString(StringGuids.OrcHornbowWayOfTheBow6Feature);
                    Helpers.BlueprintUnitFactDescription(specialization) = Helpers.BlueprintUnitFactDescription(blueprint);
                    specialization.HideInCharacterSheetAndLevelUp = true;
                    specialization.Groups = new FeatureGroup[0];
                    CopyFromBlueprint(specialization, ExistingGuids.WeaponSpecialization);
                    specialization.ComponentsArray = new BlueprintComponent[] { specializationFeature };
                    Helpers.BlueprintScriptableObjectAssetGuid(specialization) = CustomGuids.OrcHornbowWayOfTheBow6Feature;
                    specialization.name = "OrcHornbowWayOfTheBow6Feature";
                    ResourcesLibrary.LibraryObject.BlueprintsByAssetId?.Add(specialization.AssetGuid, specialization);
                    ResourcesLibrary.LibraryObject.GetAllBlueprints()?.Add(specialization);

                    var focusFeature = ScriptableObject.CreateInstance<AddParametrizedFeatures>();
                    Helpers.AddParametrizedFeaturesFeatures(focusFeature,
                        new Helpers.AddParametrizedFeaturesData[] {
                            new Helpers.AddParametrizedFeaturesData() {
                                feature = ResourcesLibrary.TryGetBlueprint<BlueprintParametrizedFeature>(ExistingGuids.WeaponFocus),
                                category = OrcHornbow.WeaponCategoryOrcHornbow
                            }
                        });
                    focusFeature.name = "$AddParametrizedFeatures$933fc35b-8817-4099-b502-625920ba6091";

                    var classLevel = ScriptableObject.CreateInstance<AddFeatureOnClassLevel>();
                    classLevel.Class = ResourcesLibrary.TryGetBlueprint<BlueprintCharacterClass>(ExistingGuids.MonkClass);
                    classLevel.Level = 6;
                    classLevel.Feature = specialization;
                    classLevel.AdditionalClasses = new BlueprintCharacterClass[0];
                    classLevel.Archetypes = new BlueprintArchetype[0];
                    classLevel.name = "$AddFeatureOnClassLevel$5c32b8be-2e18-4ed9-8a93-23a66e066c82";

                    var focus = ScriptableObject.CreateInstance<BlueprintFeature>();
                    Helpers.BlueprintUnitFactDisplayName(focus) = LocalizedStringHelper.GetLocalizedString(StringGuids.OrcHornbowWayOfTheBowFeature);
                    Helpers.BlueprintUnitFactDescription(focus) = Helpers.BlueprintUnitFactDescription(blueprint);
                    focus.Groups = new FeatureGroup[0];
                    CopyFromBlueprint(focus, ExistingGuids.WeaponFocus);
                    focus.ComponentsArray = new BlueprintComponent[] { focusFeature, classLevel };
                    Helpers.BlueprintScriptableObjectAssetGuid(focus) = CustomGuids.OrcHornbowWayOfTheBowFeature;
                    focus.name = "OrcHornbowWayOfTheBowFeature";
                    ResourcesLibrary.LibraryObject.BlueprintsByAssetId?.Add(focus.AssetGuid, focus);
                    ResourcesLibrary.LibraryObject.GetAllBlueprints()?.Add(focus);

                    blueprint.AllFeatures = blueprint.AllFeatures.Concat(new BlueprintFeature[] { focus }).ToArray();
                }
            }
            return blueprint;
        }

        static public void CopyFromBlueprint(BlueprintFeature feature, string guid) {
            var copyFromBlueprint = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>(guid);
            Helpers.BlueprintUnitFactIcon(feature) = copyFromBlueprint.Icon;
        }

        static public void Init() {
            GetBlueprint();
        }
    }
}