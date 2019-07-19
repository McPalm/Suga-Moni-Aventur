using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadParaflax : MonoBehaviour
{
    public Vector3 offset;
    Transform camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = camera.position * .9f + offset + new Vector3(0f, 0f, 10f);
    }
}
