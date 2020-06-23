using System;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using UnityEngine;

namespace ArmsArmor
{
	public class WeaponFocusTempleSword {
		static BlueprintFeature blueprint = null;
		static private BlueprintFeature GetBlueprint() {
			if (!blueprint) {
				var component = ScriptableObject.CreateInstance<Kingmaker.Designers.Mechanics.Facts.WeaponFocus>();
				component.WeaponType = TempleSword.GetBlueprint();
				component.AttackBonus = 1;
				component.name = "$WeaponTypeAttackBonus$3c04e154-6593-4451-ab5d-605a2bd283dd";

				blueprint = ScriptableObject.CreateInstance<BlueprintFeature>();
				blueprint.Groups = Array.Empty<FeatureGroup>();
				blueprint.Ranks = 1;
				blueprint.IsClassFeature = true;
				Helpers.BlueprintUnitFactDisplayName(blueprint) = LocalizedStringHelper.GetLocalizedString("c641bed7-07d1-4fd0-899B-6d9a3d65d712");
				Helpers.BlueprintUnitFactDescription(blueprint) = LocalizedStringHelper.GetLocalizedString("6fcbb42e-ab9c-475b-bfa5-7330d6331810");
				CopyFromBlueprint(blueprint, "3d980f3962b79384eb9aa602cffeef2c");
				blueprint.ComponentsArray = new BlueprintComponent[] { component };
				Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = "0d9ab546885b4159bf290aae2b187177";
				blueprint.name = "WeaponFocusTempleSword";
				ResourcesLibrary.LibraryObject.BlueprintsByAssetId?.Add(blueprint.AssetGuid, blueprint);
				ResourcesLibrary.LibraryObject.GetAllBlueprints()?.Add(blueprint);
			}
			return blueprint;
		}
		static public void CopyFromBlueprint(BlueprintFeature feature, string guid) {
			var copyFromBlueprint = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>(guid);
			Helpers.BlueprintUnitFactIcon(feature) = copyFromBlueprint.Icon;
		}

		static public void Init() {
			GetBlueprint();
		}
	}
}