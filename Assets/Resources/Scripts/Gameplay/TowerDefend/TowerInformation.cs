using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerInformation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public int level;

    [SerializeField]
    public  GameObject towerLevel02;

    [SerializeField]
    public GameObject towerLevel03;

    [SerializeField]
    public  GameObject BuiderBase;

    [SerializeField]
    public string type; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string getType { get { return type; } }
    public int getLevel { get { return level; } }
}
