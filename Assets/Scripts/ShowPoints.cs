using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPoints : MonoBehaviour
{

    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        //setWinner = GameObject.FindWithTag("GameController").GetComponent<SetWinner>();
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
            if (gm.p1Score == 1)
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (gm.p1Score == 2)
            {
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
            }
            else if (gm.p1Score == 3)
            {
                gameObject.transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                for(int i = 0; i < gameObject.transform.childCount; i++)
                {
                    gameObject.transform.GetChild(i).gameObject.SetActive(false);
                }
            }
        }
        else if (gameObject.name == "P2 Points")
        {
            if (gm.p2Score == 1)
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (gm.p2Score == 2)
            {
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
            }
            else if (gm.p2Score == 3)
            {
                gameObject.transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                for (int i = 0; i < gameObject.transform.childCount; i++)
                {
                    gameObject.transform.GetChild(i).gameObject.SetActive(false);
                }
            }
        }
    }
}
