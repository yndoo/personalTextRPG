using personalTextRPG.Scene;
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
            switch(sceneType)
            {
                case SceneType.StartScene:
                    curScene = new StartScene();
                    break;
                case SceneType.StatusScene:
                    curScene = new StatusScene();
                    break;
                case SceneType.InventoryScene:
                    curScene = new InventoryScene();
                    break;
                case SceneType.Store:
                    curScene = new Store();
                    break;
                default:
                    Console.WriteLine("LoadScene 실패");
                    Thread.Sleep(1000);
                    break;
            }
            if(curScene != null) curScene.Start();
        }

        public void GameStart()
        {
            curScene.Update();
            Thread.Sleep(10);
        }
    }
}
