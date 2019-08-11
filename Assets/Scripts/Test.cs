using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour
{

    void Start()
    {

        //各平台下数据库存储的绝对路径(通用)
        //PC：sql = new SQLiteHelper("data source=" + Application.dataPath + "/sqlite4unity.db");
        //Mac：sql = new SQLiteHelper("data source=" + Application.dataPath + "/sqlite4unity.db");
        //Android：sql = new SQLiteHelper("URI=file:" + Application.persistentDataPath + "/sqlite4unity.db");
        //iOS：sql = new SQLiteHelper("data source=" + Application.persistentDataPath + "/sqlite4unity.db");


        //PC平台下的相对路径
        //sql = new SQLiteHelper("data source="sqlite4unity.db");
        //编辑器：Assets/sqlite4unity.db
        //编译后：和AppName.exe同级的目录下，这里比较奇葩
        //当然可以用更随意的方式sql = new SQLiteHelper("data source="D://SQLite//sqlite4unity.db");
        //确保路径存在即可否则会发生错误

        //如果是事先创建了一份数据库
        //可以将这个数据库放置在StreamingAssets目录下然后再拷贝到
        //Application.persistentDataPath + "/sqlite4unity.db"路径即可


        //创建数据库名称为xuanyusong.db
        DbAccess db = new DbAccess("data source=xuanyusong.db");
        //创建数据库表，与字段
        db.CreateTable("momo", new string[] { "name", "qq", "email", "blog" }, new string[] { "text", "text", "text", "text" });
        //关闭对象
        //db.CloseSqlConnection();


        //创建数据库名称为xuanyusong.db
        //DbAccess db = new DbAccess("data source=xuanyusong.db");
        //请注意 插入字符串是 已经要加上'宣雨松' 不然会报错
        db.InsertInto("momo", new string[] { "'宣雨松'", "'289187120'", "'xuanyusong@gmail.com'", "'www.xuanyusong.com'" });
        //db.CloseSqlConnection();



        //创建数据库名称为xuanyusong.db
        // DbAccess db = new DbAccess("data source=xuanyusong.db");

        db.UpdateInto("momo", new string[] { "name", "qq" }, new string[] { "'xuanyusong'", "'11111111'" }, "email", "'xuanyusong@gmail.com'");

        db.CloseSqlConnection();


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

    }

}

