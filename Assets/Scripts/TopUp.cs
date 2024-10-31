using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class TopUp : MonoBehaviour
{
    private string cardNo;
    private string cardHolder;
    private string cardExpire;
    private string cardThreeDigits;
    private List<string> cardInfoBuffer = new List<string>();
    [SerializeField] private TextMeshPro cardNoObject;
    [SerializeField] private TextMeshPro cardHolderObject;
    [SerializeField] private TextMeshPro cardExpireObject;
    [SerializeField] private TextMeshPro cardThreeDigitsObject;
    private DataStorage dataStorage;

    // Start is called before the first frame update
    void Start()
    {
        dataStorage = GameObject.FindGameObjectWithTag("DataStorage").GetComponent<DataStorage>();
        if (PlayerPrefs.HasKey("PaymentInfo"))
        {
            cardInfoBuffer = PlayerPrefs.GetString("PaymentInfo").Split('|').ToList();
            cardNo = cardInfoBuffer[0];
            cardHolder = cardInfoBuffer[1];
            cardExpire = cardInfoBuffer[2];
            cardThreeDigits = cardInfoBuffer[3];
            cardNoObject.text = cardNo;
            cardHolderObject.text = cardHolder;
            cardExpireObject.text = cardExpire;
            cardThreeDigitsObject.text = cardThreeDigits;
        }
    }

    void ProcessPayment()
    {
        PlayerPrefs.SetString("PaymentInfo", cardNoObject.text.ToString() + "|" + cardHolderObject.text.ToString() + "|" + cardExpireObject.text.ToString() + "|" + cardThreeDigitsObject.text.ToString());
        dataStorage.gems += 100;
    }
}
