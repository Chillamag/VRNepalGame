using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DiceManager : MonoBehaviour {

    public Transform sideCheck_1;
    public Transform sideCheck_2;
    public Transform sideCheck_3;
    public Transform sideCheck_4;
    public Transform sideCheck_5;
    public Transform sideCheck_6;
    public float sideCheckRadius = 0.7f;
    public LayerMask whatIsGround;
    public bool side_1;
    public bool side_2;
    public bool side_3;
    public bool side_4;
    public bool side_5;
    public bool side_6;

    private Rigidbody diceRB;
    public GameObject diceToRoll;
    public float rollStrength;
    public Vector3 diceVector;
    public Vector3 diceTorque;
    public Vector3 rollDir;
    private int vec1;
    private int vec2;
    private int vec3;
    public int numberOfDice;

    public bool readyToRoll;
    public bool playerCanMove;

    public float gazeTime = 2f;
    private float timer;
    private bool gazedAt;
    public GameObject redDice;

    // Use this for initialization
    void Start () {
        diceRB = GetComponent<Rigidbody>();
        readyToRoll = false;
        playerCanMove = false;
        ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerExitHandler);
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (gazedAt)
        {
            timer += Time.deltaTime;
            Vector3 newScale = new Vector3(timer/gazeTime*2, redDice.transform.localScale.y, redDice.transform.localScale.z);
            Vector3 newPos = new Vector3(-1.1f + (timer / gazeTime), redDice.transform.localPosition.y, redDice.transform.localPosition.z);

            redDice.transform.localScale = newScale;
            redDice.transform.localPosition = newPos;

            if (timer >= gazeTime)
            {
                ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                timer = 0f;
                //GetComponent<Collider>().enabled = false;
            }
        }

        side_1 = Physics.CheckSphere(sideCheck_1.position, sideCheckRadius, whatIsGround);
        side_2 = Physics.CheckSphere(sideCheck_2.position, sideCheckRadius, whatIsGround);
        side_3 = Physics.CheckSphere(sideCheck_3.position, sideCheckRadius, whatIsGround);
        side_4 = Physics.CheckSphere(sideCheck_4.position, sideCheckRadius, whatIsGround);
        side_5 = Physics.CheckSphere(sideCheck_5.position, sideCheckRadius, whatIsGround);
        side_6 = Physics.CheckSphere(sideCheck_6.position, sideCheckRadius, whatIsGround);

        if (readyToRoll)
        {
            if (side_1)
            {
                numberOfDice = 1;

            }
            else if (side_2)
            {
                numberOfDice = 2;

            }
            else if (side_3)
            {
                numberOfDice = 3;

            }
            else if (side_4)
            {
                numberOfDice = 4;

            }
            else if (side_5)
            {
                numberOfDice = 5;

            }
            else if (side_6)
            {
                numberOfDice = 6;

            }
            else
            {
                return;
            }
        }

        if (diceRB.IsSleeping() && playerCanMove)
        {
            MovePlayer.diceNumber = numberOfDice;
            MovePlayer.rollDice();
            playerCanMove = false;
            MovePlayer.diceCanTeleport = true;
            //diceToRoll.transform.position = MovePlayer.teleportDicePoint.transform.position;
        }
    }



    public void MoveDice()
    {
        readyToRoll = true;

        vec1 = Random.Range(0, 50);
        vec2 = Random.Range(0, 5);
        vec3 = Random.Range(0, 50);
        diceTorque = new Vector3(vec1, vec2, vec3);

        //rollDir = diceToRoll.transform.position - transform.position;
        //rollDir = rollDir.normalized;
        //MovePlayer.teleportDicePoint.transform.position* rollStrength
        diceRB.AddForce(5,50,5, ForceMode.Impulse);
        diceRB.AddTorque(diceTorque * rollStrength);
        playerCanMove = true;
        //MovePlayer.diceCanTeleport = true;
    }

    public void PointerEnter()
    {
        gazedAt = true;
        redDice.SetActive(true);
    }
    public void PointerExit()
    {
        gazedAt = false;
        timer = 0;
        redDice.SetActive(false);
        redDice.transform.localScale = new Vector3(0.1f, 2.1f, 2.1f);
        redDice.transform.localPosition = new Vector3(-1.1f, 0, 0);
    }


}
