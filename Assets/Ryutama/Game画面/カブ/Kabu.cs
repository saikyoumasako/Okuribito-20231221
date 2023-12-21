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
        rb.bodyType = RigidbodyType2D.Kinematic; // �ŏ���Kinematic�ɐݒ�
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDynamic)
        {
            // Kinematic��Ԃō��E�Ɉړ�
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float movementSpeed = kabuspeed; // �ړ����x

            Vector2 movement = new Vector2(horizontalInput * movementSpeed * Time.deltaTime, 0);
            transform.Translate(movement,Space.World);

            // Kinematic��Ԃ�Z���̉�]��ύX
            float rotationSpeed = Kaburotation; // ��]���x

            if (Input.GetKey(KeyCode.E))
            {
                transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.W))
            {
                transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
            }

            // Space�L�[�������ꂽ�瓮����悤�ɂ���
            if (Input.GetKeyDown(KeyCode.Space))
            {
                canMove = true;
                rb.bodyType = RigidbodyType2D.Dynamic; // Rigidbody��Dynamic�ɕύX
                isDynamic = true;
            }

        }
        else
        {
            //�������đ��x���O�ɂȂ�����V�����J�u���Đ���
            if (Mathf.Approximately(rb.velocity.magnitude, 0f))
            { 
                stopTime += Time.deltaTime;
                    //1.5�b�o�߂�����J�u���Ăяo��
                    if (stopTime > 1.5f)
                    {
                        TrySpawnNextKabu();
                
                    }
            }
            //�J�u�����������ꍇ�̏���
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
