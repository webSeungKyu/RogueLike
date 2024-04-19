using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    bool enemy0OnOff = true;
    public GameObject enemy0;
    public int enemy0Total = 0;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(SpawnEnemy0());
    }

    IEnumerator SpawnEnemy0()
    {
        while (enemy0OnOff)
        {
            yield return new WaitForSeconds(3f);
            Vector3 ran = new Vector2(Random.Range(5f, 8f), Random.Range(5f, 8f));
            Vector3 ran2 = new Vector2(Random.Range(-5f, -8f), Random.Range(-5f, -8f));
            Vector3 ran3 = new Vector2(Random.Range(5f, 8f), Random.Range(-5f, -8f));
            Vector3 ran4 = new Vector2(Random.Range(-5f, -8f), Random.Range(5f, 8f));
            Instantiate(enemy0, player.transform.position + ran, Quaternion.identity);
            Instantiate(enemy0, player.transform.position + ran2, Quaternion.identity);
            Instantiate(enemy0, player.transform.position + ran3, Quaternion.identity);
            Instantiate(enemy0, player.transform.position + ran4, Quaternion.identity);
            yield return null;
            
        }
        
    }

    void Update()
    {
    }
}
