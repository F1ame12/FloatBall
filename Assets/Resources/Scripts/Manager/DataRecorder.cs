using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FloatBall
{
    public class DataRecorder : SingletonUnity<DataRecorder>
    {
        int killnum = 0;
        int enemynum = 0;
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
        public int EnemyNum
        {
            get
            {
                return enemynum;
            }
            set
            {
                enemynum = value;
            }
        }

        private void OnGUI()
        {
            GUILayout.Label("击杀数：" + killnum);
            GUILayout.Label("剩余敌人数：" + enemynum);
        }

    }
}


