using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamdomSpawnInMap : MonoBehaviour
{
    // Start is called before the first frame update

    public float minX = -12;
    public float maxX =12;
    public float minY = -12;
    public float maxY = 12;

    Timer timer;
    [SerializeField]
    GameObject evironment;

    void Start()
    {
        
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 4;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Finished)
        {
            int randomNumber = Random.Range(1, 4);
            for(int i= 0; i<=randomNumber; i++)
            {
                spawObject();

            }
            
            timer.Run();

        }
    }
    void spawObject()
    {
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 2);
        GameObject spawBaby = Instantiate<GameObject>(evironment, randomPosition, Quaternion.identity);
        
    }
}
