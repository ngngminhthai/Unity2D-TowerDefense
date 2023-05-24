using System.Collections.Generic;
using UnityEngine;

public class PlayerAssetManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int Gold { get; set; }
    public Dictionary<string, int> UnitLevel { get; set; } = new Dictionary<string, int>();

    void Start()
    {
        //gold from default
        Gold = 0;

        //default level for 3 defender unit
        UnitLevel.Add("archery", 1);
        UnitLevel.Add("warrion", 1);
        UnitLevel.Add("mage", 1);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void LoadFromPlayerFrebs(int gold, Dictionary<string, int> unitlevel)
    {
        Gold = gold;
        UnitLevel = unitlevel;
    }
}
