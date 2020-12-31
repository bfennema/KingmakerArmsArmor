using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.FactLogic;

namespace ArmsArmor
{
    public class MonkWeaponProficiency {
        static BlueprintFeature blueprint = null;
        static private BlueprintFeature GetBlueprint() {
            if (!blueprint) {
                blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>(ExistingGuids.MonkWeaponProficiency);
                foreach (var entry in blueprint.ComponentsArray) {
                    if (entry is AddProficiencies addProficiencies) {
                        var proficiencies = addProficiencies.WeaponProficiencies.ToList();
                        proficiencies.Add(TempleSword.WeaponCategoryTempleSword);
                        addProficiencies.WeaponProficiencies = proficiencies.ToArray();
                        break;
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