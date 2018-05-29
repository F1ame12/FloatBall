using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FloatBall
{
    public class GameManager : SingletonUnity<GameManager>
    {
        public static float GameBorderLeft = -12.5f;
        public static float GameBorderRight = 12.5f;
        public static float GameBorderUp = 6.9f;
        public static float GameBorderDown = -6.9f;

        private void Start()
        {
            
        }

    }
}
