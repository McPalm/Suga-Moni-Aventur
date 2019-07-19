using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoiseScatterBecauseFuckYou : MonoBehaviour
{
    public float spread = 1f;
    public float speed = 1f;

    float seed;

    Vector3 home;

    private void Start()
    {
        home = transform.localPosition;
        seed = Random.value * 11111f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localPosition = home + new Vector3(
            .5f - Mathf.PerlinNoise(Time.timeSinceLevelLoad * speed, seed),
            .5f - Mathf.PerlinNoise(Time.timeSinceLevelLoad * speed, seed + 8.51f)) * spread;
    }
}
