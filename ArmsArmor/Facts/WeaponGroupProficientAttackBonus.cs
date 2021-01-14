using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.RuleSystem.Rules;

namespace ArmsArmor
{
    [ComponentName("Weapon group attack bonus")]
    [AllowedOn(typeof(BlueprintUnitFact))]
    public class WeaponGroupProficientAttackBonus : RuleInitiatorLogicComponent<RuleCalculateAttackBonusWithoutTarget> {
        public override void OnEventAboutToTrigger(RuleCalculateAttackBonusWithoutTarget evt) {
            if (evt.Weapon != null && evt.Weapon.Blueprint.FighterGroup == this.WeaponGroup) {
                var proficiencies = Helpers.MultiSetWeaponCategoryData(Helpers.UnitProficiencyWeaponProficiencies(evt.Initiator.Descriptor.Proficiencies));
                if (proficiencies.ContainsKey(evt.Weapon.Blueprint.Category)) {
                    if (proficiencies[evt.Weapon.Blueprint.Category] > 1) {
                        if (m_ModifierAttack == null) {
                            m_ModifierAttack = evt.Initiator.Stats.AdditionalAttackBonus.AddModifier(this.AttackBonus * base.Fact.GetRank(), this, Descriptor);
                        }
                        return;
                    }
                }
            }
            m_ModifierAttack.Remove();
            m_ModifierAttack = null;
        }

        public override void OnEventDidTrigger(RuleCalculateAttackBonusWithoutTarget evt) {
        }

        public override void OnFactDeactivate() {
            base.OnFactDeactivate();
            if (m_ModifierAttack != null) {
                m_ModifierAttack.Remove();
                m_ModifierAttack = null;
            }
        }


        public WeaponFighterGroup WeaponGroup;

        public int AttackBonus;

        public ModifierDescriptor Descriptor;

        private ModifiableValue.Modifier m_ModifierAttack;
    }
}