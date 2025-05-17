using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    [SerializeField] AudioSource coinFX;

    public void OnTriggerEnter(Collider other)
    {
        coinFX.Play();
        MasterInfo.instance.coinCount += 1;
        this.gameObject.SetActive(false);
    }
}
