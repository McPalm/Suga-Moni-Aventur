using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColorFader : MonoBehaviour
{
    public Color target;


    Color start;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        yield return new WaitForSeconds(1f);

        var camera = Camera.main;
        start = camera.backgroundColor;
        for(float f = 0; f < 1f; f += Time.deltaTime * .25f)
        {
            camera.backgroundColor = Color.Lerp(start, target, f);
            yield return null;
        }
        camera.backgroundColor = target;
    }

    private void OnDisable()
    {
        Camera.main.backgroundColor = start;
    }
}
