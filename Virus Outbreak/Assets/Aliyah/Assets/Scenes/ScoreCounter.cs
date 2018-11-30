using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Aliyah Amy
//Implement in text script

public class ScoreCounter : MonoBehaviour
{
    public static int playerScore = 0;
    public int timerScore = 0;
    public int killsScore = 100;//100
    public int comboScore = 10;//10
    public int damageScore = 50;//-50
    public int finalScore = 0;
    Text score;
    private int startingTime = 0;


    // Use this for initialization
    void Start()
    {
        score = GetComponent<Text>();
        startingTime = (int)Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        timerScore = ((int)Time.time - startingTime);
        playerScore = timerScore;
        updateScore();
    }

    /*to implement
     *     public ScoreCounter counter;
     *     
     *     void AddScore()
        {
            counter.addKillsScore();//or addDamageScore();
        }

        AddScore();

    */

    public void addKillsScore()
    {
        playerScore += killsScore;
        updateScore();
    }

    public void addDamageScore()
    {
        playerScore -= damageScore;
        updateScore();
    }

    public void updateScore()
    {
        score.text = "Score: " + playerScore;
    }
}
