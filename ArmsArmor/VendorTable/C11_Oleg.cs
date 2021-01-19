using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;
using Kingmaker.Blueprints.Loot;
using UnityEngine;

namespace ArmsArmor
{
    public class C11_OlegVendorTable {
        static BlueprintSharedVendorTable blueprint = null;
        static public BlueprintSharedVendorTable GetBlueprint() {
            if (!blueprint) {
                var items = new BlueprintItem[4] {
                    Main.ModSettings.TempleSword == true ? StandardTempleSword.GetBlueprint(1) : null,
                    Main.ModSettings.OrcHornbow == true ? StandardOrcHornbow.GetBlueprint(1) : null,
                    SpikedHeavyShield.GetBlueprint(),
                    SpikedLightShield.GetBlueprint(),
                };
                var counts = new int[4] { 1, 1, 1, 1 };
                var names = new string[4] {
                    "a2786f12-e324-496d-9b66-44f1fb58757e",
                    "f122fce8-2754-43ce-96b0-0447f11c177e",
                    "25282f48-af8b-4c78-9161-b08293157328",
                    "6ce59ada-2a4f-4af2-9ee7-857718a29ae5",
                };

                blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintSharedVendorTable>(ExistingGuids.C11_OlegVendorTable);
                for (var i = 0; i < items.Length; i++) {
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