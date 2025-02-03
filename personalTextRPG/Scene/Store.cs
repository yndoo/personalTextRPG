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
            Console.Clear();
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
                if (i < 3)
                {
                    type = "공격력";
                }
                else
                {
                    type = "방어력";
                }
                if (inven[i] == true)   // 이미 가지고 있는 아이템
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
            Console.WriteLine("상점 - 아이템 구매\n필요한 아이템을 얻을 수 있는 상점입니다.\n");
            //보유 골드
            //아이템 목록(번호 표시)
            //번호 선택 시 구매
        }

        public override void Update()
        {
            base.Update();
            Console.WriteLine("상점\n필요한 아이템을 얻을 수 있는 상점입니다.\n");

            Display();

            Console.WriteLine("1. 아이템 구매\n0. 나가기");
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
                            // 아이템 구매 
                            //ItemSales();
                            break;
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
