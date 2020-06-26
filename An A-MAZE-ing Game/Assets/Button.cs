using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine;

public class Button : MonoBehaviour, IPointerClickHandler
{



    public class ButtonClickedEvent : UnityEvent {


        
    }
    [FormerlySerializedAs("onClick")]
    private ButtonClickedEvent m_OnClick = new ButtonClickedEvent();




    public GameObject Lifesteal;
    public GameObject Sharpness;
    public GameObject hope;

    public ButtonClickedEvent onClick
    {
        
        get { return m_OnClick; }
        set { m_OnClick = value; }
    }

    private void Press()
    {
        

        UISystemProfilerApi.AddMarker("Button.onClick", this);
        Sharpness = GameObject.Find("HUD/SharpnessButton");
        Lifesteal = GameObject.Find("HUD/LifestealButton");
        Invoke("sup", 0f);
    }

    void sup()
    {
        print("im in bois");
        hope = GameObject.Find("HUD/LifestealButton");
        if (this.gameObject.name == "LifestealButton")
        {
            
            GameObject.Find("HUD/Enchantment").GetComponent<Text>().text = "Enchantment: Lifesteal";
            Lifesteal.SetActive(false);
            Sharpness.SetActive(false);

        }

        if (this.gameObject.name == "SharpnessButton")
        {
            GameObject.Find("HUD/Enchantment").GetComponent<Text>().text = "Enchantment: Sharpness";
            Sharpness.SetActive(false);
            Lifesteal.SetActive(false);
        }

    }
    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left)
            return;

        Press();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
