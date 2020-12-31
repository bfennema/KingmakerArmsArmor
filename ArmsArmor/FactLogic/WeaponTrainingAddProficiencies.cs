using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Parts;
using Kingmaker.Utility;

namespace ArmsArmor
{
    [ComponentName("Add proficiencies")]
    [AllowedOn(typeof(BlueprintUnit))]
    [AllowedOn(typeof(BlueprintUnitFact))]
    [AllowMultipleComponents]
    public class WeaponTrainingAddProficiencies : OwnedGameLogicComponent<UnitDescriptor>, IHandleEntityComponent<UnitEntityData> {
        public override void OnTurnOn() {
            if (base.Owner.HasFact(this.Fact)) {
                var unitPartWeaponTraining = base.Owner.Get<UnitPartWeaponTraining>();
                foreach (Fact fact in unitPartWeaponTraining.WeaponTrainings) {
                    if (fact.GetRank() >= WeaponTrainingRankRestriction) {
                        foreach (var gameLogicComponent in fact.Components) {
                            if (gameLogicComponent is WeaponGroupAttackBonus weaponGroupAttackBonus) {
                                var blueprint = CombatCompetenceProficiencies.GetBlueprint(weaponGroupAttackBonus.WeaponGroup);
                                CombatCompetence.AddProficiency(this.Fact, blueprint);
                            }
                        }
                    }
                }
            }
        }

        public override void OnTurnOff() {
            if (base.Owner.HasFact(this.Fact)) {
                if (base.Owner.HasFact(this.Fact)) {
                    var unitPartWeaponTraining = base.Owner.Get<UnitPartWeaponTraining>();
                    foreach (Fact fact in unitPartWeaponTraining.WeaponTrainings) {
                        if (fact.GetRank() >= WeaponTrainingRankRestriction) {
                            foreach (var gameLogicComponent in fact.Components) {
                                if (gameLogicComponent is WeaponGroupAttackBonus weaponGroupAttackBonus) {
                                    var blueprint = CombatCompetenceProficiencies.GetBlueprint(weaponGroupAttackBonus.WeaponGroup);
                                    CombatCompetence.RemoveProficiency(this.Fact);
                                }
                            }
                        }
                    }
                }
            }
        }

        public void OnEntityCreated(UnitEntityData entity) {
            if (base.Owner.HasFact(this.Fact)) {
                var unitPartWeaponTraining = base.Owner.Get<UnitPartWeaponTraining>();
                foreach (Fact fact in unitPartWeaponTraining.WeaponTrainings) {
                    if (fact.GetRank() >= WeaponTrainingRankRestriction) {
                        foreach (var gameLogicComponent in fact.Components) {
                            if (gameLogicComponent is WeaponGroupAttackBonus weaponGroupAttackBonus) {
                                var blueprint = CombatCompetenceProficiencies.GetBlueprint(weaponGroupAttackBonus.WeaponGroup);
                                CombatCompetence.AddProficiency(this.Fact, blueprint);
                            }
                        }
                    }
                }
            }
        }

        public void OnEntityRemoved(UnitEntityData entity) {
        }

        public int WeaponTrainingRankRestriction = 0;
    }
}