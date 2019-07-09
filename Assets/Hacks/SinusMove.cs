using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinusMove : MonoBehaviour
{
    public Vector2 Direction;
    public float Frequency;

    Vector2 home;

    private void Start()
    {
        home = transform.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localPosition = home + Direction * Mathf.Sin(Frequency * Time.timeSinceLevelLoad + home.x);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position + (Vector3)Direction, transform.position - (Vector3)Direction);
    }
}
