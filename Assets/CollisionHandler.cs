using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    /// <summary>
    /// The callback for collisions from particle systems.
    /// </summary>
    /// <param name="other"></param>
    private void OnParticleCollision(GameObject other)
    {
        if (!enabled)
        {
            return;
        }
        Debug.Log(name + " collided with '" + other.name + "' @ " + other.transform.position + "");
    }
}
