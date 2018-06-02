using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FloatBall
{
    public class Bullet : MonoBehaviour
    {
        ScoreRecorder scorerecorder;

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
            scorerecorder = GameObject.Find("Main Camera").GetComponent<ScoreRecorder>();
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

        private void OnTriggerEnter2D(Collider2D collision)
        {
            CircleCollider2D circle = collision as CircleCollider2D;
            if (circle.gameObject.tag.Equals("Enemy") && circle.radius == 0.25)
            {
                if (gameObject.GetComponent<SpriteRenderer>().color != Color.red)
                {
                    
                    Debug.Log("Hit Enemy!");
                    scorerecorder.Killnum += 1;
                    Destroy(gameObject);
                }
 
            }
            else if (circle.gameObject.tag.Equals("Player") && circle.radius == 0.25)
            {
                if (gameObject.GetComponent<SpriteRenderer>().color == Color.red)
                {
                    Debug.Log("Hit Player!");
                    Destroy(gameObject);
                }
                
            }
            
        }

    }
}


