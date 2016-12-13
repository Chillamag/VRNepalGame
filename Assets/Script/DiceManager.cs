using UnityEngine;
using System.Collections;

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

    // Use this for initialization
    void Start () {
        diceRB = GetComponent<Rigidbody>();
        readyToRoll = false;
        playerCanMove = false;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

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

}
