using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject Heart;
    public GameObject Coin;
    public TMPro.TextMeshPro Text;
    public AudioClip WinAudio;
    public AudioClip NeedMoreAudio;
    public AudioClip EnoughMoneyAudio;

    public int NeedCoin = 5;

    bool playedThing = false;

    private void Update()
    {
        if(NeedCoin > 0)
        {
            Coin.SetActive(true);
            Text.text = $"x{NeedCoin}";
        }
        else if(!playedThing)
        {
            Coin.SetActive(false);
            Text.gameObject.SetActive(false);
            AudioPool.PlaySound(Camera.main.transform.position, EnoughMoneyAudio);
            playedThing = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (NeedCoin <= 0 && collision.GetComponent<SugaMoni>())
        {
            Heart.SetActive(true);
            collision.GetComponent<SugaMoni>().Disable = true;
            FindObjectOfType<SceneTransitionManager>().NextStage();
            AudioPool.PlaySound(transform.position, WinAudio);
        }
        else
        {
            AudioPool.PlaySound(transform.position, NeedMoreAudio);
        }
    }
}
