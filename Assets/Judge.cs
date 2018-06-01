using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public static partial class StringExtensions
{
    /// 文字列が指定されたいずれかの文字列と等しいかどうかを返す拡張メソッド
    public static bool IsAny(this string self, params string[] values)
    {
        return values.Any(c => c == self);
    }
}

public class Judge : MonoBehaviour
{

    // Use this for initialization
    public void JudgeAnswer()
    {

        Text answer = this.GetComponentInChildren<Text>();

        //textをいれたらクリア（3H）
        if (answer.text.IsAny
            (
            "チャック・ベリー", "小野小町", "しょうゆ"
            ))

        {
            Debug.Log("正解");
            ResultMgr.SetJudgeData("正解");
            SceneManager.LoadScene("Result");
        }
        else
        {
            Debug.Log("不正解");
            ResultMgr.SetJudgeData("不正解");
            SceneManager.LoadScene("Result");
        }
    }

}





