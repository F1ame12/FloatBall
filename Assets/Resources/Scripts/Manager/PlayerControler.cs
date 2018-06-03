using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FloatBall
{
    public class PlayerControler : SingletonUnity<PlayerControler>
    {

        float playerspeed;
        //float timecount = 0f;
        //bool canshot;
        ShootControler playergun;

        void Start()
        {
            //canshot = true;
            playergun = gameObject.GetComponent<ShootControler>();
            playerspeed = gameObject.GetComponent<Player>().Speed;
        }

        void Update()
        {
            Move();
            /*
            if (timecount < 0.3 && canshot == false)
            {
                timecount += Time.deltaTime;
            }
            else if (timecount > 0.3)
            {
                Debug.Log("Player Can shot Now");
                canshot = true;
                timecount = 0;
            }
            */
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
                //canshot = false;
                //Debug.Log("player's position is " + playerpos.ToString());
                target = target.normalized;
                target.z = 0f;
                //playergun.ShotCd = 1.5f;
                playergun.Shot(playerpos, target);
            }

            //控制小球移动

            if (Input.GetKey(KeyCode.W) && !BorderInspector.OnUpBorder(playerpos))
            {
                //Debug.Log("up!");
                transform.Translate(Vector3.up * Time.deltaTime * playerspeed);
            }
            if (Input.GetKey(KeyCode.S) && !BorderInspector.OnDownBorder(playerpos))
            {
                //Debug.Log("down!");
                transform.Translate(Vector3.down * Time.deltaTime * playerspeed);
            }
            if (Input.GetKey(KeyCode.A) && !BorderInspector.OnLeftBorder(playerpos))
            {
                //Debug.Log("left!");
                transform.Translate(Vector3.left * Time.deltaTime * playerspeed);
            }
            if (Input.GetKey(KeyCode.D) && !BorderInspector.OnRightBorder(playerpos))
            {
                //Debug.Log("right");
                transform.Translate(Vector3.right * Time.deltaTime * playerspeed);
            }
        }
    }
}

