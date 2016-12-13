using UnityEngine;
using System.Collections;

public class QuestionManager : MonoBehaviour {

    public GameObject question1;
    public Quaternion qRot;
    //public GameObject q;
    public bool qShown;
    public float qRotY;

	// Use this for initialization
	void Start () {
        //q.GetComponent<GameObject>();
        //question1 = q;
        question1.SetActive(false);
        qShown = false;
        //qRot = new Quaternion();
	}
	
	// Update is called once per frame
	void Update () {
        

        if (Input.GetKeyDown(KeyCode.K))
        {
            if(!qShown)
                ShowQuestion();
            else
            {
                question1.SetActive(false);
                qShown = false;
            }

        }
    }


    public void ShowQuestion ()
    {
        //Dårlig hardcode måde at sætte y rotation, da der kommer en mærkelig bug, når den tager rotation fra fieldet..
        //Midlertidig, hurtig løsning.. Kan fixes ved videre udvikling
        switch (MovePlayer.nextPoint)
        {
            case 1: { qRotY = 0; break; }
            case 2: { qRotY = 90; break; }
            case 3: { qRotY = 40.5f; break; }
            case 4: { qRotY = -7.8f; break; }
            case 5: { qRotY = -27.4f; break; }
            case 6: { qRotY = -13.6f; break; }
            case 7: { qRotY = -0.18f; break; }
            case 8: { qRotY = 2.61f; break; }
            case 9: { qRotY = 0; break; }
            case 10: { qRotY = 90; break; }
            case 11: { qRotY = 127.7f; break; }
            case 12: { qRotY = 182.73f; break; }
            case 13: { qRotY = 180; break; }
            case 14: { qRotY = 175; break; }
            case 15: { qRotY = 143; break; }
            case 16: { qRotY = 40; break; }
            case 17: { qRotY = 0; break; }
            case 18: { qRotY = 0; break; }
            case 19: { qRotY = 0; break; }
            case 20: { qRotY = 58.8f; break; }
            case 21: { qRotY = 86.36f; break; }
            case 22: { qRotY = 115.32f; break; }
            case 23: { qRotY = 180; break; }
            case 24: { qRotY = 175.8f; break; }
            case 25: { qRotY = 200f; break; }
            case 26: { qRotY = -125.6f; break; }
            case 27: { qRotY = -176.45f; break; }
            case 28: { qRotY = -172.39f; break; }
            case 29: { qRotY = -139.67f; break; }
            case 30: { qRotY = -113.8f; break; }
            case 31: { qRotY = 158.39f; break; }
            case 32: { qRotY = 134.69f; break; }
            case 33: { qRotY = 92.61f; break; }
            case 34: { qRotY = 100f; break; }
            case 35: { qRotY = 95.94f; break; }
            case 36: { qRotY = 65.4f; break; }
            case 37: { qRotY = -7.26f; break; }
            case 38: { qRotY = -34.4f; break; }
            case 39: { qRotY = -45.63f; break; }
            case 40: { qRotY = -11.47f; break; }
            case 41: { qRotY = 43.87f; break; }
            case 42: { qRotY = 80.45f; break; }
            case 43: { qRotY = 0; break; }
            case 44: { qRotY = -3.95f; break; }
        }


        //qRot = new Quaternion(0, MovePlayer.teleportDicePoint.transform.rotation.y, MovePlayer.teleportDicePoint.transform.rotation.z, 1);
        question1.transform.position = MovePlayer.qField.transform.position;
        qRot = Quaternion.Euler(0, qRotY, 0);
        question1.transform.rotation = qRot;
        question1.SetActive(true);
        qShown = true;
    }

}
