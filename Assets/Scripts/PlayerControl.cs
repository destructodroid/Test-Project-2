using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;
    public float Speed;
    public GameObject GameWIn;
    public GameObject PausePanel;
    private bool isGameWon = false;
    private bool isPaused = false;
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
        else if (isPaused == true)
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
        else if (Input.GetAxis("Cancel") > 0)
        {
            isPaused = true;
            PausePanel.SetActive(true);
        }
        else if (Input.GetAxis("Submit") > 0)
        {
            isPaused = false;
            PausePanel.SetActive(false);
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
