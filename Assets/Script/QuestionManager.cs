using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class QuestionManager : MonoBehaviour {

    public GameObject questions;
    public GameObject q1;
    public GameObject q2;
    public GameObject q3;
    public GameObject q4;
    public GameObject q5;
    public GameObject q6;
    public GameObject q7;
    public GameObject q8;
    public GameObject q9;
    public GameObject q10;

    public Quaternion qRot;
    //public GameObject q;
    public bool qShown;
    public float qRotY;
    public int ranQ;

    AudioSource rightSound;
    AudioSource wrongSound;

    // Use this for initialization
    void Start () {
        //q.GetComponent<GameObject>();
        //question1 = q;
        questions.SetActive(false);
        q1.SetActive(false);
        q2.SetActive(false);
        q3.SetActive(false);
        q4.SetActive(false);
        q5.SetActive(false);
        q6.SetActive(false);
        q7.SetActive(false);
        q8.SetActive(false);
        q9.SetActive(false);
        q10.SetActive(false);
        qShown = false;
        //qRot = new Quaternion();
        AudioSource[] sounds = GetComponents<AudioSource>();
        rightSound = sounds[0];
        wrongSound = sounds[1];
    }
	
	// Update is called once per frame
	void Update () {
        

        if (Input.GetKeyDown(KeyCode.K))
        {
            if(!qShown)
                ShowQuestion();
            else
            {
                questions.SetActive(false);
                qShown = false;
            }

        }

        if (MovePlayer.canShowQuestion)
        {
            ShowQuestion();
            MovePlayer.canShowQuestion = false;
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

        ranQ = Random.Range(1, 11);
        switch (ranQ)
        {
            case 1: { q1.SetActive(true); break; }
            case 2: { q2.SetActive(true); break; }
            case 3: { q3.SetActive(true); break; }
            case 4: { q4.SetActive(true); break; }
            case 5: { q5.SetActive(true); break; }
            case 6: { q6.SetActive(true); break; }
            case 7: { q7.SetActive(true); break; }
            case 8: { q8.SetActive(true); break; }
            case 9: { q9.SetActive(true); break; }
            case 10: { q10.SetActive(true); break; }
        }
        //qRot = new Quaternion(0, MovePlayer.teleportDicePoint.transform.rotation.y, MovePlayer.teleportDicePoint.transform.rotation.z, 1);
        questions.transform.position = MovePlayer.qField.transform.position;
        qRot = Quaternion.Euler(0, qRotY, 0);
        questions.transform.rotation = qRot;
        questions.SetActive(true);
        qShown = true;

        
    }

    public void HideQuestions()
    {
        questions.SetActive(false);
        q1.SetActive(false);
        q2.SetActive(false);
        q3.SetActive(false);
        q4.SetActive(false);
        q5.SetActive(false);
        q6.SetActive(false);
        q7.SetActive(false);
        q8.SetActive(false);
        q9.SetActive(false);
        q10.SetActive(false);
    }

    public void WrongAnswer()
    {
        wrongSound.Play();
    }
    public void RightAnswer()
    {
        rightSound.Play();
    }


}
