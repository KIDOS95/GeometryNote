using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject figure;
    private float randomX;
    private Vector2 whereToSpawn;
    [SerializeField]
    private float spawnRate;
    [SerializeField]
    private float nextSpawn = 0.0f;




    void Start ()
    {
        StartCoroutine(Complexity()); 
    }



    IEnumerator Complexity()
    {
        yield return new WaitForSeconds(5);
        spawnRate = 1f;
        yield return new WaitForSeconds(5);
        spawnRate = 0.8f;
        yield return new WaitForSeconds(5);
        spawnRate = 0.75f;
        yield return new WaitForSeconds(10);
        spawnRate = 0.62f;
        yield return new WaitForSeconds(10);
        spawnRate = 0.5f;
        yield return new WaitForSeconds(10);
        spawnRate = 0.40f;
        yield return new WaitForSeconds(20);
        spawnRate = 0.37f;
        yield return new WaitForSeconds(20);
        spawnRate = 0.35f;
        yield return new WaitForSeconds(20);
        spawnRate = 0.33f;
        yield return new WaitForSeconds(20);
        spawnRate = 0.30f; 
        yield return new WaitForSeconds(20);
        spawnRate = 0.27f;
        yield return new WaitForSeconds(20);
        spawnRate = 0.25f;

    }


    private void Update()
    {
        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randomX = Random.Range(-1.83f, 1.58f);
            whereToSpawn = new Vector2(randomX, transform.position.y);
            Instantiate(figure, whereToSpawn, Quaternion.identity);
        }
    }
}
