using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{

    private List<Key.KeyType> keyList;

    private void Awake()
    {
        keyList = new List<Key.KeyType>();
    }

    public void AddKey(Key.KeyType keyType)
    {
        
        keyList.Add(keyType);
    }

    public void RemoveKey(Key.KeyType keyType)
    {
        keyList.Remove(keyType);
    }

    public bool ContainsKey(Key.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        

            
            Key key = collider.GetComponent<Key>();
                if(key != null)
                {
                    AddKey(key.GetKeyType());
                    Destroy(key.gameObject);
                }
            BossDoor2 bossDoor2 = collider.GetComponent<BossDoor2>();
            if (bossDoor2 != null)
            {


                if (ContainsKey(bossDoor2.GetKeyType()))
                {

                    //RemoveKey(bossDoor.GetKeyType());
                    bossDoor2.OpenDoor();
                }
            }

            BossDoor1 bossDoor = collider.GetComponent<BossDoor1>();
            if(bossDoor != null)
            {
            

                if(ContainsKey(bossDoor.GetKeyType()))
                {
                
                //RemoveKey(bossDoor.GetKeyType());
                bossDoor.OpenDoor();
                }
            }

            GoldDoor goldDoor = collider.GetComponent<GoldDoor>();
            if (goldDoor != null)
            {


                if (ContainsKey(goldDoor.GetKeyType()))
                {

                //RemoveKey(bossDoor.GetKeyType());
                goldDoor.OpenDoor();
                }
            }

            GoldDoor1 goldDoor1 = collider.GetComponent<GoldDoor1>();
            if (goldDoor1 != null)
            {


                if (ContainsKey(goldDoor1.GetKeyType()))
                {

                    //RemoveKey(bossDoor.GetKeyType());
                    goldDoor1.OpenDoor();
                }
            }

            ShieldDoor shieldDoor = collider.GetComponent<ShieldDoor>();
            if (shieldDoor != null)
            {


                if (ContainsKey(shieldDoor.GetKeyType()))
                {

                    //RemoveKey(bossDoor.GetKeyType());
                    shieldDoor.OpenDoor();
                }
            }

            ShieldDoor1 shieldDoor1 = collider.GetComponent<ShieldDoor1>();
            if (shieldDoor1 != null)
            {


                if (ContainsKey(shieldDoor1.GetKeyType()))
                {

                    //RemoveKey(bossDoor.GetKeyType());
                    shieldDoor1.OpenDoor();
                }
            }
    }

    
}
