using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPoints : MonoBehaviour
{

    SetWinner setWinner;

    // Start is called before the first frame update
    void Start()
    {
        setWinner = GameObject.FindWithTag("GameController").GetComponent<SetWinner>();
    }

    // Update is called once per frame
    void Update()
    {
        PointsChecker();
    }

    void PointsChecker()
    {
        if (gameObject.name == "P1 Points")
        {
            if (setWinner.p1Score == 1)
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (setWinner.p1Score == 2)
            {
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
            }
            else if (setWinner.p1Score == 3)
            {
                gameObject.transform.GetChild(2).gameObject.SetActive(true);
            }
        }
        else if (gameObject.name == "P2 Points")
        {
            if (setWinner.p2Score == 1)
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (setWinner.p2Score == 2)
            {
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
            }
            else if (setWinner.p2Score == 3)
            {
                gameObject.transform.GetChild(2).gameObject.SetActive(true);
            }
        }
    }
}
