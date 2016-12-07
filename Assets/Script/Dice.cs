using UnityEngine;
using System.Collections;

public class Dice : MonoBehaviour {

    public GameObject dice;
    public float num = 5.0f;

	// Use this for initialization
	void Start () {
        dice.gameObject.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        dice.gameObject.SetActive(false);
        Debug.Log("Yo");
        if (dice)
        {
            dice.gameObject.SetActive(false);
        }
    }
}
