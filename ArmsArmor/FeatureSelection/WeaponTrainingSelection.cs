using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Selection;

namespace ArmsArmor
{
	public class WeaponTrainingSelection {
		static readonly string guid = "b8cecf4e5e464ad41b79d5b42b76b399";
		static public void Init() {
			var blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintFeatureSelection>(guid);
			var features = blueprint.AllFeatures.ToList();
			features.Add(CombatCompetence.GetBlueprint());
			blueprint.AllFeatures = features.ToArray();
		}
	}
}