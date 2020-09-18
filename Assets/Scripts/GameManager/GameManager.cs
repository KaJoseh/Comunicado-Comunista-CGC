using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool created;

    public GameStats gameStats;

    /// <summary>
    /// 
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
        GameMode = GameManager.gameModes.PLAYING;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

}
