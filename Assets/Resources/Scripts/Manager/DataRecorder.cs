using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FloatBall
{
    public class DataRecorder : SingletonUnity<DataRecorder>
    {
        bool openData = true;
        int killNum = 0;
        int enemyNum = 0;
        int lifeCount = 0;
        //GameObject[] hud;
        //Text text_lifeCount;

        public bool OpenData
        {
            get
            {
                return openData;
            }
            set
            {
                openData = value;
            }
        }

        public int LifeCount
        {
            get
            {
                return lifeCount;
            }
            set
            {
                lifeCount = value;
            }
        }
        public int Killnum
        {
            get
            {
                return killNum;
            }
            set
            {
                killNum = value;
            }
        }
        public int EnemyNum
        {
            get
            {
                return enemyNum;
            }
            set
            {
                enemyNum = value;
            }
        }

        private void Start()
        {
            
        }

        private void Update()
        {
            
        }

        private void OnGUI()
        {
            if (openData)
            {
                GUILayout.Label("生命数：" + lifeCount);
                GUILayout.Label("击杀数：" + killNum);
                GUILayout.Label("剩余敌人数：" + enemyNum);
            }
            
        }

    }
}


