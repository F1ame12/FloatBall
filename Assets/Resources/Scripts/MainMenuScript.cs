using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace FloatBall
{
    public class MainMenuScript : MonoBehaviour
    {
        public Canvas exitMenu;
        public Canvas mainMenu;
        public Button mainMenu_startGame;
        public Button mainMenu_exitGame;
        public Button exitMenu_exitGame;
        public Button exitMenu_cancelExit;

        public void Start()
        {
            exitMenu.enabled = false;
            GameObject.Find("Main Camera").GetComponent<DataRecorder>().OpenData = false;
        }


        public void ExitGame()
        {
            mainMenu_startGame.enabled = false;
            mainMenu_exitGame.enabled = false;
            exitMenu.enabled = true;
        }

        public void RealExitGame()
        {
            Application.Quit();
        }

        public void CancelExitGame()
        {
            exitMenu.enabled = false;
            mainMenu_startGame.enabled = true;
            mainMenu_exitGame.enabled = true;
        }

        public void StartGame()
        {
            SceneManager.LoadScene(1);
        }

    }
}


