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

        // Use this for initialization
        void Start()
        {
            datarecorder = GameObject.Find("Main Camera").GetComponent<DataRecorder>();
            color = gameObject.GetComponent<SpriteRenderer>().color;
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

        private void OnTriggerEnter2D(Collider2D collider)
        {
            CircleCollider2D other = collider as CircleCollider2D;
            if (other.gameObject.tag.Equals("Enemy") && other.radius == 0.25)
            {
                if (color == Color.white)
                {
                    Destroy(gameObject);
                }
 
            }
            else if (other.gameObject.tag.Equals("Player") && other.radius == 0.25)
            {
                if (color == Color.red)
                {
                    Debug.Log("Bullet:  Hit Player!");
                    Destroy(gameObject);
                }
                
            }
            
        }

    }
}


