using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	public GameObject player;
	
	private Vector3 offset;
    private Vector3 nummer1;

    void Start (){
		offset = transform.position - player.transform.position;
        //nummer1 = player.transform.position.y;

    }
	
	void LateUpdate (){
        //transform.position = player.transform.position + offset;
        //transform.position = new Vector3(3,3,3);
        //transform.rotation = player.transform.rotation;
	}
}