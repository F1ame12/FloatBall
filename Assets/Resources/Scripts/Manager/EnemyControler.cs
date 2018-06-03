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

        public int EnemySpawnerNum
        {
            get
            {
                return enemySpawnerList.Count;
            }
        }

        public int MaxEnemySpawnerNum
        {
            get
            {
                return enemySpawnerMaxNum;
            }
            set
            {
                enemySpawnerMaxNum = value;
            }
        }

        void Start()
        {
            enemyMaxNum = 10;
            enemySpawnerMaxNum = 2;
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
            DifficultyChange();
            CreateEnemy();
            CreateEnemySpawner();
            datarecorder.EnemyNum = EnemyNum;
        }

        public void OpenData(bool status)
        {
            if (status)
            {
                datarecorder.OpenData = true;
            }
            else
            {
                datarecorder.OpenData = false;
            }
        }

        void DifficultyChange()
        {
            if (datarecorder.Killnum == 10)
            {
                MaxEnemyNum = 15;
                MaxEnemySpawnerNum = 3;
            }
            if (datarecorder.Killnum == 30)
            {
                MaxEnemyNum = 20;
                MaxEnemySpawnerNum = 4;
            }
            if (datarecorder.Killnum == 50)
            {
                MaxEnemyNum = 25;
                MaxEnemySpawnerNum = 5;
            }
            if (datarecorder.Killnum == 70)
            {
                MaxEnemyNum = 30;
                MaxEnemySpawnerNum = 6;
            }
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


        public void DestoryEnemy(GameObject Object)
        {
            foreach(GameObject i in enemyList)
            {
                if (i.Equals(Object))
                {
                    GameObject temp = i;
                    enemyList.Remove(i);
                    Destroy(i);
                    break;
                }
            }
        }

        private void CreateEnemySpawner()
        {
            if (EnemySpawnerNum < MaxEnemySpawnerNum)
            {
                GameObject tempEnemySpawner;
                tempEnemySpawner = GameObject.Instantiate(enemySpawner_prefab, RandomPos(), Quaternion.identity);
                enemySpawnerList.Add(tempEnemySpawner);
                tempEnemySpawner.GetComponent<EnemySpawner>().CreateCd = 3;
            }
            
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
            float waitTime = 0f;
            while (waitTime < 5f)
            {
                waitTime += Time.deltaTime;
            }
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
                tempEnemySpawner.GetComponent<EnemySpawner>().CreateCd = 3;
            }
        }

    }
}


