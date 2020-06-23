using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.FactLogic;

namespace ArmsArmor
{
	public class MonkWeaponProficiency {
		static readonly string guid = "c7d6f5244c617734a8a76b6785a752b4";
		static BlueprintFeature blueprint = null;
		static private BlueprintFeature GetBlueprint() {
			if (!blueprint) {
				blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>(guid);
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