using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip coinSFX;
    [SerializeField] AudioClip dobleJumpSFX;
    [SerializeField] AudioClip jumpSFX;
    [SerializeField] AudioClip powerUpDobleJumpSFX;
    [SerializeField] AudioClip powerUpShieldSFX;
    [SerializeField] AudioClip shieldBreakSFX;
    [SerializeField] AudioClip gameOverHitSFX;
    //[SerializeField] AudioClip landSFX;

    public void PlayAudioSFX(string referenceAudioSFX) 
    {

        switch (referenceAudioSFX) //Mejor utilizar un switch que if anidados
        {
            case "Coin":

                audioSource.clip = coinSFX;
                break;

            case "Jump":

                audioSource.clip = jumpSFX;
                break;

            case "DobleJump":

                audioSource.clip = dobleJumpSFX;
                break;
            case "PowerUpDobleJump":

                audioSource.clip = powerUpDobleJumpSFX;
                break;
            case "PowerUpShield":

                audioSource.clip = powerUpShieldSFX;
                break;
            case "ShieldBreak":

                audioSource.clip = shieldBreakSFX;
                break;
            case "GameOverHit":

                audioSource.clip = gameOverHitSFX;
                break;

        }

        audioSource.Play();

        /*
        if (referenceAudioSFX == "Land")
        {
            audioSource.clip = landSFX;
        }
       */


    }
}
