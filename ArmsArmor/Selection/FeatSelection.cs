using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;

namespace ArmsArmor
{
    public class FeatSelection {
        class Mechanics {
            public BlueprintFeature feature;
            public bool enable;
        }

        static public void Init() {
            var guids = new string[] {
                ExistingGuids.BasicFeatSelection,
                ExistingGuids.CombatTrick,
                ExistingGuids.EldritchKnightFeatSelection,
                ExistingGuids.FighterFeatSelection,
                ExistingGuids.MagusFeatSelection,
                ExistingGuids.WarDomainGreaterFeatSelection
            };

            var mechanics = new Mechanics[] {
                new Mechanics() { feature = UpsettingShieldStyleFeat.GetBlueprint(), enable = Main.ModSettings.UpsettingShieldStyle },
                new Mechanics() { feature = UpsettingStrikeFeat.GetBlueprint(), enable = Main.ModSettings.UpsettingShieldStyle },
                new Mechanics() { feature = UpsettingVengeanceFeat.GetBlueprint(), enable = Main.ModSettings.UpsettingShieldStyle },
            };

            foreach (var guid in guids) {
                var blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintFeatureSelection>(guid);
                var allFeatures = blueprint.AllFeatures.ToList();

                foreach (var mechanic in mechanics) {
                    if (mechanic.enable) {
                        allFeatures.Add(mechanic.feature);
                    } else {
                        allFeatures.Remove(mechanic.feature);
                    }
                }

                blueprint.AllFeatures = allFeatures.ToArray();
            }
        }
    }
}