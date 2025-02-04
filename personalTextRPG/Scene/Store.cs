using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personalTextRPG.Scene
{
    class Store : SceneBase
    {
        private Item item;
        public Store()
        {
            item = new Item();
        }
        public override void Start()
        {
            base.Start();
        }

        private void Display()
        {
            //보유 골드
            Console.WriteLine("[보유 골드]");
            Console.WriteLine("{0} G", Character.Instance.Gold);
            //아이템 목록
            Console.WriteLine("[아이템 목록]");
            List<bool?> inven = Character.Instance.Inventory;
            for (int i = 0; i < inven.Count(); i++)
            {
                string type;
                List<object> dump = item[(ItemType)i];

                // inventory : enum 번호 그대로임 -> 갑옷인지 무기인지 번호로 구분 가능
                if (i <= (int)ItemType.ArmorA)
                {
                    type = "공격력";
                }
                else
                {
                    type = "방어력";
                }

                // 출력
                if (inven[i] != null)   // 이미 가지고 있는 아이템
                {
                    Console.WriteLine($" - {dump[0].ToString().PadRight(10)}\t| {type} +{dump[1]}\t| {dump[2].ToString().PadRight(30)}\t| 구매완료");
                }
                else                    // 가지고 있지 않은 아이템
                {
                    Console.WriteLine($" - {dump[0].ToString().PadRight(10)}\t| {type} +{dump[1]}\t| {dump[2].ToString().PadRight(30)}\t| {dump[3]} G");
                }
            }
        }
        private void ItemSales()
        {
            Console.Clear();
            Console.WriteLine("상점 - 아이템 구매\n필요한 아이템을 얻을 수 있는 상점입니다.\n");
            //보유 골드
            Console.WriteLine("[보유 골드]");
            Console.WriteLine("{0} G", Character.Instance.Gold);
            //아이템 목록 (번호 표시)
            Console.WriteLine("[아이템 목록]");
            List<bool?> inven = Character.Instance.Inventory;
            for (int i = 0; i < inven.Count(); i++)
            {
                string type;
                List<object> dump = item[(ItemType)i];
                // inventory : enum 번호 그대로임 -> 갑옷인지 무기인지 번호로 구분 가능
                if (i <= (int)ItemType.ArmorA)
                {
                    type = "공격력";
                }
                else
                {
                    type = "방어력";
                }
                // 출력
                if (inven[i] != null)   // 이미 가지고 있는 아이템
                {
                    Console.WriteLine($" - {i+1} {dump[0].ToString().PadRight(10)}\t| {type} +{dump[1]}\t| {dump[2].ToString().PadRight(30)}\t| 구매완료");
                }
                else                    // 가지고 있지 않은 아이템
                {
                    Console.WriteLine($" - {i+1} {dump[0].ToString().PadRight(10)}\t| {type} +{dump[1]}\t| {dump[2].ToString().PadRight(30)}\t| {dump[3]} G");
                }
            }
            //번호 선택 시 구매
            Console.WriteLine("\n0. 나가기");
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
                            // 아이템 구매 
                            goodsNum = key.Key - ConsoleKey.D1; // Key 값으로 계산해서 1 ~ 6번 아이템의 인덱스 0~5 구함
                            if (inven[goodsNum] == null)
                            {
                                int price = (int)item[(ItemType)goodsNum][3];
                                if (Character.Instance.Gold >= price)
                                {
                                    Character.Instance.Inventory[goodsNum] = false;
                                    Character.Instance.Gold -= price;
                                    Console.WriteLine("구매를 완료했습니다.");
                                    Thread.Sleep(500);
                                }
                                else
                                {
                                    Console.WriteLine("Gold 가 부족합니다.");
                                    goodsNum = -1;
                                }
                            }
                            else
                            {
                                Console.WriteLine("이미 구매한 아이템입니다.");
                                goodsNum = -1;
                            }
                            break;
                        case ConsoleKey.D0:
                            return; // 구매 창만 나가면 됨
                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            break;
                    }
                    if (goodsNum >= 0) break; // 구매 성공시에만 돌아감
                }
            }
        }

        public override void Update()
        {
            base.Update();
            Console.Clear();
            Console.WriteLine("상점\n필요한 아이템을 얻을 수 있는 상점입니다.\n");

            Display();

            Console.WriteLine("\n1. 아이템 구매\n0. 나가기");
            Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    // 키 입력이 있었다면 키를 확인
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.D1:
                            // 아이템 구매 선택
                            ItemSales();
                            return; // Update 다시 돌기 위함
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
