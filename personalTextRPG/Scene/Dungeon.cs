using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personalTextRPG.Scene
{
    internal class Dungeon : SceneBase
    {
        private Random random;
        public override void Start()
        {
            base.Start();
            random = new Random();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("던전 입장\n");
            Console.ResetColor();
        }

        private void PlayDungeon(int reward, int recommended, string title)
        {
            Console.Clear();

            bool isClear;
            Character player = Character.Instance;
            int playerDefense = player.Defense + player.ItemDefense;
            int originalHp = player.Health;
            int originalGold = player.Gold;
            int finalLoseHp = 0;

            // 방어력에 따라 수행
            if (playerDefense < recommended)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("※ 방어력이 권장 방어력보다 낮습니다.");
                
                int p = random.Next(1, 101);
                if (p > 40) isClear = true;
                else 
                { 
                    isClear = false; 
                    finalLoseHp = originalHp / 2; 
                }
            }
            else
            {
                isClear = true;
            }

            // 연출
            Console.ResetColor();
            Console.WriteLine("{0}님이 최선을 다하고 있습니다.", player.Name);
            for (int i = 5; i > 0; --i)
            {
                Console.WriteLine("{0}..", i);
                Thread.Sleep(500);
            }

            Console.Clear();
            // 결과 계산
            if (isClear)
            {
                int loseHP = random.Next(20, 36);
                finalLoseHp = loseHP - (playerDefense - recommended);
                player.Health -= finalLoseHp;

                int pAtt = player.Attack + player.ItemAttack;
                int bonusPercent = random.Next(pAtt, pAtt * 2 + 1);
                int finalReward = reward + (int)reward * bonusPercent / 100;
                player.Gold += finalReward;

                Console.WriteLine("던전 클리어");
                Console.WriteLine($"축하합니다! {title} 던전을 클리어 하였습니다.");
            }
            else
            {
                player.Health -= finalLoseHp;
                Console.WriteLine("던전 실패!");
            }
            // 결과 출력
            Console.WriteLine("\n[탐험 결과]");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("체력 {0} -> {1}", originalHp, player.Health);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Gold {0} -> {1}", originalGold, player.Gold);
            Console.ResetColor();

            while(true)
            {
                Console.WriteLine("\n0. 나가기");
                Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.D0) break;
            }
            return;
        }

        public override void Update()
        {
            base.Update();
            Console.Clear();

            Console.WriteLine("1. 쉬운 던전\t| 방어력 5 이상 권장");
            Console.WriteLine("2. 보통 던전\t| 방어력 10 이상 권장");
            Console.WriteLine("3. 어려운 던전\t| 방어력 20 이상 권장");
            Console.WriteLine("\n0. 나가기");
            Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        PlayDungeon(1000, 5, "쉬운");
                        return;
                    case ConsoleKey.D2:
                        PlayDungeon(1700, 10, "보통");
                        return; ;
                    case ConsoleKey.D3:
                        PlayDungeon(2500, 20, "어려운");
                        return;
                    case ConsoleKey.D0:
                        NextScene = SceneType.StartScene;
                        break;
                    default:
                        break;
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
            GameManager.Instance.LoadScene(NextScene);
            return;
        }
    }
}
