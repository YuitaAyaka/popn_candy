using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    bool isGrounded = false ;
    public float jumpPower;
    public float moveSpeed;
    public AudioClip gemSound;
    public AudioClip jumpSound;
	Vector2 jumpForce;
	private Vector3 lastPosition;
	float lastMoveTime;
	public float speed;
	float xSxale;
	private List<string> items;
	public GameObject[] harts;
	public int life = 5 ;
	public float knockBack = 1.0f ;


	// Use this for initialization
	void Start () {
        jumpForce = new Vector2(0.0f, jumpPower);
		lastPosition = transform.position;
		items = new List<string>();
		xSxale = gameObject.transform.localScale.x;
	}

	// Update is called once per frame

	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if ( isGrounded)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(jumpForce);
                gameObject.GetComponent<AudioSource>().PlayOneShot(jumpSound);
				GetComponent<Animator>().SetInteger("Direction", 3);
                isGrounded = false;
            }
        }

		if (Input.GetKeyDown (KeyCode.LeftArrow))
		{
			gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right * (-1.0f * speed);
			GetComponent<Animator>().SetInteger("Direction", 1);
			lastMoveTime = Time.time;
			}
			
		if (Input.GetKeyDown (KeyCode.LeftArrow))
		{
			gameObject.transform.localScale = new Vector3 (xSxale * -1.0f, gameObject.transform.localScale.y, gameObject.transform.localScale.z);	
		}



	    if (Input.GetKeyDown (KeyCode.RightArrow))
		{
			gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
			GetComponent<Animator>().SetInteger("Direction", 1);
			lastMoveTime = Time.time;

		}

		if (Input.GetKeyDown (KeyCode.RightArrow))
		{
			gameObject.transform.localScale = new Vector3 (xSxale, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
		}


		if (Input.GetKeyDown (KeyCode.DownArrow))
		{
			GetComponent<Animator>().SetInteger("Direction", 4);


		}

		if (Input.GetKeyUp (KeyCode.LeftArrow))
		{
			GetComponent<Animator>().SetInteger("Direction", 0);
			gameObject.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;

		}


		if (Input.GetKeyUp (KeyCode.RightArrow))
		{
			GetComponent<Animator>().SetInteger("Direction", 0);
			gameObject.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		}

		if (Input.GetKeyUp (KeyCode.UpArrow))
		{
			GetComponent<Animator>().SetInteger("Direction", 0);
			gameObject.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		}

		if (Input.GetKeyUp (KeyCode.DownArrow))
		{
			GetComponent<Animator>().SetInteger("Direction", 0);
			gameObject.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		}


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right * -1.0f * moveSpeed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right * moveSpeed;
        }

        // test sound play
        if (Input.GetKeyDown(KeyCode.A))
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(gemSound);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        if (collision.gameObject.tag == "Gem")
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(gemSound);
            Destroy(collision.gameObject);
        }
		if (collision.gameObject.tag == "enemy")
		{
			gameObject.GetComponent<AudioSource>().PlayOneShot(gemSound);
			life = life - 1;
			harts [life].SetActive (false);
			Vector3 dist = transform.position - collision.gameObject.transform.position;
			if (isGrounded) {
				dist.y = 0.0f;
			}
			dist.Normalize ();

			transform.position = transform.position + dist * knockBack;

			// game over
		}


		if (collision.gameObject.tag == "ExitTrigger")
		{
			if (collision.gameObject.name == "warp_star1kari") {
				SceneNavigator.Instance.Change("course1-2", 0.5f);
			} else if (collision.gameObject.name == "warp_star1kari1") {
				SceneNavigator.Instance.Change("coure1-1bonus_stage", 0.5f);
			} else if (collision.gameObject.name == "warp_star1kari2") {
				SceneNavigator.Instance.Change("course1-3", 0.5f);
			} else if (collision.gameObject.name == "warp_star1kari4") {
				SceneNavigator.Instance.Change("course1-2", 0.5f);
			}



			//gameObject.GetComponent<AudioSource>().PlayOneShot(gemSound);
			//Destroy(collision.gameObject);
		}

		lastPosition = transform.position;
	}

	public void OnClick() { // 必ず public にする
		//Debug.Log ("clicked");
		GetComponent<Animator>().SetInteger("Direction", 4);
		gameObject.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
	}
	public void OffClick() { 

	GetComponent<Animator>().SetInteger("Direction", 0);
		gameObject.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
	}






			}






			

    

