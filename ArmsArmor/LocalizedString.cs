using Kingmaker.Localization;

namespace ArmsArmor
{
    class LocalizedStringHelper {
        static void AddString(string key, string result) {
            LocalizationManager.CurrentPack.Strings[key] = result;
        }

        public static LocalizedString GetLocalizedString(string key) {
            var ret = new LocalizedString();
            if (LocalizationManager.CurrentPack.Strings.ContainsKey(key)) {
                Helpers.LocalizedStringKey(ret) = key;
            }
            return ret;
        }

        static public void Init() {
            AddString(StringGuids.NonProficiencyPenalty, "Non-Proficiency Penalty");
            AddString(StringGuids.TempleSword, "Temple Sword");
            AddString(StringGuids.WeaponFocusTempleSword, "Weapon Focus (Temple Sword)");
            AddString(StringGuids.WeaponFocusTempleSwordDescription, "You gain a +1 bonus on all attack rolls you make using temple swords.");
            AddString(StringGuids.TempleSwordProficiency, "Weapon Proficiency (Temple Sword)");
            AddString(StringGuids.TempleSwordProficiencyDescription, "You become proficient with temple swords and can use them as a weapon.");
            AddString(StringGuids.OrcHornbow, "Orc Hornbow");
            AddString(StringGuids.WeaponFocusOrcHornbow, "Weapon Focus (Orc Hornbow)");
            AddString(StringGuids.WeaponFocusOrcHornbowDescription, "You gain a +1 bonus on all attack rolls you make using orc hornbows.");
            AddString(StringGuids.OrcHornbowProficiency, "Weapon Proficiency (Orc Hornbow)");
            AddString(StringGuids.OrcHornbowProficiencyDescription, "You become proficient with orc hornbows and can use them as a weapon.");
            AddString(StringGuids.CombatCompetence, "Combat Competence");
            AddString(StringGuids.CombatCompetenceDescription, "For any weapon in the associated weapon group with which the fighter is not proficient, the penalty on attack rolls taken as a result of not being proficient is reduced by an amount equal to the fighter’s weapon training bonus with that weapon group. Once the penalty is reduced to 0, the fighter becomes proficient with such weapons.");
            AddString(StringGuids.IrongripEnchantment, "Irongrip");
            AddString(StringGuids.IrongripGauntlets, "Irongrip Gauntlets");
            AddString(StringGuids.IrongripGauntletsDescription, "These gloves are made of goatskin reinforced with heavy iron strips. They provide a sure, strengthened grip on large or awkwardly shaped items. When the wearer wields an improvised melee weapon or inappropriately sized weapon, reduce the penalty for doing so by 2 (minimum 0). The gloves don’t change the number of hands required to wield such a weapon.");
            AddString(StringGuids.BashingEnchantment, "Bashing");
            AddString(StringGuids.BashingEnchantmentDescription, "A shield with this special ability is designed to perform a shield bash. A bashing shield deals damage as if it were a bashing weapon of two size categories larger (a Medium light shield thus deals 1d6 points of damage and a Medium heavy shield deals 1d8 points of damage). The shield acts as a +1 weapon when used to bash. Only light and heavy shields can have this ability.");
            AddString(StringGuids.ImpactEnchantment, "Impact");
            AddString(StringGuids.ImpactEnchantmentDescription, "This special ability can only be placed on melee weapons that are not light weapons. An impact weapon delivers a potent kinetic jolt when it strikes, dealing damage as if the weapon were one size category larger. In addition, any bull rush combat maneuver the wielder attempts while wielding the weapon gains a bonus equal to the weapon’s enhancement bonus; this includes all bull rush attempts, not only those in which a weapon is used, such as Bull Rush Strike, Shield Slam, or Unseat.");
            AddString(StringGuids.ImprovedShieldBash, "Improved Shield Bash");
            AddString(StringGuids.ImprovedShieldBashDescription, "When you perform a shield bash, you may still apply the shield’s shield bonus to your AC.");
            AddString(StringGuids.Trip, "Trip");
            AddString(StringGuids.TripDescription, "You provoke an attack of opportunity when performing a trip combat maneuver.");
            AddString(StringGuids.ImprovedTripDescription, "You do not provoke an attack of opportunity when performing a trip combat maneuver. In addition, you receive a +2 bonus on checks made to trip a foe. You also receive a +2 bonus to your Combat Maneuver Defense whenever an opponent tries to trip you.");
            AddString(StringGuids.Sunder, "Sunder");
            AddString(StringGuids.SunderDescription, "You provoke an attack of opportunity when performing a sunder combat maneuver.");
            AddString(StringGuids.ImprovedSunderDescription, "You do not provoke an attack of opportunity when performing a sunder combat maneuver. In addition, you receive a +2 bonus on checks made to sunder an item. You also receive a +2 bonus to your Combat Maneuver Defense whenever an opponent tries to sunder your gear. ");
            AddString(StringGuids.Disarm, "Disarm");
            AddString(StringGuids.DisarmDescription, "You provoke an attack of opportunity when performing a disarm combat maneuver.");
            AddString(StringGuids.ImprovedDisarmDescription, "You do not provoke an attack of opportunity when performing a disarm combat maneuver. In addition, you receive a +2 bonus on checks made to disarm a foe. You also receive a +2 bonus to your Combat Maneuver Defense whenever an opponent tries to disarm you.");
            AddString(StringGuids.SpikedLightShieldBashingPlus1, "Bashing Spiked Light Shield +1");
            AddString(StringGuids.SpikedHeavyShieldBashingPlus1, "Bashing Spiked Heavy Shield +1");
            AddString(StringGuids.TwoHand, "Two Hand");
            AddString(StringGuids.TwoHandDescription, "Wield a one-handed weapon with two hands.\nWhen a one-handed weapon is wielded with two hands during melee combat, 1-1/2 times the character’s Strength bonus is added to damage rolls.\nRapiers cannot be wielded with two hands.");
            AddString(StringGuids.OrcHornbowWayOfTheBowFeature, "Way of the Bow: Orc Hornbow");
            AddString(StringGuids.OrcHornbowWayOfTheBow6Feature, "Way of the Bow (Weapon Specialization: Orc Hornbow)");
            AddString(StringGuids.UpsettingShieldStyle, "Upsetting Shield Style");
            AddString(StringGuids.UpsettingShieldStyleDescription, "You can shield bash with a buckler as if it were a light shield, and you can use the buckler in conjunction with any feats or abilities that normally apply to light shields.\nWhile using this style, whenever you successfully deal damage to an opponent with a shield bash using your buckler, that opponent takes a –2 penalty on all attack rolls made against you until the start of your next turn.");
        }
    }
    class StringGuids {
        public const string NonProficiencyPenalty = "969f5b6f-00f6-48d8-bc06-b8a852d63bfd";
        public const string TempleSword = "5f26093f-af20-4c9f-99f3-b05f857f82bb";
        public const string WeaponFocusTempleSword = "c641bed7-07d1-4fd0-899b-6d9a3d65d712";
        public const string WeaponFocusTempleSwordDescription = "6fcbb42e-ab9c-475b-bfa5-7330d6331810";
        public const string TempleSwordProficiency = "4fa06299-19dd-48c2-bab6-de38d54fd587";
        public const string TempleSwordProficiencyDescription = "b0aa76ca-bc8e-4cde-9f30-16e0d3953732";
        public const string OrcHornbow = "b80ab81e-10b6-47fc-a0f1-4079a8547424";
        public const string WeaponFocusOrcHornbow = "9d58e91b-d27f-41eb-ac06-230a5900ba62";
        public const string WeaponFocusOrcHornbowDescription = "437278b7-ed63-4dc7-b979-71a1ed0b5fe9";
        public const string OrcHornbowProficiency = "42a698a8-dc1e-4b28-85f2-098e83f565f7";
        public const string OrcHornbowProficiencyDescription = "c5aba8e0-04ce-409e-aab2-9f45bdebfa9d";
        public const string CombatCompetence = "8e2f52b3-9deb-4570-a1b6-7ddd9dd2fd8a";
        public const string CombatCompetenceDescription = "704b2965-6fa6-43d9-a946-1539e2eb142e";
        public const string IrongripEnchantment = "2845c74a-a0aa-473b-87f0-7eedc71f6786";
        public const string IrongripGauntlets = "8213446b-b0f4-47a2-b1f8-a4048fd99568";
        public const string IrongripGauntletsDescription = "490bfc6d-3898-40d7-88ab-f741f12ec4e4";
        public const string BashingEnchantment = "3178bb0c-f6ed-4e56-9877-e5edc03fbb5d";
        public const string BashingEnchantmentDescription = "4ba52894-0155-48ac-9241-bab25Fa44e17";
        public const string ImpactEnchantment = "63a4211a-3130-41f1-a80e-a7fc45427642";
        public const string ImpactEnchantmentDescription = "3e48795f-ebf1-4e08-88e0-ab52eabf84b9";
        public const string ImprovedShieldBash = "1d8c4846-774f-41d5-b5ec-17eac2651722";
        public const string ImprovedShieldBashDescription = "52c3d9be-01fb-4b18-9f8f-bb5d8dced144";
        public const string Trip = "41f5fa8f-c3ea-44aa-8684-430b67622401";
        public const string TripDescription = "a18169a4-993b-4343-bdbc-92022c2b4cb0";
        public const string ImprovedTripDescription = "7138f6d7-67a5-4a74-95c5-b926617fc08b";
        public const string Sunder = "8dcb8d8a-1857-4c86-bc97-5306a966cd5c";
        public const string SunderDescription = "d4d4cca5-f04f-462a-a221-c80e8c6360c9";
        public const string ImprovedSunderDescription = "baf4b4c7-720c-4aa4-94da-25e0992603e8";
        public const string Disarm = "2bd58dfc-1bac-4bc9-b038-e34cdc8b48d3";
        public const string DisarmDescription = "c8019a54-566c-4383-950b-c60d4ed384c4";
        public const string ImprovedDisarmDescription = "e41c0f17-7756-4d90-9a80-814c230410b3";
        public const string SpikedLightShieldBashingPlus1 = "1ef7f90c-99ed-4408-9532-139b9219c062";
        public const string SpikedHeavyShieldBashingPlus1 = "1ba0e914-346f-4944-b23b-d855333f1554";
        public const string TwoHand = "88c2882c-452e-4549-b8fb-272a070098a6";
        public const string TwoHandDescription = "6c38be03-d665-49d2-b473-71167d2f8c40";
        public const string OrcHornbowWayOfTheBowFeature = "4683f66d-047b-4683-a9e2-ea45c001d475";
        public const string OrcHornbowWayOfTheBow6Feature = "005a8138-572f-4b69-be60-80d05df6170d";
        public const string UpsettingShieldStyle = "ff56e56f-b1f0-4ddc-ade3-f04d01cca12e";
        public const string UpsettingShieldStyleDescription = "76b6e809-7864-4081-b94f-b7c3608b1e2d";

        public const string ShieldBashFeature = "314ff56d-e93b-4915-8ca4-24a7670ad436";
        public const string SpikedLightShield = "7aa87bff-84b7-4337-9ad2-c1f6268fae0e";
        public const string SpikedHeavyShield = "3fa879e0-17e0-4d65-90b5-05c44e28a09c";
        public const string TwoWeaponFighting = "e32ce256-78dc-4fd0-bf15-21f9ebdf9921";
        public const string Buckler = "c9230736-915f-4b43-b119-f7d0b76d24cc";
    }
}