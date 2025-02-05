using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace personalTextRPG
{
    enum ItemType   // 아이템 종류
    {
        ArmorC, 
        ArmorB,
        ArmorA,
        LanceC, 
        LanceB,
        LanceA,
        LanceSSS,
        End,
    }

    enum EquipType  // 장비 장착 타입
    {
        ArmorSlot,
        WeaponSlot,
        End,
    }
    
    struct ItemInfo
    {
        public ItemType itemType;
        public EquipType slotType;
    }

    class Item
    {
        private Dictionary<ItemType, List<object>> allItemInfo; // 리스트 상세 - 0:아이템명, 1:능력치, 2:설명, 3:가격
        public List<object> this[ItemType item]
        {
            get => allItemInfo[item];
            private set => allItemInfo[item] = value;
        }
        public Dictionary<ItemType, List<object>> AllItemInfo
        {
            get => allItemInfo;
            //private set => allItem = value;
        }


        public Item()
        {
            allItemInfo = new Dictionary<ItemType, List<object>>();
            // 갑옷
            allItemInfo.Add(ItemType.ArmorC, new List<object> { "수련자 갑옷", 5, "수련에 도움을 주는 갑옷입니다.\t", 1000 });
            allItemInfo.Add(ItemType.ArmorB, new List<object> { "무쇠갑옷", 9, "무쇠로 만들어져 튼튼한 갑옷입니다.\t", 2000 });
            allItemInfo.Add(ItemType.ArmorA, new List<object> { "스파르타의 갑옷", 15, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 3500 });
            // 무기
            allItemInfo.Add(ItemType.LanceC, new List<object> { "낡은 검", 2, "쉽게 볼 수 있는 낡은 검입니다.\t", 600 });
            allItemInfo.Add(ItemType.LanceB, new List<object> { "청동 도끼", 5, "어디선가 사용됐던 것 같은 도끼입니다.\t", 1500 });
            allItemInfo.Add(ItemType.LanceA, new List<object> { "스파르타의 창", 7, "스파르타의 전사들이 사용했다는 전설의 창입니다.", 2200 });
            allItemInfo.Add(ItemType.LanceSSS, new List<object> { "토마토 (+15강)", 30, "제 블로그 이름은 토마토가 아니라 톰마토입니다.", 10000 });
        }

        private string name;    // 아이템명
        private int effects;    // 효과 수치
        private int price;      // 가격 
        private string desc;    // 설명
        private ItemType type;  // 아이템 종류

        public string Name { get => name; set => name = value; }
        public int Effects { get => effects; set => effects = value; }
        public int Price { get => price; set => price = value; }
        public string Desc { get => desc; set => desc = value; }
        public ItemType Type { get => type; set => type = value; }

        public void Use(ItemType curItem)
        {
            switch(curItem)
            {
                case ItemType.ArmorC:
                case ItemType.ArmorB:
                case ItemType.ArmorA:
                    Character.Instance.Defense += (int)allItemInfo[curItem][1];
                    break;
                case ItemType.LanceC:
                case ItemType.LanceB:
                case ItemType.LanceA:
                    Character.Instance.Attack += (int)allItemInfo[curItem][1];
                    break;
                default:
                    break;
            }
        }
    }
}
