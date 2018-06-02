using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FloatBall
{
    public class AIRespawnPoint : MonoBehaviour
    {
        float timecount = 0f;
        Vector3 circle;
        GameObject enemy_prefab = Resources.Load<GameObject>("prefab/Enemy");
        // Use this for initialization
        void Start()
        {
            enemy_prefab = Resources.Load<GameObject>("prefab/Enemy");
        }

        // Update is called once per frame
        void Update()
        {
            CircleAnimation();
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


