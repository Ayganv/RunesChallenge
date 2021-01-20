using System;
using Rune.Controller;
using UnityEngine;
using UnityEngine.UI;

namespace Rune.View
{
    public class MergeButton : MonoBehaviour
    {
        private void Start()
        {
            FindObjectOfType<Manager>().SubscribeToMergeDataEvent(UpdateButton);
        }

        private void UpdateButton(bool state)
        {
            GetComponent<Button>().interactable = state;
        }
    }
}
