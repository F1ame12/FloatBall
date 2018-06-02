using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FloatBall
{
    public class Bullet : MonoBehaviour
    {
        DataRecorder datarecorder;
        Color color;
        float speed = 7f;
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
        
        public float Speed
        {
            get
            {
                return speed;
            }
            set
            {
                this.speed = value;
            }
        }

        void Start()
        {
            datarecorder = GameObject.Find("Main Camera").GetComponent<DataRecorder>();
            color = gameObject.GetComponent<SpriteRenderer>().color;
        }

        void Update()
        {
            transform.Translate(direction * Time.deltaTime * speed);
            DestroyOverBorder();
        }

        // 到达边界销毁此对象
        private void DestroyOverBorder()
        {
            if (BorderInspector.Onborder(gameObject.transform.position))
            {
                Destroy(gameObject);
            }
        }

    }
}


