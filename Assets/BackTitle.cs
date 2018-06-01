using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackTitle : MonoBehaviour
{

    // Use this for initialization
    public void backTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
