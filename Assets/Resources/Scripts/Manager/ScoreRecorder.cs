using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FloatBall
{
    public class ScoreRecorder : SingletonUnity<ScoreRecorder>
    {
        int killnum = 0;
        
        public int Killnum
        {
            get
            {
                return killnum;
            }
            set
            {
                killnum = value;
            }
        }

        private void OnGUI()
        {
            GUILayout.Label("击杀数：" + killnum);
        }

    }
}


