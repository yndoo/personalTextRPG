using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personalTextRPG.Scene
{
    class InventoryScene : SceneBase
    {
        public override void Start()
        {
            base.Start();
            Console.Clear();
            Console.WriteLine("인텐토리 \n보유 중인 아이템을 관리할 수 있습니다.");
        }

        public override void Update()
        {
            base.Update();
            // 아이템 목록
            Console.WriteLine("1. 장착 관리\n2. 나가기");
            while(true)
            {
                if (Console.KeyAvailable)
                {
                    // 키 입력이 있었다면 키를 확인
                    ConsoleKeyInfo key = Console.ReadKey(intercept: true/*이렇게 하면 화면에 출력을 안 함*/);
                    switch (key.Key)
                    {
                        case ConsoleKey.D1:
                        //To do : 장착 관리
                        //break;
                        case ConsoleKey.D2:
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
