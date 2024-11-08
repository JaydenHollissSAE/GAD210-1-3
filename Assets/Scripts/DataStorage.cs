using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static UnityEditor.Progress;

public class DataStorage : MonoBehaviour
{
    public float rigFactor;
    public static DataStorage instance;
    public int gems = 300;
    public List<GameObject> legendary;
    public List<GameObject> epic;
    public List<GameObject> uncommon;
    public List<GameObject> common;
    public string unlockedCharacters;
    private string unlockedCharactersOld;
    private int gemsOld;
    private Controls controls;
    private GameObject tmpItem;
    [SerializeField] List<string> tmpList;

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
        controls = GetComponent<Controls>();
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
            gems = 300;
        }
        if (PlayerPrefs.HasKey("UnlockedCharacters"))
        {
            unlockedCharacters = PlayerPrefs.GetString("UnlockedCharacters");
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerPrefs.DeleteAll();
        }
        if (unlockedCharactersOld != unlockedCharacters)
        {
            PlayerPrefs.SetString("UnlockedCharacters", unlockedCharacters);
            unlockedCharactersOld = unlockedCharacters;
            tmpList = unlockedCharacters.Split("|||").ToList();
            //Debug.Log((tmpList.Count - 1)/3);
            //Debug.Log(controls.charactersList.Count);
            if ((tmpList.Count - 1) / 3 != controls.charactersList.Count)
            {
                int i = 1;
                while (i < tmpList.Count-1)
                {
                    //Debug.Log(tmpList[i]);
                    //Debug.Log(tmpList[i]);  
                    if (tmpList[i+1] == "common")
                    {
                        tmpItem = common[int.Parse(tmpList[i + 2])];
                    }
                    else if (tmpList[i + 1] == "uncommon")
                    {
                        tmpItem = uncommon[int.Parse(tmpList[i + 2])];
                    }
                    else if (tmpList[i + 1] == "epic")
                    {
                        tmpItem = epic[int.Parse(tmpList[i + 2])];
                    }
                    else if (tmpList[i + 1] == "legendary")
                    {
                        tmpItem = legendary[int.Parse(tmpList[i + 2])];
                    }

                    if (!controls.charactersList.Contains(tmpItem))
                    {
                        controls.charactersList.Add(tmpItem);
                    }


                    i += 3;
                    Debug.Log(i);
                    Debug.Log(tmpList.Count - 1);
                }
            }
        }
        if (gemsOld != gems)
        {
            PlayerPrefs.SetInt("Gems", gems);
            gemsOld = gems;
        }


    }
}
