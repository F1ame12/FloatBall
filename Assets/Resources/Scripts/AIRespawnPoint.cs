using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FloatBall
{
    public class AIRespawnPoint : MonoBehaviour
    {
        bool ismoving = false;
        float timecount = 0f;
        float speed = 2.0f;
        Vector3 movetarget;
        GameObject enemy_prefab;
        // Use this for initialization
        void Start()
        {
            enemy_prefab = Resources.Load<GameObject>("prefab/Enemy");
        }

        // Update is called once per frame
        void Update()
        {

            if (ismoving == false)
            {
                movetarget = RandomMove();
                ismoving = true;
            }
            else if (ismoving == true)
            {
                
                if (Mathf.Abs(movetarget.x - transform.position.x) <= 0.01)
                {
                    Debug.Log("AI-SPAWNER is Arrived");
                    ismoving = false;
                }
                else
                {
                    transform.Translate((movetarget - transform.position).normalized * Time.deltaTime * speed);
                }
            }
            
            //CircleAnimation();
            if (timecount < 1.5)
            {
                timecount += Time.deltaTime;
            }
            else
            {
                timecount = 0;
                CreateEnemy();
            }
        }

        private Vector3 RandomMove()
        {
            float locx = Random.Range(BorderInspector.GameBorderLeft, BorderInspector.GameBorderRight);
            float locy = Random.Range(BorderInspector.GameBorderDown, BorderInspector.GameBorderUp);
            Vector3 movepos = new Vector3(locx, locy, 0f);
            Debug.Log("AI new Loc is " + movepos.ToString());
            return movepos;
        }

        void CreateEnemy()
        {
            GameObject enemy = GameObject.Instantiate(enemy_prefab, transform.position, Quaternion.identity);
        }


        void CircleAnimation()
        {
            transform.Rotate(0f, 0f, 10f);
        }
    }
}


