using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    bool isGrounded = false ;
	public bool isGameOver = false;
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
    public GameObject attackMaruYamadaRightObj;
    public GameObject attackMaruYamadaLeftObj;
    public GameObject angelObject;
	public float angelTime;
	public float maruDispStartTime ;
	public float maruDispTime ;
    public float surinukeTime = 3.0f;
    public GameObject playerTop;
    public GameObject playerTopYamada;
	Animator animator ;
    GameObject lastCollisionObject ;
	public string scenename;
	public bool mutekiFlag = false;
	public float mutekiTime = 7.0f ;
	int AttackDir = 1 ;
    public Color surinukeColor;
    public Color startMutekiColor;
    public float rainbowTime;
    public float longPushTime = 2.0f;
    public float spinMutekiTime = 3.0f;
    float longPushKeika;
    bool longPushOn;
    bool spinCalled;
    public GameObject marbleObject;
    public GameObject marbleObject1;
    bool flying = false;
    public float flyTime = 2.0f ;
    public GameObject RainboweffectObj;
    public RuntimeAnimatorController yamadaAnim;
    bool yamadaMode = false;


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
		if (isGameOver) {
			gameObject.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		}else{
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				UpPushed ();
			}

			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				LeftPushed ();
			}


			if (Input.GetKeyDown (KeyCode.RightArrow)) {

				RightPushed ();
			}


			if (Input.GetKeyDown (KeyCode.DownArrow)) {
				//GetComponent<Animator>().SetInteger("Direction", 4);
				DownPushed ();

			}

            if (Input.GetKeyDown(KeyCode.A))
            {
                if(spinCalled)
                {
                    APushed();
                }
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                if (spinCalled)
                {
                    DPushed();
                }
            }

            if (Input.GetKeyUp (KeyCode.LeftArrow)) {
				Released ();
			}

			if (Input.GetKeyUp (KeyCode.RightArrow)) {
				Released ();
			}

			if (Input.GetKeyUp (KeyCode.UpArrow)) {
				Released ();
			}

			if (Input.GetKeyUp (KeyCode.DownArrow)) {
				Released ();
			}


			if (Input.GetKey (KeyCode.LeftArrow)) {
				gameObject.GetComponent<Rigidbody2D> ().velocity = Vector2.right * -1.0f * moveSpeed;
			}
			if (Input.GetKey (KeyCode.RightArrow)) {
				gameObject.GetComponent<Rigidbody2D> ().velocity = Vector2.right * moveSpeed;
			}
		}

        if ( flying){
            if ( AttackDir == -1 ){
                gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.left * 1.5f * moveSpeed;
            }else if (AttackDir == 1){
                gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right *1.5f * moveSpeed;
            }
        }


		playerTop.transform.position = new Vector3 (transform.position.x,transform.position.y,transform.position.z);
        if (playerTopYamada != null)
        {
            playerTopYamada.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }

        if ( mutekiFlag){
            // 色を変える
            float h;
            float s;
            float v;
            Color.RGBToHSV(gameObject.GetComponent<SpriteRenderer>().color, out h, out s, out v);

            h += Time.deltaTime * rainbowTime;
            if ( h > 1.0f ){
                h = 0.0f;
            }
            gameObject.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(h, s, v);
           
        }
        if( longPushOn){
            longPushKeika += Time.deltaTime;
            if ( longPushKeika > longPushTime){
                longPushOn = false;

                if (spinCalled == false)
                {
                    animator.SetTrigger("spin");
                    spinCalled = true;
                    StartCoroutine("spinMuteki");
                }
            }
        }
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
        if (collision.gameObject.tag == "marble")
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(gemSound);
            Destroy(collision.gameObject);
            GlobalParameters.marble_num += 1;
            //marbleObject.GetComponent<Text>().text = GlobalParameters.marble_num.ToString();
            //marbleObject1.GetComponent<Text>().text = GlobalParameters.marble_num.ToString();

            //Debug.Log(GlobalParameters.marble_num);
        }


        if (collision.gameObject.tag == "Apple") {
			gameObject.GetComponent<AudioSource> ().PlayOneShot (gemSound);
			Destroy (collision.gameObject);

			Debug.Log (GlobalParameters.heart_num);
			if (GlobalParameters.heart_num < 5) {
				
				harts [GlobalParameters.heart_num].SetActive (true);
				GlobalParameters.heart_num = harts.Length;

				for (int i = 0; i < harts.Length; i++) {
					harts [i].SetActive (true);
				}
			}
		}

	

		if (collision.gameObject.tag == "enemy") {
			if (mutekiFlag == false) {
				gameObject.GetComponent<AudioSource> ().PlayOneShot (damageSound);
				GlobalParameters.heart_num = GlobalParameters.heart_num - 1;
				if (GlobalParameters.heart_num >= 0) {
					harts [GlobalParameters.heart_num].SetActive (false);
				}
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

					// ここで天使を出す
					//SceneNavigator.Instance.Change (scenename, 0.5f);
					StartCoroutine ("ShowAngelAndGameOver");
				}

                // コルーチンを呼ぶ
                StartCoroutine("Surinuke");

            }
		}



        if (collision.gameObject.tag == "yamada")
        { 
        
        }


            if (collision.gameObject.tag == "boss")
        {
            if (mutekiFlag == false)
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(damageSound);
                GlobalParameters.heart_num = GlobalParameters.heart_num - 1;
                if (GlobalParameters.heart_num >= 0)
                {
                    harts[GlobalParameters.heart_num].SetActive(false);
                }
                Vector3 dist = transform.position - collision.gameObject.transform.position;
                if (isGrounded)
                {
                    dist.y = 0.0f;
                }
                dist.Normalize();

                transform.position = transform.position + dist * knockBack;

                // game over

                //if (isGameOver)

                if (GlobalParameters.heart_num == 0)
                {
                    isGameOver = true;
                }

                if (isGameOver)
                {

                    // ここで天使を出す
                    //SceneNavigator.Instance.Change (scenename, 0.5f);
                    StartCoroutine("ShowAngelAndGameOver");
                }

                // コルーチンを呼ぶ
                StartCoroutine("Surinuke");

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
			} else if (collision.gameObject.name == "warp_tutorial") {
				SceneNavigator.Instance.Change("tutorial2", 0.5f);
			} else if (collision.gameObject.name == "warp9") {
				GlobalParameters.useSceneStartPos = collision.gameObject.GetComponent<WarpDestination> ().useDestinationPos;
				GlobalParameters.sceneStartPos = collision.gameObject.GetComponent<WarpDestination> ().warpDestinationPos;
				SceneNavigator.Instance.Change("course2-2", 0.5f);
			} else if (collision.gameObject.name == "warp10") {
				SceneNavigator.Instance.Change("course2-3", 0.5f);
			} else if (collision.gameObject.name == "warp11") {
				SceneNavigator.Instance.Change("course3-2", 0.5f);
			} else if (collision.gameObject.name == "warp11") {
				SceneNavigator.Instance.Change("course3-2", 0.5f);
			} else if (collision.gameObject.name == "warp20") {
				SceneNavigator.Instance.Change("bosutonokaiwa", 0.5f);
			} else if (collision.gameObject.name == "STAR2") {
				SceneNavigator.Instance.Change("course2_Gaul", 0.5f);
			} else if (collision.gameObject.name == "STAR3") {
				SceneNavigator.Instance.Change("course3_Gaul", 0.5f);

			} else if (collision.gameObject.name == "warp6") {
				SceneNavigator.Instance.Change("course2-1bonus_stage", 0.5f);
			} else if (collision.gameObject.name == "warp12") {
				SceneNavigator.Instance.Change("course3-3", 0.5f);
			}

			//gameObject.GetComponent<AudioSource>().PlayOneShot(gemSound);
			//Destroy(collision.gameObject);
		}
		if (collision.gameObject.tag == "death") {

			//ここでも天使を出す
			//SceneNavigator.Instance.Change (scenename, 0.5f);
			StartCoroutine ("ShowAngelAndGameOver");
		}


		if (collision.gameObject.tag == "tutorial_enemy")
		{
			// Fungusを呼ぶ
			collision.gameObject.GetComponent<Talk>().startTalk();
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

        // スイングの時は
        // APushed()
        // 普通の時は、これ
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

    public void APushed(){
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right * (-1.5f * moveSpeed);
        GetComponent<Animator>().SetTrigger("fly");
        lastMoveTime = Time.time;

        gameObject.transform.localScale = new Vector3(xSxale * -1.0f, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        AttackDir = -1;
        StartCoroutine("flyTimer");

    }

    public void DPushed()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right * moveSpeed *1.5f ;
        GetComponent<Animator>().SetTrigger("fly");
        lastMoveTime = Time.time;

        gameObject.transform.localScale = new Vector3(xSxale, gameObject.transform.localScale.y, gameObject.transform.localScale.z);

        //Debug.Log(gameObject.GetComponent<Rigidbody2D>().velocity);
        AttackDir = 1;
        StartCoroutine("flyTimer");
    }

    private IEnumerator flyTimer()
    {
        flying = true;
        yield return new WaitForSeconds(flyTime);
        flying = false;
    }




    public void CallAttack(){
        Debug.Log(spinCalled);
        if (spinCalled)
        {
            Debug.Log("AAAAAA");
            spinCalled = false;
        }else
        {
            Debug.Log("BBBBBBBB");
            animator.SetTrigger("attack");
            StartCoroutine("AttackMaru");
        }

        if(SceneManager.GetActiveScene().name == "course3_battle_last")
        {

            GameObject boss = GameObject.Find("DX24");
            GameObject effect = Instantiate(RainboweffectObj, gameObject.transform.position, Quaternion.identity);
            gameObject.layer = LayerMask.NameToLayer("rainbow_effect");
            if ( boss != null){
                if ( boss.transform.position.x < gameObject.transform.position.x){
                    effect.GetComponent<RainbowEffect>().dir = Vector2.left;
                }else{
                    effect.GetComponent<RainbowEffect>().dir = Vector2.right;
                }
            }
        }

    }

    public void DownPushed(){
        CallAttack();
	}

	public void Released(){
		GetComponent<Animator>().SetInteger("Direction", 0);
		gameObject.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
	}

	private IEnumerator AttackMaru() {  
		// ログ出力  
		//Debug.Log ("1");  

		// 1秒待つ  
		yield return new WaitForSeconds (maruDispStartTime);  

		// ログ出力  
		//Debug.Log ("2");

        if ( yamadaMode){
            if (AttackDir == 1)
            {
                if (attackMaruYamadaRightObj != null)
                {
                    attackMaruYamadaRightObj.SetActive(true);
                }

            }
            else if (AttackDir == -1)
            {
                if (attackMaruYamadaLeftObj != null)
                {
                    attackMaruYamadaLeftObj.SetActive(true);
                }
            }

        }else{
            if (AttackDir == 1)
            {
                attackMaruRightObj.SetActive(true);

            }
            else if (AttackDir == -1)
            {
                attackMaruLeftObj.SetActive(true);
            }
        }


		// 2秒待つ  
		yield return new WaitForSeconds (maruDispTime);  

		attackMaruRightObj.SetActive(false);

        if (attackMaruYamadaRightObj != null)
        {
            attackMaruYamadaRightObj.SetActive(false);
        }
        attackMaruLeftObj.SetActive(false);
        if (attackMaruYamadaLeftObj != null){

            attackMaruYamadaLeftObj.SetActive(false); 
        }

        // ログ出力  
        //Debug.Log ("3");  
    }  


	private IEnumerator Muteki() {

            AudioSource mutekiAudioSource = gameObject.GetComponents<AudioSource>()[1];
        mutekiAudioSource.Play();
		mutekiFlag = true;

        gameObject.GetComponent<SpriteRenderer>().color = startMutekiColor;

        yield return new WaitForSeconds (mutekiTime);
        mutekiAudioSource.Stop();
        mutekiFlag = false;
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;

    }

    private IEnumerator spinMuteki(){
        mutekiFlag = true;
        yield return new WaitForSeconds(spinMutekiTime);
        mutekiFlag = false;

    }

    // 天使のコメントを入れた所で StartCroutine( "ShowAngelAndGameOver" );
    // StartCoroutine ("ShowAngelAndGameOver");
    private IEnumerator ShowAngelAndGameOver() {  
		// 天使のgameObjectに自分の場所をセット
		angelObject.transform.position = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,gameObject.transform.position.z);
		gameObject.GetComponent<SpriteRenderer>().enabled = false ;
		gameObject.GetComponent<PolygonCollider2D>().enabled = false ;
		gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0.0f;


		// 天使のgameObjectをsetActive(true);
		angelObject.SetActive(true);
		yield return new WaitForSeconds (angelTime);  
		// SceneNvigator();
		SceneNavigator.Instance.Change (scenename, 0.5f);
	}

    private IEnumerator Surinuke()
    {
        // 半透明にする
        gameObject.GetComponent<SpriteRenderer>().color = surinukeColor;
        // コリジョンをoffにする
        // レイヤーの変更
        gameObject.layer = LayerMask.NameToLayer("surinuke");


        yield return new WaitForSeconds(surinukeTime);

        // 半透明を元に戻す
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        // コリジョンをonにする
        // レイヤーを元に戻す
        gameObject.layer = LayerMask.NameToLayer("Default");

    }

    public void AttackButtonDown(){
        longPushOn = true;
        longPushKeika = 0.0f;
        spinCalled = false;
        //Debug.Log("attackButtonDown");
        //StartCoroutine("waitForLongPush");
    }

    public void AttackButtonUp()
    {
        Debug.Log("attackButtonUp");
        longPushOn = false;
    }

    private IEnumerator waitForLongPush(){
        longPushOn = false;
        yield return new WaitForSeconds(longPushTime);
        longPushOn = true;
       // アニメーション切り替え
        animator.SetTrigger("spin");
       // CallAttack();
        // その辺の処理

    }

    public void changeAnimToYamada(){
        gameObject.GetComponent<Animator>().runtimeAnimatorController = yamadaAnim;

        playerTop.SetActive(false);
        playerTopYamada.SetActive(true);
        yamadaMode = true;
    }



}
