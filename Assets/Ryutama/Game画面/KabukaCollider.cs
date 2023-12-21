using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KabukaCollider : MonoBehaviour
{
    public GameManager gameManager;
    private Vector3 initialPosition; // Collider�̏����ʒu
    public float moveSpeed = 1.0f; // �ړ����x

    // Start is called before the first frame update
    void Start()
    {
        //GameManager gameManager = GameObject.FindObjectOfType<GameManager>();

        initialPosition = transform.position; // �����ʒu��ݒ�
    }

    // Update is called once per frame
    void Update()
    {
        MoveCollider(); // �R���C�_�[�����Ɉړ�
    }

    private void MoveCollider()
    {
        // ���Ɉړ�
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // "Kabu"�^�O�̃I�u�W�F�N�g�ɓ��������Ƃ�
        if (other.CompareTag("Kabu"))
        {
            // Y���W���擾
            float kabuYPosition = other.transform.position.y;

            //Y���W�����O�ɕ\��
            //Debug.Log("Kabu Y Position: " + kabuYPosition);

            // �R���C�_�[�������ʒu�ɖ߂�
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
