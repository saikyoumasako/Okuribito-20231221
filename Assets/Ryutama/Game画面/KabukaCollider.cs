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
        initialPosition = transform.position; // �����ʒu��ݒ�    }
    }
    // Update is called once per frame
    void Update()
    {
        MoveCollider(); // �R���C�_�[�����Ɉړ�
    }

    public void InitialPosition(float increase)
    {
        // �I�u�W�F�N�g�̌��݂̈ʒu���擾
        Vector3 currentPosition = initialPosition;

        // Y���W���w�肳�ꂽ����������������
        currentPosition.y += increase * 0.8f;

        // �V�����ʒu��ݒ�
        initialPosition = currentPosition;
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
