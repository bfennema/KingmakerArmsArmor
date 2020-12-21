using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Facts;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.FactLogic;
using UnityEngine;

namespace ArmsArmor
{
	[ComponentName("Basic Mechanics proficiency")]
	[AllowedOn(typeof(BlueprintFeature))]
	public class ShieldBashRemoveACBonus : RuleInitiatorLogicComponent<RuleAttackWithWeapon>, ITargetRulebookHandler<RuleCalculateAC>, IRulebookHandler<RuleCalculateAC> {
		static BlueprintFeature improvedShieldBashFeature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>(ExistingGuids.ShieldBashFeature);
		private bool attacked;
		public override void OnEventAboutToTrigger(RuleAttackWithWeapon evt) {
			if (evt.Initiator.CombatState.ExecutedAttackNumber == 0) {
				attacked = false;
			}
			if (!base.Owner.HasFact(improvedShieldBashFeature)) {
				if (evt.Weapon.IsShield) {
					attacked = true;
				}
			}
		}

		public override void OnEventDidTrigger(RuleAttackWithWeapon evt) {
		}

		public void OnEventAboutToTrigger(RuleCalculateAC evt) {
			if (evt.Target.CombatState.ExecutedAttackNumber == 0) {
				attacked = false;
			} else if (attacked && evt.BrilliantEnergy == null && !evt.AttackType.IsTouch()) {
				evt.AddBonus(-CalculateShieldBonuses(evt.Target), this.Fact);
			}
		}

		public void OnEventDidTrigger(RuleCalculateAC evt) {
		}

		public int CalculateShieldBonuses(UnitEntityData target) {
			int num = 0;
			foreach (ModifiableValue.Modifier modifier in target.Stats.AC.Modifiers) {
				num += ((modifier.ModDescriptor != ModifierDescriptor.Shield) ? 0 : modifier.ModValue);
				num += ((modifier.ModDescriptor != ModifierDescriptor.ShieldEnhancement) ? 0 : modifier.ModValue);
				num += ((modifier.ModDescriptor != ModifierDescriptor.Focus) ? 0 : modifier.ModValue);
			}
			return num;
		}
	}

	public class ShieldBashBasicMechanics {
        static BlueprintFeature blueprint = null;
        static public BlueprintFeature GetBlueprint() {
            if (!blueprint) {
				blueprint = ScriptableObject.CreateInstance<BlueprintFeature>();
				blueprint.Ranks = 1;
				blueprint.IsClassFeature = true;
				blueprint.HideInUI = true;
				var component1 = ScriptableObject.CreateInstance<AddFacts>();
				component1.Facts = new BlueprintUnitFact[] { ShieldBashAbility.GetBlueprint() };
				component1.name = "$AddFacts$b64d985c-9ca6-48a7-b887-7a1b4bf4ea64";
				var component2 = ScriptableObject.CreateInstance<ShieldBashRemoveACBonus>();
				component2.name = "$ShieldBash$4d6ae1f0-a509-456c-85e6-57f7b8bd3d80";
				blueprint.ComponentsArray = new BlueprintComponent[] { component1, component2 };
				Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = CustomGuids.ShieldBashBasicMechanics;
				blueprint.name = "ShieldBashBasicMechanics";
				Helpers.BlueprintUnitFactDisplayName(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.ShieldBashFeature);

				ResourcesLibrary.LibraryObject.BlueprintsByAssetId?.Add(blueprint.AssetGuid, blueprint);
				ResourcesLibrary.LibraryObject.GetAllBlueprints()?.Add(blueprint);
			}
            return blueprint;
        }
    }
}