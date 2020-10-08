using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    [Header("-------| Game Data |--------")]
    //Players Stuff
    public float damage;
    public float maxHealth;
    public float drainFrequency;
    [HideInInspector]
    public int p1Score, p2Score;
    
    [Space]

    //Rounds Stuff
    public float roundDurationInSec;
    public float timeUntilNextRound;

    SetWinner sw;
    RoundManager rm;
    Timer t;
    bool canSetWinner;

    /// <summary>
    /// the gamemodes
    /// </summary>
    public enum gameModes
    {
        STARTING,
        PLAYING,
        ROUNDOVER
    }

    private gameModes gameMode;
    public gameModes GameMode
    {
        get
        {
            return gameMode;
        }

        set
        {
            gameMode = value;
        }
    }


    bool created;
    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        canSetWinner = true;
        t = GetComponent<Timer>();
        sw = GetComponent<SetWinner>();
        rm = GetComponent<RoundManager>();
        GameMode = GameManager.gameModes.PLAYING;
    }

    // Update is called once per frame
    void Update()
    {
        if( GameMode == GameManager.gameModes.ROUNDOVER && canSetWinner)
        {
            //print("Hola");
            canSetWinner = false;
            sw.SetRoundWinner();
            StartCoroutine(WaitForNewRound());
        }
    }


    IEnumerator WaitForNewRound()
    {
        yield return new WaitForSeconds(timeUntilNextRound);
        //setWinner.LookForGameWinner();
        t.timerIsRunning = true;
        t.currentTime = roundDurationInSec;
        print("3.. 2... 1... YA!");
        if (p1Score >= 3 || p2Score >= 3)
        {
            rm.NewRound();
            p1Score = 0;
            p2Score = 0;

            GameMode = GameManager.gameModes.PLAYING;
            canSetWinner = true;
        }
        else
        {
            rm.NewRound();

            GameMode = GameManager.gameModes.PLAYING;
            canSetWinner = true;
        }
    }


}
