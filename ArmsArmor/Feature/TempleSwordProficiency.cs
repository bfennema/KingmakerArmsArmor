using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.FactLogic;
using UnityEngine;

namespace ArmsArmor
{
	public class TempleSwordProficiency {
		static readonly string guid = "ec367525bd9a45b0be493a8c17ba7487";
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

				blueprint = ScriptableObject.CreateInstance<BlueprintFeature>();
				blueprint.Groups = new FeatureGroup[] { FeatureGroup.ExoticWeaponProficiency };
				blueprint.Ranks = 1;
				blueprint.IsClassFeature = true;
				Helpers.BlueprintUnitFactDisplayName(blueprint) = LocalizedStringHelper.GetLocalizedString("4fa06299-19dd-48c2-bab6-de38d54fd587");
				Helpers.BlueprintUnitFactDescription(blueprint) = LocalizedStringHelper.GetLocalizedString("b0aa76ca-bc8e-4cde-9f30-16e0d3953732");
				CopyFromBlueprint(blueprint, "097c1ceaf18f9a045b5969bad82b1fa4");
				blueprint.ComponentsArray = new BlueprintComponent[] { addProficiencies, prerequisiteNotProficient };
				Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = guid;
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