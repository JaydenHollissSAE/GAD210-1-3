using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Controls : MonoBehaviour
{
    [SerializeField] private GameObject gachaSystem;
    public static Controls controlsInstance;
    private bool gachaActive = false;
    public List<GameObject> charactersList = new List<GameObject>();
    private GameObject activeCharacter;
    private DataStorage dataStorage;

    // Start is called before the first frame update
    private void Awake()
    {

        if (controlsInstance == null)
        {
            controlsInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        dataStorage = GameObject.FindGameObjectWithTag("DataStorage").GetComponent<DataStorage>();
        StartCoroutine(GetActiveCharacter());
        if (activeCharacter == null)
        {
            Instantiate(dataStorage.common[0], new Vector3(0, 10, 0), Quaternion.identity);
            StartCoroutine(GetActiveCharacter());
        }
    }



    private IEnumerator GetActiveCharacter()
    {
        yield return new WaitForSeconds(0.2f);
        activeCharacter = GameObject.FindGameObjectWithTag("Player");
    }

    private void ChangeCharacter(int listPos)
    {
        Vector3 spawnPos = activeCharacter.transform.position;
        //Debug.Log(spawnPos);
        Instantiate(charactersList[listPos], spawnPos, Quaternion.identity);
        Destroy(activeCharacter);
        StartCoroutine(GetActiveCharacter());
        //Debug.Log(activeCharacter.transform.position);

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeCharacter(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeCharacter(1);

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeCharacter(2);

        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChangeCharacter(3);

        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            if (gachaActive)
            {
                gachaSystem.SetActive(false);
                gachaActive = false;
            }
            else
            {
                gachaSystem.SetActive(true);
                gachaActive = true;
            }
            
        }
        if (gachaActive)
        {
            if (Input.GetKeyDown(KeyCode.L)) 
            {
                //Debug.Log("Pressed Button");
                gachaSystem.GetComponent<Gacha>().Caclulation();
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {

        }
    }
}
