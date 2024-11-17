using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RuinStoneEffects : MonoBehaviour
{
	public ParticleSystem particleSystem;
	public Transform player; // The object the player approaches.
	public Transform ruinStone;
	private bool isPlaying = false;
	
	void Start()
	{
		particleSystem = GetComponent<ParticleSystem>();
	}

	void Update()
	{
		float distance = Vector3.Distance(player.position, ruinStone.position);
        if (distance <= 10f)
        {
			if (!isPlaying)
			{
				particleSystem.Play();
				isPlaying = true;
			}
			
			ChangeParticleOpacity(1-(distance)/10f);
			ChangeEmissionRate((1-(distance)/10f)*10);
			//SpawnParticles((int)(distance - (distance)/5f));
		}
		else
		{
			if (isPlaying)
			{
				particleSystem.Stop();
				isPlaying = false;
			}
			
		}
		
	}
	public void ChangeParticleOpacity(float opacity)
	{
		var main = particleSystem.main; // Access the main module

		// Modify the start color's alpha (opacity)
		Color startColor = main.startColor.color; // Get the current start color
		startColor.a = opacity; // Set the alpha value
		main.startColor = startColor; // Apply the new color
	}
	// Function to spawn a specific number of particles manually
		public void SpawnParticles(int count)
	{
		particleSystem.Emit(count); // Emit a specified number of particles
	}
	public void ChangeEmissionRate(float rate)
    {
        var emission = particleSystem.emission; // Access the emission module
        emission.rateOverTime = rate; // Set the new rate
    }
}
