using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personalTextRPG
{
    internal class GameManager
    {
        private static GameManager instance;
        private SceneBase curScene;
        private bool isGameEnd;
        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
            }
        }
        public SceneBase CurScene { get => curScene; private set => curScene = value; }
        public bool IsGameEnd { get => isGameEnd; set => isGameEnd = value; }

        public void LoadScene(SceneType sceneType)
        {
            curScene = null;
            switch(sceneType)
            {
                case SceneType.StartScene:
                    curScene = new StartScene();
                    break;
                case SceneType.Status:
                    curScene = new StatusScene();
                    break;
                default:
                    Console.WriteLine("LoadScene 실패");
                    Thread.Sleep(1000);
                    break;
            }
            curScene.Start();
        }

        public void GameLogic()
        {
            //Character.Instance.Update();
            curScene.Update();
        }
    }
}
