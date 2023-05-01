using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleHandler : MonoBehaviour
{
    private ParticleSystem _particleSystem;


    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[_particleSystem.main.maxParticles];
        int numParticles = _particleSystem.GetParticles(particles);

        for (int i = 0; i < numParticles; i++)
        {
            ParticleSystem.Particle particle = particles[i];

            // Check if the particle has a nonzero velocity
            if (particle.velocity != Vector3.zero)
            {
                // Calculate the rotation needed to make the particle face its velocity
                Quaternion targetRotation = Quaternion.LookRotation(particle.velocity, Vector3.up);
                particle.rotation3D = targetRotation.eulerAngles;
            }

            particles[i] = particle;
        }

        _particleSystem.SetParticles(particles, numParticles);
    }
}
