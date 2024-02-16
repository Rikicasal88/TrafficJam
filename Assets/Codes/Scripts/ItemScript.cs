using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public int MoneyValue;
    public float Duration;

    private void OnEnable()
    {
        StartCoroutine(Life_Co());
    }

    public IEnumerator Life_Co()
    {
        float timer = 0;

        while (timer < Duration)
        {
            yield return null;
           
            timer += Time.deltaTime;
        }
        gameObject.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag.Equals("Player"))
        {
            AudioManagerScript.instance.PlayOneShot(AudioClipType.Money);
            PoolManagerScript.instance.GetParticlesFromPool(ParticleType.Money).transform.position = other.transform.position;
            GameManagerScript.instance.Money += MoneyValue;
            gameObject.SetActive(false);
        }
    }
}
