using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FloatBall
{
    public class EnemySpawnerTrigger : MonoBehaviour
    {
        string triggerType;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            triggerType = "Touched";
            EnemySpawner enemySpawner = gameObject.GetComponentInParent<EnemySpawner>();
            enemySpawner.OnMyTrigger(triggerType, collision);
        }

    }
}
