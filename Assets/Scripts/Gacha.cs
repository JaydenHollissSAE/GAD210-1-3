using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Gacha : MonoBehaviour
{
    public static Gacha gachaInstance;

    private float rigFactor;
    private string unlockedCharacters;
    private string reward;
    private List<GameObject> legendary;
    private List<GameObject> epic;
    private List<GameObject> uncommon;
    private List<GameObject> common;
    private int rewardPos;
    private string rewardRare;
    private TextMeshProUGUI resultText;
    private DataStorage dataStorage;
    private int gems;

    private void Awake()
    {
        if (gachaInstance == null)
        {
            gachaInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        Debug.Log(gachaInstance);

        gameObject.SetActive(false);
    }


    void Start()
    {
        //gameObject.transform.position.z = 0;
        dataStorage = GameObject.FindGameObjectWithTag("DataStorage").GetComponent<DataStorage>();
        rigFactor = dataStorage.rigFactor;
        unlockedCharacters = dataStorage.unlockedCharacters;
        gems = dataStorage.gems;


        legendary = dataStorage.legendary;
        epic = dataStorage.epic;
        uncommon = dataStorage.uncommon;
        common = dataStorage.common;


        resultText = gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        //Debug.Log(resultText.text);

    }

    public void Caclulation()
    {
        gems -= 100;
        float chance = Random.Range(0.1f, rigFactor);
        float result = (chance / rigFactor) * 100;
        //Debug.Log("Start");

        if (result < 70f)
        {
            if (result < 50f)
            {
                if (result < 30f)
                {
                    if (result < 10f)
                    {
                        rewardRare = "legendary";
                        rewardPos = Random.Range(0, legendary.Count - 1);
                        reward = legendary[rewardPos].name;
                    }
                    else
                    {
                        rewardRare = "epic";
                        rewardPos = Random.Range(0, epic.Count - 1);
                        reward = epic[rewardPos].name;
                    }
                }
                else
                {
                    rewardRare = "uncommon";
                    rewardPos = Random.Range(0, uncommon.Count - 1);
                    reward = uncommon[rewardPos].name;
                }
            }
            else
            {
                rewardRare = "common";
                rewardPos = Random.Range(0, common.Count - 1);
                reward = common[rewardPos].name;
            }
        }
        else
        {
            reward = "nothing";
        }

        //Debug.Log("Calc Done");

        dataStorage.gems = gems;
        if (reward != "nothing")
        {
            if (!unlockedCharacters.Contains(reward))
            {
                unlockedCharacters += "|||" + reward + "|||" + rewardRare + "|||" + rewardPos.ToString();
                dataStorage.unlockedCharacters = unlockedCharacters;
            }

            resultText.text = "Congradulations!\nYou got a " + reward;
            //Debug.Log("Final1");
        }
        else
        {
            resultText.text = "Nothing Obtained";
            //Debug.Log("Final2");
        }
    }
}
