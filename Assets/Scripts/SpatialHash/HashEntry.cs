using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashEntry<K, V> : MonoBehaviour
{
    K key;
    V value;
    HashEntry<K, V> next;

    public K Key { get => key; }
    public V Value { get => value; set => this.value = value; }
    public HashEntry<K, V> Next { get => next; set => next = value; }

    public HashEntry(K key, V value)
    {
        this.key = key;
        this.value = value;
    }
}
