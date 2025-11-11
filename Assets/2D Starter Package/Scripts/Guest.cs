//behavior for restaurant guest components
//NO LONGER USED!!!! old script, use person and group instead

using System;
using UnityEngine;

namespace DigitalWorlds.StarterPackage2D
{
    public class Guest : MonoBehaviour
    {
        public GameObject foodSprite;
        public GameObject sitSprite;
        public GameObject standSprite;
        public GameObject foodBubble;
        public GameObject moneyBubble;
        public string food;
        public string order;
        public float  secUntilLeave;
        public float secUntilEnter;
        public int paymentAmount;

        void Start()
        {
            foodSprite.SetActive(false);
            sitSprite.SetActive(false);
            standSprite.SetActive(false);
            foodBubble.SetActive(false);
            moneyBubble.SetActive(false);
            Invoke(nameof(enter), secUntilEnter);
        }

        void enter()
        {
            standSprite.SetActive(true);
        }
        public void takeOrder()
        {
            sitSprite.SetActive(true);
            foodBubble.SetActive(true);
            CollectableManager.Instance.AddCollectable(order, 1);
            standSprite.SetActive(false);
        }

        //decrements if count is > 0, otherwise does nothing
        public void serveOrder()
        {
            if (CollectableManager.Instance == null)
            {
                Debug.LogWarning("CollectableManager not found!");
                return;
            }

            int c = CollectableManager.Instance.FindCollectable(food).count;
            if(c > 0)
            {
                CollectableManager.Instance.AddCollectable(food, -1);
                CollectableManager.Instance.AddCollectable(order, -1);
                foodBubble.SetActive(false);
                foodSprite.SetActive(true);
                Invoke(nameof(disableGuest), secUntilLeave);
            }
        }

        void disableGuest()
        {
            foodSprite.SetActive(false);
            sitSprite.SetActive(false);
            CollectableManager.Instance.AddCollectable("GuestCount", 1);
            moneyBubble.SetActive(true);

        }

        public void money()
        {
            CollectableManager.Instance.AddCollectable("Money", paymentAmount);
            moneyBubble.SetActive(false);
        }

    }
}
