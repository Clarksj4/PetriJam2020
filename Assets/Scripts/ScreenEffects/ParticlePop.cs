using UnityEngine;
using System.Collections;

public class ParticlePop : ScreenEffect
{
    public ParticleSystem system;

    public override void Play()
    {
        system.Play();
    }

    public override void Stop()
    {
        system.Stop();

        Destroy(gameObject);
    }
}
