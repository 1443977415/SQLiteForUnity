using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Text text;
    public Text text1;
    private void Awake()
    {
        text .text= System.DateTime.Now.ToString(FieldConst.TIME_FORMAT);
        Init();
        text1.text = System.DateTime.Now.ToString(FieldConst.TIME_FORMAT);
    }
    void Start()
    {

        //创建数据库名称为xuanyusong.db
        //DbAccess db = new DbAccess("data source=xuanyusong.db");
        //请注意 插入字符串是 已经要加上'宣雨松' 不然会报错
        //db.InsertInto("momo", new string[] { "'宣雨松'", "'289187120'", "'xuanyusong@gmail.comqqqqqq'", "'www.xuanyusong.comq'" });
        //db1.InsertInto("momo", new string[] { "'宣雨松1'", "'2891871qqq20'", "'xuanyusong@gmail.com111'", "'www.xuanyusong.com'" });
        //db.CloseSqlConnection();



        //创建数据库名称为xuanyusong.db
        // DbAccess db = new DbAccess("data source=xuanyusong.db");

        //db.UpdateInto("momo", new string[] { "name", "qq" }, new string[] { "'xuanyusong'", "'11111111'" }, "email", "'xuanyusong@gmail.comqqqqqq'");
        //db1.UpdateInto("momo", new string[] { "name", "qq" }, new string[] { "'xuanyusong1'", "'22qqq222'" }, "email", "'xuanyusong@gmail.com111'");

        //db.CloseSqlConnection();
        //db1.CloseSqlConnection();


        /*
        //创建数据库名称为xuanyusong.db
        DbAccess db = new DbAccess("data source=xuanyusong.db");
        //请注意 插入字符串是 已经要加上'宣雨松' 不然会报错
        db.CreateTable("momo", new string[] { "name", "qq", "email", "blog" }, new string[] { "text", "text", "text", "text" });
        //我在数据库中连续插入三条数据
        db.InsertInto("momo", new string[] { "'宣雨松'", "'289187120'", "'xuanyusong@gmail.com'", "'www.xuanyusong.com'" });
        db.InsertInto("momo", new string[] { "'雨松MOMO'", "'289187120'", "'000@gmail.com'", "'www.xuanyusong.com'" });
        db.InsertInto("momo", new string[] { "'哇咔咔'", "'289187120'", "'111@gmail.com'", "'www.xuanyusong.com'" });

        //然后在删掉两条数据
        db.Delete("momo", new string[] { "email", "email" }, new string[] { "'xuanyusong@gmail.com'", "'000@gmail.com'" });

        db.CloseSqlConnection();*/



        /*
         //创建数据库名称为xuanyusong.db
        DbAccess db = new DbAccess("data source=xuanyusong.db");
        //请注意 插入字符串是 已经要加上'宣雨松' 不然会报错
        db.CreateTable("momo",new string[]{"name","qq","email","blog"}, new string[]{"text","text","text","text"});
        //我在数据库中连续插入三条数据
        db.InsertInto("momo", new string[]{ "'宣雨松'","'289187120'","'xuanyusong@gmail.com'","'www.xuanyusong.com'"   });
        db.InsertInto("momo", new string[]{ "'雨松MOMO'","'289187120'","'000@gmail.com'","'www.xuanyusong.com'"   });
        db.InsertInto("momo", new string[]{ "'哇咔咔'","'289187120'","'111@gmail.com'","'www.xuanyusong.com'"   });

        //然后在删掉两条数据
        db.Delete("momo",new string[]{"email","email"}, new string[]{"'xuanyusong@gmail.com'","'000@gmail.com'"}  );

        //注解1
        SqliteDataReader sqReader = db.SelectWhere("momo",new string[]{"name","email"},new string[]{"qq"},new string[]{"="},new string[]{"289187120"});

        while (sqReader.Read())
        {
            Debug.Log(sqReader.GetString(sqReader.GetOrdinal("name")) + sqReader.GetString(sqReader.GetOrdinal("email")));
        } 

        db.CloseSqlConnection();*/

        /*
            //IOS
            //数据库文件储存地址
                string appDBPath = Application.persistentDataPath + "/xuanyusong.db";

                DbAccess db = new DbAccess(@"Data Source=" + appDBPath);

                //请注意 插入字符串是 已经要加上'宣雨松' 不然会报错
                db.CreateTable("momo",new string[]{"name","qq","email","blog"}, new string[]{"text","text","text","text"});
                //我在数据库中连续插入三条数据
                db.InsertInto("momo", new string[]{ "'宣雨松'","'289187120'","'xuanyusong@gmail.com'","'www.xuanyusong.com'"   });
                db.InsertInto("momo", new string[]{ "'雨松MOMO'","'289187120'","'000@gmail.com'","'www.xuanyusong.com'"   });
                db.InsertInto("momo", new string[]{ "'哇咔咔'","'289187120'","'111@gmail.com'","'www.xuanyusong.com'"   });

                //然后在删掉两条数据
                db.Delete("momo",new string[]{"email","email"}, new string[]{"'xuanyusong@gmail.com'","'000@gmail.com'"}  );

                //注解1
                using (SqliteDataReader sqReader = db.SelectWhere("momo",new string[]{"name","email"},new string[]{"qq"},new string[]{"="},new string[]{"289187120"}))
                {

                    while (sqReader.Read())
                    {
                        //目前中文无法显示
                        Debug.Log(sqReader.GetString(sqReader.GetOrdinal("name")));

                        Debug.Log(sqReader.GetString(sqReader.GetOrdinal("email")));

                    } 

                    sqReader.Close();
                }

                db.CloseSqlConnection();*/



        //Android
        //数据库文件储存地址
        /*
                string appDBPath = Application.persistentDataPath + "/xuanyusong.db";

                //注意！！！！！！！这行代码的改动
                DbAccess db = new DbAccess("URI=file:" + appDBPath);

                //请注意 插入字符串是 已经要加上'宣雨松' 不然会报错
                db.CreateTable("momo", new string[] { "name", "qq", "email", "blog" }, new string[] { "text", "text", "text", "text" });
                //我在数据库中连续插入三条数据
                db.InsertInto("momo", new string[] { "'宣雨松'", "'289187120'", "'xuanyusong@gmail.com'", "'www.xuanyusong.com'" });
                db.InsertInto("momo", new string[] { "'雨松MOMO'", "'289187120'", "'000@gmail.com'", "'www.xuanyusong.com'" });
                db.InsertInto("momo", new string[] { "'哇咔咔'", "'289187120'", "'111@gmail.com'", "'www.xuanyusong.com'" });

                //然后在删掉两条数据
                db.Delete("momo", new string[] { "email", "email" }, new string[] { "'xuanyusong@gmail.com'", "'000@gmail.com'" });

                //注解1
                using (SqliteDataReader sqReader = db.SelectWhere("momo", new string[] { "name", "email" }, new string[] { "qq" }, new string[] { "=" }, new string[] { "289187120" }))
                {

                    while (sqReader.Read())
                    {
                        Debug.Log("xuanyusong" + sqReader.GetString(sqReader.GetOrdinal("name")));

                        Debug.Log("xuanyusong" + sqReader.GetString(sqReader.GetOrdinal("email")));

                    }

                    sqReader.Close();
                }

                db.CloseSqlConnection();*/
        InsertTest();
    }

    void Init() {
        DbAccess db = new DbAccess();
        db.DelteAllTables();
        db.CreateAllTables();
        db.CloseSqlConnection();
    }
    void InsertTest() {
        DbAccess db = new DbAccess();
        db.InsertIntoSpecific(FieldConst.FRIEND, new string[] { FieldConst.FRIEND_ID,  FieldConst.FRIEND_LEVEL, FieldConst.RECOVERY_TIME, FieldConst.BECOME_FRIEND_TIME }, new string[] { "1", "'1'", "'哈哈哈'", "'倒萨'" }, FieldConst.FRIEND_ID);
        db.InsertIntoSpecific(FieldConst.FRIEND, new string[] { FieldConst.FRIEND_ID, FieldConst.FRIEND_NAME, FieldConst.FRIEND_LEVEL, FieldConst.BECOME_FRIEND_TIME }, new string[] { "1", "'b'", "'2'", "'哈哈哈2'" }, FieldConst.FRIEND_ID);
        db.InsertIntoSpecific(FieldConst.FRIEND, new string[]{  FieldConst.FRIEND_NAME, FieldConst.FRIEND_LEVEL, FieldConst.RECOVERY_TIME, FieldConst.BECOME_FRIEND_TIME }, new string[]{"'b'","'3'","'倒萨3'", "'哈哈哈3'" }, FieldConst.FRIEND_NAME);
        db.InsertIntoSpecific(FieldConst.FRIEND, new string[]{  FieldConst.FRIEND_ID, FieldConst.FRIEND_LEVEL, FieldConst.RECOVERY_TIME, FieldConst.BECOME_FRIEND_TIME }, new string[]{"'2'","'3'","'倒萨3'", "'哈哈哈3'" }, FieldConst.FRIEND_ID);

        db.InsertIntoSpecific(FieldConst.FRIEND, new string[]{ FieldConst.FRIEND_ID, FieldConst.FRIEND_NAME, FieldConst.FRIEND_LEVEL, FieldConst.RECOVERY_TIME }, new string[]{"2","'b'","'4'","'哈哈哈4'" }, FieldConst.FRIEND_ID);//禁用   自己看

        //db.InsertIntoSpecific(FieldConst.FRIEND, new string[] { FieldConst.FRIEND_ID+","+ FieldConst.FRIEND_NAME, FieldConst.FRIEND_LEVEL, FieldConst.RECOVERY_TIME, FieldConst.BECOME_FRIEND_TIME }, new string[] {  "1,'10'","'5'", "'哈哈哈5'", "'倒萨5'" });
        db.CloseSqlConnection();
    }
    void InsertTest2()
    {
        DbAccess db = new DbAccess();
        db.InsertInto(FieldConst.FRIEND, new string[] { "1", "'a'", "'1'", "'哈哈哈'", "'倒萨'" });
        db.InsertInto(FieldConst.FRIEND, new string[] { "1", "'b'", "'2'", "'哈哈哈2'", "'倒萨2'" });
        db.InsertInto(FieldConst.FRIEND, new string[] { "1", "'b'", "'3'", "'哈哈哈3'", "'倒萨3'" });
        db.InsertInto(FieldConst.FRIEND, new string[] { "2", "'b'", "'4'", "'哈哈哈4'", "'倒萨4'" });
        db.InsertInto(FieldConst.FRIEND, new string[] { "3", "'a'", "'5'", "'哈哈哈5'", "'倒萨5'" });
        db.CloseSqlConnection();
    }

}

