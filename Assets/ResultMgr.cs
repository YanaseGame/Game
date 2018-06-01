using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultMgr : MonoBehaviour {

    public static string g_judgeData;
    public static int g_scoreData;

    void Start()
    {
       
        if (g_judgeData == "不正解")
        {       
            SpriteRenderer judgeImage = GameObject.Find("JudgeImage").GetComponent<SpriteRenderer>();
            Sprite loadingImage = Resources.Load<Sprite>("batsu");
            judgeImage.sprite = loadingImage;
            Text judgeLabel = GameObject.Find("JudgeLabel").GetComponent<Text>();
            judgeLabel.text = "不正解";
        }
        else if (g_judgeData == "正解")
        {
            g_scoreData++;
        }
        
    }

	public static void SetJudgeData (string judgeData)
    {
        g_judgeData = judgeData;
	}
    public static int GetScoreData()
    {
        return g_scoreData;
    }
    public static int SetScoreData(int scoreData)
    {
        g_scoreData = scoreData;
        return g_scoreData;  
    }
}
