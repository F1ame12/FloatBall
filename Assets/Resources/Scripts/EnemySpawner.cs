using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FloatBall
{
    public class EnemySpawner : MonoBehaviour
    {
        bool ismoving;
        float timecount;
        float speed;
        Vector3 movetarget;
        GameObject player;
        
        public bool IsMoving
        {
            get
            {
                return ismoving;
            }
            set
            {
                ismoving = value;
            }
        }

        void Start()
        {
            ismoving = false;
            timecount = 0f;
            speed = 2.0f;
            player = GameObject.FindGameObjectWithTag("Player");
        }

        // Update is called once per frame
        void Update()
        {
            ChangePos();
            //CircleAnimation();
            if (timecount < 5)
            {
                timecount += Time.deltaTime;
            }
            else
            {
                timecount = 0;
                CreateEnemy();
            }
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

        void CreateEnemy()
        {
            //GameObject enemy = GameObject.Instantiate(enemy_prefab, transform.position, Quaternion.identity);
        }


        void CircleAnimation()
        {
            transform.Rotate(0f, 0f, 10f);
        }
    }
}


