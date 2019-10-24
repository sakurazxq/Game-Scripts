using LitJson;
using System;
using System.Collections.Generic;
using System.IO;

namespace json操作
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<Skill> skillList = new List<Skill>();

            //JsonData jsonData = JsonMapper.ToObject(File.ReadAllText("json技能信息.txt"));   //使用JsonMapper解析json文本，JsonData代表一个数组或者一个对象，这里代表数组
            //foreach (JsonData temp in jsonData)    //这里temp代表一个对象
            //{
            //    Skill skill = new Skill();
            //    JsonData idValue = temp["id"];   //通过字符串索引器取得键值对的值
            //    JsonData nameValue = temp["name"];
            //    JsonData damageValue = temp["damage"];
            //    int id = Int32.Parse(idValue.ToString());
            //    int damage = Int32.Parse(damageValue.ToString());
            //    skill.id = id;
            //    skill.damage = damage;
            //    skill.name = nameValue.ToString();
            //    skillList.Add(skill);
            //}
            //foreach(var temp in skillList)
            //{
            //    Console.WriteLine(temp);
            //}

            //Skill[] skillArray = JsonMapper.ToObject<Skill[]>(File.ReadAllText("json技能信息.txt"));
            //foreach(var temp in skillArray)
            //{
            //    Console.WriteLine(temp);
            //}

            //List<Skill> skillList = JsonMapper.ToObject<List<Skill>>(File.ReadAllText("json技能信息.txt"));
            //foreach (var temp in skillList)
            //{
            //    Console.WriteLine(temp);
            //}

            //Player p = JsonMapper.ToObject<Player>(File.ReadAllText("player.txt"));
            //Console.WriteLine(p);
            //foreach(var temp in p.SkillList)
            //{
            //    Console.WriteLine(temp);
            //}

            Player p = new Player();
            p.Name = "花千骨";
            p.Level = 100;
            p.Age = 18;
            string json = JsonMapper.ToJson(p);
            Console.WriteLine(json);

            Console.ReadKey();
        }
    }
}
