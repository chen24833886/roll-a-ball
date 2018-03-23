using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class move : MonoBehaviour {

    Rigidbody rb;
    public Text countText;
    public float speed;
    int count;
	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();
        count = 0;
        countText.text = "分數:";

	}
	
	// Update is called once per frame
	void Update () {
        var x = Input.GetAxis("Horizontal");
        var z=Input.GetAxis("Vertical");
        //transform.Translate(x, 0 ,z);
        rb.AddForce(new Vector3(x,0,z));
	}
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("pick"))
        other.gameObject.SetActive(false);
        count++;
        countText.text = "分數:"+count.ToString();
    }
}
