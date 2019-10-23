using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace _8_xml操作
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Skill> skillList = new List<Skill>();   //创建技能信息集合
            XmlDocument xmlDoc = new XmlDocument();   //XmlDocument专门用来解析xml文档
            //xmlDoc.Load("skill.txt");
            xmlDoc.LoadXml(File.ReadAllText("skill.txt"));
            XmlNode rootNode = xmlDoc.FirstChild;
            XmlNodeList skillNodeList = rootNode.ChildNodes;

            foreach(XmlNode skillNode in skillNodeList)
            {
                Skill skill = new Skill();
                XmlNodeList fieldNodeList = skillNode.ChildNodes;
                foreach(XmlNode fieldNode in fieldNodeList)
                {
                    if(fieldNode.Name == "id")
                    {
                        int id = Int32.Parse(fieldNode.InnerText);
                        skill.Id = id;
                    }else if(fieldNode.Name == "name")
                    {
                        string name = fieldNode.InnerText;
                        skill.Name = name;
                        skill.Lang = fieldNode.Attributes[0].Value;
                    }
                    else
                    {
                        skill.Damage = Int32.Parse(fieldNode.InnerText);
                    }
                }
                skillList.Add(skill);
            }
            foreach(Skill skill in skillList)
            {
                Console.WriteLine(skill);
            }
            Console.ReadKey();

        }
    }
}
