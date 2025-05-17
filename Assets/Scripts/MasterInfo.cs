using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterInfo : MonoBehaviour
{
    public int coinCount = 0;
    public int livesCount = 3;
    //public int highScore = 0;

    public static MasterInfo instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    [SerializeField] GameObject coinDisplay;
    public GameObject livesDisplay;
   // public GameObject highScoreDisplay;
    // Start is called before the first frame update
    void Start()
    {
        coinCount = 0;
        coinDisplay.GetComponent<TMPro.TMP_Text>().text = "COINS: " + coinCount;
        livesDisplay.GetComponent<TMPro.TMP_Text>().text = "LIVES: " + livesCount;
       // highScoreDisplay.GetComponent<TMPro.TMP_Text>().text = "High Score: " + highScore;
    }

    // Update is called once per frame
    void Update()
    {
        coinDisplay.GetComponent<TMPro.TMP_Text>().text = "COINS: " + coinCount;
        livesDisplay.GetComponent<TMPro.TMP_Text>().text = "LIVES: " + livesCount;
        //highScoreDisplay.GetComponent<TMPro.TMP_Text>().text = "High Score: " + highScore;
    }
}
