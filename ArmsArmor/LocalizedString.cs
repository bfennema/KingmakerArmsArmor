using Kingmaker.Localization;

namespace ArmsArmor
{
    class LocalizedStringHelper
    {
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
            AddString("969f5b6f-00f6-48d8-bc06-b8a852d63bfd", "Non-Proficiency Penalty");
            AddString("5f26093f-af20-4c9f-99f3-b05f857f82bb", "Temple Sword");
            AddString("c641bed7-07d1-4fd0-899b-6d9a3d65d712", "Weapon Focus (Temple Sword)");
            AddString("6fcbb42e-ab9c-475b-bfa5-7330d6331810", "You gain a +1 bonus on all attack rolls you make using temple swords.");
            AddString("4fa06299-19dd-48c2-bab6-de38d54fd587", "Weapon Proficiency (Temple Sword)");
            AddString("b0aa76ca-bc8e-4cde-9f30-16e0d3953732", "You become proficient with temple swords and can use them as a weapon.");
            AddString("8e2f52b3-9deb-4570-a1b6-7ddd9dd2fd8a", "Combat Competence");
            AddString("704b2965-6fa6-43d9-a946-1539e2eb142e", "For any weapon in the associated weapon group with which the fighter is not proficient, the penalty on attack rolls taken as a result of not being proficient is reduced by an amount equal to the fighter’s weapon training bonus with that weapon group. Once the penalty is reduced to 0, the fighter becomes proficient with such weapons.");
            AddString("2845c74a-a0aa-473b-87f0-7eedc71f6786", "Irongrip");
            AddString("8213446b-b0f4-47a2-b1f8-a4048fd99568", "Irongrip Gauntlets");
            AddString("490bfc6d-3898-40d7-88ab-f741f12ec4e4", "These gloves are made of goatskin reinforced with heavy iron strips. They provide a sure, strengthened grip on large or awkwardly shaped items. When the wearer wields an improvised melee weapon or inappropriately sized weapon, reduce the penalty for doing so by 2 (minimum 0). The gloves don’t change the number of hands required to wield such a weapon.");
            AddString("3178bb0c-f6ed-4e56-9877-e5edc03fbb5d", "Bashing");
            AddString("4ba52894-0155-48ac-9241-bab25Fa44e17", "A shield with this special ability is designed to perform a shield bash. A bashing shield deals damage as if it were a bashing weapon of two size categories larger (a Medium light shield thus deals 1d6 points of damage and a Medium heavy shield deals 1d8 points of damage). The shield acts as a +1 weapon when used to bash. Only light and heavy shields can have this ability.");
            AddString("63a4211a-3130-41f1-a80e-a7fc45427642", "Impact");
            AddString("3e48795f-ebf1-4e08-88e0-ab52eabf84b9", "This special ability can only be placed on melee weapons that are not light weapons. An impact weapon delivers a potent kinetic jolt when it strikes, dealing damage as if the weapon were one size category larger. In addition, any bull rush combat maneuver the wielder attempts while wielding the weapon gains a bonus equal to the weapon’s enhancement bonus; this includes all bull rush attempts, not only those in which a weapon is used, such as Bull Rush Strike, Shield Slam, or Unseat.");
            AddString("1d8c4846-774f-41d5-b5ec-17eac2651722", "Improved Shield Bash");
        }
    }
}