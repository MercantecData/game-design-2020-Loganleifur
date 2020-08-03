using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamecontrollerscript : MonoBehaviour
{

    public Text ui_text;

    //ui_text.text = "HP: " + hp thing
    //public void OnTriggerEnter2d() { GameController.hp}
    // Start is called before the first frame update

    public static gamecontrollerscript instance;
    public void Awake()
    {
        instance = this;
    }

    
}
