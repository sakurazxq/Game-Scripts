using System;
using System.Collections.Generic;
using System.Text;

namespace json操作
{
    class Player
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Age { get; set; }
        public List<Skill> SkillList { get; set; }

        public override string ToString()
        {
            return string.Format("Name:{0},Level:{1},Age:{2},SkillList:{3}", Name,Level,Age,SkillList);
        }
    }
}
