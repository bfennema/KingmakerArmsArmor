using System.Collections.Generic;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Controllers.Units;
using Kingmaker.ElementsSystem;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;

namespace ArmsArmor
{
	[AllowedOn(typeof(BlueprintUnitFact))]
	[AllowMultipleComponents]
	public class AddInitiatorAttackWithWeaponBuff : BuffLogic, ITickEachRound, IInitiatorRulebookHandler<RuleAttackWithWeapon>, IRulebookHandler<RuleAttackWithWeapon>, IInitiatorRulebookSubscriber {
		public BlueprintBuff TargetBuff;
		public bool OnlyHit = true;
		public bool AsChild = true;
		readonly List<Buff> list = new List<Buff>();

		public void OnNewRound() {
			foreach (var buff in list) {
				buff.Remove();
            }
			list.Clear();
		}

		public override void OnFactActivate() {
		}
        public override void OnFactDeactivate() {
			foreach (var buff in list) {
				buff.Remove();
			}
			list.Clear();
		}

        public void OnEventAboutToTrigger(RuleAttackWithWeapon evt) {
		}

		public void OnEventDidTrigger(RuleAttackWithWeapon evt) {
			if (!OnlyHit || evt.AttackRoll.IsHit) {
				var buff = evt.Target.Descriptor.AddBuff(this.TargetBuff, Context, null);
				if (!list.Contains(buff)) {
					list.Add(buff);
                }
			}
		}
	}
}
