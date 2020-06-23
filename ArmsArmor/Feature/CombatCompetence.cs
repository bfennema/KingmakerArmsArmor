using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using UnityEngine;

namespace ArmsArmor
{
	public class CombatCompetence {
		static readonly string guid = "d86d68db71034cdc818e32e9694d6e0f";
		static BlueprintFeature blueprint = null;
		static public BlueprintFeature GetBlueprint() {
			if (!blueprint) {
				var prerequisiteClassLevel = ScriptableObject.CreateInstance<PrerequisiteClassLevel>();
				prerequisiteClassLevel.CharacterClass = ResourcesLibrary.TryGetBlueprint<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
				prerequisiteClassLevel.Level = 9;
				prerequisiteClassLevel.name = "$PrerequisiteClassLevel$8ba90c8f-82fd-49b6-b654-f00e68b1f291";

				var weaponTrainingAddProficiencies = ScriptableObject.CreateInstance<WeaponTrainingAddProficiencies>();
				weaponTrainingAddProficiencies.WeaponTrainingRankRestriction = 4;
				weaponTrainingAddProficiencies.name = "$WeaponTrainingAddProficiencies";

				blueprint = ScriptableObject.CreateInstance<BlueprintFeature>();
				blueprint.Groups = new FeatureGroup[] { FeatureGroup.WeaponTraining };
				blueprint.Ranks = 1;
				blueprint.ReapplyOnLevelUp = true;
				blueprint.IsClassFeature = true;
				Helpers.BlueprintUnitFactDisplayName(blueprint) = LocalizedStringHelper.GetLocalizedString("8e2f52b3-9deb-4570-a1b6-7ddd9dd2fd8a");
				Helpers.BlueprintUnitFactDescription(blueprint) = LocalizedStringHelper.GetLocalizedString("704b2965-6fa6-43d9-a946-1539e2eb142e");
				blueprint.ComponentsArray = new BlueprintComponent[] { prerequisiteClassLevel, weaponTrainingAddProficiencies };
				Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = guid;
				blueprint.name = "CombatCompetence";
				ResourcesLibrary.LibraryObject.BlueprintsByAssetId?.Add(blueprint.AssetGuid, blueprint);
				ResourcesLibrary.LibraryObject.GetAllBlueprints()?.Add(blueprint);
			}
			return blueprint;
		}
	}
}