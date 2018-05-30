using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FloatBall
{
    public class Bullet : MonoBehaviour
    {

        float speed = 5.0f;
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
            // 到达边界销毁此对象
            if (BorderInspector.Onborder(gameObject.transform.position))
            {
                Destroy(gameObject);
            }
        }


    }
}


