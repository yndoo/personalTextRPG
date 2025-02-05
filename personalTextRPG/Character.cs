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
        전사,
        도적,
        End
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
        private List<ItemInfo?> equipSlot;       // 장착 부위별 한가지만 장착 가능. (인덱스는 EquipType) "해당 부위에 어떤 아이템이 장착되었는가"를 의미하게 됨.
        private HashSet<ItemType> inventory;     // 소유 장비 Set (모든 아이템)
        private int level;
        private string? name;
        private CharacterClass? charClass;
        private int attack;
        private int defense;
        private int health;
        private int maxHp;
        private int gold;
        private int experience;                 // 경험치 (= 던전 클리어 횟수)

        // 아이템 증가 능력치 따로 저장
        private int itemAttack;     
        private int itemDefense;

        public List<ItemInfo?> EquipSlot { get { return equipSlot; } set { equipSlot = value; } }
        public HashSet<ItemType> Inventory { get { return inventory; } set { inventory = value; } }
        public int Level 
        {  get => level; 
           set 
            { 
                level = value;
                experience = 0;
            } 
        }
        public string? Name { get => name; set => name = value; }
        public CharacterClass? CharClass { get => charClass; set => charClass = value; }
        public int Attack { get { return attack; } set { attack = value; } }   
        public int Defense { get { return defense; } set { defense = value; } }
        public int Health 
        { 
            get { return health; } 
            set 
            { 
                health = value; 
                if (health < 0) health = 0; 
                else if (health > maxHp) health = maxHp;
            } 
        }
        public int MaxHp { get { return maxHp; } set { maxHp = value; health = maxHp; } }
        public int Gold { get { return gold; } set { gold = value; } }
        public int ItemAttack { get { return itemAttack; } set { itemAttack = value; } }
        public int ItemDefense { get { return itemDefense; } set { itemDefense = value; } }
        public int Experience 
        { 
            get => experience;
            set 
            {
                experience = value; 
                if(experience == Level)
                {
                    Console.WriteLine("레벨 업!{0} -> {1}",Level, ++Level);
                }
            }
        }

        private Character()
        {
            level = 1;
            name = null;
            charClass = null;
            attack = 10;
            itemAttack = 0;
            defense = 5;
            itemDefense = 0;
            health = 100;
            MaxHp = 100;
            gold = 1500;

            inventory = new HashSet<ItemType>();

            EquipSlot = new List<ItemInfo?>();
            for (int i = 0; i < (int)EquipType.End; i++)
            {
                EquipSlot.Add(null); // 처음에 맨몸 상태 
            }
        }
    }
}
