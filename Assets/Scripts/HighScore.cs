using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public int highScore = 0;
    public GameObject highScoreDisplay;
    // Start is called before the first frame update
    void Start()
    {
        highScoreDisplay.GetComponent<TMPro.TMP_Text>().text = "High Score: " + highScore;
    }

    // Update is called once per frame
    void Update()
    {
        if(MasterInfo.instance.coinCount > highScore)
        {
            highScore = MasterInfo.instance.coinCount;
            highScoreDisplay.GetComponent<TMPro.TMP_Text>().text = "High Score: " + highScore;
        }
        else
        {
            highScoreDisplay.GetComponent<TMPro.TMP_Text>().text = "High Score: " + highScore;
        }
    }
}
