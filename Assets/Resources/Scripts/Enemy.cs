using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FloatBall
{
    public class Enemy : MonoBehaviour
    {
        //Status status;
        DataRecorder dataRecorder;
        EnemyControler enemyControl;
        ShootControler enemyGun;
        bool ismoving;
        bool canshot;
        float shotWaitTime;
        float timecount;
        float speed;
        Vector3 movetarget;
        Vector3 playerpos;
        Vector3 targetpos;
        GameObject playerobj;

        public float Speed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = value;
            }
        }

        void Start()
        {
            //status = Status.Normal;
            ismoving = false;
            speed = 2.5f;
            enemyControl = GameObject.Find("Main Camera").GetComponent<EnemyControler>();
            dataRecorder = GameObject.Find("Main Camera").GetComponent<DataRecorder>();
            playerobj = GameObject.FindGameObjectWithTag("Player");
            enemyGun = gameObject.GetComponent<ShootControler>();
        }

        // Update is called once per frame
        void Update()
        {
            ChangePos();
        }



        // 随机改变位置
        void ChangePos()
        {
            if (ismoving == false)
            {
                movetarget = EnemyControler.RandomPos();
                ismoving = true;
            }
            else if (ismoving == true)
            {

                if (Mathf.Abs(movetarget.x - transform.position.x) <= 0.1f)
                {
                    Debug.Log("AI-SPAWNER is Arrived");
                    ismoving = false;
                }
                else
                {
                    transform.Translate((movetarget - transform.position).normalized * Time.deltaTime * speed);
                }
            }
        }

        // 向玩家射击
        void ShotToPlayer()
        {
            Vector3 target = targetpos - transform.position;
            target.z = 0f;
            enemyGun.ShotCd = 1.5f;
            enemyGun.BulletColor = "red";
            enemyGun.Shot(transform.position, target.normalized);
        }

        // 鉴别触发器
        public void OnMyTrigger(string type, Collider2D collision)
        {
            if (type != null && type.Equals("FindPlayer"))
            {
                CircleCollider2D other = collision as CircleCollider2D;
                targetpos = collision.gameObject.transform.position;
                canshot = true;
                if (other.gameObject.tag.Equals("Player"))
                {
                    Debug.Log("Enemy:   Player in Range!");
                    Debug.Log("Enemy:   Shot to Player!");
                    ShotToPlayer();
                }
            }

            if (type != null && type.Equals("NotFindPlayer"))
            {
                CircleCollider2D other = collision as CircleCollider2D;
                if (other.gameObject.tag.Equals("Player"))
                {
                    Debug.Log("Enemy:   Player Out of Range!");
                    canshot = false;
                }
            }

            if (type != null && type.Equals("Touched"))
            {
                CircleCollider2D other = collision as CircleCollider2D;
                if (other.gameObject.tag.Equals("Bullet") && other.gameObject.GetComponent<SpriteRenderer>().color == Color.white)
                {
                    Debug.Log("Enemy:   Killed By Player!");
                    Destroy(other.gameObject);
                    dataRecorder.Killnum += 1;
                    enemyControl.DestoryEnemy(gameObject);
                }
            }
        }




   
    }
}


