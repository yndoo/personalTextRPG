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
            List<bool?> body = Character.Instance.Body;
            for (int i = 0; i < (int)ItemType.End; i++)
            {
                if (inven.Contains((ItemType)i) == false) continue;
                string equiped = "", type;
                List<object> dump = item[(ItemType)i]; // i타입 아이템 정보 리스트

                if (i <= (int)ItemType.ArmorA)
                {
                    type = "공격력";
                }
                else
                {
                    type = "방어력";
                }

                if (body[i] == true)   // 장착된 아이템 표시
                {
                    equiped = "[E]";
                }
                Console.WriteLine($" - {equiped}{dump[0].ToString().PadRight(10)}\t| {type} +{dump[1]}\t| {dump[2]}");
            }
        }
        // 장착 관리 출력
        private void EquipManage()
        {
            Console.Clear();
            Console.WriteLine("인텐토리 - 장착 관리\n보유 중인 아이템을 관리할 수 있습니다.");
            // 아이템 목록
            Console.WriteLine("\n[아이템 목록]");
            HashSet<ItemType> inven = Character.Instance.Inventory;
            List<bool?> body = Character.Instance.Body;
            int view = 1;
            for (int i = 0; i < (int)ItemType.End; i++)
            {
                if (inven.Contains((ItemType)i) == false) continue;
                string equiped = "", type;
                List<object> dump = item[(ItemType)i]; // i타입 아이템 정보 리스트

                if (i <= (int)ItemType.ArmorA)
                {
                    type = "공격력";
                }
                else
                {
                    type = "방어력";
                }

                if (body[i] == true)   // 장착된 아이템 표시
                {
                    equiped = "[E]";
                }
                Console.WriteLine($" - {view++} {equiped}{dump[0].ToString().PadRight(10)}\t| {type} +{dump[1]}\t| {dump[2]}");
            }

            Console.WriteLine("\n0. 나가기");
            Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");

            // 번호 입력 시 장착/장착 해제
            while (true)
            {
                int goodsNum = -1;
                if (Console.KeyAvailable)
                {
                    // 키 입력이 있었다면 키를 확인
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.D1:
                        case ConsoleKey.D2:
                        case ConsoleKey.D3:
                        case ConsoleKey.D4:
                        case ConsoleKey.D5:
                        case ConsoleKey.D6:
                            // 아이템 장착 
                            break;
                        case ConsoleKey.D0:
                            return; // 장착 관리창만 나가기 
                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            break;
                    }
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
                            //To do : 장착 관리
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
