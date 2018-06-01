using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{


    
    void Start()
    {
        //〇問だったかを表示する
        Text scoreLabel = GameObject.Find("Score").GetComponent<Text>();
        scoreLabel.color = Color.black;
        int Score = QuizMgr.GetQuestionData();
        scoreLabel.text = Score + " 問到達";

        //☆を表示する
        Text starLabel = GameObject.Find("StarLabel").GetComponent<Text>();
        if (Score >= 100)
        {
            starLabel.text = "☆ ＋ " + 5 ;
            return;
        }
        if (Score >= 75)
        {
            starLabel.text = "☆ ＋ " + 4;
            return;
        }
        if (Score >= 50)
        {
            starLabel.text = "☆ ＋ " + 3;
            return;
        }
        if (Score >= 30)
        {
            starLabel.text = "☆ ＋ " + 2;
            return;
        }
        if (Score >= 15)
        {
            starLabel.text = "☆ ＋ " + 1;
            return;
        }
    }   
 }
