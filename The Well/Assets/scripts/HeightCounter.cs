using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightCounter : MonoBehaviour
{
    private float climb;
    public Transform Player;

    public int Height;

    private HeightManager HeightManager;
    void Start()
    { 

        HeightManager = GameObject.Find("ScoreManager").GetComponent<HeightManager>();

    }

    // Update is called once per frame
   public void Update()
    {

        climb = Player.position.y;
        HeightC();

    }
    void HeightC()
    {
        int howTall = Mathf.RoundToInt(climb);
        Debug.Log(howTall);
        if (climb > 0)
        {
            if (climb >= howTall)
            {
                HeightManager.IncrementScore(Height); ;
                //print ("Heightincreasre");
            }
        }
    }
}
