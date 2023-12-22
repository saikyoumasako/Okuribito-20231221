using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public GameObject mainCamera; // �J�����I�u�W�F�N�g�̎Q��
    public GameObject kabuSpawner; // �J�u�X�|�i�[�̎Q��
    public GameObject kabukaColliderOb;//�J�u�R���C�_�[�̎Q��

    private float money = 0f;
    private float kabuka = 100f;
    private float fallkabuka = 0f;
    private float gameTime = 180f;
    public float increaseRange = 1.5f; // ������臒l��ݒ肷��
    public float initialY = -3.15f; // ������Y���W
    public float kabukaIncrease = 10f; // Y���W���������邲�Ƃ�kabuka�̑�����
    private float newYIncreases = 0f;

    private bool positionUp = false;
    private bool positionUpUp = false;
    private bool positionUpUpUp = false;
    private bool positionUpUpUpUp = false;

    public TMPro.TMP_Text moneyText;
    public TMPro.TMP_Text kabukaText;
    public TMPro.TMP_Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGameTime(); //���Ԍo��
    }

    private void UpdateGameTime()
    {
        gameTime -= Time.deltaTime; // �o�ߎ��Ԃ����Z
        if (gameTime <= 0)
        {
            gameTime = 0; // ���Ԃ�0�����ɂȂ�Ȃ��悤�ɂ���
            // ���Ԑ؂ꎞ�̏�����ǉ��i�Q�[���I�[�o�[�Ȃǁj

        }
        timeText.text = Mathf.Round(gameTime).ToString(); // ���Ԃ𐮐��ŕ\��
    }
    private void UpdateTexts() //�J�u���Ǝ��Y�e�L�X�g������������
    {
        kabukaText.text = Mathf.Floor(kabuka) + "%".ToString();
        moneyText.text =  Mathf.Floor(money).ToString();
    }

    public void FallKabuka(float fall) //���������J�u
    {
        fallkabuka += fall / 10; //�������J�u��10���̂P���J�u�����猸��
    }

    public void Kabukachange(float Yposition)�@//�J�u����ς���
    {
        if(Yposition > initialY)
        {
            newYIncreases = (Yposition - initialY); // ��������Y���W�̌�
            //Debug.Log(newYIncreases);
            float kabukaIncreasevalue = newYIncreases * kabukaIncrease; // kabuka�̑�����
            kabuka = 100 + kabukaIncreasevalue - fallkabuka;

            CheckPosition();
            UpdateTexts();
        }
    }

    void CheckPosition() //�J�u�̍��������l�ȏ㒴�����Ƃ��ɏ������s��
    {
        if(newYIncreases > increaseRange)
        {
            if (!positionUp)
            {
                CameraPosition();
                KabuSpawnerPosition();
                kabukaIncrease = kabukaIncrease * 2;
                positionUp = true;
            }

        }
        if (newYIncreases > increaseRange * 2) //2�{
        {
            if (!positionUpUp)
            {
                CameraPosition();
                KabuSpawnerPosition();
                kabukaIncrease = kabukaIncrease * 2;

                positionUpUp = true;
            }

        }
        if (newYIncreases > increaseRange * 3) //3�{
        {
            if (!positionUpUpUp)
            {
                CameraPosition();
                KabuSpawnerPosition();
                kabukaIncrease = kabukaIncrease * 2;

                positionUpUpUp = true;
            }

        }
        if (newYIncreases > increaseRange * 4) //4�{
        {
            if (!positionUpUpUpUp)
            {
                CameraPosition();
                KabuSpawnerPosition();
                kabukaIncrease = kabukaIncrease * 2;

                positionUpUpUpUp = true;
            }

        }


    }

    void CameraPosition()         // �J�����I�u�W�F�N�g��Y���W���X�V
    {
        float cameraY = mainCamera.transform.position.y; // ���݂�Y���W���擾
        float cameraYposition = cameraY + (increaseRange / 2); // newYIncreases������Y���W�𑝉�
        mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, cameraYposition, mainCamera.transform.position.z);
    }

    public void KabuSpawnerPosition() //�J�u�X�|�[���|�W�V�����ύX
    {
        float kabuSpawnerY = kabuSpawner.transform.position.y; // ���݂�Y���W���擾
        float kabuSpawnerYposition = kabuSpawnerY + (increaseRange * 0.8f);
        kabuSpawner.transform.position = new Vector3(kabuSpawner.transform.position.x, kabuSpawnerYposition, kabuSpawner.transform.position.z);
        kabukaColliderOb.GetComponent<KabukaCollider>().InitialPosition(increaseRange); //���Ԃ��R���C�_�[�̏㏸
    }



    public void MoneyIncrease(int value) //���Y����
    {
        money += value * (kabuka / 100);
        UpdateTexts();
    }

    public void MoneyDecrease(int value) //���Y���Z
    {
        kabuka -= value / 10;
        money -= value * (kabuka / 100);
        UpdateTexts();
    }
}
