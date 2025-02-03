using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personalTextRPG
{
    enum SceneType
    {
        StartScene,     // 시작화면 
        Status,         // 상태보기
        Inventory,      // 인벤토리
        Shop,           // 상점 
    }
    class SceneBase
    {
        public virtual void Start()
        {

        }
        public virtual void Update()
        {

        }
    }

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
            int input = -1;
            bool success = false;
            while (!success)
            {
                success = int.TryParse(Console.ReadLine(), out input);
                if(input < 1 || input > 3)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    success = false;
                }
            }
            Console.WriteLine("이동 중..");
            Thread.Sleep(1000);
            GameManager.Instance.LoadScene((SceneType)input);
        }
    }
    class StatusScene : SceneBase
    {
        public override void Start()
        {
            base.Start();
            Console.Clear();
            Console.WriteLine("상태 보기");
        }

        public override void Update()
        {
            base.Update();

        }
    }
}
