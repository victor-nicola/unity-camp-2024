using UnityEngine;

public class ParticleExclusionZone : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public float exclusionRadius = 10f;
    public Transform exclusionObject;

    private ParticleSystem.Particle[] particles;
    private int maxParticles;

    void Start()
    {
        if (particleSystem != null)
        {
            maxParticles = particleSystem.main.maxParticles;
            particles = new ParticleSystem.Particle[maxParticles];
        }
    }

    void Update()
    {
        if (particleSystem != null && exclusionObject != null)
        {
            int numParticlesAlive = particleSystem.GetParticles(particles);
            Vector3 exclusionPosition = exclusionObject.position;

            for (int i = 0; i < numParticlesAlive; i++)
            {
                float distance = Vector3.Distance(exclusionPosition, particles[i].position);
                if (distance < exclusionRadius)
                {
                    particles[i].remainingLifetime = 0f; // Remove particle
                }
            }

            particleSystem.SetParticles(particles, numParticlesAlive);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (exclusionObject != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(exclusionObject.position, exclusionRadius);
        }
    }
}
