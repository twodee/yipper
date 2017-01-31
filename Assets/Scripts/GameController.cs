using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
  public Transform start;
  public Transform stop;
  public GameObject ball;
  public Text maximum;

  public Dictionary<int, List<List<int>>> trials;

  void Start() {
    trials = new Dictionary<int, List<List<int>>>();

    trials[1] = new List<List<int>>();
    trials[1].Add(new List<int>() {1, 0, 1, 0});
    trials[1].Add(new List<int>() {1, 1, 1, 0, 1});

    trials[2] = new List<List<int>>();
    trials[2].Add(new List<int>() {1, 2, 1, 0, 2});
    trials[2].Add(new List<int>() {2, 0, 2, 1, 1});

    trials[3] = new List<List<int>>();
    trials[3].Add(new List<int>() {2, 3, 0, 1, 2, 1});
    trials[3].Add(new List<int>() {3, 0, 2, 0, 3});

    trials[4] = new List<List<int>>();
    trials[4].Add(new List<int>() {4, 2, 0});
    trials[4].Add(new List<int>() {4, 1, 2, 2, 3, 0});

    trials[5] = new List<List<int>>();
    trials[5].Add(new List<int>() {5, 3, 2, 4, 0, 1});
    trials[5].Add(new List<int>() {3, 3, 5, 0, 2, 3, 1});

    trials[8] = new List<List<int>>();
    trials[8].Add(new List<int>() {8, 1, 3, 2});
    trials[8].Add(new List<int>() {6, 3, 4, 5});
  }
  
  void Update() {
  }

  public void Go() {
    StartCoroutine(Slide());
  }

  IEnumerator Slide() {
    int max = int.Parse(maximum.text);
    List<int> digits = trials[max][0];
    trials[max].RemoveAt(0);

    while (digits.Count > 0) {
      int digit = digits[0];
      digits.RemoveAt(0);

      float proportion = digit / (float) max;
      Color color = new Color(0.0f, proportion, 0.0f);

      ball.GetComponent<Renderer>().material.color = color;

      float startTime = Time.time;
      float targetDuration = 6.0f;

      float elapsed = Time.time - startTime;
      while (elapsed < targetDuration) {
        ball.transform.position = Vector3.Lerp(start.position, stop.position, elapsed / targetDuration);
        elapsed = Time.time - startTime;
        yield return null;
      }
    }
  }
}
