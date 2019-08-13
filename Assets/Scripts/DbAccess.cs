using UnityEngine;
using System;
using Mono.Data.Sqlite;
using System.IO;

public class DbAccess

{
    //各平台下数据库存储的绝对路径(通用)
    //PC：sql = new SQLiteHelper("data source=" + Application.dataPath + "/sqlite4unity.db");
    //Mac：sql = new SQLiteHelper("data source=" + Application.dataPath + "/sqlite4unity.db");
    //Android：sql = new SQLiteHelper("URI=file:" + Application.persistentDataPath + "/sqlite4unity.db");
    //iOS：sql = new SQLiteHelper("data source=" + Application.persistentDataPath + "/sqlite4unity.db");
    //注意如果插入字符串 需要 ' ' 包围起来  ，不包围默认为数字，会转换错误
#if UNITY_EDITOR
    private string pathPrefix = "data source=" + Application.dataPath + "/";
#elif UNITY_IOS
        private string pathPrefix = "data source=" + Application.persistentDataPath + "/";
#elif UNITY_ANDROID
        private string pathPrefix = "URI=file:" + Application.persistentDataPath + "/";
#elif UNITY_EDITOR_WIN
        private string pathPrefix = "data source=" + Application.dataPath + "/";
#elif UNITY_EDITOR_OSX
        private string pathPrefix = "data source=" + Application.dataPath + "/";
#else
        Debug.Log("Any other platform");
#endif

    private SqliteConnection dbConnection;

    private SqliteCommand dbCommand;

    private SqliteDataReader reader;
    private bool isConnected;
    public DbAccess(string dbName="aliya.db")

    {
        isConnected = false;
        OpenDB(dbName);
    }
   /* public DbAccess()
    {
        isclosed = true;
    }
    */
    public void OpenDB(string dbName = "aliya.db")

    {
        if (isConnected)
            return;
        try
        {
            dbConnection = new SqliteConnection(pathPrefix + dbName);

            dbConnection.Open();
            isConnected = true;
            Debug.Log("Connected to db");
        }
        catch (Exception e)
        {
            string temp1 = e.ToString();
            isConnected = false;
            Debug.Log(temp1);
        }

    }

    public void CloseSqlConnection()

    {
        if (!isConnected)
            return;
        if (dbCommand != null)
        {

            dbCommand.Dispose();

        }

        dbCommand = null;

        if (reader != null)
        {

            reader.Dispose();

        }

        reader = null;

        if (dbConnection != null)
        {

            dbConnection.Close();

        }

        dbConnection = null;
        isConnected = false;
        Debug.Log("Disconnected from db.");

    }

    public SqliteDataReader ExecuteQuery(string sqlQuery)

    {
        if (!isConnected) {
            Debug.LogWarning("Disconnected from db.");
            return null;
        }
        dbCommand = dbConnection.CreateCommand();

        dbCommand.CommandText = sqlQuery;

        reader = dbCommand.ExecuteReader();

        return reader;

    }

    public SqliteDataReader ReadFullTable(string tableName)

    {

        string query = "SELECT * FROM " + tableName;

        return ExecuteQuery(query);

    }
   // insert or replace：如果不存在就插入，存在就更新 
    //insert or ignore：如果不存在就插入，存在就忽略 
    public SqliteDataReader InsertInto(string tableName, string[] values)

    {

        string query = "INSERT OR REPLACE INTO " + tableName + " VALUES (" + values[0]; //存在则更新
       // string query = "INSERT INTO " + tableName + " VALUES (" + values[0];//插入新数据

        for (int i = 1; i < values.Length; ++i)
        {

            query += ", " + values[i];

        }

        query += ")";

        return ExecuteQuery(query);

    }

    public SqliteDataReader UpdateInto(string tableName, string[] cols, string[] colsvalues, string selectkey, string selectvalue)
    {

        string query = "UPDATE " + tableName + " SET " + cols[0] + " = " + colsvalues[0];

        for (int i = 1; i < colsvalues.Length; ++i)
        {

            query += ", " + cols[i] + " =" + colsvalues[i];
        }

        query += " WHERE " + selectkey + " = " + selectvalue + " ";

        return ExecuteQuery(query);
    }

    public SqliteDataReader DeleteByOr(string tableName, string[] cols, string[] colsvalues)
    {
        string query = "DELETE FROM " + tableName + " WHERE " + cols[0] + " = " + colsvalues[0];

        for (int i = 1; i < colsvalues.Length; ++i)
        {

            query += " or " + cols[i] + " = " + colsvalues[i];
        }
        Debug.Log(query);
        return ExecuteQuery(query);
    }
    public SqliteDataReader DeleteByAnd(string tableName, string[] cols, string[] colsvalues)
    {
        string query = "DELETE FROM " + tableName + " WHERE " + cols[0] + " = " + colsvalues[0];

        for (int i = 1; i < colsvalues.Length; ++i)
        {

            query += " and " + cols[i] + " = " + colsvalues[i];
        }
        Debug.Log(query);
        return ExecuteQuery(query);
    }
    public SqliteDataReader InsertIntoSpecific(string tableName, string[] cols, string[] values)

    {

        if (cols.Length != values.Length)
        {

            throw new SqliteException("columns.Length != values.Length");

        }

        string query = "INSERT OR REPLACE INTO " + tableName + "(" + cols[0];

        for (int i = 1; i < cols.Length; ++i)
        {

            query += ", " + cols[i];

        }

        query += ") VALUES (" + values[0];

        for (int i = 1; i < values.Length; ++i)
        {

            query += ", " + values[i];

        }

        query += ")";
        Debug.Log(query);
        return ExecuteQuery(query);

    }

    public SqliteDataReader DeleteContents(string tableName)

    {

        string query = "DELETE FROM " + tableName;

        return ExecuteQuery(query);

    }

    public SqliteDataReader CreateTable(string name, string[] col, string[] colType)

    {

        if (col.Length != colType.Length)
        {

            throw new SqliteException("columns.Length != colType.Length");

        }

        string query = "CREATE TABLE " + name + " (" + col[0] + " " + colType[0];

        for (int i = 1; i < col.Length; ++i)
        {

            query += ", " + col[i] + " " + colType[i];

        }

        query += ")";
        return ExecuteQuery(query);

    }

    public SqliteDataReader SelectWhere(string tableName, string[] items, string[] col, string[] operation, string[] values)

    {

        if (col.Length != operation.Length || operation.Length != values.Length)
        {

            throw new SqliteException("col.Length != operation.Length != values.Length");

        }

        string query = "SELECT " + items[0];

        for (int i = 1; i < items.Length; ++i)
        {

            query += ", " + items[i];

        }

        query += " FROM " + tableName + " WHERE " + col[0] + operation[0] + "'" + values[0] + "' ";

        for (int i = 1; i < col.Length; ++i)
        {

            query += " AND " + col[i] + operation[i] + "'" + values[0] + "' ";

        }

        return ExecuteQuery(query);

    }
    //这里不是用清空数据因为统一全部重新生成新的表，不然还得判断那些表没有生成
    public void DelteAllTables()
    {
        SqliteDataReader re = ExecuteQuery("SELECT name FROM sqlite_master WHERE type = 'table'");
        System.Collections.Generic.List<string> tbNames = new System.Collections.Generic.List<string>();
        while (re.Read())
        {
            tbNames.Add(re.GetValue(0).ToString());
            //Debug.LogWarning(re.GetValue(0));
        }
        re.Close();
        foreach (string name in tbNames)
        {
            ExecuteQuery("DROP TABLE " + name);
        }
    }
    public void CreateAllTables()
    {
        //FieldConst.ARMOR_ID为唯一约束
        CreateTable(FieldConst.ARMOR, new string[] { FieldConst.ARMOR_ID, FieldConst.ARMOR_LEVEL1, FieldConst.ARMOR_LEVEL2, FieldConst.ARMOR_LEVEL3, FieldConst.ARMOR_LEVEL4, FieldConst.ARMOR_LEVEL5, FieldConst.ARMOR_LEVEL6, FieldConst.ARMOR_LEVEL7, FieldConst.ARMOR_LEVEL8, FieldConst.ARMOR_LEVEL9, FieldConst.ARMOR_LEVEL10 }, new string[] { "varchar(300) UNIQUE", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)" });
        //FieldConst.UNIQUE_ID为主键
        CreateTable(FieldConst.DARK_MARKET, new string[] {FieldConst.UNIQUE_ID,FieldConst.MERCHANDISE+"1", FieldConst.MERCHANDISE+"1"+FieldConst._QUANTITY, FieldConst.CURRENCY_TYPE + "1", FieldConst.CURRENCY_TYPE + "1"+FieldConst._PRICE,
            FieldConst.MERCHANDISE+"2", FieldConst.MERCHANDISE+"2"+FieldConst._QUANTITY, FieldConst.CURRENCY_TYPE + "2", FieldConst.CURRENCY_TYPE + "2"+FieldConst._PRICE,
            FieldConst.MERCHANDISE+"3", FieldConst.MERCHANDISE+"3"+FieldConst._QUANTITY, FieldConst.CURRENCY_TYPE + "3", FieldConst.CURRENCY_TYPE + "3"+FieldConst._PRICE,
            FieldConst.MERCHANDISE+"4", FieldConst.MERCHANDISE+"4"+FieldConst._QUANTITY, FieldConst.CURRENCY_TYPE + "4", FieldConst.CURRENCY_TYPE + "4"+FieldConst._PRICE,
            FieldConst.MERCHANDISE+"5", FieldConst.MERCHANDISE+"5"+FieldConst._QUANTITY, FieldConst.CURRENCY_TYPE + "5", FieldConst.CURRENCY_TYPE + "5"+FieldConst._PRICE,
            FieldConst.MERCHANDISE+"6", FieldConst.MERCHANDISE+"6"+FieldConst._QUANTITY, FieldConst.CURRENCY_TYPE + "6", FieldConst.CURRENCY_TYPE + "6"+FieldConst._PRICE,
            FieldConst.MERCHANDISE+"7", FieldConst.MERCHANDISE+"7"+FieldConst._QUANTITY, FieldConst.CURRENCY_TYPE + "7", FieldConst.CURRENCY_TYPE + "7"+FieldConst._PRICE,
            FieldConst.MERCHANDISE+"8", FieldConst.MERCHANDISE+"8"+FieldConst._QUANTITY, FieldConst.CURRENCY_TYPE + "8", FieldConst.CURRENCY_TYPE + "8"+FieldConst._PRICE,
            FieldConst.REFRESH_TIME,FieldConst.REFRESHABLE_QUANTITY
        }, new string[] { "INT PRIMARY KEY", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)" });
        //FieldConst.UNIQUE_ID为主键
        CreateTable(FieldConst.FAMILY, new string[] { FieldConst.UNIQUE_ID, FieldConst.FAMILYID, FieldConst.FAMILYNAME, FieldConst.MEMBER + "0", FieldConst.MEMBER + "1", FieldConst.MEMBER + "2", FieldConst.MEMBER + "3", FieldConst.MEMBER + "4", FieldConst.MEMBER + "5" }, new string[] { "INT PRIMARY KEY", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)" });
        //目前以friendID为唯一键   但是为了安全可能使用其他或者名字为唯一约束   多约束
        CreateTable(FieldConst.FRIEND, new string[] { FieldConst.FRIEND_ID, FieldConst.FRIEND_NAME, FieldConst.FRIEND_LEVEL, FieldConst.RECOVERY_TIME, FieldConst.BECOME_FRIEND_TIME }, new string[] { "INT PRIMARY KEY", "varchar(300) UNIQUE", "varchar(300)", "varchar(300)", "varchar(300)" });
        //FieldConst.UNIQUE_ID为主键
        CreateTable(FieldConst.PLAYER, new string[] { FieldConst.UNIQUE_ID,FieldConst.GAME_NAME, FieldConst.COIN, FieldConst.IRON, FieldConst.DIAMOND, FieldConst .ENERGY, FieldConst.EXPERIENCE, FieldConst.LEVEL, FieldConst.ROLE, FieldConst.STAGE, FieldConst.TOWER_STAGE, FieldConst.SCROLL_SKILL_10, FieldConst.SCROLL_SKILL_30
        , FieldConst.SCROLL_SKILL_100, FieldConst.EXPERIENCE_POTION, FieldConst.SMALL_ENERGY_POTION, FieldConst.RECOVER_TIME, FieldConst.HANG_STAGE, FieldConst.HANG_UP_TIME, FieldConst.BASIC_SUMMON_SCROLL, FieldConst.PRO_SUMMON_SCROLL, FieldConst.FRIEND_GIFT, FieldConst.PROPHET_SUMMON_SCROLL
       , FieldConst.FORTUNE_WHEEL_TICKET_BASIC, FieldConst.FORTUNE_WHEEL_TICKET_PRO, FieldConst.FAMILYID}, new string[] { "INT PRIMARY KEY", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)" });
        //FieldConst.ROLE_NAME为唯一约束
        CreateTable(FieldConst.ROLE, new string[] {FieldConst.ROLE_NAME, FieldConst.ROLE_STAR, FieldConst.ROLE_LEVEL, FieldConst.PASSIVE_SKILL_1_LEVEL, FieldConst.PASSIVE_SKILL_2_LEVEL, FieldConst.PASSIVE_SKILL_3_LEVEL, FieldConst.PASSIVE_SKILL_4_LEVEL, FieldConst.SKILL_POINT, FieldConst.SEGMENT }, new string[] { "varchar(300)  UNIQUE", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)" });
        //FieldConst.UNIQUE_ID为主键
        CreateTable(FieldConst.SKILL, new string[] {
            FieldConst.UNIQUE_ID,
            FieldConst.M1 + FieldConst._LEVEL ,
            FieldConst.M1 + "1" + FieldConst._LEVEL,
            FieldConst.M1 + "2" + FieldConst._LEVEL,
FieldConst.M1 + "3" + FieldConst._LEVEL,
FieldConst.M1 + "11" + FieldConst._LEVEL,
FieldConst.M1 + "12" + FieldConst._LEVEL,
FieldConst.M1 + "13" + FieldConst._LEVEL,
FieldConst.M1 + "21" + FieldConst._LEVEL,
FieldConst.M1 + "22" + FieldConst._LEVEL,
FieldConst.M1 + "23" + FieldConst._LEVEL,
FieldConst.M1 + "31" + FieldConst._LEVEL,
FieldConst.M1 + "32" + FieldConst._LEVEL,
FieldConst.M1 + "33" + FieldConst._LEVEL,
FieldConst.P1 + FieldConst._LEVEL,
FieldConst.P1 + "1" + FieldConst._LEVEL,
FieldConst.P1 + "2" + FieldConst._LEVEL,
FieldConst.P1 + "3" + FieldConst._LEVEL,
FieldConst.P1 + "11" + FieldConst._LEVEL,
FieldConst.P1 + "12" + FieldConst._LEVEL,
FieldConst.P1 + "13" + FieldConst._LEVEL,
FieldConst.P1 + "21" + FieldConst._LEVEL,
FieldConst.P1 + "22" + FieldConst._LEVEL,
FieldConst.P1 + "23" + FieldConst._LEVEL,
FieldConst.P1 + "31" + FieldConst._LEVEL,
FieldConst.P1 + "32" + FieldConst._LEVEL,
FieldConst.P1 + "33" + FieldConst._LEVEL,
FieldConst.G1+ FieldConst._LEVEL,
FieldConst.G1 + "1" + FieldConst._LEVEL,
FieldConst.G1 + "2" + FieldConst._LEVEL,
FieldConst.G1 + "3" + FieldConst._LEVEL,
FieldConst.G1 + "11" + FieldConst._LEVEL,
FieldConst.G1 + "12" + FieldConst._LEVEL,
FieldConst.G1 + "13" + FieldConst._LEVEL,
FieldConst.G1 + "21" + FieldConst._LEVEL,
FieldConst.G1 + "22" + FieldConst._LEVEL,
FieldConst.G1 + "23" + FieldConst._LEVEL,
FieldConst.G1 + "31" + FieldConst._LEVEL,
FieldConst.G1 + "32" + FieldConst._LEVEL,
FieldConst.G1 + "33" + FieldConst._LEVEL }, new string[] { "INT PRIMARY KEY", "varchar(300)","varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)" , "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)" });
        //FieldConst.UNIQUE_ID为主键
        CreateTable(FieldConst.USERINFO, new string[] { FieldConst.UNIQUE_ID, FieldConst.TOKEN, FieldConst.PASSWORD, FieldConst.ACCOUNT, FieldConst.EMAIL, FieldConst.PHONE__NUMBER }, new string[] { "INT PRIMARY KEY", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)" });
        //FieldConst.WEAPON_NAME为唯一约束
        CreateTable(FieldConst.WEAPON, new string[] { FieldConst.WEAPON_NAME, FieldConst.WEAPON_STAR, FieldConst.WEAPON_LEVEL, FieldConst.PASSIVE_SKILL_1_LEVEL, FieldConst.PASSIVE_SKILL_2_LEVEL, FieldConst.PASSIVE_SKILL_3_LEVEL, FieldConst.PASSIVE_SKILL_4_LEVEL, FieldConst.SKILL_POINT, FieldConst.SEGMENT }, new string[] { "varchar(300)  UNIQUE", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)", "varchar(300)" });
    }
}   