using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public List<GameObject> WaveSpawn = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(WaveTime());
    }

    IEnumerator WaveTime()
    {
        int counter = 0;
        while (true)
        {
            WaveSpawn[counter].SetActive(false);
            counter++;

            if(counter >= WaveSpawn.Count)
                counter = 0;

            WaveSpawn[counter].SetActive(true);
            yield return new WaitForSeconds(FlyweightPointer.Wave.timeWave);
        }
    }
}
