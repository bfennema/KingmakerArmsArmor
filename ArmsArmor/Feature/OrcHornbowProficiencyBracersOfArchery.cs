using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.FactLogic;
using UnityEngine;

namespace ArmsArmor
{
    public class OrcHornbowProficiencyBracersOfArchery {
        static BlueprintFeature blueprint = null;
        static public BlueprintFeature GetBlueprint() {
            if (!blueprint) {
                var addProficiencies = ScriptableObject.CreateInstance<AddProficiencies>();
                addProficiencies.ArmorProficiencies = new ArmorProficiencyGroup[0];
                addProficiencies.WeaponProficiencies = new WeaponCategory[] { OrcHornbow.WeaponCategoryOrcHornbow };
                addProficiencies.name = "$AddProficiencies$cfe1d6c6-d5f8-4fbd-80d1-c17c24126d1a";

                blueprint = ScriptableObject.CreateInstance<BlueprintFeature>();
                blueprint.Groups = new FeatureGroup[] { FeatureGroup.ExoticWeaponProficiency };
                blueprint.Ranks = 1;
                blueprint.IsClassFeature = true;
                Helpers.BlueprintUnitFactDisplayName(blueprint) = new LocalizedString();
                Helpers.BlueprintUnitFactDescription(blueprint) = new LocalizedString();
                CopyFromBlueprint(blueprint, ExistingGuids.NunchakuProficiency);
                blueprint.ComponentsArray = new BlueprintComponent[] { addProficiencies };
                Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = CustomGuids.OrcHornbowProficiencyBracersOfArchery;
                blueprint.name = "OrcHornbowProficiencyBracersOfArchery";
                ResourcesLibrary.LibraryObject.BlueprintsByAssetId?.Add(blueprint.AssetGuid, blueprint);
                ResourcesLibrary.LibraryObject.GetAllBlueprints()?.Add(blueprint);
            }
            return blueprint;
        }

        static public void CopyFromBlueprint(BlueprintFeature feature, string guid) {
            var copyFromBlueprint = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>(guid);
            Helpers.BlueprintUnitFactIcon(feature) = copyFromBlueprint.Icon;
        }
    }
}