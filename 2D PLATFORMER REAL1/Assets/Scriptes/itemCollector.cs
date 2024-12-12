using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemCollector : MonoBehaviour
{
   
        private int Banana = 0;

        [SerializeField] private Text BananaText;
        [SerializeField] private AudioClip pickSound;

    //[SerializeField] private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Banana"))
            {
            SoundManager.instance.PlayerSound(pickSound);

            Destroy(collision.gameObject);
                Banana++;
                BananaText.text = " " + Banana;
            }
        }
    
}

