using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ParticleTriggerHandler : MonoBehaviour
{
    ParticleSystem particlesHit;

    // Start is called before the first frame update
    void Start()
    {
        Material particleMaterial = new Material(Shader.Find("Particles/Standard Unlit"));

        // Create a Particle System.
        var go = new GameObject("Particle Systems For Hits");
        go.transform.Rotate(-90, 0, 0); // Rotate so the system emits upwards.
        particlesHit = go.AddComponent<ParticleSystem>();
        //var meshRenderer = go.AddComponent<MeshRenderer>();
        //meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
        //particlesHit.shape.
        particlesHit.maxParticles = 10;
        go.GetComponent<ParticleSystemRenderer>().material = particleMaterial;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnParticleTrigger()
    {
        if (!enabled)
        {
            return;
        }

        ParticleSystem ps = GetComponent<ParticleSystem>();

        // particles
        List<Particle> enter = new List<ParticleSystem.Particle>();
        // get
        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);

        // iterate
        for (int i = 0; i < numEnter; i++)
        {
            ParticleSystem.Particle p = enter[i];
            // Draw something at the position of the particle
            var paramsEmitter = new EmitParams();
            paramsEmitter.position = p.position;
            paramsEmitter.startSize = 0.2f;
            paramsEmitter.velocity = p.velocity;
            paramsEmitter.startLifetime = 0.2f;
            paramsEmitter.applyShapeToPosition = true;
            particlesHit.Emit(paramsEmitter, 1);
        }

        // set
        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
    }
}
