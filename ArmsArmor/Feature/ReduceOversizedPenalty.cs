using System;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Localization;
using UnityEngine;

namespace ArmsArmor
{
	public class ReduceOversizedPenalty {
		static readonly string guid = "94d5c8963cd14cc8a4cc4e0189d02c29";
		static BlueprintFeature blueprint = null;
		static public BlueprintFeature GetBlueprint() {
			if (!blueprint) {
				blueprint = ScriptableObject.CreateInstance<BlueprintFeature>();
				blueprint.Groups = Array.Empty<FeatureGroup>();
				blueprint.Ranks = 1;
				blueprint.HideInUI = true;
				Helpers.BlueprintUnitFactDisplayName(blueprint) = new LocalizedString();
				Helpers.BlueprintUnitFactDescription(blueprint) = new LocalizedString();
				blueprint.ComponentsArray = new BlueprintComponent[] { GetComponent() };
				Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = guid;
				blueprint.name = "ReduceOversizedPenalty";
				ResourcesLibrary.LibraryObject.BlueprintsByAssetId?.Add(blueprint.AssetGuid, blueprint);
				ResourcesLibrary.LibraryObject.GetAllBlueprints()?.Add(blueprint);
			}
			return blueprint;
		}

		static private ReduceOversizedPenaltyLogic GetComponent() {
			var logic = ScriptableObject.CreateInstance<ReduceOversizedPenaltyLogic>();
			logic.reduction = 2;
			logic.name = "$ReduceOversizedPenaltyLogic$1be45c40-2cf9-43b4-9d22-786628c55516";
			return logic;
		}
	}
}