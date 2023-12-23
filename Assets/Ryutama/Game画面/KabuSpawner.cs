using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KabuSpawner : MonoBehaviour
{

    public Kabu[] kabuPrefab; // KabuのPrefab

    private bool spawnStop = false;


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
        }
    }

    public void CallSpawnKabu()
    {
        if (!spawnStop)
        {
            SpawnKabu();
        }
    }

    public void SpawnStop() //残り時間が0になったら呼び出される
    {
        spawnStop = true;
    }

}
