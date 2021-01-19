using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;
using Kingmaker.Blueprints.Loot;
using UnityEngine;

namespace ArmsArmor
{
    public class RogueLike_NPCVendorTable {
        static BlueprintSharedVendorTable blueprint = null;
        static public BlueprintSharedVendorTable GetBlueprint() {
            if (!blueprint) {
                var items = new BlueprintItem[8] {
                    Main.ModSettings.TempleSword == true ? StandardTempleSword.GetBlueprint(1) : null,
                    Main.ModSettings.TempleSword == true ? StandardTempleSword.GetBlueprint(2) : null,
                    Main.ModSettings.OrcHornbow == true ? StandardOrcHornbow.GetBlueprint(1) : null,
                    Main.ModSettings.OrcHornbow == true ? StandardOrcHornbow.GetBlueprint(2) : null,
                    SpikedHeavyShield.GetBlueprint(),
                    SpikedLightShield.GetBlueprint(),
                    SpikedHeavyShieldBashingPlus1.GetBlueprint(),
                    SpikedLightShieldBashingPlus1.GetBlueprint(),
                };
                var counts = new int[8] { 8, 4, 8, 4, 3, 3, 1, 1 };
                var names = new string[8] {
                    "8f93b0de-dc1e-49ee-a715-c6f4ceda81ff",
                    "f3a5e70b-268f-403b-b777-c2281cc6e516",
                    "239c7d13-98c7-4406-abf0-16e7eefa4c3f",
                    "0e408f99-171d-4ed1-a8eb-fbddac029a6b",
                    "47ac1657-43b5-43a2-8773-96606c260e4c",
                    "c3e445c3-74f4-42e7-9123-23fa0a95872b",
                    "f452f864-76b0-462e-afc8-cf6b7ebe63e2",
                    "fc5533db-a395-4586-9aff-a655b8ee9ae9",
                };

                blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintSharedVendorTable>(ExistingGuids.RogueLike_NPCVendorTable);
                for (var i=0; i<items.Length; i++) {
                    if (items[i] != null) {
                        var loot = new LootItem();
                        Helpers.LootItemItem(loot) = items[i];
                        var pack = ScriptableObject.CreateInstance<LootItemsPackFixed>();
                        Helpers.LootItemsPackFixedItem(pack) = loot;
                        Helpers.LootItemsPackFixedCount(pack) = counts[i];
                        pack.name = "$LootItemsPackFixed$" + names[i];
                        blueprint.ComponentsArray = blueprint.ComponentsArray.Concat(new BlueprintComponent[] { pack }).ToArray();
                    }
                }
            }
            return blueprint;
        }

        static public void Init() {
            GetBlueprint();
        }
    }
}