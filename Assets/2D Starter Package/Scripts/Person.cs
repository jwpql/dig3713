using DigitalWorlds.Dialogue;
using Unity.VisualScripting;
using UnityEngine;

/*
 * Manages individual customers (orders, dialogue)
 */

namespace DigitalWorlds.StarterPackage2D { 
public class Person : MonoBehaviour
{
        public Sprite sitSprite = null;
        public SpriteRenderer spriteRenderer;
        public Group group;
        public GameObject foodBubble = null;
        //public BoxCollider2D boxCollider = null;
        ButtonEvents2D buttonEvent = null;
        public GameObject foodSprite = null;
        public GameObject talkBubble = null;
        public int orderID = 0;
        public bool tookOrder = false;
        public Renderer renderer;
        //needed to hide food bubble at start

        void Start()
        {
            renderer = GetComponent<Renderer>();
            renderer.sortingOrder = -(int)(GetComponent<Collider2D>().bounds.min.y * 1000);
            buttonEvent = GetComponent<ButtonEvents2D>();
            if (buttonEvent != null)
            {
                buttonEvent.enabled = false;
            }
            if (foodBubble != null)
            {
                foodBubble.SetActive(false);
            }
            if(talkBubble != null)
            {
                talkBubble.SetActive(false);
            }
        }
        public void sitL() //sit on left side of table facing right
        {
            spriteRenderer.flipX = true;
            spriteRenderer.sprite = sitSprite;
            if (foodBubble != null)
            {
                foodBubble.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + (float) 1.2);
                foodBubble.SetActive(true);
            }
            if (buttonEvent != null)
            {
                buttonEvent.enabled = true;
            }
            if (foodSprite != null)
            {
                foodSprite.transform.position = new Vector3(this.transform.position.x + (float)1, this.transform.position.y - (float)0.5);
            }
            if (talkBubble != null)
            {
                talkBubble.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + (float)1.2);
                if (orderID == 0)
                {
                    talkBubble.SetActive(true);
                }
            }
        }

        public void sitR()
        {
            spriteRenderer.flipX = false;
            spriteRenderer.sprite = sitSprite;
            if (foodBubble != null)
            {
                foodBubble.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + (float) 1.2);
                foodBubble.SetActive(true);
            }
            if (buttonEvent != null)
            {
                buttonEvent.enabled = true;
            }
            if (foodSprite != null)
            {
                foodSprite.transform.position = new Vector3(this.transform.position.x - (float)1, this.transform.position.y - (float)0.5);
            }
            if (talkBubble != null)
            {
                talkBubble.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + (float)1.2);
                if (orderID == 0)
                {
                    talkBubble.SetActive(true);
                }
            }
        }

        public void order()
        {
            if (orderID == 0)
            {
                return; //does nothing if customer wants nothing
            }
            group.tableManager.playInteractSound();
            if (tookOrder == true)
            {
                if (orderID == 1)
                {
                    if (CollectableManager.Instance.FindCollectable("Food1").count > 0)
                    {
                        foodSprite.SetActive(true);
                        buttonEvent.enabled = false;
                        group.decrementOrder();
                        CollectableManager.Instance.AddCollectable("Order1", -1);
                        CollectableManager.Instance.AddCollectable("Food1", -1);
                        if(talkBubble != null)
                        {
                            Invoke(nameof(enableTalkBubble), 1f);
                        }
                    }
                        
                }
                if (orderID == 2)
                {
                    if (CollectableManager.Instance.FindCollectable("Food2").count > 0)
                    {
                        foodSprite.SetActive(true);
                        buttonEvent.enabled = false;
                        group.decrementOrder();
                        CollectableManager.Instance.AddCollectable("Order2", -1);
                        CollectableManager.Instance.AddCollectable("Food2", -1);
                        if (talkBubble != null)
                        {
                            Invoke(nameof(enableTalkBubble), 1f);
                        }
                    }

                }
                if (orderID == 3)
                {
                    if (CollectableManager.Instance.FindCollectable("Food3").count > 0)
                    {
                        foodSprite.SetActive(true);
                        buttonEvent.enabled = false;
                        group.decrementOrder();
                        CollectableManager.Instance.AddCollectable("Order3", -1);
                        CollectableManager.Instance.AddCollectable("Food3", -1);
                        if (talkBubble != null)
                        {
                            Invoke(nameof(enableTalkBubble), 1f);
                        }
                    }

                }

            }
            else if (tookOrder == false)
            {
                tookOrder = true;
                foodBubble.SetActive(false);
                if(orderID == 1)
                {
                     CollectableManager.Instance.AddCollectable("Order1", 1);
                }
                else if (orderID == 2)
                {
                    CollectableManager.Instance.AddCollectable("Order2", 1);
                }
                else if (orderID == 3)
                {
                    CollectableManager.Instance.AddCollectable("Order3", 1);
                }
            }
        }

        void enableTalkBubble()
        {
            talkBubble.SetActive(true);
        }

        // ik i shouldnt call this every frame BUT IT DOESNT WORK OTHERWISE... AM I STUPID
        private void LateUpdate()
        {
            renderer.sortingOrder = -(int)(GetComponent<Collider2D>().bounds.min.y * 1000);
        }
    }
}