using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic;

namespace ArmsArmor
{
	public class BasicFeatsProgression {
		static readonly string guid = "5b72dd2ca2cb73b49903806ee8986325";
		static public void Init() {
			var blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintProgression>(guid);
			foreach (var entry in blueprint.LevelEntries) {
				if (entry.Level == 1) {
					entry.Features.Add(NonProficiencyAttackPenaltyBasicMechanics.GetBlueprint());
					entry.Features.Add(ShieldBashBasicMechanics.GetBlueprint());
					break;
				}
			}
		}
		static public void Update(UnitDescriptor unit) {
			var mechanic1 = NonProficiencyAttackPenaltyBasicMechanics.GetBlueprint();
			var mechanic2 = ShieldBashBasicMechanics.GetBlueprint();

			if (!unit.Progression.Features.HasFact(mechanic1)) {
				var feature = unit.Progression.Features.AddFeature(mechanic1);
				feature.Source = ResourcesLibrary.TryGetBlueprint<BlueprintProgression>(guid);
			}
			if (!unit.Progression.Features.HasFact(mechanic2)) {
				var feature = unit.Progression.Features.AddFeature(mechanic2);
				feature.Source = ResourcesLibrary.TryGetBlueprint<BlueprintProgression>(guid);
			}
		}
	}
}