using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BtnScript : MonoBehaviour {

    public float gazeTime = 2f;
    private float timer;
    private bool gazedAt;
    public Image btnImg;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gazedAt)
        {
            timer += Time.deltaTime;
            btnImg.fillAmount = 1;
            btnImg.fillAmount -= (timer/gazeTime);
            if (timer >= gazeTime)
            {
                ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                timer = 0;
                btnImg.fillAmount = 1;
                gazedAt = false;
                //GetComponent<Collider>().enabled = false;
            }
        }
	}
    public void PointerEnter()
    {
        gazedAt = true;

    }
    public void PointerExit()
    {
        gazedAt = false;
        timer = 0;
        btnImg.fillAmount = 1;
    }
}
