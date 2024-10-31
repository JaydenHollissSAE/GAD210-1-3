using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStorage : MonoBehaviour
{
    public float rigFactor;
    public static DataStorage instance;
    public int gems;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("GachaRig"))
        {
            rigFactor = PlayerPrefs.GetFloat("GachaRig");
        }
        else
        {
            rigFactor = Random.Range(100f, 500f);
            PlayerPrefs.SetFloat("GachaRig", rigFactor);
        }
        if (PlayerPrefs.HasKey("Gems"))
        {
            gems = PlayerPrefs.GetInt("Gems");
        }
        else
        {
            gems = 0;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
