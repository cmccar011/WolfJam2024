using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuinStoneEffects : MonoBehaviour
{ 
    public float maxPowerIncrease = 10f; // Max power boost when close
    public float proximityRange = 5f;   // Range where power starts growing
    public LayerMask playerLayer;       // Player layer for detection

    private Transform player;

    void Update()
    {
        // Detect player within proximity range
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, proximityRange, playerLayer);

        if (playerCollider != null)
        {
            player = playerCollider.transform;

            // Calculate distance and increase power based on proximity
            float distance = Vector2.Distance(transform.position, player.position);
            float powerIncrease = Mathf.Lerp(maxPowerIncrease, 0, distance / proximityRange);

            // Call a method to update the player's power (requires a player script)
            //player.GetComponent<PlayerController>().UpdatePower(powerIncrease);
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Visualize the proximity range in the editor
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, proximityRange);
    }
}

