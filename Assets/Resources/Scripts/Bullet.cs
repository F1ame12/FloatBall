using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FloatBall
{
    public class Bullet : MonoBehaviour
    {

        public float speed = 10f;
        Vector3 direction;

        public Vector3 Direction
        {
            get
            {
                return direction;
            }
            set
            {
                direction = value;
            }
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(direction * Time.deltaTime * speed);
            if (Findborder())
            {
                Destroy(gameObject);
            }
        }

        //检测子弹是否到达游戏边界
        bool Findborder()
        {
            float locx = transform.position.x;
            float locy = transform.position.y;
            GameObject itself = gameObject;
            if (locy > GameManager.GameBorderUp)
            {
                return true;
            }
            if (locy < GameManager.GameBorderDown)
            {
                return true;
            }
            if (locx < GameManager.GameBorderLeft)
            {
                return true;
            }
            if (locx > GameManager.GameBorderRight)
            {
                return true;
            }
            return false;
        }
    }
}


