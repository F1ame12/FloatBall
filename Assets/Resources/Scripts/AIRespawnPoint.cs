using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FloatBall
{
    public class AIRespawnPoint : MonoBehaviour
    {
        Vector3 circle;
        // Use this for initialization
        void Start()
        {
            circle = new Vector3(0f, 0f, 1f);
        }

        // Update is called once per frame
        void Update()
        {
            CircleAnimation();
        }



        void CircleAnimation()
        {

            transform.Rotate(0f, 0f, 10f);
            
        }
    }
}


