using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//using Linq;


public class MovePlayer : MonoBehaviour {

    //public bool moveRight;
    public float moveSpeed;

    public static Transform nextDicePoint;
    public static GameObject teleportDicePoint;
    public static GameObject nextField;
    public static GameObject qField;
    public Transform currentPoint;
    public Transform menuPoint;
    public Transform startPoint;
    public static int nextPoint;
    public static Text diceText;

    public GameObject[] _fields;

    public Transform[] points;

    public int pointSelection;

    private Rigidbody myRigidbody;

    public float damping;

    public GameObject diceToRoll;
    public static int diceNumber;
    public static int turnStart;
    public static int turnEnd;
    public int fieldNumber;
    public static bool diceCanTeleport;
    public static bool canShowQuestion;

    public static GameObject diceCube;
    private static Quaternion diceRot1 = new Quaternion(-90, 180, -90, 1);
    private static Quaternion diceRot2 = new Quaternion(0, 0, 0, 1);
    private static Quaternion diceRot3 = new Quaternion(0, -90, 0, 1);
    private static Quaternion diceRot4 = new Quaternion(0, 90, 0, 1);
    private static Quaternion diceRot5 = new Quaternion(0, -180, 0, 1);
    private static Quaternion diceRot6 = new Quaternion(-90, 0, -90, 1);

    public static bool isMenu;

    void Start()
    {
        teleportDicePoint = new GameObject();
        nextField = new GameObject();
        qField = new GameObject();
        //GameStart();
        //diceText = GetComponent<Text>();
        //diceText.text = "Terning: ";
        myRigidbody = GetComponent<Rigidbody>();
        _fields = new GameObject[44];
        for (int i = 0; i < _fields.Length; i++)
        {
            _fields = GameObject.FindGameObjectsWithTag("Fields");
        }
        //_fields = _fields.OrderBy(Field => Field.Name).ToList();
        canShowQuestion = false;
    }

    public void GameStart()
    {
        if (isMenu)
        {
            //Yo
        }else
        {
            currentPoint = points[pointSelection];
            myRigidbody = GetComponent<Rigidbody>();
            turnEnd = 0;
            turnStart = 0;
            fieldNumber = 0;
            diceCube = GameObject.Find("theDice");
        }

    }

    public static void rollDice() {
        //diceNumber = Random.Range(1,7);
        //diceNumber = 3;
        turnEnd = turnStart + diceNumber;
        //Debug.Log("Dice = " + diceNumber);
        //diceText.text = "Terning: " + diceNumber.ToString();
        

        //switch (diceNumber) {
        //    case 1:
                
        //        diceCube.gameObject.transform.localRotation = diceRot1;
        //        break;
        //    case 2:
                
        //        diceCube.gameObject.transform.localRotation = diceRot2;
        //        break;
        //    case 3:
                
        //        diceCube.gameObject.transform.localRotation = diceRot3;
        //        break;
        //    case 4:
                
        //        diceCube.gameObject.transform.localRotation = diceRot4;
        //        break;
        //    case 5:
                
        //        diceCube.gameObject.transform.localRotation = diceRot5;
        //        break;
        //    case 6:
                
        //        diceCube.gameObject.transform.localRotation = diceRot6;
        //        break;
        //}


    }

    //Burde ikke være i update men en selvstændig metode
    void LateUpdate()
    {

        if (isMenu)
        {
            transform.position = Vector3.MoveTowards(transform.position, menuPoint.position, Time.deltaTime * moveSpeed);
        }else
        {
            transform.position = Vector3.MoveTowards(transform.position, currentPoint.position, Time.deltaTime * moveSpeed);
            Quaternion pRotation = Quaternion.LookRotation(points[pointSelection].position - transform.position);
            Quaternion pRotation2 = Quaternion.LookRotation(points[pointSelection + 1].position - transform.position);

            transform.rotation = Quaternion.Slerp(transform.rotation, pRotation2, Time.deltaTime * damping);

            nextDicePoint = points[pointSelection+1];
            //teleportDicePoint = points[pointSelection+1];
        }
        

        if (transform.position == currentPoint.position && fieldNumber < turnEnd){
            //transform.rotation = Quaternion.Slerp(transform.rotation, pRotation, Time.deltaTime * damping);
            pointSelection++;
            fieldNumber++;


            if (pointSelection >= points.Length) { //-1

                pointSelection = points.Length;
                //YOUWON!!
            }
            currentPoint = points[pointSelection];
            
            //nextPoint = points[4];

        }
        else if (fieldNumber == turnEnd){
            turnStart = turnEnd;
            //teleportDicePoint = points[fieldNumber+1];
            teleportDicePoint.transform.position = Vector3.Lerp(points[fieldNumber].transform.position, points[fieldNumber + 1].transform.position, 0.5f);

            nextField.transform.position = points[fieldNumber +1].transform.position;
            nextPoint = fieldNumber+1;
            qField.transform.position = Vector3.Lerp(points[fieldNumber].transform.position, points[fieldNumber + 1].transform.position, 0.25f);

            qField.transform.rotation = points[fieldNumber + 1].transform.rotation;
            nextField.transform.rotation = points[fieldNumber + 1].transform.rotation;
            //diceToRoll.transform.position = teleportDicePoint.transform.position;
            if (diceCanTeleport)
            {
                diceToRoll.transform.position = teleportDicePoint.transform.position;
                diceCanTeleport = false;
                canShowQuestion = true;
                //QuestionManager.ShowQuestion();

            }
            //transform.rotation = Quaternion.Slerp(transform.rotation, pRotation2, Time.deltaTime);
        }

/*            if (transform.position == currentPoint.position){
            
            pointSelection--;

            if (pointSelection == 0){
            }
            currentPoint = points[pointSelection];
            }*/
    }
}
