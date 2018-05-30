using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FloatBall
{
    public class PlayerControler : SingletonUnity<PlayerControler>
    {
        //float locX;
        //float locY;
        float speed;
        ShootControl gun;
        // Use this for initialization
        void Start()
        {
            gun = new ShootControl();
            speed = gameObject.GetComponent<Player>().Speed;
        }

        // Update is called once per frame
        void Update()
        {
            Move();
        }

        private void Move()
        {

            //当前小球世界坐标
            Vector3 playerpos = transform.position;
            //当前鼠标世界坐标
            Vector3 mousepos = Input.mousePosition;
            //转化小球坐标为屏幕坐标，获得从小球到鼠标的方向
            Vector3 target = mousepos - Camera.main.WorldToScreenPoint(playerpos);

            //左键朝目标方向射击
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("player's position is " + playerpos.ToString());
                target = target.normalized;
                target.z = 0f;
                gun.Shot(playerpos, target);
            }

            //控制小球移动

            if (Input.GetKey(KeyCode.W) && !BorderInspector.OnUpBorder(playerpos))
            {
                Debug.Log("up!");
                transform.Translate(Vector3.up * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.S) && !BorderInspector.OnDownBorder(playerpos))
            {
                Debug.Log("down!");
                transform.Translate(Vector3.down * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.A) && !BorderInspector.OnLeftBorder(playerpos))
            {
                Debug.Log("left!");
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.D) && !BorderInspector.OnDownBorder(playerpos))
            {
                Debug.Log("right");
                transform.Translate(Vector3.right * Time.deltaTime * speed);
            }
        }
    }
}

