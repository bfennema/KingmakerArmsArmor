using System;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Enums;
using Kingmaker.Items;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Parts;
using UnityEngine;

namespace ArmsArmor
{
    [ComponentName("Basic Mechanics proficiency")]
    [AllowedOn(typeof(BlueprintUnitFact))]
    public class NonProficiencyAttackPenalty : RuleInitiatorLogicComponent<RuleCalculateAttackBonusWithoutTarget> {
        static BlueprintFeature martialWeaponProficiencyFeature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>(ExistingGuids.MartialWeaponProficiencyFeature);
        public override void OnEventAboutToTrigger(RuleCalculateAttackBonusWithoutTarget evt) {
            ItemEntityWeapon maybeWeapon = evt.Initiator.Body.PrimaryHand.MaybeWeapon;
            ItemEntityWeapon maybeWeapon2 = evt.Initiator.Body.SecondaryHand.MaybeWeapon;
            if (evt.Weapon == null || (maybeWeapon != evt.Weapon && maybeWeapon2 != evt.Weapon)) {
                return;
            }
            if (base.Owner.IsPlayerFaction && !base.Owner.Body.IsPolymorphed
                && !base.Owner.Proficiencies.Contains(evt.Weapon.Blueprint.Category)
                && !(evt.Weapon.Blueprint.Category == WeaponCategory.DuelingSword
                    && base.Owner.Proficiencies.Contains(WeaponCategory.Longsword))
                && !(Helpers.IsExoticTwoHandedMartialWeapon(evt.Weapon.Blueprint)
                    && base.Owner.HasFact(martialWeaponProficiencyFeature)
                    && evt.Weapon.HoldInTwoHands)) {
                int penalty = -4;
                if (base.Owner.HasFact(CombatCompetence.GetBlueprint())) {
                    var unitPartWeaponTraining = base.Owner.Get<UnitPartWeaponTraining>();
                    if (unitPartWeaponTraining != null) {
                        penalty += Math.Min(unitPartWeaponTraining.GetWeaponRank(evt.Weapon), 4);
                    }
                }
                evt.AddBonus(penalty, base.Fact);
            }
        }

        public override void OnEventDidTrigger(RuleCalculateAttackBonusWithoutTarget evt) {
        }
    }

    public class NonProficiencyAttackPenaltyBasicMechanics {
        static BlueprintFeature blueprint = null;

        static public BlueprintFeature GetBlueprint() {
            if (!blueprint) {
                blueprint = ScriptableObject.CreateInstance<BlueprintFeature>();
                blueprint.Ranks = 1;
                blueprint.IsClassFeature = true;
                blueprint.HideInUI = true;
                var component = ScriptableObject.CreateInstance<NonProficiencyAttackPenalty>();
                component.name = "$NonProficiencyAttackPenalty$b74b4b86-9c23-4988-9e2c-7033aac18cbe";
                blueprint.ComponentsArray = new BlueprintComponent[] { component };
                Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = CustomGuids.NonProficiencyAttackPenaltyBasicMechanics;
                blueprint.name = "NonProficiencyAttackPenaltyBasicMechanics";
                Helpers.BlueprintUnitFactDisplayName(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.NonProficiencyPenalty);

                ResourcesLibrary.LibraryObject.BlueprintsByAssetId?.Add(blueprint.AssetGuid, blueprint);
                ResourcesLibrary.LibraryObject.GetAllBlueprints()?.Add(blueprint);
            }
            return blueprint;
        }
    }
}