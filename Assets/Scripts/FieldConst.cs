using UnityEngine;
using UnityEditor;

public class FieldConst
{
    public const string ENGLISH = "English";
    public const string CHINESE = "Chinese";
    public const string STANDARD = "Standard";
    public const string LOCALIZATION = "localization";
    public const string UNIQUE_ID = "unique_id";
    public const int UNIQUE_ID_VALUES = 1;
    public const string _LEVEL = "_level";
    public const string SKILL = "skill";
    public const string TIME_FORMAT = "yyyy-MM-dd HH:mm:ss";

    #region Player Field
    public const string COIN = "coin";
    public const string IRON = "iron";
    public const string DIAMOND = "diamond";
    public const string ENERGY = "energy";
    public const string EXPERIENCE = "experience";
    public const string LEVEL = "level";
    public const string ROLE = "role";
    public const string STAGE = "stage";
    public const string SCROLL_SKILL_10 = "skill_scroll_10";
    public const string SCROLL_SKILL_30 = "skill_scroll_30";
    public const string SCROLL_SKILL_100 = "skill_scroll_100";
    public const string EXPERIENCE_POTION = "experience_potion";
    public const string SMALL_ENERGY_POTION = "small_energy_potion";
    public const string RECOVER_TIME = "recover_time";
    public const string COOLING_TIME = "cooling_time";
    public const string HANG_UP_TIME = "hang_up_time";
    public const string HANG_UP_TIME_SECONDS = "hang_up_time_seconds";
    public const string HANG_STAGE = "hang_stage";
    public const string BASIC_SUMMON_SCROLL = "basic_summon_scroll";
    public const string PRO_SUMMON_SCROLL = "pro_summon_scroll";
    public const string FRIEND_GIFT = "friend_gift";
    public const string PROPHET_SUMMON_SCROLL = "prophet_summon_scroll";
    public const string FORTUNE_WHEEL_TICKET_BASIC = "fortune_wheel_ticket_basic";
    public const string FORTUNE_WHEEL_TICKET_PRO = "fortune_wheel_ticket_pro";
    public const string GAME_NAME = "game_name";
    public const string TOWER_STAGE = "tower_stage";

    #endregion
    #region Skill Field
    public const string M1 = "m1";
    public const string G1 = "g1";
    public const string P1 = "p1";
    #endregion
    #region UserInfo Field
    public const string USERINFO = "userinfo";
    public const string PLAYER = "player";
    public const string ACCOUNT = "account";
    public const string PASSWORD = "password";
    public const string IP = "ip";
    public const string TOKEN = "token";
    public const string USER_NAME = "user_name";
    public const string GENDER = "gender";
    public const string EMAIL = "email";
    public const string PHONE__NUMBER = "phone_number";
    public const string BIRTH_DAY = "birth_day";
    public const string LAST_TIME_LOGIN = "last_time_login";
    public const string REGISTRATION_TIME = "registration_time";
    public const string HEAD_PHOTO = "head_photo";
    public const string IS_BIND_ACCOUNT = "is_bind_account";
    public const string IS_BIND_EMAIL = "is_bind_email";
    public const string IS_BIND_PHONE = "is_bind_phone";
    public const string SALT = "salt";

    #endregion
    #region WeaponBag Field
    public const string WEAPON = "weapon";
    public const string WEAPON_NAME = "weapon_name";
    public const string WEAPON_STAR = "weapon_star";
    public const string WEAPON_LEVEL = "weapon_level";
    #endregion
    #region WeaponTables Field
    public const string PASSIVE_ = "passive_";
    public const string SKILL_ = "skill_";
    public const string PASSIVE_SKILL_1_LEVEL = "passive_skill_1_level";
    public const string _PASSIVE_SKILL_1_LEVEL = "_passive_skill_1_level";
    public const string PASSIVE_SKILL_2_LEVEL = "passive_skill_2_level";
    public const string _PASSIVE_SKILL_2_LEVEL = "_passive_skill_2_level";
    public const string PASSIVE_SKILL_3_LEVEL = "passive_skill_3_level";
    public const string _PASSIVE_SKILL_3_LEVEL = "_passive_skill_3_level";
    public const string PASSIVE_SKILL_4_LEVEL = "passive_skill_4_level";
    public const string _PASSIVE_SKILL_4_LEVEL = "_passive_skill_4_level";
    public const string _SKILL_POINT = "_skill_point";
    public const string SKILL_POINT = "skill_point";
    public const string SEGMENT = "segment";
    public const string _SEGMENT = "_segment";
    public const string STAR = "star";
    public const string _STAR = "_star";
    #endregion
    #region Dark Market
    public const string DARK_MARKET = "dark_market";
    public const string MERCHANDISE = "merchandise";
    public const string _QUANTITY = "_quantity";
    public const string CURRENCY_TYPE = "currency_type";
    public const string _PRICE = "_price";
    public const string REFRESH_TIME = "refresh_time";
    public const string REFRESHABLE_QUANTITY = "refreshable_quantity";
    #endregion
    #region Role Field
    public const string ROLE_NAME = "role_name";
    public const string ROLE_STAR = "role_star";
    public const string ROLE_LEVEL = "role_level";
    #endregion
    #region Armor Field
    //存储方式 armorarmor_level1: 1
    public const string ARMOR = "armor";
    public const string ARMOR_ID = "armor_id";
    public const string ARMOR_LEVEL1 = "armor_level1";
    public const string ARMOR_LEVEL2 = "armor_level2";
    public const string ARMOR_LEVEL3 = "armor_level3";
    public const string ARMOR_LEVEL4 = "armor_level4";
    public const string ARMOR_LEVEL5 = "armor_level5";
    public const string ARMOR_LEVEL6 = "armor_level6";
    public const string ARMOR_LEVEL7 = "armor_level7";
    public const string ARMOR_LEVEL8 = "armor_level8";
    public const string ARMOR_LEVEL9 = "armor_level9";
    public const string ARMOR_LEVEL10 = "armor_level10";
    public const string ARMOR_TOTAL_COUNT = "armor_total_count";

    #endregion

    #region Lottery Field
    public enum LotteryType
    {
        BasicSummon, ProSummon, FriendSummon, BasicSummon10, ProSummon10, FriendSummon10,
        BasicSummonSkill,
        ProSummonSkill,
        FriendSummonSkill,
        ProSummonSkill10,
        BasicSummonSkill10,
        FriendSummonSkill10,
        BasicSummonRole,
        ProSummonRole,
        FriendSummonRole,
        BasicSummonRole10,
        ProSummonRole10,
        FriendSummonRole10,
        ProphetSummon,
        ProphetSummon10,
        FortuneWheelBasic,
        FortuneWheelPro
    }
    public const string SKILLS_COIN = "skills_coin";
    public const string SKILLS_DIAMOND = "skills_diamond";
    public const string SKILLS_BASIC_SUMMON_SCROLL = "skills_basic_summon_scroll";
    public const string SKILLS_PRO_SUMMON_SCROLL = "skills_pro_summon_scroll";
    public const string SKILLS_FRIEND_GIFT = "skills_friend_gift";
    public const string SKILLS_PROPHET_SUMMON_SCROLL = "skills_prophet_summon_scroll";
    public const string WEAPONS_COIN = "weapons_coin";
    public const string WEAPONS_DIAMOND = "weapons_diamond";
    public const string WEAPONS_BASIC_SUMMON_SCROLL = "weapons_basic_summon_scroll";
    public const string WEAPONS_PRO_SUMMON_SCROLL = "weapons_pro_summon_scroll";
    public const string WEAPONS_FRIEND_GIFT = "weapons_friend_gift";
    public const string WEAPONS_PROPHET_SUMMON_SCROLL = "weapons_prophet_summon_scroll";
    public const string ROLES_COIN = "roles_coin";
    public const string ROLES_DIAMOND = "roles_diamond";
    public const string ROLES_BASIC_SUMMON_SCROLL = "roles_basic_summon_scroll";
    public const string ROLES_PRO_SUMMON_SCROLL = "roles_pro_summon_scroll";
    public const string ROLES_FRIEND_GIFT = "roles_friend_gift";
    public const string ROLES_PROPHET_SUMMON_SCROLL = "roles_prophet_summon_scroll";
    public const string FORTUNE_WHEEL_COIN = "fortune_wheel_coin";
    public const string FORTUNE_WHEEL_DIAMOND = "fortune_wheel_diamond";
    public const string FORTUNE_WHEEL_BASIC_SUMMON_SCROLL = "fortune_wheel_basic_summon_scroll";
    public const string FORTUNE_WHEEL_PRO_SUMMON_SCROLL = "fortune_wheel_pro_summon_scroll";
    public const string FORTUNE_WHEEL_FRIEND_GIFT = "fortune_wheel_friend_gift";
    public const string FORTUNE_WHEEL_FORTUNE_WHEEL_TICK_BASIC = "fortune_wheel_fortune_wheel_ticket_basic";
    public const string FORTUNE_WHEEL_FORTUNE_WHEEL_TICK_PRO = "fortune_wheel_fortune_wheel_ticket_pro";
    #endregion

    #region Config Field
    public enum ConfigType
    {
        LevelEnemyLayouts,
        LevelEnemyLayoutsTower,
        Monster,
        HangUp,
        Lottery,
        StageReward,
        WorldDistribution,
        EntryConsumables,
        AllTower
    }
    public const string LEVELENEMYLAYOUTSCONFIG = "LevelEnemyLayouts.json";
    public const string LEVELENEMYLAYOUTSTOWERCONFIG = "LevelEnemyLayoutsTower.json";
    public const string MONSTERCONFIG = "Monster.json";
    public const string HANGUPCONFIG = "HangUp.json";
    public const string LOTTERYCONFIG = "Lottery.json";
    public const string STAGEREWARDCONFIG = "StageReward.json";
    public const string WORLDDISTRIBUTIONCONFIG = "WorldDistribution.json";
    public const string ENTRYCONSUMABLESCONFIG = "EntryConsumables.json";
    public const string ALLTOWERCONFIG = "AllTower.json";
    #endregion
    #region friend
    public const string FRIEND = "friend";
    public const string _ID = "_id";
    public const string FRIEND_ID = "friend_id";
    public const string _NAME = "_name";
    public const string FRIEND_NAME = "friend_name";
    public const string FRIEND_LEVEL = "friend_level";
    public const string RECOVERY_TIME = "recovery_time";
    public const string _RECOVERY_TIME = "_recovery_time";
    public const string _BECOME_FRIEND_TIME = "_become_friend_time";
    public const string BECOME_FRIEND_TIME = "become_friend_time";
    public const string FRIEND_TOTAL_COUNT = "friend_total_count";
    #endregion

    #region family
    public const string FAMILY = "family";
    public const string FAMILYID = "familyid";
    public const string FAMILYNAME = "familyname";
    public const string MEMBER = "member";
    public const string FAMILY_TOTAL_MEBERS = "family_total_mebers";
    #endregion
}
