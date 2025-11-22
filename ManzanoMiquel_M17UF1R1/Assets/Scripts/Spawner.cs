using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float TimeBetweenEnemies = 5f;
    private float TimeSpan = 0f;
    [SerializeField] private GameObject enemy;
    private float timeInterval;

    private Vector2 initialPosition;

    public Stack<GameObject> EnemiesStack = new Stack<GameObject>();

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (Time.time >= TimeSpan)
        {
            if (EnemiesStack.Count == 0)
            {
                GameObject enem = Instantiate(enemy, initialPosition, Quaternion.identity);
                enem.GetComponent<Enemy>()._spawner = this;
            }
            else
            {
                GameObject enem = EnemiesStack.Pop();
                Debug.Log("Reusing enemy from stack");
                enem.SetActive(true);
                enem.transform.position = transform.position;
            }

            TimeSpan = Time.time + TimeBetweenEnemies;
            //Debug.Log(Time.time);
        }
    }
}
