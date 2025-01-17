using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class NetGoalManager : MonoBehaviour
{
    [SerializeField] private AudioSource goalAudio;
    public int score = 0;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject messageText;

    private void Start()
    {
        scoreText.text = score.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            goalAudio.Play();
            score += 1;
            scoreText.text = score.ToString();
            messageText.SetActive(true);
            Wait();
            messageText.SetActive(false);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
    }
}