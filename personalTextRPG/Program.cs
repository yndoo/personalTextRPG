using personalTextRPG.Scene;

namespace personalTextRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager.Instance.LoadScene(SceneType.StartScene);

            while(!GameManager.Instance.IsGameEnd)
            {
                GameManager.Instance.GameLogic();
               
            }
        }
    }
}
