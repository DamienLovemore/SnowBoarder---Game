using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem trailEffect;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Terrain")
            trailEffect.Play();
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Terrain")
            trailEffect.Stop();
    }
}
