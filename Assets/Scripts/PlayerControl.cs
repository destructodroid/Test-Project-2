using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;
    public float Speed;
    public GameObject GameWIn;
    private bool isGameWon = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameWon == true)
        {
            return;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            rigidbody2d.velocity = new Vector2(Speed, 0f);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rigidbody2d.velocity = new Vector2(-Speed, 0f);
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            rigidbody2d.velocity = new Vector2(0f, Speed);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            rigidbody2d.velocity = new Vector2(0f, -Speed);
        }
        else if (Input.GetAxis("Horizontal")==0 && Input.GetAxis("Vertical")==0)
        {
            rigidbody2d.velocity = new Vector2(0f, 0f);
        }
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Door")
        {
            Debug.Log("Level Complete");
            GameWIn.SetActive(true);
            isGameWon = true;
        }
    }
}
