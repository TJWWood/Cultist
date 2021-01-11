using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static InventoryManager;

public class GenerateUI : MonoBehaviour
{
    public Canvas inventoryCanvas;
    Vector3 nameTextPosition = new Vector3(0f, 0f, 0f);
    Vector3 quantityTextPosition = new Vector3(120f, 0f, 0f);
    Vector3 weightTextPosition = new Vector3(160f, 0f, 0f);
    Vector3 valueTextPosition = new Vector3(200f, 0f, 0f);
    public Button button;
    public GameObject player;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            Generate();
        }
    }

    void AddEatComponent(string name, float foodWeight, float value)
    {
        player.AddComponent<EatFood>();
        player.GetComponent<EatFood>().foodName = name;
        player.GetComponent<EatFood>().foodValue = value;
        player.GetComponent<EatFood>().weight = foodWeight;
    }

    void AddDrinkComponent(string name, float drinkWeight, float value)
    {
        player.AddComponent<UseDrink>();
        player.GetComponent<UseDrink>().drinkName = name;
        player.GetComponent<UseDrink>().drinkValue = value;
        player.GetComponent<UseDrink>().weight = drinkWeight;
    }

    void AddMedComponent(string name, float medWeight, float value)
    {
        player.AddComponent<UseMed>();
        //player.GetComponent<UseMed>().medName = name;
        //player.GetComponent<UseMed>().medValue = value;
        //player.GetComponent<UseMed>().weight = medWeight;
    }

    void Generate()
    {
        Font font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        foreach (KeyValuePair<string, ItemData> entry in FoodStorage)
        {
            if (entry.Value.GetQuantity() > 0)
            {
                GameObject nameGO = new GameObject(entry.Key + "GO");
                nameGO.transform.SetParent(inventoryCanvas.gameObject.transform);
                nameGO.transform.localPosition = nameTextPosition;

                Button nameButton = Instantiate(button, nameGO.gameObject.transform);
                nameButton.name = entry.Key + "ButtonGO";
                nameButton.onClick.AddListener(delegate { AddEatComponent(entry.Key, entry.Value.GetWeight(), entry.Value.GetValue()); });

                //nameGO.gameObject.AddComponent<Image>().color = Color.blue;
                //nameButton.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 30);
                //nameButton.targetGraphic = nameGO.GetComponent<Image>();

                //GameObject nameTextGO = new GameObject(entry.Key + "TextGO");
                //nameTextGO.transform.SetParent(nameButton.gameObject.transform);
                Text nameText = nameButton.GetComponentInChildren<Text>();
                nameText.gameObject.name = entry.Key + "TextGO";
                nameText.text = entry.Key;
                nameText.font = font;
                nameText.fontSize = 22;
                //nameText.horizontalOverflow = HorizontalWrapMode.Overflow;
                //nameText.transform.localPosition = nameTextPosition;

                nameTextPosition.y -= 40f;

                //TODO MAKE FOLLOWING DETAILS HAVE CORRECT HEIGHT

                GameObject quantityGO = new GameObject(entry.Key + "QuantityGO");
                quantityGO.transform.SetParent(nameText.gameObject.transform);
                Text quantityText = quantityGO.gameObject.AddComponent<Text>();
                quantityText.text = entry.Value.GetQuantity().ToString();
                quantityText.font = font;
                quantityText.fontSize = 22;
                quantityText.transform.localPosition = quantityTextPosition;

                GameObject weightGO = new GameObject(entry.Key + "WeightGO");
                weightGO.transform.SetParent(quantityGO.gameObject.transform);
                Text weightText = weightGO.gameObject.AddComponent<Text>();
                weightText.text = entry.Value.GetWeight().ToString();
                weightText.font = font;
                weightText.fontSize = 22;
                weightText.transform.localPosition = weightTextPosition;

                GameObject valueGO = new GameObject(entry.Key + "ValueGO");
                valueGO.transform.SetParent(weightGO.gameObject.transform);
                Text valueText = valueGO.gameObject.AddComponent<Text>();
                valueText.text = entry.Value.GetValue().ToString();
                valueText.font = font;
                valueText.fontSize = 22;
                valueText.transform.localPosition = valueTextPosition;
            }
        }
        foreach (KeyValuePair<string, ItemData> entry in DrinkStorage)
        {
            if (entry.Value.GetQuantity() > 0)
            {
                GameObject nameGO = new GameObject(entry.Key + "GO");
                nameGO.transform.SetParent(inventoryCanvas.gameObject.transform);
                nameGO.transform.localPosition = nameTextPosition;

                Button nameButton = Instantiate(button, nameGO.gameObject.transform);
                nameButton.name = entry.Key + "ButtonGO";
                nameButton.onClick.AddListener(delegate { AddDrinkComponent(entry.Key, entry.Value.GetWeight(), entry.Value.GetValue()); });

                //nameGO.gameObject.AddComponent<Image>().color = Color.blue;
                //nameButton.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 30);
                //nameButton.targetGraphic = nameGO.GetComponent<Image>();

                //GameObject nameTextGO = new GameObject(entry.Key + "TextGO");
                //nameTextGO.transform.SetParent(nameButton.gameObject.transform);
                Text nameText = nameButton.GetComponentInChildren<Text>();
                nameText.gameObject.name = entry.Key + "TextGO";
                nameText.text = entry.Key;
                nameText.font = font;
                nameText.fontSize = 22;
                //nameText.horizontalOverflow = HorizontalWrapMode.Overflow;
                //nameText.transform.localPosition = nameTextPosition;

                nameTextPosition.y -= 40f;

                //TODO MAKE FOLLOWING DETAILS HAVE CORRECT HEIGHT

                GameObject quantityGO = new GameObject(entry.Key + "QuantityGO");
                quantityGO.transform.SetParent(nameText.gameObject.transform);
                Text quantityText = quantityGO.gameObject.AddComponent<Text>();
                quantityText.text = entry.Value.GetQuantity().ToString();
                quantityText.font = font;
                quantityText.fontSize = 22;
                quantityText.transform.localPosition = quantityTextPosition;

                GameObject weightGO = new GameObject(entry.Key + "WeightGO");
                weightGO.transform.SetParent(quantityGO.gameObject.transform);
                Text weightText = weightGO.gameObject.AddComponent<Text>();
                weightText.text = entry.Value.GetWeight().ToString();
                weightText.font = font;
                weightText.fontSize = 22;
                weightText.transform.localPosition = weightTextPosition;

                GameObject valueGO = new GameObject(entry.Key + "ValueGO");
                valueGO.transform.SetParent(weightGO.gameObject.transform);
                Text valueText = valueGO.gameObject.AddComponent<Text>();
                valueText.text = entry.Value.GetValue().ToString();
                valueText.font = font;
                valueText.fontSize = 22;
                valueText.transform.localPosition = valueTextPosition;
            }
        }
        foreach (KeyValuePair<string, ItemData> entry in MedStorage)
        {
            if (entry.Value.GetQuantity() > 0)
            {
                GameObject nameGO = new GameObject(entry.Key + "GO");
                nameGO.transform.SetParent(inventoryCanvas.gameObject.transform);
                nameGO.transform.localPosition = nameTextPosition;

                Button nameButton = Instantiate(button, nameGO.gameObject.transform);
                nameButton.name = entry.Key + "ButtonGO";
                nameButton.onClick.AddListener(delegate { AddMedComponent(entry.Key, entry.Value.GetWeight(), entry.Value.GetValue()); });

                //nameGO.gameObject.AddComponent<Image>().color = Color.blue;
                //nameButton.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 30);
                //nameButton.targetGraphic = nameGO.GetComponent<Image>();

                //GameObject nameTextGO = new GameObject(entry.Key + "TextGO");
                //nameTextGO.transform.SetParent(nameButton.gameObject.transform);
                Text nameText = nameButton.GetComponentInChildren<Text>();
                nameText.gameObject.name = entry.Key + "TextGO";
                nameText.text = entry.Key;
                nameText.font = font;
                nameText.fontSize = 22;
                //nameText.horizontalOverflow = HorizontalWrapMode.Overflow;
                //nameText.transform.localPosition = nameTextPosition;

                nameTextPosition.y -= 40f;

                //TODO MAKE FOLLOWING DETAILS HAVE CORRECT HEIGHT

                GameObject quantityGO = new GameObject(entry.Key + "QuantityGO");
                quantityGO.transform.SetParent(nameText.gameObject.transform);
                Text quantityText = quantityGO.gameObject.AddComponent<Text>();
                quantityText.text = entry.Value.GetQuantity().ToString();
                quantityText.font = font;
                quantityText.fontSize = 22;
                quantityText.transform.localPosition = quantityTextPosition;

                GameObject weightGO = new GameObject(entry.Key + "WeightGO");
                weightGO.transform.SetParent(quantityGO.gameObject.transform);
                Text weightText = weightGO.gameObject.AddComponent<Text>();
                weightText.text = entry.Value.GetWeight().ToString();
                weightText.font = font;
                weightText.fontSize = 22;
                weightText.transform.localPosition = weightTextPosition;

                GameObject valueGO = new GameObject(entry.Key + "ValueGO");
                valueGO.transform.SetParent(weightGO.gameObject.transform);
                Text valueText = valueGO.gameObject.AddComponent<Text>();
                valueText.text = entry.Value.GetValue().ToString();
                valueText.font = font;
                valueText.fontSize = 22;
                valueText.transform.localPosition = valueTextPosition;
            }
        }
    }
}
