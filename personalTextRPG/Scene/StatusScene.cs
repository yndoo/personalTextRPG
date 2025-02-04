using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace personalTextRPG.Scene
{
    class StatusScene : SceneBase
    {
        public override void Start()
        {
            base.Start();
            Console.Clear();
            Console.WriteLine("상태 보기\n캐릭터의 정보가 표시됩니다.\n");
        }

        private void PrintStatus()
        {
            Character player = Character.Instance;
            // 아이템 수치는 장비를 구매할 때가 아니라, 장착할 때 적용해야함. -> 장착한것들만 더해야함 -> 그게 itemAttack, itemDefense
            string itemAtt = "", itemDef = "";
            if (player.ItemAttack > 0) itemAtt = new string($" (+{player.ItemAttack})");
            if (player.ItemAttack > 0) itemDef = new string($" (+{player.ItemDefense})");

            Console.WriteLine($"Lv.{player.Level.ToString("D2")}");
            Console.WriteLine($"{player.Name} ({player.CharClass})");
            Console.WriteLine($"공격력\t: {player.Attack.ToString().PadRight(3)}{itemAtt}");
            Console.WriteLine($"방어력\t: {player.Defense.ToString().PadRight(3)}{itemDef}");
            Console.WriteLine($"체력\t: {player.Health}");
            Console.WriteLine($"Gold\t: {player.Gold} G");
        }

        public override void Update()
        {
            base.Update();
            PrintStatus();

            Console.WriteLine("\n0. 나가기"); 
            Console.Write("원하시는 행동을 입력해주세요.\n>> ");
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    // 키 입력이 있었다면 키를 확인
                    ConsoleKeyInfo key = Console.ReadKey(true/*이렇게 하면 화면에 출력을 안 함*/);
                    if (key.Key == ConsoleKey.D0)
                    {
                        // 나가기
                        Console.WriteLine("이동 중..");
                        Thread.Sleep(500);
                        GameManager.Instance.LoadScene(SceneType.StartScene);
                        return;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        continue;
                    }
                }
            }
        }
    }
}
