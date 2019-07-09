using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    bool respawning = false;

    internal void Kill()
    {
        if (!respawning)
            StartCoroutine(RespawnRoutine());
    }

    IEnumerator RespawnRoutine()
    {
        respawning = true;
        var suga = FindObjectOfType<SugaMoni>();
        suga.GetComponent<SpriteRenderer>().flipY = true;
        suga.Disable = true;
        suga.VMomentum = 4f;
        yield return new WaitForSeconds(1f);
        suga.transform.position = transform.position;
        FindObjectOfType<CameraFollow>().Lag();
        yield return new WaitForSeconds(.5f);
        respawning = false;
        suga.Disable = false;
        suga.GetComponent<SpriteRenderer>().flipY = false;
    }
}
