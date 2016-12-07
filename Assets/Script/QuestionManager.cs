using UnityEngine;
using System.Collections;

public class QuestionManager : MonoBehaviour {

    public GameObject question1;
    public Quaternion qRot;
    //public GameObject q;

	// Use this for initialization
	void Start () {
        //q.GetComponent<GameObject>();
        //question1 = q;
        question1.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.K))
        {
            ShowQuestion();
        }
    }


    public void ShowQuestion ()
    {
        qRot = new Quaternion(0, MovePlayer.teleportDicePoint.transform.rotation.y, MovePlayer.teleportDicePoint.transform.rotation.z, 1);
        question1.transform.position = MovePlayer.teleportDicePoint.transform.position;
        question1.transform.rotation = qRot;
        question1.SetActive(true);
    }

}
