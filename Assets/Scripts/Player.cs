using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    bool isGrounded = false ;
	bool isGameOver = false;
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
	public GameObject[] candys;
	public float knockBack = 1.0f ;
	public GameObject attackMaruRightObj;
	public GameObject attackMaruLeftObj;
	public float maruDispStartTime ;
	public float maruDispTime ;
	public GameObject playerTop;
	Animator animator ;
	GameObject lastCollisionObject ;
	public string scenename;
	bool mutekiFlag = false;
	public float mutekiTime = 7.0f ;
	int AttackDir = 1 ;

	// Use this for initialization
	void Start () {
		if (GlobalParameters.useSceneStartPos) {
			transform.position = new Vector3 (GlobalParameters.sceneStartPos.x, GlobalParameters.sceneStartPos.y, GlobalParameters.sceneStartPos.z);
			GlobalParameters.useSceneStartPos = false;
		}
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

			if (GlobalParameters.heart_num < 5) {
				GlobalParameters.heart_num = GlobalParameters.heart_num + 1;
				harts [GlobalParameters.heart_num - 1].SetActive (true);
			}
		}
		if (collision.gameObject.tag == "Apple") {
			gameObject.GetComponent<AudioSource> ().PlayOneShot (gemSound);
			Destroy (collision.gameObject);
			harts [GlobalParameters.heart_num].SetActive (true);
			GlobalParameters.heart_num = harts.Length;

			for (int i = 0; i < harts.Length; i++) {
				harts [i].SetActive (true);
			}
		}

		if (collision.gameObject.tag == "enemy") {
			if (mutekiFlag == false) {
				gameObject.GetComponent<AudioSource> ().PlayOneShot (damageSound);
				GlobalParameters.heart_num = GlobalParameters.heart_num - 1;
				harts [GlobalParameters.heart_num].SetActive (false);
				Vector3 dist = transform.position - collision.gameObject.transform.position;
				if (isGrounded) {
					dist.y = 0.0f;
				}
				dist.Normalize ();

				transform.position = transform.position + dist * knockBack;

				// game over

				//if (isGameOver)
		
				if (GlobalParameters.heart_num == 0) {
					isGameOver = true;
				}

				if (isGameOver) { 
					SceneNavigator.Instance.Change (scenename, 0.5f);
				}
			}
		}
	

	

		if (collision.gameObject.tag == "CandyTrigger")
		{
			gameObject.GetComponent<AudioSource>().PlayOneShot(gemSound);
			Destroy(collision.gameObject);
			candys [GlobalParameters.candy_num].SetActive(true);
			GlobalParameters.candy_num++;
			StartCoroutine ("Muteki");

		}

	
		

		if (collision.gameObject.tag == "ExitTrigger")
		{
			if (collision.gameObject.name == "warp4") {
				GlobalParameters.useSceneStartPos = collision.gameObject.GetComponent<WarpDestination> ().useDestinationPos;
				GlobalParameters.sceneStartPos = collision.gameObject.GetComponent<WarpDestination> ().warpDestinationPos;
				SceneNavigator.Instance.Change("course1-2", 0.5f);
			} else if (collision.gameObject.name == "warp5") {
				SceneNavigator.Instance.Change("coure1-1bonus_stage", 0.5f);
			} else if (collision.gameObject.name == "warp2") {
				SceneNavigator.Instance.Change("course1-3", 0.5f);
			} else if (collision.gameObject.name == "warp1") {
				SceneNavigator.Instance.Change("course1-2", 0.5f);
			} else if (collision.gameObject.name == "STAR") {
				PlayerPrefs.SetInt ("Stage1Clear", 1);
				SceneNavigator.Instance.Change("course1_Gaul", 0.5f);
			} else if (collision.gameObject.name == "warp7") {
				SceneNavigator.Instance.Change("course2-2", 0.5f);
			} else if (collision.gameObject.name == "warp6") {
				SceneNavigator.Instance.Change("course2-1bonus_stage", 0.5f);
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
		AttackDir = -1;
	}

	public void RightPushed(){
		gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right * moveSpeed;
		GetComponent<Animator>().SetInteger("Direction", 1);
		lastMoveTime = Time.time;

		gameObject.transform.localScale = new Vector3 (xSxale, gameObject.transform.localScale.y, gameObject.transform.localScale.z);

		Debug.Log (gameObject.GetComponent<Rigidbody2D> ().velocity);
		AttackDir = 1;
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

		if (AttackDir == 1) {
			attackMaruRightObj.SetActive (true);
		}else if ( AttackDir == -1 ){
			attackMaruLeftObj.SetActive (true);
		}

		// 2秒待つ  
		yield return new WaitForSeconds (maruDispTime);  

		attackMaruRightObj.SetActive(false);
		attackMaruLeftObj.SetActive(false);

		// ログ出力  
		Debug.Log ("3");  
	}  

	private IEnumerator Muteki() {  
		// ログ出力  
		Debug.Log ("1");  


		mutekiFlag = true;
		// 1秒待つ  
		yield return new WaitForSeconds (mutekiTime);  

		mutekiFlag = false;

		// ログ出力  
		Debug.Log ("3");  
	}  

}






			

    

