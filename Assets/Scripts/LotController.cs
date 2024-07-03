using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LotController : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve curve;
    [SerializeField]
    private GameObject lotPrefab;
    [SerializeField]
    private GameObject parentGameObject;
    [SerializeField]
    private Trade trade;
    [SerializeField]
    private ScrollRect scrollRect;
    [SerializeField]
    private GameObject buyButtons;
    [SerializeField]
    private GameObject notEnoughMoney;
    [SerializeField]
    private int columnsNumber = 1;

    private static GameObject _notEnoughMoney;
    private static GameObject _buyButtons;
    private static Trade _trade;

    private static GameObject _thisLot;
    private static float _price;
    private static Banana _banana;

    void Start()
    {
        LotGenerator.curve = curve;
        LotGenerator.lotPrefab = lotPrefab;
        LotGenerator.parentTransform = parentGameObject.transform;


        SetupGridLayoutGroup();
        FierstFillingScrollRect(150);


        //This is not right, but i am X3
        _trade = trade;
        _notEnoughMoney = notEnoughMoney;
        _buyButtons = buyButtons;
    }

    public static void ClickOnLot(GameObject thisLot, Banana banana, float price)
    {
        if (_trade.Balance >= price)
        {
            _buyButtons.SetActive(true);

            BuyButton buyButton = _buyButtons.GetComponent<BuyButton>();
            buyButton.BuyLot += BuyLot;
            buyButton.OffThisLot += OffThisLot;

            _thisLot = thisLot;
            _price = price;
            _banana = banana;
        }
        else
        {
            _notEnoughMoney.SetActive(true);
        }
    }
    public void LeaveOneBanan(Banana banana)
    {
        var LotComponents = parentGameObject.GetComponentsInChildren<Lot>();
        foreach (var LotComponent in LotComponents)
        {
            if(LotComponent.Banana != banana)
            {
                LotComponent.gameObject.SetActive(false);
            }
        }
    }
    private void FierstFillingScrollRect(int bananaNumber)
    {
        for (int i = 0; i < bananaNumber; i++)
        {
            int rarity = Convert.ToInt32(Random.Range(0, 4));
            int banana = Convert.ToInt32(Random.Range(0, AllBananas.Bananas[rarity].Length));
            LotGenerator.CreateLot(AllBananas.Bananas[rarity][banana]);
        }

        //Scoll up ScrollRect
        scrollRect.verticalNormalizedPosition = 1f;
    }
    private static void BuyLot()
    {
        _trade.Balance -= _price;
        _trade.BalanceText.text = Convert.ToString(_trade.Balance);
        Inventory.AddNewItem(_banana);
    }
    private static void OffThisLot()
    {
        _thisLot.SetActive(false);
    }
    private void SetupGridLayoutGroup()
    {
        parentGameObject.GetComponent<GridLayoutGroup>().constraintCount = columnsNumber;

        float spaceX = 10 + 100 * (LotGenerator.lotPrefab.GetComponent<RectTransform>().lossyScale.x - 1);
        float spaceY = 20 + 136.66f * (LotGenerator.lotPrefab.GetComponent<RectTransform>().lossyScale.y - 1);
        parentGameObject.GetComponent<GridLayoutGroup>().spacing = new Vector2(spaceX, spaceY);
    }
}

