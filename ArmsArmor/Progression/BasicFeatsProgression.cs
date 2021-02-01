using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic;

namespace ArmsArmor
{
    public class BasicFeatsProgression {
        class Mechanics {
            public BlueprintFeature feature;
            public bool enable;
        }

        static public void Init() {
            Update(null);
        }

        static public void Update(UnitDescriptor unit) {
            var blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintProgression>(ExistingGuids.BasicFeatsProgression);
            var mechanics = new Mechanics[] {
                new Mechanics() { feature = NonProficiencyAttackPenaltyBasicMechanics.GetBlueprint(), enable = Main.ModSettings.EquipWeaponWithoutProficiency },
                new Mechanics() { feature = ShieldBashBasicMechanics.GetBlueprint(), enable = Main.ModSettings.ShieldBash },
                new Mechanics() { feature = TripBasicMechanics.GetBlueprint(), enable = Main.ModSettings.Trip },
                new Mechanics() { feature = SunderBasicMechanics.GetBlueprint(), enable = Main.ModSettings.Sunder },
                new Mechanics() { feature = DisarmBasicMechanics.GetBlueprint(), enable = Main.ModSettings.Disarm },
                new Mechanics() { feature = TwoHandBasicMechanics.GetBlueprint(), enable = Main.ModSettings.TwoHand }
            };

            if (unit == null) {
                foreach (var entry in blueprint.LevelEntries) {
                    if (entry.Level == 1) {
                        foreach (var mechanic in mechanics) {
                            if (mechanic.enable) {
                                entry.Features.Add(mechanic.feature);
                            } else {
                                entry.Features.Remove(mechanic.feature);
                            }
                        }
                        break;
                    }
                }
            } else {
                foreach (var mechanic in mechanics) {
                    if (mechanic.enable) {
                        if (!unit.Progression.Features.HasFact(mechanic.feature)) {
                            var feature = unit.Progression.Features.AddFeature(mechanic.feature);
                            feature.Source = blueprint;
                        }
                    } else {
                        if (unit.Progression.Features.HasFact(mechanic.feature)) {
                            unit.Progression.Features.RemoveFact(mechanic.feature);
                        }
                    }
                }
            }
        }
    }
}