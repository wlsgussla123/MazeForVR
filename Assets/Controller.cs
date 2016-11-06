using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
    private bool isWalking = false;
    private Vector3 spawnPoint;

	// Use this for initialization
	void Start () {
         spawnPoint = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	    if(isWalking)
        {
            transform.position = transform.position + Camera.main.transform.forward * .5f * Time.deltaTime;          
        }

        // 미로 밖을 탈출하면 다시 스폰 포인트에서 시작.
        if(transform.position.y < -10f)
        {
            transform.position = spawnPoint;
        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.name.Contains("plane"))
            {
                isWalking = false;
            }
            else
            {
                isWalking = true;
            }
        }
    }
}
