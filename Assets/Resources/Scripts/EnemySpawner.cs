using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FloatBall
{
    public class EnemySpawner : MonoBehaviour
    {
        bool ismoving;
        float createWaitTime;
        float speed;
        Vector3 movetarget;
        GameObject player;
        EnemyControler enemyControl;

        void Start()
        {
            ismoving = false;
            createWaitTime = 0f;
            speed = 2.0f;
            player = GameObject.FindGameObjectWithTag("Player");
            enemyControl = GameObject.Find("Main Camera").GetComponent<EnemyControler>();
        }

        // Update is called once per frame
        void Update()
        {
            ChangePos();
            //CircleAnimation();
        }

        void ChangePos()
        {
            if (ismoving == false)
            {
                movetarget = EnemyControler.RandomPos();
                ismoving = true;
            }
            else if (ismoving == true)
            {

                if (Mathf.Abs(movetarget.x - transform.position.x) <= 0.1)
                {
                    Debug.Log("AI-SPAWNER is Arrived");
                    ismoving = false;
                }
                else
                {
                    transform.Translate((movetarget - transform.position).normalized * Time.deltaTime * speed);
                }
            }
        }

        public void CreateEnemy(GameObject enemy_prefab)
        {
            if (createWaitTime < 5)
            {
                createWaitTime += Time.deltaTime;
            }
            else if (enemyControl.EnemyNum < enemyControl.MaxEnemyNum)
            {
                createWaitTime = 0;
                GameObject enemy = GameObject.Instantiate(enemy_prefab, transform.position, Quaternion.identity);
                enemyControl.AddEnemy(enemy);
            }
            
        }

    }
}


