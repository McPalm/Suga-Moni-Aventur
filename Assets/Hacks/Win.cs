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

    public int NeedCoin = 5;

    private void Update()
    {
        if(NeedCoin > 0)
        {
            Coin.SetActive(true);
            Text.text = $"x{NeedCoin}";
        }
        else
        {
            Coin.SetActive(false);
            Text.gameObject.SetActive(false);
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
