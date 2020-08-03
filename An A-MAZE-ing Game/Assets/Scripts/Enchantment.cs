using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enchantment : MonoBehaviour
{

    public Button yourButton;



    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        print("You have clicked the button!");
    }

    void Update()
    {
        
    }

    void OnClick()
    {

    }
}
