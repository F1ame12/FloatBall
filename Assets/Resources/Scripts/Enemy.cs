using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FloatBall
{
    public class Enemy : MonoBehaviour
    {

        ShootControl gun = new ShootControl();
        bool canshot = false;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void FixedUpdate()
        {
            if (canshot)
            {
                canshot = false;
            }
            else
            {
                canshot = true;
            }
        }

        private void OnTriggerStay2D(Collider2D collider)
        {
            if (!canshot)
            {
                return;
            }
            CircleCollider2D circle = collider as CircleCollider2D;
            if (circle.gameObject.tag.Equals("Player") && circle.radius == 0.25)
            {
                Debug.Log("Find Player!");
                Vector3 target = collider.gameObject.transform.position - transform.position;
                target.z = 0f;
                gun.Color = "red";
                gun.Shot(transform.position, target.normalized);
            }
        }

    }
}


