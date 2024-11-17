using System.Collections;
using System.Collections.Generic;
using UnityEditor.Scripting;
using UnityEngine;

public class EffectsFromRuinStones : MonoBehaviour
{
    public bool resonance = true;
    public float mana = 100;
    public float ManaDrainRate = 0.05f;
    public Transform target; // The object the player approaches.
    public GameObject aura; // The GameObject representing the aura (e.g., a translucent circle).
    public float maxScale = 3.0f; // Maximum scale of the aura.
    public float minScale = 1.0f; // Minimum scale of the aura.
    public float glowDistance = 10.0f; // Distance at which the aura reaches maximum scale and opacity.
    public float maxOpacity = 0.8f; // Maximum opacity of the aura.
    public float minOpacity = 0.2f; // Minimum opacity of the aura.

    private SpriteRenderer auraRenderer; // SpriteRenderer of the aura.

    void Start()
    {
        if (aura == null)
        {
            Debug.LogError("PlayerAuraProximity: Aura GameObject is not assigned!");
            return;
        }

        // Get the SpriteRenderer component of the aura.
        auraRenderer = aura.GetComponent<SpriteRenderer>();
        if (auraRenderer == null)
        {
            Debug.LogError("PlayerAuraProximity: Aura GameObject does not have a SpriteRenderer!");
        }
    }

    void Update()
    {
        if (resonance)
        {
            mana = mana - ManaDrainRate;
            if (mana <= 0)
            {
                resonance = false;
            }
        }
        if (target == null || aura == null || auraRenderer == null)
        {
            return;
        }

        // Calculate the distance between the player and the target.
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance <= 0.0f)
        {
            mana = 100;
            resonance = true;
        }

        // Normalize the distance to a range of [0, 1].
        float proximity = Mathf.Clamp01(1.0f - (distance / glowDistance));


        // Scale the aura based on proximity.
        float currentScale = Mathf.Lerp(minScale, maxScale, proximity);
        aura.transform.localScale = new Vector3(currentScale, currentScale, 1.0f);

        // Adjust the aura's opacity based on proximity.
        float currentOpacity = Mathf.Lerp(minOpacity, maxOpacity, proximity);
        Color auraColor = auraRenderer.color;
        auraRenderer.color = new Color(auraColor.r, auraColor.g, auraColor.b, currentOpacity);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ruin"))
            {
                resonance = true;
                mana = 100;
            }
    }
}