using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{

    public void NextScene()
    {
        //問題数（Q１～）をリセット
        QuizMgr.numberQuestions = 1;
        //今いるシーンがTitleという名前であれば、Quizという名前のシーンに移動する
        if (SceneManager.GetActiveScene().name == "Title")
        {
            //☆が0の場合、スコアのシーンに飛ばす
            int Box = QuizMgr.Starbox();
            if (Box <= 0)
            {
                SceneManager.LoadScene("Score");
                return;
            }                        
            //効果音出す
            GetComponent<AudioSource>().Play();
            //(0)を入れるだけでリセット(今は使わない)
            QuizMgr.SetScoreData(0);
            //クイズシーンへ
            SceneManager.LoadScene("Quiz");
            //問題をシャッフルするメソッドを起動（☆を-１もする）
            QuizMgr.shuffleSet();
            //ハートの画像（DontDestroyOnLoad中）をリセット！
            HeartBox.OnDestroy();
            HeartBox2.OnDestroy();
            HeartBox3.OnDestroy();           
        }
    }
    public void SettingScene()
    {
        if (SceneManager.GetActiveScene().name == "Title")
        {
            SceneManager.LoadScene("設定");
        }
    }

    public void SettingScene2()
    {
        if (SceneManager.GetActiveScene().name == "Title")
        {
            SceneManager.LoadScene("その他");
        }
    }


    public void EndScene()
    {
        if (SceneManager.GetActiveScene().name == "Score")
        {
            SceneManager.LoadScene("Title");           
        }
    }

}
     