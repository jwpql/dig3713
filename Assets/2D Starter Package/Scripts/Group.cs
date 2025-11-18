/*
 * Managers groups of customers (max group size = 4)
 */

using DigitalWorlds.Dialogue;
using DigitalWorlds.StarterPackage2D;
using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

namespace DigitalWorlds.StarterPackage2D
{
    public class Group : MonoBehaviour
    {
        public Person one = null;
        public Person two = null;
        public Person three = null;
        public Person four = null;
        public TableManager tableManager = null;
        int tableNum = 0; 

        public GameObject exclamationBubble;
        public BoxCollider2D boxCollider;
        public float secUntilEnter = 0; // set to -1 if you want something else to trigger their entrance
        DialogueManager dialogueManager;
        public GameObject[] after = {}; //if you want more groups to enter after this one leaves
           
        //automatically set
        int size = 1;
        int numDialogues = 0;
        int numOrders = 1;
        float timer = 300;

        private void Start()
        {
            dialogueManager = FindAnyObjectByType<DialogueManager>();
            boxCollider.enabled = false;
            numDialogues = 0;
            size = 0;
            numOrders = 0;
            exclamationBubble.SetActive(false);  
            if (one != null)
            {
                size++;
                one.group = this;
                one.gameObject.SetActive(false);
                if(one.talkBubble != null)
                {
                    numDialogues++;
                }
                if(one.orderID!=0)
                {
                    numOrders++;
                }
            }
            if (two != null)
            {
                size++;
                two.group = this;
                two.gameObject.SetActive(false);
                if (two.talkBubble != null)
                {
                    numDialogues++;
                }
                if (two.orderID != 0)
                {
                    numOrders++;
                }
            }
            if (three != null)
            {
                size++;
                three.group = this;
                three.gameObject.SetActive(false);
                if (three.talkBubble != null)
                {
                    numDialogues++;
                }
                if (three.orderID != 0)
                {
                    numOrders++;
                }
            }
            if (four != null)
            {
                size++;
                four.group = this;
                four.gameObject.SetActive(false);
                if (four.talkBubble != null)
                {
                    numDialogues++;
                }
                if (four.orderID != 0)
                {
                    numOrders++;
                }
            }
            if(secUntilEnter > -1)
            {
                Invoke(nameof(enter), secUntilEnter);
            }
            
        }

        void enter()
        {
            tableManager.playEnterSound();
            timer = 300;
            exclamationBubble.SetActive(true); 
            if (one != null)
            {
                one.gameObject.SetActive(true); 
            }
            if (two != null)
            {
                two.gameObject.SetActive(true);
            }
            if (three != null)
            {
                three.gameObject.SetActive(true);
            }
            if (four != null)
            {
                four.gameObject.SetActive(true);
            }
            boxCollider.enabled = true;
        }

        //moves people to table
        public bool seatAt(int table)
        {
            if(tableManager == null)
            {
                Debug.LogWarning("TableManager not found!");
                return false;
            }

            tableNum = table;
            Destroy(boxCollider);


            if (table==1 && size < 3)
            {
                if (one != null)
                {
                    one.transform.position = new Vector3((float)-6.53, (float)0.39);
                    one.sitL();
                }
                if (two != null) 
                { 
                    two.transform.position = new Vector3((float)-4.58, (float)0.39);
                    two.sitR();
           
                }
                return true;
            }

            else if(table==2 && size < 3)
            {
                if (one != null)
                {
                    one.transform.position = new Vector3((float)-1.52, (float)0.39);
                    one.sitL();
                }
                if (two != null)
                {
                    two.transform.position = new Vector3((float)0.51, (float)0.39);
                    two.sitR();
                }
                return true;
            }

            else if(table == 3 && size < 5)
            {
                if (one != null)
                {
                    one.transform.position = new Vector3((float)-7.53, (float)-2.55);
                    one.sitL();
                }
                if (two != null)
                {
                    two.transform.position = new Vector3((float)-4.52, (float)-2.55);
                    two.sitR();
                }
                if (three != null)
                {
                    three.transform.position = new Vector3((float)-7.53, (float)-3.63);
                    three.sitL();
                }
                if (four != null)
                {
                    four.transform.position = new Vector3((float)-4.52, (float)-3.63);
                    four.sitR();
                }
                return true;
            }

            else if (table == 4 && size < 5)
            {
                if (one != null)
                {
                    one.transform.position = new Vector3((float)-1.51, (float)-2.55);
                    one.sitL();
                }
                if (two != null)
                {
                    two.transform.position = new Vector3((float)1.53, (float)-2.55);
                    two.sitR();
                }
                if (three != null)
                {
                    three.transform.position = new Vector3((float)-1.51, (float)-3.63);
                    three.sitL();
                }
                if (four != null)
                {
                    four.transform.position = new Vector3((float)1.53, (float)-3.63);
                    four.sitR();
                }
                return true;
            }
            else
            {
                tableManager.textArea.canvasRenderer.SetAlpha(1f);
                tableManager.textArea.text = "Can't choose this table.";
                tableManager.textArea.CrossFadeAlpha(0, 3.0f, true);
            }
                return false;

        }
        public void takeOrder()
        {
            if(tableManager == null)
            {
                Debug.LogWarning("TableManager not found!");
                return;
            }

            if(tableManager.waiting == null) //no other group is waiting for a seat
            {
                tableManager.playInteractSound();
                if (tableManager.hasValidTable(size))
                {
                    tableManager.waiting = this;
                    exclamationBubble.SetActive(false);
                }
            }
            else
            {
                if (dialogueManager.IsInDialogue == false)
                {
                    tableManager.textArea.canvasRenderer.SetAlpha(1f);
                    tableManager.textArea.text = "Another group is waiting to be seated.";
                    tableManager.textArea.CrossFadeAlpha(0, 3.0f, false);
                }            }
        }

        public void decrementOrder()
        {
            tableManager.playInteractSound();
            numOrders--;
        }

        public void decrementDialogue()
        {
            if(numDialogues != 0)
            {
                numDialogues--;
            }
            
        }

        private void Update()
        {
            if (numOrders == 0 && numDialogues == 0)
            {
                if (dialogueManager.IsInDialogue == false)
                {
                    Invoke(nameof(leave), 7f); //makes group leave after 7sec
                    numOrders = -1; //prevents multiple invokes
                }
               
            }
            if(numOrders != 0 && timer >= 0)
            {
                timer -= Time.deltaTime;
            }
        }

        void leave()
        {
            tableManager.playExitSound();
            //calculate money based on time
            int earnings = 10 * size;
            earnings += (int)(timer/80)*10;
            CollectableManager.Instance.AddCollectable("Money", earnings);
            tableManager.addMoney(earnings);

            //make other groups enter
            if (after.Length > 0)
            {
                foreach(GameObject g in after)
                {
                    g.SetActive(true);
                }
            }

            //get rid of everything
            tableManager.freeTable(tableNum);
            CollectableManager.Instance.AddCollectable("GuestCount", 1);
            if (one != null)
            {
                if(one.foodSprite != null)
                {
                    one.foodSprite.SetActive(false);
                }
                if (one.talkBubble != null)
                {
                    one.talkBubble.SetActive(false);
                }   
                Destroy(one.gameObject);
            }
            if (two != null)
            {
                if (two.foodSprite != null) {
                    two.foodSprite.SetActive(false);
                }
                if (two.talkBubble != null)
                {
                    two.talkBubble.SetActive(false);
                }   
                Destroy(two.gameObject);
            }
            if (three != null)
            {
                if (three.foodSprite != null)
                {
                    three.foodSprite.SetActive(false);
                }
                if (three.talkBubble != null)
                {
                    three.talkBubble.SetActive(false);
                }
                Destroy(three.gameObject);
            }
            if (four != null)
            {
                if (four.foodSprite != null)
                {
                    four.foodSprite.SetActive(false);
                }
                if (four.talkBubble != null)
                {
                    four.talkBubble.SetActive(false);
                }
                Destroy(four.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}

/*
 * For dialogue- there are 3 possible points where you can talk to people
 * While theyre standing, when they order, after they order
 * 
 * While they're standing/when you order dialogue use colliders on the group/ person. 
 * cant really avoid triggering those
 * everything else uses the * bubble collider
 * 
 * numDialogues count number of dialogues not linked to seating/ordering
 * numDialogues is decremented using the 2d button event thing
 * 
 * customers wont leave until you talk to them
 * 
 * this is so scuffed im sorry
*/