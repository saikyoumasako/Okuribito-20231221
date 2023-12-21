using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KabuSpawner : MonoBehaviour
{

    public Kabu[] kabuPrefab; // Kabu��Prefab


    // Start is called before the first frame update
    void Start()
    {
        SpawnKabu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Kabu�𐶐�����֐�
    public void SpawnKabu()
    {
        if (kabuPrefab.Length > 0)
        {
            // �z�񂩂烉���_���ɃC���f�b�N�X��I��
            int randomIndex = Random.Range(0, kabuPrefab.Length);

            // Kabu��Prefab��RespawnPos�̈ʒu�ɐ���
            Kabu kabu = Instantiate(kabuPrefab[randomIndex], transform.position, Quaternion.identity);
            kabu.Init(this);
            // �K�v�ɉ����āAKabu�ɑ΂��Ēǉ��̏������s��
        }
    }

    // ���̊֐��̓Q�[�����ŕK�v�ȏꏊ�ŌĂяo���K�v������܂�
    public void CallSpawnKabu()
    {
        SpawnKabu();
    }
}
