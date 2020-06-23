using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;

namespace ArmsArmor
{
	public class ExoticWeaponProficiencySelection {
		static readonly string guid = "9a01b6815d6c3684cb25f30b8bf20932";
		static public void Init() {
			var blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintFeatureSelection>(guid);
			var features = blueprint.AllFeatures.ToList();
			features.Add(TempleSwordProficiency.GetBlueprint());
			blueprint.AllFeatures = features.ToArray();

			foreach (var component in blueprint.ComponentsArray) {
				if (component is PrerequisiteNotProficient prerequisiteNotProficient) {
					var weaponProficiencies = prerequisiteNotProficient.WeaponProficiencies.ToList();
					weaponProficiencies.Add(TempleSword.WeaponCategoryTempleSword);
					prerequisiteNotProficient.WeaponProficiencies = weaponProficiencies.ToArray();
				}
			}
		}
	}
}