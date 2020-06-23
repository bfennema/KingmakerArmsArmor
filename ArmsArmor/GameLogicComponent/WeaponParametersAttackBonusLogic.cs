#if !PATCH21
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Enums;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic.Parts;

namespace ArmsArmor
{
	[ComponentName("Weapon parameters attack bonus")]
	[AllowedOn(typeof(BlueprintUnitFact))]
	[AllowMultipleComponents]
	public class WeaponParametersAttackBonusLogic : RuleInitiatorLogicComponent<RuleCalculateAttackBonusWithoutTarget> {
		public bool OnlyFinessable;
		public bool Ranged;
		public bool OnlyTwoHanded;
		public int AttackBonus;
		public bool ScaleByBasicAttackBonus;
		public bool OnlyForFullAttack;

		public override void OnEventAboutToTrigger(RuleCalculateAttackBonusWithoutTarget evt) {
			if (evt.Weapon == null) {
				return;
			}
			RulebookEvent rule = evt.Reason.Rule;
			if (rule != null && rule is RuleAttackWithWeapon attack && !attack.IsFullAttack && OnlyForFullAttack) {
				return;
			}
			int num = this.AttackBonus;
			if (this.ScaleByBasicAttackBonus) {
				num *= (1 + base.Owner.Stats.BaseAttackBonus.ModifiedValue / 4);
			}
			bool flagFinesse = !OnlyFinessable || evt.Weapon.Blueprint.Type.Category.HasSubCategory(WeaponSubCategory.Finessable) || evt.Initiator.Descriptor.Ensure<DamageGracePart>().HasEntry(evt.Weapon.Blueprint.Category);
			bool flagRanged = (Ranged && evt.Weapon.Blueprint.IsRanged) || (!Ranged && !evt.Weapon.Blueprint.IsRanged);
			bool flagTwoHanded = !OnlyTwoHanded || evt.Weapon.Blueprint.IsTwoHanded;
			if (flagFinesse && flagRanged && flagTwoHanded) {
				evt.AddBonus(num * base.Fact.GetRank(), base.Fact);
			}
		}
		public override void OnEventDidTrigger(RuleCalculateAttackBonusWithoutTarget evt) { }
	}
}
#endif