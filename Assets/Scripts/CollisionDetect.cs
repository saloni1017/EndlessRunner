using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetect : MonoBehaviour
{
    [SerializeField] GameObject thePlayer;
    [SerializeField] GameObject playerAnim;
    [SerializeField] AudioSource collisionFX;
    [SerializeField] GameObject fadeOut;

    public void OnTriggerEnter(Collider other)
    {
        StartCoroutine(CollisionEnd());
    }

    IEnumerator CollisionEnd()
    {
        collisionFX.Play();
        MasterInfo.instance.livesCount -= 1;
        MasterInfo.instance.livesDisplay.GetComponent<TMPro.TMP_Text>().text = "LIVES: " + MasterInfo.instance.livesCount;
        if (MasterInfo.instance.livesCount <= 0)
        {
            MasterInfo.instance.livesDisplay.GetComponent<TMPro.TMP_Text>().text = "LIVES: 0" ;
            thePlayer.GetComponent<PlayerMovement>().enabled = false;
            playerAnim.GetComponent<Animator>().Play("Stumble Backwards");
            fadeOut.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            SceneManager.LoadScene(2);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
