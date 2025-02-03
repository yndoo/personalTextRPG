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
            Console.WriteLine($"Lv.{player.Level.ToString("D2")}");
            Console.WriteLine($"{player.Name} ({player.CharClass})");
            Console.WriteLine($"공격력\t: {player.Attack}");
            Console.WriteLine($"방어력\t: {player.Defense}");
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
                    ConsoleKeyInfo key = Console.ReadKey(intercept: true/*이렇게 하면 화면에 출력을 안 함*/);
                    if (key.Key == ConsoleKey.D0)
                    {
                        // 나가기
                        Console.WriteLine("이동 중..");
                        Thread.Sleep(500);
                        GameManager.Instance.LoadScene(SceneType.StartScene);
                        return;
                    }
                }
            }
        }
    }
}
