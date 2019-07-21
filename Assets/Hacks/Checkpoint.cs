using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D()
    {
        Destroy(gameObject);
        var spawn = FindObjectOfType<Spawn>();
        spawn.transform.position = transform.position;
    }
}
