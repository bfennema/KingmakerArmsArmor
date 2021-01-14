using System.Runtime.CompilerServices;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs;
using Kingmaker.UnitLogic.Mechanics;

namespace ArmsArmor
{
    [ComponentName("Weapon group damage bonus")]
    [AllowedOn(typeof(BlueprintUnitFact))]
    public class WeaponGroupProficientDamageBonus : RuleInitiatorLogicComponent<RuleCalculateWeaponStats> {
        private MechanicsContext Context {
            get {
                return (base.Fact as Buff)?.Context ?? (base.Fact as Feature)?.Context;
            }
        }

        public override void OnEventAboutToTrigger(RuleCalculateWeaponStats evt) {
            int num = this.AdditionalValue.Calculate(this.Context);
            if (evt.Weapon.Blueprint.FighterGroup == this.WeaponGroup) {
                var proficiencies = Helpers.MultiSetWeaponCategoryData(Helpers.UnitProficiencyWeaponProficiencies(evt.Initiator.Descriptor.Proficiencies));
                if (proficiencies.ContainsKey(evt.Weapon.Blueprint.Category)) {
                    if (proficiencies[evt.Weapon.Blueprint.Category] > 1) {
                        evt.AddTemporaryModifier(evt.Initiator.Stats.AdditionalDamage.AddModifier(this.DamageBonus * base.Fact.GetRank() + num, this, this.Descriptor));
                    }
                }
            }
        }

        public override void OnEventDidTrigger(RuleCalculateWeaponStats evt) {
        }

        public WeaponFighterGroup WeaponGroup;

        public int DamageBonus;

        public ContextValue AdditionalValue;

        public ModifierDescriptor Descriptor;
    }
}
