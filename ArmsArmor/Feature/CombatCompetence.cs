using System.Collections.Generic;
using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.FactLogic;
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

                var addFacts = ScriptableObject.CreateInstance<AddFacts>();
                addFacts.Facts = new BlueprintUnitFact[0];
                addFacts.name = "$AddFacts$ad08fabd-b42f-4915-ab85-7bf1ea70e896";

                blueprint = ScriptableObject.CreateInstance<BlueprintFeature>();
                blueprint.Groups = new FeatureGroup[] { FeatureGroup.WeaponTraining };
                blueprint.Ranks = 1;
                blueprint.ReapplyOnLevelUp = true;
                blueprint.IsClassFeature = true;
                Helpers.BlueprintUnitFactDisplayName(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.CombatCompetence);
                Helpers.BlueprintUnitFactDescription(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.CombatCompetenceDescription);
                blueprint.ComponentsArray = new BlueprintComponent[] { prerequisiteClassLevel, weaponTrainingAddProficiencies, addFacts };
                Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = CustomGuids.CombatCompetence;
                blueprint.name = "CombatCompetence";
                ResourcesLibrary.LibraryObject.BlueprintsByAssetId?.Add(blueprint.AssetGuid, blueprint);
                ResourcesLibrary.LibraryObject.GetAllBlueprints()?.Add(blueprint);
            }
            return blueprint;
        }

        static public void AddProficiency(Fact fact, BlueprintFeature blueprint) {
            var AddFacts = fact.SelectComponents<AddFacts>().FirstOrDefault();
            AddFacts.OnFactDeactivate();
            AddFacts.Facts = new BlueprintFeature[] { blueprint };
            AddFacts.OnFactActivate();
        }

        static public void RemoveProficiency(Fact fact) {
            var AddFacts = fact.SelectComponents<AddFacts>().FirstOrDefault();
            AddFacts.OnFactDeactivate();
            AddFacts.Facts = new BlueprintFeature[0];
            AddFacts.OnFactActivate();
        }
    }

    public class CombatCompetenceProficiencies {
        static Dictionary<WeaponFighterGroup, BlueprintFeature> blueprints = new Dictionary<WeaponFighterGroup, BlueprintFeature>();
        static readonly string[] guids = {
            CustomGuids.CombatCompetenceProficiencyNone,
            CustomGuids.CombatCompetenceProficiencyAxe,
            CustomGuids.CombatCompetenceProficiencyBladesHeavy,
            CustomGuids.CombatCompetenceProficiencyBladesLight,
            CustomGuids.CombatCompetenceProficiencyBows,
            CustomGuids.CombatCompetenceProficiencyCrossbows,
            CustomGuids.CombatCompetenceProficiencyDouble,
            CustomGuids.CombatCompetenceProficiencyFlails,
            CustomGuids.CombatCompetenceProficiencyHammers,
            CustomGuids.CombatCompetenceProficiencyMonk,
            CustomGuids.CombatCompetenceProficiencyNatural,
            CustomGuids.CombatCompetenceProficiencyPolearms,
            CustomGuids.CombatCompetenceProficiencySpears,
            CustomGuids.CombatCompetenceProficiencyThrown,
            CustomGuids.CombatCompetenceProficiencyClose
        };

        static public BlueprintFeature GetBlueprint(WeaponFighterGroup group, List<WeaponCategory> categories = null) {
            if (!blueprints.ContainsKey(group)) {
                var addProficiencies = ScriptableObject.CreateInstance<AddProficiencies>();
                addProficiencies.ArmorProficiencies = new ArmorProficiencyGroup[0];
                addProficiencies.WeaponProficiencies = categories.ToArray();
                addProficiencies.name = "$AddProficiencies$7fee2f82-6fa7-44d2-9e26-339d5da9057f";

                var blueprint = ScriptableObject.CreateInstance<BlueprintFeature>();
                blueprint.Groups = new FeatureGroup[0];
                blueprint.Ranks = 1;
                blueprint.IsClassFeature = true;
                blueprint.HideInUI = true;
                Helpers.BlueprintUnitFactDisplayName(blueprint) = new LocalizedString();
                Helpers.BlueprintUnitFactDescription(blueprint) = new LocalizedString();
                blueprint.ComponentsArray = new BlueprintComponent[] { addProficiencies };
                Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = guids[(int)group];
                blueprint.name = "CombatCompetenceProficiency" + group.ToString();
                ResourcesLibrary.LibraryObject.BlueprintsByAssetId?.Add(blueprint.AssetGuid, blueprint);
                ResourcesLibrary.LibraryObject.GetAllBlueprints()?.Add(blueprint);
                blueprints[group] = blueprint;
            }
            return blueprints[group];
        }

        static public void Init() {
            Dictionary<WeaponFighterGroup, List<WeaponCategory>> WeaponGroupToCategories = new Dictionary<WeaponFighterGroup, List<WeaponCategory>>();
            foreach (var weaponType in ResourcesLibrary.GetBlueprints<BlueprintWeaponType>()) {
                if (WeaponGroupToCategories.ContainsKey(weaponType.FighterGroup)) {
                    if (!WeaponGroupToCategories[weaponType.FighterGroup].Contains(weaponType.Category)) {
                        WeaponGroupToCategories[weaponType.FighterGroup].Add(weaponType.Category);
                    }
                } else {
                    WeaponGroupToCategories.Add(weaponType.FighterGroup, new List<WeaponCategory> { weaponType.Category });
                }
            }
            foreach (var group in WeaponGroupToCategories.Keys) {
                GetBlueprint(group, WeaponGroupToCategories[group]);
            }
        }
    }
}