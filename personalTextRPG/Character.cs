using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personalTextRPG
{
    enum CharacterClass // 직업
    {
        None,
        전사,
        마법사,
    }

    internal class Character
    {
        private static Character instance;
        public static Character Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Character();    
                }
                return instance;
            }
        }

        private int level;
        private string name;
        private CharacterClass charClass;
        private int attack;
        private int defense;
        private int health;
        private int gold;
        public int Level {  get { return level; } set { level = value; } }
        public string Name { get => name; set => name = value; }
        public CharacterClass CharClass { get => charClass; set => charClass = value; }
        public int Attack { get { return attack; } set { attack = value; } }   
        public int Defense { get { return defense; } set { defense = value; } }
        public int Health { get { return health; } set { health = value; } }    
        public int Gold { get { return gold; } set { gold = value; } }   

        private Character()
        {
            level = 1;
            name = "None";
            charClass = CharacterClass.전사;
            attack = 10;
            defense = 5;
            health = 100;
            gold = 1500;
        }
    }
}
