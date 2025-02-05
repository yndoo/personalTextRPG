using System;
using System.Collections.Generic;
using System.Linq;
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
            HashSet<ItemType> inven = Character.Instance.Inventory;
            List<bool?> body = Character.Instance.BodySlot;
            for (int i = 0; i < (int)ItemType.End; i++)
            {
                if (inven.Contains((ItemType)i) == false) continue;
                ItemInfo curInfo = item[i]; // i타입 아이템 정보 리스트

                string type = curInfo.slotType == EquipType.ArmorSlot ? "방어력" : "공격력";
                string equiped = "";

                if (body[i] == true)   // 장착된 아이템 표시
                {
                    equiped = "[E]";
                }
                Console.WriteLine($" - {equiped}{curInfo.name.PadRight(10)}\t| {type} +{curInfo.effects}\t| {curInfo.desc}");
            }
        }
        // 장착 관리 출력
        private void EquipManage()
        {
            Console.Clear();
            Console.WriteLine("인텐토리 - 장착 관리\n보유 중인 아이템을 관리할 수 있습니다.");
            // 아이템 목록
            Console.WriteLine("\n[아이템 목록]");
            Character player = Character.Instance;
            HashSet<ItemType> inven = player.Inventory;
            List<bool?> body = player.BodySlot;

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

                if (body[i] == true)   // 장착된 아이템 표시
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
                if (viewItemMap.ContainsKey(viewNum))
                {
                    ItemType curType = viewItemMap[viewNum]; // Enum ItenType 번호. Body에는 이 번호로 접근해야 함. 
                    ItemInfo curInfo = item[(int)curType];
                    if (player.BodySlot[(int)curType] == true)
                    {
                        player.BodySlot[(int)curType] = false;
                        // 장착된 능력치 해제
                        if (curInfo.slotType == EquipType.ArmorSlot)
                        {
                            player.ItemDefense -= curInfo.effects;    // 갑옷인 경우
                        }
                        else if (curInfo.slotType == EquipType.WeaponSlot)
                        {
                            player.ItemAttack -= curInfo.effects;     // 무기인 경우
                        }
                    }
                    else
                    {
                        player.BodySlot[(int)curType] = true;
                        // 능력치 적용
                        if (curInfo.slotType == EquipType.ArmorSlot)
                        {
                            player.ItemDefense += curInfo.effects;    // 갑옷인 경우
                        }
                        else if (curInfo.slotType == EquipType.WeaponSlot)
                        {
                            player.ItemAttack += curInfo.effects;     // 무기인 경우
                        }
                    }
                    return;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
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
                            EquipManage();
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
