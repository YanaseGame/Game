using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPon : MonoBehaviour {


    // Use this for initialization
    public void Pon () {

        //効果音出す
        GetComponent<AudioSource>().Play();
       
    }
	
}
