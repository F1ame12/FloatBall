using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FloatBall
{
    public class EnemyLargeCircleTrigger : MonoBehaviour
    {
        string triggerType;
        // Use this for initialization

        private void OnTriggerStay2D(Collider2D collision)
        {
            triggerType = "FindPlayer";
            Enemy enemy = gameObject.GetComponentInParent<Enemy>();
            enemy.OnMyTrigger(triggerType, collision);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            triggerType = "NotFindPlayer";
            Enemy enemy = gameObject.GetComponentInParent<Enemy>();
            enemy.OnMyTrigger(triggerType, collision);
        }

    }
}


