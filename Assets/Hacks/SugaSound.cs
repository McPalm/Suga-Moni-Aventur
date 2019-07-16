using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugaSound : MonoBehaviour
{
    public AudioClip Duck;
    public AudioClip Jump;

    
    void Start()
    {
        var suga = GetComponent<SugaMoni>();
        suga.OnJump += OnJump;
    }

    public void OnDuck()
    {
        AudioPool.PlaySound(transform.position, Duck);
    }

    void OnJump()
    {
        AudioPool.PlaySound(transform.position, Jump);
    }


}
