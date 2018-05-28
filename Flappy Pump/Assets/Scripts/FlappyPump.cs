using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyPump : MonoBehaviour {

    public float upForce = 200f;
    bool isDead = false;
    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!isDead)
        {
            if(Input.GetMouseButtonDown(0))
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(0, upForce));
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        GameManager.Instance.Died();
    }
}
