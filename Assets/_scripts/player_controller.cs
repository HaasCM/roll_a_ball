using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_controller : MonoBehaviour {
    public float speed;
    public Text countText;
    public Text winText;
    private int count = 0;
    private Rigidbody body;

    void Start() {
        body = GetComponent<Rigidbody>();
        setCountText();
    }

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 vec = new Vector3(moveHorizontal, 0.0f, moveVertical);

        body.AddForce(vec * speed);
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Pick Up")) {
            count++;
            other.gameObject.SetActive(false);
            setCountText();
        }
    }

    void setCountText() {
        countText.text = "Count: " + count.ToString();
        if(count >= 8) {
            winText.text = "You Win!";
        }
    }
}