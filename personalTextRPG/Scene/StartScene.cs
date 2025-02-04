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

            // 이름 설정
            while (true)
            {
                if (Character.Instance.Name != null) break;
                Console.Clear();
                Console.WriteLine("텍스트 마을에 오신 여러분 환영합니다.");
                Console.Write("플레이어의 이름을 입력해주세요.\n>> ");
                string input = Console.ReadLine();
                Console.WriteLine($"\n입력하신 이름은 {input}입니다. 저장하시겠습니까?");
                Console.WriteLine("1. 저장\n2. 취소");
                Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        Character.Instance.Name = input;
                        break;
                    default:
                        break;
                }
            }

            // 직업 설정
            while (true)
            {
                if (Character.Instance.CharClass != null) break;
                Console.Clear();
                Console.WriteLine("텍스트 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("직업을 선택해주세요.\n");
                for (int i = 0; i < (int)CharacterClass.End; i++)
                {
                    Console.Write($"{i + 1}. {(CharacterClass)i} ");
                }
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.D2:
                        Character.Instance.CharClass = (CharacterClass)(key.Key - ConsoleKey.D1);
                        break;
                    default:
                        break;
                }
            }
        }

        public override void Update()
        {
            base.Update();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("텍스트 마을");
            Console.ResetColor();
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine("1. 상태 보기\n2. 인벤토리\n3. 상점\n4. 던전 입장 \n5. 휴식하기");
            Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
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
                        case ConsoleKey.D4:
                            NextScene = SceneType.Dungeon;
                            break;
                        case ConsoleKey.D5:
                            NextScene = SceneType.RestingArea;
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
