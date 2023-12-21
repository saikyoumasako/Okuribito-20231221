using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KabuSpawner : MonoBehaviour
{

    public Kabu[] kabuPrefab; // KabuのPrefab


    // Start is called before the first frame update
    void Start()
    {
        SpawnKabu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Kabuを生成する関数
    public void SpawnKabu()
    {
        if (kabuPrefab.Length > 0)
        {
            // 配列からランダムにインデックスを選択
            int randomIndex = Random.Range(0, kabuPrefab.Length);

            // KabuのPrefabをRespawnPosの位置に生成
            Kabu kabu = Instantiate(kabuPrefab[randomIndex], transform.position, Quaternion.identity);
            kabu.Init(this);
            // 必要に応じて、Kabuに対して追加の処理を行う
        }
    }

    // この関数はゲーム内で必要な場所で呼び出す必要があります
    public void CallSpawnKabu()
    {
        SpawnKabu();
    }
}
