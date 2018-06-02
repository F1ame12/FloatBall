using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FloatBall
{
    public class ShootControler : SingletonUnity<ShootControler>
    {
        string color = null;
        GameObject bullet_prefab;

        public string Color
        {
            set
            {
                color = value;
            }
        }

        private void Start()
        {
            bullet_prefab = Resources.Load<GameObject>("prefab/Bullet");
        }

        public void Shot(Vector3 from, Vector3 target)
        {
            GameObject bullet = GameObject.Instantiate(bullet_prefab, from, Quaternion.identity);
            if (color != null && color.Equals("red"))
            {
                bullet.GetComponent<SpriteRenderer>().color = UnityEngine.Color.red;
            }
            bullet.GetComponent<Bullet>().Direction = target;
        }
    }
}

