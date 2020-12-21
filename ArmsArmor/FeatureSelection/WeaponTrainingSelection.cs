using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Selection;

namespace ArmsArmor
{
	public class WeaponTrainingSelection {
		static public void Init() {
			var blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintFeatureSelection>(ExistingGuids.WeaponTrainingSelection);
			var features = blueprint.AllFeatures.ToList();
			features.Add(CombatCompetence.GetBlueprint());
			blueprint.AllFeatures = features.ToArray();
		}
	}
}