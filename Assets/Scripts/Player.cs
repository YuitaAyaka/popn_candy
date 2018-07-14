using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    bool isGrounded = false ;
	bool isGameOver = false ;

    public float jumpPower;
    public float moveSpeed;
    public AudioClip gemSound;
	public AudioClip damageSound;
    public AudioClip jumpSound;
	Vector2 jumpForce;
	private Vector3 lastPosition;
	float lastMoveTime;
	float xSxale;
	private List<string> items;
	public GameObject[] harts;
	public int life = 5 ;
	public float knockBack = 1.0f ;
	public GameObject attackMaruObj;
	public float maruDispStartTime ;
	public float maruDispTime ;
	public GameObject playerTop;
	Animator animator ;
	GameObject lastCollisionObject ;
	public string scenename;

	// Use this for initialization
	void Start () {
        jumpForce = new Vector2(0.0f, jumpPower);
		lastPosition = transform.position;
		items = new List<string>();
		xSxale = gameObject.transform.localScale.x;
		animator = this.GetComponent<Animator> ();
	}

	// Update is called once per frame

	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
			UpPushed ();
        }

		if (Input.GetKeyDown (KeyCode.LeftArrow))
		{
			LeftPushed ();
		}


	    if (Input.GetKeyDown (KeyCode.RightArrow))
		{

			RightPushed ();
		}


		if (Input.GetKeyDown (KeyCode.DownArrow))
		{
			//GetComponent<Animator>().SetInteger("Direction", 4);
			DownPushed ();

		}

		if (Input.GetKeyUp (KeyCode.LeftArrow))
		{
			Released ();
		}

		if (Input.GetKeyUp (KeyCode.RightArrow))
		{
			Released ();
		}

		if (Input.GetKeyUp (KeyCode.UpArrow))
		{
			Released ();
		}

		if (Input.GetKeyUp (KeyCode.DownArrow))
		{
			Released ();
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

		playerTop.transform.position = new Vector3 (transform.position.x,transform.position.y,transform.position.z);
    }

	void dispItem(GameObject triggerObjct)
	{
		GameObject go = triggerObjct.GetComponent<ItemStart>().ItemObject;
		if ( go == null)
		{
			return;
		}

		if ( go.activeSelf)
		{
			return;
		}

	}

    private void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.gameObject.tag == "Ground") {
			isGrounded = true;
		}
		if (collision.gameObject.tag == "Gem") {
			gameObject.GetComponent<AudioSource> ().PlayOneShot (gemSound);
			Destroy (collision.gameObject);
			life = life + 1;
			harts [life - 1].SetActive (true);
		}
		if (collision.gameObject.tag == "Apple") {
			gameObject.GetComponent<AudioSource> ().PlayOneShot (gemSound);
			Destroy (collision.gameObject);
			harts [life].SetActive (true);
			life = harts.Length;

			for (int i = 0; i < harts.Length; i++) {
				harts [i].SetActive (true);
			}
		}
		if (collision.gameObject.tag == "enemy") {
			gameObject.GetComponent<AudioSource> ().PlayOneShot (damageSound);
			life = life - 1;
			harts [life].SetActive (false);
			Vector3 dist = transform.position - collision.gameObject.transform.position;
			if (isGrounded) {
				dist.y = 0.0f;
			}
			dist.Normalize ();

			transform.position = transform.position + dist * knockBack;

			// game over


			for (int i = 0; i > harts.Length;) {
			 harts [i].SetActive (false);
			}
			    //life = 0;

			
			if (isGameOver){
				
		} else {
				
			SceneNavigator.Instance.Change (scenename, 0.5f);
		}
	

		if (collision.gameObject.tag == "CandyTrigger")
		{
			gameObject.GetComponent<AudioSource>().PlayOneShot(gemSound);
			Destroy(collision.gameObject);
			//dispItem(GetComponent<Collider>().gameObject);
			//lastCollisionObject = GetComponent<Collider>().gameObject;
			//if (collider.gameObject.name == "Candy_1") {
				//ItemManager.GetItem("Candy1_red");
			//}
			if (collision.gameObject.name == "Candy_1") {
				ItemManager.GetItem("Candy1_red");
				//Debug.Log ("わーい");
			}

		}

			}




		

		if (collision.gameObject.tag == "ExitTrigger")
		{
			if (collision.gameObject.name == "warp4") {
				SceneNavigator.Instance.Change("course1-2", 0.5f);
			} else if (collision.gameObject.name == "warp5") {
				SceneNavigator.Instance.Change("coure1-1bonus_stage", 0.5f);
			} else if (collision.gameObject.name == "warp2") {
				SceneNavigator.Instance.Change("course1-3", 0.5f);
			} else if (collision.gameObject.name == "warp1") {
				SceneNavigator.Instance.Change("course1-2", 0.5f);
			} else if (collision.gameObject.name == "STAR") {
				SceneNavigator.Instance.Change("course1_Gaul", 0.5f);
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


	public void LeftPushed(){
		gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right * (-1.0f * moveSpeed);
		GetComponent<Animator>().SetInteger("Direction", 1);
		lastMoveTime = Time.time;

		gameObject.transform.localScale = new Vector3 (xSxale * -1.0f, gameObject.transform.localScale.y, gameObject.transform.localScale.z);	
	}

	public void RightPushed(){
		gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right * moveSpeed;
		GetComponent<Animator>().SetInteger("Direction", 1);
		lastMoveTime = Time.time;

		gameObject.transform.localScale = new Vector3 (xSxale, gameObject.transform.localScale.y, gameObject.transform.localScale.z);

		Debug.Log (gameObject.GetComponent<Rigidbody2D> ().velocity);
	}

	public void UpPushed(){
		if ( isGrounded)
		{
			gameObject.GetComponent<Rigidbody2D>().AddForce(jumpForce);
			gameObject.GetComponent<AudioSource>().PlayOneShot(jumpSound);
			animator.SetTrigger ("jump"); 
			gameObject.GetComponent<Animator>().SetInteger("Direction", 3);
			//animator.SetInteger("Direction", 3);
			isGrounded = false;
			}
	}

	public void CallAttack(){
		StartCoroutine ("AttackMaru"); 
	}

	public void DownPushed(){
		animator.SetTrigger ("attack"); 
		CallAttack ();
	}

	public void Released(){
		GetComponent<Animator>().SetInteger("Direction", 0);
		gameObject.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
	}

	private IEnumerator AttackMaru() {  
		// ログ出力  
		Debug.Log ("1");  

		// 1秒待つ  
		yield return new WaitForSeconds (maruDispStartTime);  

		// ログ出力  
		Debug.Log ("2");
		attackMaruObj.SetActive(true);

		// 2秒待つ  
		yield return new WaitForSeconds (maruDispTime);  

		attackMaruObj.SetActive(false);

		// ログ出力  
		Debug.Log ("3");  
	}  

}






			

    

