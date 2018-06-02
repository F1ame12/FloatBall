using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FloatBall
{
    public class Enemy : MonoBehaviour
    {

        ShootControl gun = new ShootControl();
        bool canshot = false;
        float timecount = 0;
        float speed = 3f;
        Vector3 playerpos;
        GameObject player;
        // Use this for initialization
        void Start()
        {
            player = GameObject.Find("player").gameObject;
        }

        // Update is called once per frame
        void Update()
        {
            playerpos = player.transform.position;
            if (canshot)
            {
                timecount += Time.deltaTime;
            }
            
            transform.Translate((playerpos - transform.position).normalized * Time.deltaTime * speed);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            CircleCollider2D circle = collision as CircleCollider2D;
            if (circle.gameObject.tag.Equals("Player") && circle.radius == 0.25)
            {
                Debug.Log("Enemy:   Player Out of Range!");
                canshot = false;
            }
            else if (circle.gameObject.tag.Equals("Bullet"))
            {
                int chance = Random.Range(0, 1);
                if (chance == 1)
                {

                }
            }

        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            
            CircleCollider2D circle = collision as CircleCollider2D;
            targetpos = collision.gameObject.transform.position;
            canshot = true;
            if (circle.gameObject.tag.Equals("Player") && circle.radius == 0.25)
            {
                Debug.Log("Enemy:   Player in Range!");
                if (canshot && timecount > 0.5)
                {
                    Debug.Log("Enemy:   Shot to Player!");
                    timecount = 0;
                    ShotToPlayer();
                    
                }
                
            }
            
        }
        Vector3 targetpos;
        void ShotToPlayer()
        {
            Vector3 target = targetpos - transform.position;
            target.z = 0f;
            gun.Color = "red";
            gun.Shot(transform.position, target.normalized);
        }

      

    }
}


