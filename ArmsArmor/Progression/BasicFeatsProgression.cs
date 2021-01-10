using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic;

namespace ArmsArmor
{
    public class BasicFeatsProgression {
        static public void Init() {
            Update(null);
        }
        static public void Update(UnitDescriptor unit) {
            var blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintProgression>(ExistingGuids.BasicFeatsProgression);
            var mechanics = new BlueprintFeature[] {
                NonProficiencyAttackPenaltyBasicMechanics.GetBlueprint(),
                ShieldBashBasicMechanics.GetBlueprint(),
                TripBasicMechanics.GetBlueprint(),
                SunderBasicMechanics.GetBlueprint(),
                DisarmBasicMechanics.GetBlueprint(),
                TwoHandBasicMechanics.GetBlueprint(),
            };

            if (unit == null) {
                foreach (var entry in blueprint.LevelEntries) {
                    if (entry.Level == 1) {
                        foreach (var mechanic in mechanics) {
                            entry.Features.Add(mechanic);
                        }
                        break;
                    }
                }
            } else {
                foreach (var mechanic in mechanics) {
                    if (!unit.Progression.Features.HasFact(mechanic)) {
                        var feature = unit.Progression.Features.AddFeature(mechanic);
                        feature.Source = blueprint;
                    }
                }
            }
        }
    }
}