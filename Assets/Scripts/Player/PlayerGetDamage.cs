using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetDamage : MonoBehaviour
{
    PlayerHealth playerH;
    

    // Start is called before the first frame update
    void Start()
    {
        playerH = GetComponent<PlayerHealth>();
        
    }

}
