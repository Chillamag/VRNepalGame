using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	//public Text countText;
	//public Text winText;
	//public Image winScreen;
	//public GameObject restartCanvas;
	//public GameObject mainCanvas;
	//public GameObject pickUp;
    public GameObject mainCam;
    public GameObject topCam;
    public GameObject faces;
    public GameObject faceCanvas;
    public GameObject gameCanvas;

    private bool isTopCam;

    //public GameObject pickUpToSpawn;
	private float minZ=-8, minX=-8; 
	private float maxZ=8, maxX=8; 
	private float minY=10, maxY=10;

	private Rigidbody rb;
	private int count;

	void Start(){
		rb = GetComponent<Rigidbody> ();
		count = 0;
		//SetCountText ();
		//winText.text = "YOU WIN!";
		//winScreen.gameObject.SetActive (false);
		//restartCanvas.gameObject.SetActive (false);


		Time.timeScale = 1f;
        //mainCam.gameObject.SetActive(true);
        //topCam.gameObject.SetActive(false);
        //faces.gameObject.SetActive(false);
        //faceCanvas.gameObject.SetActive(true);


        //isTopCam = false;
        //Cursor.visible = false;
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    ShiftCam();
        //}

        if (Input.GetKeyDown(KeyCode.Mouse1) && !MovePlayer.isMenu)
        {
            //ShiftCam();
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && !MovePlayer.isMenu)
        {
            //MovePlayer.rollDice();
        }
    }

    void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
        //bool shiftCam = Input.GetKey("K");
        //float playerRotation = Input.GetAxis("Horizontal");
        float rotateSpeed = 180.0f;

        Vector3 movement = new Vector3 (
            moveHorizontal
            //0.0f
            ,0.0f,moveVertical);

		rb.AddForce (movement * speed);

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(-Vector3.up * rotateSpeed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        
    }

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag("Pick Up")){
			other.gameObject.SetActive(false);
			//GameObject pickup = (GameObject)Instantiate(pickUp,other.gameObject.transform.position,Quaternion.identity);
			//Destroy (pickup, 1.0f);
			count = count +1;
			SetCountText ();



			//Instantiate (pickUpToSpawn, new Vector3 (Random.Range (minX, maxX), Random.Range (minY, maxY), Random.Range (minZ, maxZ)), Quaternion.Euler(new Vector3(270, 0, 0)));
			//pickUpToSpawn.transform.Rotate(new Vector3(-90,0,0));

			if(count >= 100){
				//restartCanvas.gameObject.SetActive (true);
				Time.timeScale = 0f;

			}
		}
	}
	void SetCountText(){
		//countText.text = "Count: " + count.ToString ();
	}

    public void Exit() {
        Application.Quit();
    }

    public void ShiftCam(){

        if (isTopCam)
        {
            mainCam.gameObject.SetActive(false);
            topCam.gameObject.SetActive(true);
            faces.gameObject.SetActive(true);
            faceCanvas.gameObject.SetActive(false);
            isTopCam = false;
        }
        else if (!isTopCam)
        {
            mainCam.gameObject.SetActive(true);
            topCam.gameObject.SetActive(false);
            faces.gameObject.SetActive(false);
            faceCanvas.gameObject.SetActive(true);
            isTopCam = true;
        }
    }

    void SetWinScreen(){
		//winText.text = "YOU WIN!";
		//winScreen.gameObject.SetActive (true);

	}

}
