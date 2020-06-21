using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public float period;
    private float SpawnDelay;
  //  public float SpawnDuration;

    public Enemy prefab;
    private SpriteRenderer SRenderer;

    public Animator SpawnAnimator;

    void Start()
    {
        SRenderer = GetComponent<SpriteRenderer>();
        SpawnDelay = 0;
        SpawnAnimator.SetBool("Spawns", false);
    }

    void Update()
    {
        SpawnDelay += Time.deltaTime;
      //  SpawnDuration -= Time.deltaTime;

        if (SRenderer.isVisible)
        {
            if (SpawnDelay >= period)
            {
                SpawnDelay = 0;
                Instantiate(prefab, transform.position, transform.rotation);
                SpawnAnimator.SetBool("Spawns",true);
               // SpawnDuration = 0.5f;

            }
            if (SpawnDelay >= 0.5f)
            {
                SpawnAnimator.SetBool("Spawns", false);
            }
        }
    }
}
