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
        print("added: " + keyType);
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
        print("hi");
        Key key = collider.GetComponent<Key>();
        if(key != null)
        {
            AddKey(key.GetKeyType());
            Destroy(key.gameObject);
        }

        BossDoor1 bossDoor = collider.GetComponent<BossDoor1>();
        if(bossDoor != null)
        {
            print("keytime");

            if(ContainsKey(bossDoor.GetKeyType())) {
                //WE got the KEY BOIS
                //RemoveKey(bossDoor.GetKeyType());
                bossDoor.OpenDoor();
            }
        }
    }

    
}
