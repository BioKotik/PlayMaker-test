using UnityEngine;

public class PartilcesPath : MonoBehaviour
{
    public AnimationCurve curve;
    public Transform target;

    private float time = 0f;
    private ParticleSystem particleSystem;
    private ParticleSystem.MainModule mainModule;
    private ParticleSystem.Particle[] particles;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        mainModule = particleSystem.main;
        particles = new ParticleSystem.Particle[mainModule.maxParticles];
    }

    //void LateUpdate()
    //{
    //    particleSystem.GetParticles(particles);
    //    int i = 0;
    //
    //    while (i < particles.Length)
    //    {
    //        Vector3 direction = target.position - particles[i].position;
    //        direction.Normalize();
    //
    //        particles[i].position += direction * Time.deltaTime;
    //
    //        i++;
    //    }
    //
    //    particleSystem.SetParticles(particles);
    //}

    void LateUpdate()
    {
        time += Time.deltaTime;
        int length = particleSystem.GetParticles(particles);
        int i = 0;

        while (i < length)
        {
            //Target is a Transform object
            Vector3 direction = target.position - particles[i].position;

            Debug.Log(direction);

            particles[i].position += direction * Time.deltaTime;

            if (Vector3.Distance(target.position, particles[i].position) < 1.0f)
            {
                particles[i].remainingLifetime = -0.1f; //Kill the particle
            }

            i++;

        }

        particleSystem.SetParticles(particles, length);
    }
}
