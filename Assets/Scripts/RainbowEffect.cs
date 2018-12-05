using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowEffect : MonoBehaviour {
    public float speed = 2.0f;
    public Vector2 dir = Vector2.right;
    public GameObject effectObj;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Rigidbody2D>().velocity = dir * speed;
	}




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "boss")
        {
            if (effectObj != null)
            {
                Instantiate(effectObj, collision.gameObject.transform.position, Quaternion.identity);
                float h;
                float s;
                float v;
                Color.RGBToHSV(gameObject.GetComponent<SpriteRenderer>().color, out h, out s, out v);
            }

            collision.gameObject.GetComponent<BossHP>().HP--;

            if (collision.gameObject.GetComponent<BossHP>().HP < 0 ){
                Destroy(collision.gameObject);
            }
            // game over

            // エフェクトを表示

        }
    }


    // onCollisionEnter
    // tag boss
    // HPを減らす
    // HP が0
}
