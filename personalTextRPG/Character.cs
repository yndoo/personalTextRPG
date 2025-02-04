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

        private List<bool?> body;               // true : 장착, false : 장착X, null : 갖고 있지 않음. (인덱스는 ItemType)
        private HashSet<ItemType> inventory;    // 소유 장비 Set 
        private int level;
        private string? name;
        private CharacterClass charClass;
        private int attack;
        private int defense;
        private int health;
        private int gold;

        // 아이템 증가 능력치 따로 저장
        private int itemAttack;     
        private int itemDefense;

        public List<bool?> Body { get { return body; } set { body = value; } }
        public HashSet<ItemType> Inventory { get { return inventory; } set { inventory = value; } }
        public int Level {  get { return level; } set { level = value; } }
        public string Name { get => name; set => name = value; }
        public CharacterClass CharClass { get => charClass; set => charClass = value; }
        public int Attack { get { return attack; } set { attack = value; } }   
        public int Defense { get { return defense; } set { defense = value; } }
        public int Health { get { return health; } set { health = value; } }    
        public int Gold { get { return gold; } set { gold = value; } }
        public int ItemAttack { get { return itemAttack; } set { itemAttack = value; } }
        public int ItemDefense { get { return itemDefense; } set { itemDefense = value; } }

        private Character()
        {
            level = 1;
            name = null;
            charClass = CharacterClass.전사;
            attack = 10;
            itemAttack = 0;
            defense = 5;
            itemDefense = 0;
            health = 100;
            gold = 1500;

            inventory = new HashSet<ItemType>();

            body = new List<bool?>();
            for (int i = 0; i < (int)ItemType.End; i++)
            {
                body.Add(null); // 처음에 맨몸 상태 
            }
        }
    }
}
