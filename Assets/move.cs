using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class move : MonoBehaviour {

    Rigidbody rb;
    public Text countText;
	public Text winText;
	public Text time;
    public float speed;
    int count;
	DateTime curr;
	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();
        count = 0;
        countText.text = "分數:";
		winText.text = "";
		curr = DateTime.Now;
		time.text = "45";
	}

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
        //transform.Translate(x, 0 ,z);
        rb.AddForce(new Vector3(x, 0, z)*speed);
        TimeSpan ts = DateTime.Now - curr;
        if (winText.text != "You Win!") { 
        if (ts.Seconds < 45)
        {
            time.text = (44 - ts.Seconds).ToString() + ":" + (1000 - ts.Milliseconds).ToString();

        }
        else
        {
            time.text = "0";
            winText.text = "You lose!";
        }
        }
	}
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("pick"))
        other.gameObject.SetActive(false);
        count++;
        countText.text = "分數:"+count.ToString();

		if (count == 7 && winText.text !="You lose!") {
			winText.text="You Win!";
            
		}
    }
}
