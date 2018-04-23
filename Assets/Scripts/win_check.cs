using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class win_check : MonoBehaviour {
    public int winCount = 5;
    public GameObject Player;
    //public int player;
    public GameObject winScreen;

    // Use this for initialization
    void Start()
    {

    }



    // Update is called once per frame
    void Update() {



    }

    public void GameWin()
    {

        winScreen.SetActive(true);
        Player.SetActive(false);


    }


}
