using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace personalTextRPG.Scene
{
    class InventoryScene : SceneBase
    {
        private Item item;
        public InventoryScene()
        {
            item = new Item();
        }
        public override void Start()
        {
            base.Start();
        }
        // 인벤토리 출력
        private void PrintInventory()
        {
            Console.WriteLine("\n[아이템 목록]");
            Character player = Character.Instance;
            HashSet<ItemType> inven = player.Inventory;
            
            for (int i = 0; i < (int)ItemType.End; i++)
            {
                if (inven.Contains((ItemType)i) == false) continue;
                ItemInfo curInfo = item[i]; // i타입 아이템 정보 리스트

                string type = curInfo.slotType == EquipType.ArmorSlot ? "방어력" : "공격력";
                string equiped = "";

                if (player.EquipSlot[(int)curInfo.slotType].HasValue && player.EquipSlot[(int)curInfo.slotType].Value.itemType == curInfo.itemType)   // 장착된 아이템 표시
                {
                    equiped = "[E]";
                }
                Console.WriteLine($" - {equiped}{curInfo.name.PadRight(10)}\t| {type} +{curInfo.effects}\t| {curInfo.desc}");
            }
        }
        // 장착 관리 출력
        private void EquipManageScreen()
        {
            Console.Clear();
            Console.WriteLine("인텐토리 - 장착 관리\n보유 중인 아이템을 관리할 수 있습니다.");
            // 아이템 목록
            Console.WriteLine("\n[아이템 목록]");
            Character player = Character.Instance;
            HashSet<ItemType> inven = player.Inventory;

            // view 번호와 실제 ItemType 번호 매칭용 Dictionary
            // (HashSet은 순서가 보장이 되지 않기 때문에 따로 생성한 것.)
            Dictionary<int, ItemType> viewItemMap = new Dictionary<int, ItemType>(); 
            int view = 1;

            for (int i = 0; i < (int)ItemType.End; i++)
            {
                ItemType curType = (ItemType)i;
                if (inven.Contains(curType) == false) continue;
                viewItemMap[view] = (ItemType)i;

                ItemInfo curInfo = item[i]; // i타입 아이템 정보 리스트
                string equiped = "";
                string type = curInfo.slotType == EquipType.ArmorSlot ? "방어력" : "공격력";

                if (player.EquipSlot[(int)curInfo.slotType].HasValue && player.EquipSlot[(int)curInfo.slotType].Value.itemType == curInfo.itemType)   // 장착된 아이템 표시
                {
                    equiped = "[E]";
                }
                Console.WriteLine($" - {view++} {equiped}{curInfo.name.PadRight(10)}\t| {type} +{curInfo.effects}\t| {curInfo.desc}");
            }

            Console.WriteLine("\n0. 나가기");
            Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");

            // 번호 입력 시 장착/장착 해제
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.D0) return; 

                // 아이템 장착 
                int viewNum = key.Key - ConsoleKey.D0;
                if (viewItemMap.ContainsKey(viewNum))   // 인벤토리 목록에 있는 아이템 선택 시
                {
                    ItemType curType = viewItemMap[viewNum]; // Enum ItenType 번호. Body에는 이 번호로 접근해야 함. 
                    ItemInfo curInfo = item[(int)curType];
                    // 장착스위치
                    ToggleEquip(curInfo);
                    return;
                }
                else 
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }
        private void ToggleEquip(ItemInfo? _newItem)
        {
            ItemInfo newItem = _newItem.Value;
            EquipType slot = newItem.slotType;
            Character player = Character.Instance;
            ItemInfo? oldItem = player.EquipSlot[(int)slot];
            // 같은 부위에 아이템이 장착되어 있을 때
            if (oldItem != null)
            {
                // 기존 장착템의 효과 해제
                switch (slot)
                {
                    case EquipType.ArmorSlot:
                        player.ItemDefense -= oldItem.Value.effects;
                        break;
                    case EquipType.WeaponSlot:
                        player.ItemAttack -= oldItem.Value.effects;
                        break;
                    default:
                        break;
                }

                // 장착 해제만 해야할 때
                if (oldItem.Value.itemType == newItem.itemType)
                {
                    player.EquipSlot[(int)slot] = null;
                    return;
                }
            }

            // 새로운 아이템을 장착
            player.EquipSlot[(int)slot] = _newItem;
            switch (slot)
            {
                case EquipType.ArmorSlot:
                    player.ItemDefense += newItem.effects;
                    break;
                case EquipType.WeaponSlot:
                    player.ItemAttack += newItem.effects;
                    break;
                default:
                    break;
            }
        }

        public override void Update()
        {
            base.Update();
            Console.Clear();
            Console.WriteLine("인텐토리 \n보유 중인 아이템을 관리할 수 있습니다.");
            // 아이템 목록
            PrintInventory();

            Console.WriteLine("\n1. 장착 관리\n0. 나가기");
            Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
            
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    // 키 입력이 있었다면 키를 확인
                    ConsoleKeyInfo key = Console.ReadKey(intercept: true/*이렇게 하면 화면에 출력을 안 함*/);
                    switch (key.Key)
                    {
                        case ConsoleKey.D1:
                            EquipManageScreen();
                            return;
                        case ConsoleKey.D0:
                            NextScene = SceneType.StartScene;
                            break;
                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            break;
                    }
                }

                if (NextScene == SceneType.None)
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
            // NextScene으로 이동
            Console.WriteLine("이동 중..");
            Thread.Sleep(500);
            GameManager.Instance.LoadScene(NextScene);
            return;
        }
    }
}
