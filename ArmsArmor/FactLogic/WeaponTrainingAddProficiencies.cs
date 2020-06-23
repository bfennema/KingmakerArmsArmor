using System.Collections.Generic;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.Enums;
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
				Dictionary<WeaponFighterGroup, List<WeaponCategory>> WeaponGroupToCategories = new Dictionary<WeaponFighterGroup, List<WeaponCategory>>();
				foreach (var weaponType in ResourcesLibrary.GetBlueprints<BlueprintWeaponType>()) {
					if (WeaponGroupToCategories.ContainsKey(weaponType.FighterGroup)) {
						WeaponGroupToCategories[weaponType.FighterGroup].Add(weaponType.Category);
					} else {
						WeaponGroupToCategories.Add(weaponType.FighterGroup, new List<WeaponCategory> { weaponType.Category });
					}
				}
				foreach (Fact fact in unitPartWeaponTraining.WeaponTrainings) {
					if (fact.GetRank() >= WeaponTrainingRankRestriction) {
						foreach (var gameLogicComponent in fact.Components) {
							if (gameLogicComponent is WeaponGroupAttackBonus weaponGroupAttackBonus && WeaponGroupToCategories.ContainsKey(weaponGroupAttackBonus.WeaponGroup)) {
								foreach (var category in WeaponGroupToCategories[weaponGroupAttackBonus.WeaponGroup]) {
									base.Owner.Proficiencies.Add(category);
								}
							}
						}
					}
				}
			}
		}

		public override void OnTurnOff() {
			if (base.Owner.HasFact(this.Fact)) {
				var unitPartWeaponTraining = base.Owner.Get<UnitPartWeaponTraining>();
				Dictionary<WeaponFighterGroup, List<WeaponCategory>> WeaponGroupToCategories = new Dictionary<WeaponFighterGroup, List<WeaponCategory>>();
				foreach (var weaponType in ResourcesLibrary.GetBlueprints<BlueprintWeaponType>()) {
					if (WeaponGroupToCategories.ContainsKey(weaponType.FighterGroup)) {
						WeaponGroupToCategories[weaponType.FighterGroup].Add(weaponType.Category);
					} else {
						WeaponGroupToCategories.Add(weaponType.FighterGroup, new List<WeaponCategory> { weaponType.Category });
					}
				}
				foreach (Fact fact in unitPartWeaponTraining.WeaponTrainings) {
					if (fact.GetRank() >= WeaponTrainingRankRestriction) {
						foreach (var gameLogicComponent in fact.Components) {
							if (gameLogicComponent is WeaponGroupAttackBonus weaponGroupAttackBonus && WeaponGroupToCategories.ContainsKey(weaponGroupAttackBonus.WeaponGroup)) {
								foreach (var category in WeaponGroupToCategories[weaponGroupAttackBonus.WeaponGroup]) {
									base.Owner.Proficiencies.Remove(category);
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
				Dictionary<WeaponFighterGroup, List<WeaponCategory>> WeaponGroupToCategories = new Dictionary<WeaponFighterGroup, List<WeaponCategory>>();
				foreach (var weaponType in ResourcesLibrary.GetBlueprints<BlueprintWeaponType>()) {
					if (WeaponGroupToCategories.ContainsKey(weaponType.FighterGroup)) {
						WeaponGroupToCategories[weaponType.FighterGroup].Add(weaponType.Category);
					} else {
						WeaponGroupToCategories.Add(weaponType.FighterGroup, new List<WeaponCategory> { weaponType.Category });
					}
				}
				foreach (Fact fact in unitPartWeaponTraining.WeaponTrainings) {
					if (fact.GetRank() >= WeaponTrainingRankRestriction) {
						foreach (var gameLogicComponent in fact.Components) {
							if (gameLogicComponent is WeaponGroupAttackBonus weaponGroupAttackBonus && WeaponGroupToCategories.ContainsKey(weaponGroupAttackBonus.WeaponGroup)) {
								foreach (var category in WeaponGroupToCategories[weaponGroupAttackBonus.WeaponGroup]) {
									base.Owner.Proficiencies.Add(category);
								}
							}
						}
					}
				}
			}
		}

		public void OnEntityRemoved(UnitEntityData entity) {
		}

		private Dictionary<WeaponFighterGroup, List<WeaponCategory>> GetWeaponGroupToCategories() {
			Dictionary<WeaponFighterGroup, List<WeaponCategory>> WeaponGroupToCategories = new Dictionary<WeaponFighterGroup, List<WeaponCategory>>();

			foreach (var weaponType in ResourcesLibrary.GetBlueprints<BlueprintWeaponType>()) {
				if (WeaponGroupToCategories.ContainsKey(weaponType.FighterGroup)) {
					WeaponGroupToCategories[weaponType.FighterGroup].Add(weaponType.Category);
				} else {
					WeaponGroupToCategories.Add(weaponType.FighterGroup, new List<WeaponCategory> { weaponType.Category });
				}
			}
			return WeaponGroupToCategories;
		}

		public int WeaponTrainingRankRestriction = 0;
	}
}