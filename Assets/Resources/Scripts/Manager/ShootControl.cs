using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FloatBall
{
    public class ShootControl
    {
        public void Shot(Vector3 from, Vector3 target)
        {
            GameObject bullet_prefab = Resources.Load<GameObject>("prefab/Bullet");
            GameObject bullet = GameObject.Instantiate(bullet_prefab, from, Quaternion.identity);
            bullet.GetComponent<Bullet>().Direction = target;

        }
    }
}

