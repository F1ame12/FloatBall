using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FloatBall
{
    public class PlayerTrigger : MonoBehaviour
    {
        string triggerType;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            triggerType = "Touched";
            Player player = gameObject.GetComponentInParent<Player>();
            player.OnMyTrigger(triggerType, collision);
        }

    }
}

