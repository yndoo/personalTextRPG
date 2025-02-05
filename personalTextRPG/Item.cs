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
        public ItemType itemType;   // 아이템 종류(뺄수도)
        public EquipType slotType;  // 장착 슬롯 타입
        public string name;         // 아이템명
        public int effects;         // 능력치
        public string desc;         // 설명
        public int price;           // 가격
    }

    class Item
    {
        private List<ItemInfo> itemInfos;
        public ItemInfo this[int i]
        {
            get => itemInfos[i];
            private set => itemInfos[i] = value;
        }

        public List<ItemInfo> ItemInfos
        {
            get => itemInfos;
        }
        public Item()
        {
            itemInfos = new List<ItemInfo>();
            itemInfos.Add(new ItemInfo {itemType = ItemType.ArmorC, slotType = EquipType.ArmorSlot, name = "수련자 갑옷", effects = 5, desc = "수련에 도움을 주는 갑옷입니다.\t", price = 1000});
            itemInfos.Add(new ItemInfo { itemType = ItemType.ArmorB, slotType = EquipType.ArmorSlot, name = "무쇠갑옷", effects = 9, desc = "무쇠로 만들어져 튼튼한 갑옷입니다.\t", price = 2000 });
            itemInfos.Add(new ItemInfo { itemType = ItemType.ArmorA, slotType = EquipType.ArmorSlot, name = "스파르타의 갑옷", effects = 15, desc = "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", price = 3500 });
            itemInfos.Add(new ItemInfo { itemType = ItemType.LanceC, slotType = EquipType.WeaponSlot, name = "낡은 검", effects = 2, desc = "쉽게 볼 수 있는 낡은 검입니다.\t", price = 1000 });
            itemInfos.Add(new ItemInfo { itemType = ItemType.LanceB, slotType = EquipType.WeaponSlot, name = "청동 도끼", effects = 5, desc = "어디선가 사용됐던 것 같은 도끼입니다.\t", price = 1500 });
            itemInfos.Add(new ItemInfo { itemType = ItemType.LanceA, slotType = EquipType.WeaponSlot, name = "스파르타의 창", effects = 7, desc = "스파르타의 전사들이 사용했다는 전설의 창입니다.", price = 2200 });
            itemInfos.Add(new ItemInfo { itemType = ItemType.LanceSSS, slotType = EquipType.WeaponSlot, name = "토마토 (+15강)", effects = 30, desc = "제 블로그 이름은 토마토가 아니라 톰마토입니다.", price = 10000 });
        }
    }
}
