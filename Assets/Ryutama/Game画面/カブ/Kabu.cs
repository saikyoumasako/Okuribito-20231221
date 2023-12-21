using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kabu : MonoBehaviour
{
    private Rigidbody2D rb;
    private KabuSpawner spawner;
    private GameManager gameManager;

    private bool canMove = false;
    private bool isDynamic = false;
    private bool preaseSpawn = true;

    public int value = 0;
    public float kabuspeed = 5.0f;
    public float Kaburotation = 100f;

    private float stopTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic; // 最初はKinematicに設定
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDynamic)
        {
            // Kinematic状態で左右に移動
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float movementSpeed = kabuspeed; // 移動速度

            Vector2 movement = new Vector2(horizontalInput * movementSpeed * Time.deltaTime, 0);
            transform.Translate(movement,Space.World);

            // Kinematic状態でZ軸の回転を変更
            float rotationSpeed = Kaburotation; // 回転速度

            if (Input.GetKey(KeyCode.E))
            {
                transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.W))
            {
                transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
            }

            // Spaceキーが押されたら動けるようにする
            if (Input.GetKeyDown(KeyCode.Space))
            {
                canMove = true;
                rb.bodyType = RigidbodyType2D.Dynamic; // RigidbodyをDynamicに変更
                isDynamic = true;
            }

        }
        else
        {
            //落下して速度が０になったら新しいカブを再生成
            if (Mathf.Approximately(rb.velocity.magnitude, 0f))
            { 
                stopTime += Time.deltaTime;
                    //1.5秒経過したらカブを呼び出す
                    if (stopTime > 1.5f)
                    {
                        TrySpawnNextKabu();
                
                    }
            }
            //カブが落下した場合の処理
            if (transform.position.y < -12)
            {

                TrySpawnNextKabu();
                gameManager.MoneyDecrease(value);
                Destroy(this.gameObject);
            }
        }



    }

    void TrySpawnNextKabu()
    {
        if (preaseSpawn)
        {
            spawner.CallSpawnKabu();
            gameManager.MoneyIncrease(value);
            preaseSpawn = false;
        }
    }
    public void Init(KabuSpawner kabu)
    {
        spawner = kabu;
    }
}
