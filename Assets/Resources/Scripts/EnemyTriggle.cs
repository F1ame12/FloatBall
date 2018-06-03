using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FloatBall
{
    public class EnemyTriggle : MonoBehaviour
    {

        string triggerType;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            triggerType = "Touched";
            Enemy enemy = gameObject.GetComponentInParent<Enemy>();
            enemy.OnMyTrigger(triggerType, collision);
        }
    }
}


