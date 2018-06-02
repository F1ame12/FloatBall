using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FloatBall
{
    public class Player : MonoBehaviour
    {
        float speed = 5f;
        
        public float Speed
        {
            get
            {
                return speed;
            }
            set
            {
                if (value < 0f)
                {
                    this.speed = 0f;
                }
                this.speed = value;
            }
        }

        public void OnMyTrigger(string type, Collider2D collider)
        {
            if (type != null && type.Equals("Touched"))
            {
                CircleCollider2D other = collider as CircleCollider2D;
                if (other.gameObject.tag.Equals("Bullet"))
                {
                    if (other.gameObject.GetComponent<SpriteRenderer>().color == Color.red)
                    {
                        Debug.Log("Player:  Get Hurt!");
                        Destroy(other.gameObject);
                    }
                }
            }
        }

    }

}

