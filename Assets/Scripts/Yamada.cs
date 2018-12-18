using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yamada : MonoBehaviour {

    GameObject player_green;

    private Rigidbody2D rb2d;
    Rigidbody2D rigidbody2D;
    public float speed = 100.0f;
    public float waitTime = 1.0f;
    bool waiting = false;
    Vector3 initScale;
    Vector3 revScale;
    bool randomMove = true;
    public float chaseDistance = 2.0f;
    public float randTimeMin = 1.0f;
    public float randTimeMax = 3.0f;
    int randDir = 0;
    public GameObject effectObj;

    void Start()
    {
        // オブジェクトのRigidbody2Dを取得
        rb2d = GetComponent<Rigidbody2D>();
        // PLAYERオブジェクトを取得
        player_green = GameObject.Find("Player");

        initScale = transform.localScale;
        revScale = new Vector3(initScale.x * -1.0f, initScale.y, initScale.z);

        StartCoroutine("setRundomTimeAndDirection");
    }

    void Update()
    {
        if (randomMove)
        {
            // ランダムに動かす
            float distanceFromPlayer = Vector3.Distance(player_green.transform.position, gameObject.transform.position);
            // Debug.Log (distanceFromPlayer);
            if (randDir == 0)
            {
                rb2d.velocity = Vector2.left * speed;
                transform.localScale = initScale;

            }
            else
            {
                rb2d.velocity = Vector2.right * speed;
                transform.localScale = revScale;
            }

            if (distanceFromPlayer < chaseDistance)
            {
                randomMove = false;
            }
        }
        else
        {
            // 移動関数の呼び出し
            if (waiting == false)
            {
                EnemyMove();
            }
        }
    }

    // ENEMYの移動関数1フレーム毎にUpdate関数から呼び出される
    void EnemyMove()
    {
        if (player_green.GetComponent<Player>().isGameOver)
        {
            rb2d.velocity = Vector2.zero;
            return;
        }

        // PLAYERの位置を取得
        Vector2 targetPos = player_green.transform.position;
        // PLAYERのx座標
        float x = targetPos.x;
        // ENEMYは、地面を移動させるので座標は常に0とする
        float y = 0;
        // 移動を計算させるための２次元のベクトルを作る
        Vector2 direction = new Vector2(
            x - transform.position.x, y).normalized;
        // ENEMYのRigidbody2Dに移動速度を指定する
        rb2d.velocity = direction * speed;


        if (direction.x < 0)
        {
            transform.localScale = initScale;
        }
        else
        {
            transform.localScale = revScale;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // プレイヤーが無敵状態だったら
            if (collision.gameObject.GetComponent<Player>().mutekiFlag)
            {
                // エフェクト表示
                Instantiate(effectObj, gameObject.transform.position, Quaternion.identity);
                // 消す
                Destroy(gameObject);
            }
            else
            {
                StartCoroutine("WaitForPlayer");
            }
        }
    }

    private IEnumerator WaitForPlayer()
    {
        // ログ出力  
        //Debug.Log ("1");  
        waiting = true;
        // 1秒待つ  
        yield return new WaitForSeconds(waitTime);

        waiting = false;

    }

    private IEnumerator setRundomTimeAndDirection()
    {
        randDir = Random.Range(0, 2);

        float radTime = Random.Range(randTimeMin, randTimeMax);
        yield return new WaitForSeconds(radTime);

        StartCoroutine("setRundomTimeAndDirection");
    }

}
