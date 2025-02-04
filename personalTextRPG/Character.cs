using personalTextRPG.Scene;
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
        private string? name;
        private CharacterClass charClass;
        private int attack;
        private int itemAttack;
        private int defense;
        private int itemDefense;
        private int health;
        private int gold;
        private List<bool?> inventory; // true : 장착, false : 장착X, null : 갖고 있지 않음. (인덱스는 ItemType)
        public int Level {  get { return level; } set { level = value; } }
        public string Name { get => name; set => name = value; }
        public CharacterClass CharClass { get => charClass; set => charClass = value; }
        public int Attack { get { return attack; } set { attack = value; } }   
        public int ItemAttack { get { return itemAttack; } set { itemAttack = value; } }
        public int Defense { get { return defense; } set { defense = value; } }
        public int ItemDefense { get { return itemDefense; } set { itemDefense = value; } }
        public int Health { get { return health; } set { health = value; } }    
        public int Gold { get { return gold; } set { gold = value; } }
        public List<bool?> Inventory { get { return inventory; } set { inventory = value; } }

        private Character()
        {
            level = 1;
            name = null;
            charClass = CharacterClass.전사;
            attack = 10;
            defense = 5;
            health = 100;
            gold = 1500;
            inventory = new List<bool?>();
            for(int i = 0; i < (int)ItemType.End; i++)
            {
                inventory.Add(null);
            }
        }
    }
}
