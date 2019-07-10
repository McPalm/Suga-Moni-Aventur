using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoiseScatterBecauseFuckYou : MonoBehaviour
{
    public float spread = 1f;
    public float speed = 1f;


    Vector3 home;

    private void Start()
    {
        home = transform.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localPosition = home + new Vector3(
            .5f - Mathf.PerlinNoise(Time.timeSinceLevelLoad * speed, .1f),
            .5f - Mathf.PerlinNoise(Time.timeSinceLevelLoad * speed, 7.1f)) * spread;
    }
}
