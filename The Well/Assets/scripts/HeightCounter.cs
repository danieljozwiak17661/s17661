using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightCounter : MonoBehaviour
{
    private float climb;
    public Transform Player;

    public int Height;
    private int howTallmax;

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
       // Debug.Log(howTall);

            if (howTall > howTallmax)
            {
                HeightManager.IncrementScore(Height);
                howTallmax = howTall;
                //print ("Heightincreasre");
            }
    }
}
