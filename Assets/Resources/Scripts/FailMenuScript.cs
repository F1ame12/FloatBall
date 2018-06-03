using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace FloatBall
{
    public class FailMenuScript : MonoBehaviour
    {
        public Canvas failMenu;
        public Button failMenu_restartGame;
        public Button failMenu_backToMainMenu;

        public void Start()
        {
            failMenu.enabled = false;
        }

        public void ShowFailMenu()
        {
            failMenu.enabled = true;
        }


        public void RestartGame()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(1);
        }

        public void BackToMainMenu()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }
    }
}