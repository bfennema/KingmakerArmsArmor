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
	public class TempleSwordProficiency {
		static BlueprintFeature blueprint = null;
		static public BlueprintFeature GetBlueprint() {
			if (!blueprint) {
				var addProficiencies = ScriptableObject.CreateInstance<AddProficiencies>();
				addProficiencies.ArmorProficiencies = new ArmorProficiencyGroup[0];
				addProficiencies.WeaponProficiencies = new WeaponCategory[] { TempleSword.WeaponCategoryTempleSword };
				addProficiencies.name = "$AddProficiencies$b9a90f26-a97a-4e75-a889-3a0f08cc68e1";

				var prerequisiteNotProficient = ScriptableObject.CreateInstance<PrerequisiteNotProficient>();
				prerequisiteNotProficient.ArmorProficiencies = new ArmorProficiencyGroup[0];
				prerequisiteNotProficient.WeaponProficiencies = new WeaponCategory[] { TempleSword.WeaponCategoryTempleSword };
				prerequisiteNotProficient.name = "$PrerequisiteNotProficient$2b3a5ff8-2195-44f9-b1d5-5905b69a9d81";

				var addStartingEquipment = ScriptableObject.CreateInstance<AddStartingEquipment>();
				addStartingEquipment.BasicItems = new BlueprintItem[0];
				addStartingEquipment.CategoryItems = new WeaponCategory[] { TempleSword.WeaponCategoryTempleSword };
				addStartingEquipment.name = "$AddStartingEquipment$f1d926b7-c5bf-40d9-9ade-2dd735b13e0c";

				blueprint = ScriptableObject.CreateInstance<BlueprintFeature>();
				blueprint.Groups = new FeatureGroup[] { FeatureGroup.ExoticWeaponProficiency };
				blueprint.Ranks = 1;
				blueprint.IsClassFeature = true;
				Helpers.BlueprintUnitFactDisplayName(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.TempleSwordProficiency);
				Helpers.BlueprintUnitFactDescription(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.TempleSwordProficiencyDescription);
				CopyFromBlueprint(blueprint, ExistingGuids.NunchakuProficiency);
				blueprint.ComponentsArray = new BlueprintComponent[] { addProficiencies, prerequisiteNotProficient, addStartingEquipment };
				Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = CustomGuids.TempleSwordProficiency;
				blueprint.name = "TempleSwordProficiency";
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