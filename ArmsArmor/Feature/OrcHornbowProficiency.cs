using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Items;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.FactLogic;
using UnityEngine;

namespace ArmsArmor
{
    public class OrcHornbowProficiency {
        static BlueprintFeature blueprint = null;
        static public BlueprintFeature GetBlueprint() {
            if (!blueprint) {
                var addProficiencies = ScriptableObject.CreateInstance<AddProficiencies>();
                addProficiencies.ArmorProficiencies = new ArmorProficiencyGroup[0];
                addProficiencies.WeaponProficiencies = new WeaponCategory[] { OrcHornbow.WeaponCategoryOrcHornbow };
                addProficiencies.name = "$AddProficiencies$366223fa-d764-47c5-aa9e-e6c26177eb57";

                var prerequisiteNotProficient = ScriptableObject.CreateInstance<PrerequisiteNotProficient>();
                prerequisiteNotProficient.ArmorProficiencies = new ArmorProficiencyGroup[0];
                prerequisiteNotProficient.WeaponProficiencies = new WeaponCategory[] { OrcHornbow.WeaponCategoryOrcHornbow };
                prerequisiteNotProficient.name = "$PrerequisiteNotProficient$59be52db-f125-461b-9da8-6809e288660d";

                var addStartingEquipment = ScriptableObject.CreateInstance<AddStartingEquipment>();
                addStartingEquipment.BasicItems = new BlueprintItem[0];
                addStartingEquipment.CategoryItems = new WeaponCategory[] { OrcHornbow.WeaponCategoryOrcHornbow };
                addStartingEquipment.name = "$AddStartingEquipment$e2054b22-6b49-491a-817f-b57d353c9f85";

                blueprint = ScriptableObject.CreateInstance<BlueprintFeature>();
                blueprint.Groups = new FeatureGroup[] { FeatureGroup.ExoticWeaponProficiency };
                blueprint.Ranks = 1;
                blueprint.IsClassFeature = true;
                Helpers.BlueprintUnitFactDisplayName(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.OrcHornbowProficiency);
                Helpers.BlueprintUnitFactDescription(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.OrcHornbowProficiencyDescription);
                CopyFromBlueprint(blueprint, ExistingGuids.NunchakuProficiency);
                blueprint.ComponentsArray = new BlueprintComponent[] { addProficiencies, prerequisiteNotProficient, addStartingEquipment };
                Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = CustomGuids.OrcHornbowProficiency;
                blueprint.name = "OrcHornbowProficiency";
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