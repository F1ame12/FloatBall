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
        

        

        
    }

}

