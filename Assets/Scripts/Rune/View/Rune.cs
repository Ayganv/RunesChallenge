using System;
using Rune.Controller;
using Rune.Model;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Rune.View {
    public class Rune : MonoBehaviour {
        public UnityEvent<string> onAmountChangedString;
        public Image rarity, type, background;
        public Data data;
        public GameObject QuantityDisplay;
        

        public void SetUp(Data assignedData) {
            data = assignedData;
            onAmountChangedString.Invoke(data.Amount.ToString());
            data.OnAmountChanged += delegate(int i) { onAmountChangedString.Invoke(i.ToString()); };
            GetComponent<Button>().onClick.AddListener(() => FindObjectOfType<Manager>().AddToMergeArea(this));
            UpdateImages();
        }

        public void ListenToRuneMove()
        {
            data.OnRuneMoved += DestroyThis;
        }

        public void SubscribeToDrag(ref Action dropEvent)
        {
            dropEvent += DestroyThis;
        }

        public void DestroyThis()
        {
            Destroy(gameObject);
            data.OnRuneMoved -= DestroyThis;
        }

        private void UpdateImages() {
            rarity.sprite = data.Rarity.Sprite;
            type.sprite = data.RuneType.Sprite;
            background.color = data.RuneType.Color;
        }

        public void QuantityDisplayTextToggle(bool isActive){
            QuantityDisplay.SetActive(isActive);
        }

    }
}