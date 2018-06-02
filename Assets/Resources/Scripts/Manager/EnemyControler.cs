using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FloatBall
{
    public class EnemyControler : SingletonUnity<EnemyControler>
    {
        int enemyMaxNum;
        int enemySpawnerMaxNum;
        GameObject enemy_prefab;
        GameObject enemySpawner_prefab;
        DataRecorder datarecorder;
        List<GameObject> enemyList;
        List<GameObject> enemySpawnerList;
        
        public int MaxEnemyNum
        {
            get
            {
                return enemyMaxNum;
            }
            set
            {
                enemyMaxNum = value;
            }
        }

        public int EnemyNum
        {
            get
            {
                return enemyList.Count;
            }
        }

        public int EnemySpawerNum
        {
            get
            {
                return enemySpawnerList.Count;
            }
        }

        void Start()
        {
            enemyMaxNum = 15;
            enemySpawnerMaxNum = 5;
            enemy_prefab = Resources.Load<GameObject>("prefab/Enemy");
            enemySpawner_prefab = Resources.Load<GameObject>("prefab/EnemySpawner");
            datarecorder = gameObject.GetComponent<DataRecorder>();
            enemyList = new List<GameObject>();
            enemySpawnerList = new List<GameObject>();

            BaseEnemy();
        }

        // Update is called once per frame
        void Update()
        {
            CreateEnemy();
            datarecorder.EnemyNum = EnemyNum;
        }

        private void CreateEnemy()
        {
            if (enemyList.Count != enemyMaxNum)
            {
                foreach(GameObject i in enemySpawnerList)
                {
                    EnemySpawner enemySpawner = i.GetComponent<EnemySpawner>();
                    enemySpawner.CreateEnemy(enemy_prefab);
                }
            }
        }

        public void AddEnemy(GameObject enemy)
        {
            enemyList.Add(enemy);
        }


        public bool DestoryEnemy(GameObject gameObject)
        {
            foreach(GameObject i in enemyList)
            {
                if (i.Equals(gameObject))
                {
                    enemyList.Remove(i);
                    return true;
                }
            }
            return false;
        }

        public bool DestoryEnemySpawner(GameObject gameObject)
        {
            foreach (GameObject i in enemySpawnerList)
            {
                if (i.Equals(gameObject))
                {
                    enemyList.Remove(i);
                    return true;
                }
            }
            return false;
        }

        public static Vector3 RandomPos()
        {
            float locx = Random.Range(BorderInspector.GameBorderLeft, BorderInspector.GameBorderRight);
            float locy = Random.Range(BorderInspector.GameBorderDown, BorderInspector.GameBorderUp);
            Vector3 movepos = new Vector3(locx, locy, 0f);
            //Debug.Log("AI new Loc is " + movepos.ToString());
            return movepos;
        }


        //游戏初始化随机位置刷新敌人
        private void BaseEnemy()
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject tempEnemy;
                tempEnemy = GameObject.Instantiate(enemy_prefab, RandomPos(), Quaternion.identity);
                enemyList.Add(tempEnemy);
            }
            for (int i = 0; i < 2; i++)
            {
                GameObject tempEnemySpawner;
                tempEnemySpawner = GameObject.Instantiate(enemySpawner_prefab, RandomPos(), Quaternion.identity);
                enemySpawnerList.Add(tempEnemySpawner);
            }
        }

    }
}


