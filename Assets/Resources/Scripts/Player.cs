using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FloatBall
{
    public class Player : MonoBehaviour
    {
        float speed = 5f;
        float locX;
        float locY;

        ShootControl gun = new ShootControl();

        // Use this for initialization
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            Move();
        }

        private void Move()
        {
            locX = transform.position.x;
            locY = transform.position.y;
            

            //Vector3 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            //direction.z = 0f;

            //transform.Translate(direction);
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 playerpos = transform.position;
                Debug.Log("player's position is " + playerpos.ToString());
                Vector3 target = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
                target.z = 0f;
                target = target.normalized;
                gun.Shot(playerpos, target);
            }
            
            if (Input.GetKey(KeyCode.W) && locY < GameManager.GameBorderUp)
            {
                Debug.Log("up!");
                transform.Translate(Vector3.up * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.S) && locY > GameManager.GameBorderDown)
            {
                Debug.Log("down!");
                transform.Translate(Vector3.down * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.A) && locX > GameManager.GameBorderLeft)
            {
                Debug.Log("left!");
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.D) && locX < GameManager.GameBorderRight)
            {
                Debug.Log("right");
                transform.Translate(Vector3.right * Time.deltaTime * speed);
            }
        }
    }

}

