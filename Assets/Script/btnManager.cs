using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class btnManager : MonoBehaviour {

    public float gazeTime = 2f;
    private float timer;
    private bool gazedAt;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gazedAt)
        {
            timer += Time.deltaTime;

            //Vector3 newScale = new Vector3(timer / gazeTime * 2, redChild.localScale.y, redChild.transform.localScale.z);
            //Vector3 newPos = new Vector3(-80f + (timer / gazeTime), redChild.transform.localPosition.y, redChild.transform.localPosition.z);



            if (timer >= gazeTime)
            {
                ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                timer = 0f;
                //GetComponent<Collider>().enabled = false;
            }
        }
	}

    public void WrongAnswer()
    {

    }
    public void RightAnswer()
    {

    }
    public void PointerEnter()
    {
        gazedAt = true;

    }
    public void PointerExit() 
    {
        gazedAt = false;
        timer = 0;
        //Transform redChild = transform.GetChild(0);
        //redChild.localScale = new Vector3();
        //redChild
        //redChild.transform.localPosition = newPos;
    }
}
