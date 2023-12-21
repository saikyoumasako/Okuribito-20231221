using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KabukaCollider : MonoBehaviour
{
    public GameManager gameManager;
    private Vector3 initialPosition; // Colliderの初期位置
    public float moveSpeed = 1.0f; // 移動速度

    // Start is called before the first frame update
    void Start()
    {
        //GameManager gameManager = GameObject.FindObjectOfType<GameManager>();

        initialPosition = transform.position; // 初期位置を設定
    }

    // Update is called once per frame
    void Update()
    {
        MoveCollider(); // コライダーを下に移動
    }

    private void MoveCollider()
    {
        // 下に移動
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // "Kabu"タグのオブジェクトに当たったとき
        if (other.CompareTag("Kabu"))
        {
            // Y座標を取得
            float kabuYPosition = other.transform.position.y;

            //Y座標をログに表示
            //Debug.Log("Kabu Y Position: " + kabuYPosition);

            // コライダーを初期位置に戻す
            transform.position = initialPosition;

            gameManager.Kabukachange(kabuYPosition);
        }
        else if (other.CompareTag("Kago"))
        {
            transform.position = initialPosition;
            //Debug.Log("Kago");
        }
    }
}
