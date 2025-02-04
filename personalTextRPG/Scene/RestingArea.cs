using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personalTextRPG.Scene
{
    internal class RestingArea : SceneBase
    {
        private int cost;
        public RestingArea()
        {
            cost = 500;
        }
        public override void Start()
        {
            base.Start();
            Console.Clear();
            Console.WriteLine("여행자의 쉼터\n휴식을 취할 수 있습니다.\n");
        }

        public override void Update()
        {
            base.Update();
            Console.Clear();
            Console.WriteLine("쉼터에 수상한 기계가 있습니다.");
            Console.Write("\n아무 키 입력 >> ");
            Console.ReadKey(true);

            Console.Clear();
            Console.WriteLine("\"바디프렌드..?\"\n\n{0} 골드를 넣으면 작동합니다. 사용하시겠습니까?", cost);

            Console.WriteLine("1. 사용하기\n0. 나가기");
            Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");

            while(true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        Character player = Character.Instance;
                        if (player.Gold >= cost)
                        {
                            player.Gold -= cost;
                            Character.Instance.Health = 100;
                            NextScene = SceneType.StartScene;
                            Console.WriteLine("\n체력이 회복되었습니다! 마을로 돌아갑니다.");
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            Console.WriteLine("골드가 부족합니다. 현재 골드 : {0}", player.Gold);
                        }
                        break;
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
