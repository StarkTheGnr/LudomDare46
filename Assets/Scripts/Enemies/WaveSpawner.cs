using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] Path, WaveEnemies;

    [SerializeField]
    int[] count;

    [SerializeField]
    float[] startSpawningAfter, delayBetweenSpawns;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < WaveEnemies.Length; i++)
        {
            StartCoroutine("Spawn", i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawn(int index)
    {
        yield return new WaitForSeconds(startSpawningAfter[index]);
        for(int i = 0; i < count[index]; i++)
        {
            GameObject enemy = Instantiate(WaveEnemies[index], transform.position, Quaternion.identity);
            Navigation navigation = enemy.GetComponent<Navigation>();
            navigation.path = Path;
            navigation.Navigate();

            yield return new WaitForSeconds(delayBetweenSpawns[index]);
        }
    }
}
