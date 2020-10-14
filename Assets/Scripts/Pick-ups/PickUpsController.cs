using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpsController : MonoBehaviour
{

    public GameObject pickUp;
    public int pickUpsAmount;

    GameObject[] pickUpsLocations;

    // Start is called before the first frame update
    void Start()
    {
        GeneratePickUps();
    }


    public void GeneratePickUps()
    {
        pickUpsLocations = GameObject.FindGameObjectsWithTag("PickUpLocation");

        for(int i = 0; i < pickUpsAmount; i++)
        {
            shuffleArray(pickUpsLocations);
            Instantiate(pickUp, pickUpsLocations[0].transform.position, pickUpsLocations[0].transform.rotation);
        }

    }

    void shuffleArray(GameObject[] array)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < array.Length; t++)
        {
            GameObject tmp = array[t];
            int r = Random.Range(t, array.Length);
            array[t] = array[r];
            array[r] = tmp;
        }
    }
}
