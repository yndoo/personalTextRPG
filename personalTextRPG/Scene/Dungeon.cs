using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personalTextRPG.Scene
{
    internal class Dungeon : SceneBase
    {
        public override void Start()
        {
            base.Start();
            Console.Clear();
            Console.WriteLine("던전 입장\n던전으로 들어가시겠습니까?\n");
        }

        public override void Update()
        {
            base.Update();
            Console.Clear();

            Console.WriteLine("1. 들어가기\n0. 나가기");
            Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.D1:
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
