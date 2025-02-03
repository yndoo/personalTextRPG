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
                    ConsoleKeyInfo key = Console.ReadKey(intercept: true/*이렇게 하면 화면에 출력을 안 함*/);
                    switch (key.Key)
                    {
                        case ConsoleKey.D1:
                            NextScene = SceneType.StatusScene;
                            break;
                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            break;
                    }
                    break;
                }
            }
            // NextScene으로 이동
            if (NextScene == SceneType.None)
            {
                return;
            }
            Console.WriteLine("이동 중..");
            Thread.Sleep(500);
            GameManager.Instance.LoadScene(NextScene);
            return;
        }
    }
}
