using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using UnityEngine;

namespace ArmsArmor
{
	public class CombatCompetence {
		static BlueprintFeature blueprint = null;
		static public BlueprintFeature GetBlueprint() {
			if (!blueprint) {
				var prerequisiteClassLevel = ScriptableObject.CreateInstance<PrerequisiteClassLevel>();
				prerequisiteClassLevel.CharacterClass = ResourcesLibrary.TryGetBlueprint<BlueprintCharacterClass>(ExistingGuids.FighterClass);
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
				Helpers.BlueprintUnitFactDisplayName(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.CombatCompetence);
				Helpers.BlueprintUnitFactDescription(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.CombatCompetenceDescription);
				blueprint.ComponentsArray = new BlueprintComponent[] { prerequisiteClassLevel, weaponTrainingAddProficiencies };
				Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = CustomGuids.CombatCompetence;
				blueprint.name = "CombatCompetence";
				ResourcesLibrary.LibraryObject.BlueprintsByAssetId?.Add(blueprint.AssetGuid, blueprint);
				ResourcesLibrary.LibraryObject.GetAllBlueprints()?.Add(blueprint);
			}
			return blueprint;
		}
	}
}