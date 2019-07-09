using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    Mobile suga;
    Vector2 home;

    bool falling = false;

    // Start is called before the first frame update
    void Start()
    {
        suga = FindObjectOfType<SugaMoni>();
        home = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!falling && suga.Grounded)
        {
            var dx = Mathf.Abs(suga.transform.position.x - transform.position.x);
            if(dx < .75f && suga.transform.position.y > transform.position.y && suga.transform.position.y < transform.position.y + 1f)
            {
                StartCoroutine(Fall());
            }
        }
    }

    IEnumerator Fall()
    {
        falling = true;
        yield return new WaitForSeconds(.4f);
        var momentum = 0f;
        for (int i = 0; i < 120; i++)
        {
            yield return new WaitForFixedUpdate();
            transform.Translate(new Vector3(0f, -momentum * Time.fixedDeltaTime));
            if(momentum < 10f)
                momentum += 35f * Time.fixedDeltaTime;
        }

        transform.position = home;
        falling = false;
    }
}
