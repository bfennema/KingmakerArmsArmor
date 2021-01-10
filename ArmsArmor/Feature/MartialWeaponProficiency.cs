using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.FactLogic;

namespace ArmsArmor
{
    public class MartialWeaponProficiency {
        static BlueprintFeature blueprint = null;
        static private BlueprintFeature GetBlueprint() {
            if (!blueprint) {
                blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>(ExistingGuids.MartialWeaponProficiency);
                foreach (var entry in blueprint.ComponentsArray) {
                    if (entry is AddProficiencies addProficiencies) {
                        if (addProficiencies.RaceRestriction != null
                            && addProficiencies.RaceRestriction.AssetGuid == ExistingGuids.HalfOrcRace) {
                            var proficiencies = addProficiencies.WeaponProficiencies.ToList();
                            proficiencies.Add(OrcHornbow.WeaponCategoryOrcHornbow);
                            addProficiencies.WeaponProficiencies = proficiencies.ToArray();
                            break;
                        }
                    }
                }
            }
            return blueprint;
        }

        static public void Init() {
            GetBlueprint();
        }
    }
}