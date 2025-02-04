using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personalTextRPG.Scene
{
    class StartScene : SceneBase
    {
        public override void Start()
        {
            base.Start();
            Console.Clear();
            Console.WriteLine("텍스트 마을에 오신 여러분 환영합니다.");
            if(Character.Instance.Name == null)
            {
                Console.Write("플레이어의 이름을 입력해주세요.\n>> ");
                Character.Instance.Name = Console.ReadLine();
            }
        }

        public override void Update()
        {
            base.Update();
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine("1. 상태 보기\n2. 인벤토리\n3. 상점");
            Console.Write("원하시는 행동을 입력해주세요.\n>> ");
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    // 키 입력이 있었다면 키를 확인
                    ConsoleKeyInfo key = Console.ReadKey(true/*이렇게 하면 화면에 출력을 안 함*/);
                    switch (key.Key)
                    {
                        case ConsoleKey.D1:
                            NextScene = SceneType.StatusScene;
                            break;
                        case ConsoleKey.D2:
                            NextScene = SceneType.InventoryScene;
                            break;
                        case ConsoleKey.D3:
                            NextScene = SceneType.Store;
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
