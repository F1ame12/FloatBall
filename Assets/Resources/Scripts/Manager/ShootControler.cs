using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FloatBall
{
    public class ShootControler : SingletonUnity<ShootControler>
    {
        string bulletColor;
        float shotCd;
        bool canShot;
        float shotWaitTime;
        GameObject bullet_prefab;

        public string BulletColor
        {
            set
            {
                bulletColor = value;
            }
        }

        public float ShotCd
        {
            get
            {
                return shotCd;
            }
            set
            {
                shotCd = value;
            }
        }


        private void Start()
        {
            bullet_prefab = Resources.Load<GameObject>("prefab/Bullet");
            shotCd = 0.0f;
            shotWaitTime = 0.0f;
            canShot = true;
        }

        private void Update()
        {
            ShotWaitTime();
        }

        void ShotWaitTime()
        {
            if (shotWaitTime < shotCd)
            {
                shotWaitTime += Time.deltaTime;
            }
            else
            {
                shotWaitTime = 0f;
                canShot = true;
            }
        }

        public void Shot(Vector3 from, Vector3 target)
        {
            if (canShot)
            {
                GameObject bullet = GameObject.Instantiate(bullet_prefab, from, Quaternion.identity);
                bullet.GetComponent<Bullet>().Direction = target;
                if (bulletColor != null && bulletColor.Equals("red"))
                {
                    bullet.GetComponent<SpriteRenderer>().color = UnityEngine.Color.red;
                }

                canShot = false;
            }
            
            
        }
    }
}

