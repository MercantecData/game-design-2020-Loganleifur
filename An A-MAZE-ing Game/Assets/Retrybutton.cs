using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.Serialization;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;
using System;

public class Retrybutton : MonoBehaviour, IPointerClickHandler
{

    public class ButtonClickedEvent : UnityEvent
    {



    }
    [FormerlySerializedAs("onClick")]
    private ButtonClickedEvent m_OnClick = new ButtonClickedEvent();




    

    public ButtonClickedEvent onClick
    {

        get { return m_OnClick; }
        set { m_OnClick = value; }
    }

    private void Press()
    {


        UISystemProfilerApi.AddMarker("Button.onClick", this);
        
        Invoke("sup", 0f);
    }

    void sup()
    {
        SceneManager.LoadScene(0);

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
