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
            
            if (collision.gameObject.tag.Equals("enemy"))
            {
                Debug.Log("Get Enemy!");
                scorerecorder.Killnum += 1;
                collision.gameObject.transform.localScale += new Vector3(0.1f,0.1f,0.1f);
                Destroy(gameObject);
            }
        }

    }
}


