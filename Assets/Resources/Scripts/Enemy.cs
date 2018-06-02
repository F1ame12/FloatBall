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
            canshot = false;
            shotWaitTime = 1.5f;
            timecount = 0f;
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
            ShotWaitTime();
            
        }

        void ShotWaitTime()
        {
            if (canshot)
            {
                timecount += Time.deltaTime;
            }
        }

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

        void ShotToPlayer()
        {
            Vector3 target = targetpos - transform.position;
            target.z = 0f;
            enemyGun.Color = "red";
            enemyGun.Shot(transform.position, target.normalized);
        }

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
                    if (canshot && timecount > shotWaitTime)
                    {
                        Debug.Log("Enemy:   Shot to Player!");
                        timecount = 0;
                        ShotToPlayer();
                    }
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
                    if (enemyControl.DestoryEnemy(gameObject))
                    {
                        Destroy(gameObject);
                    }
                    dataRecorder.Killnum += 1;
                }
            }
        }
   
    }
}


