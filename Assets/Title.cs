using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour
{

    public void Start()
    {
        //☆を出す
        Text StarBox = GameObject.Find("Star").GetComponent<Text>();
        int Box = QuizMgr.Starbox();
        StarBox.text = "☆ × " + Box;
    }
}