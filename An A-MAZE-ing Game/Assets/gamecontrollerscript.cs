using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamecontrollerscript : MonoBehaviour
{

    public Text ui_text;
    // Start is called before the first frame update

    public static gamecontrollerscript instance;
    public void Awake()
    {
        instance = this;
    }

    
}
