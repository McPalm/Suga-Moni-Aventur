using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurt : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var suga = collision.transform.GetComponent<SugaMoni>();
        if(suga)
        {
            FindObjectOfType<Spawn>().Kill();
        }
    }
}
