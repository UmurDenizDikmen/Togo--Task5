using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CharacterState : MonoBehaviour
{
    public static CharacterState instance;
    public static float SpeedPlayer = 5f;
    Animator anim;
    private bool IsGameStart = false;
    List<GameObject> CollectableObject = new List<GameObject>();
    public Transform CollectableFinishPoint;
    Vector3 OffsetFinishPoint;
    public TextMeshProUGUI PointText;
    private int Score = 0;
    public GameObject PanelGameOver;


    void Start()
    {
        instance = this;
        PointText.text = Score.ToString();
        anim = transform.GetChild(0).GetComponent<Animator>();
        OffsetFinishPoint = new Vector3(0, 0.7f, 0);
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && IsGameStart == false)
        {
            anim.SetBool("IsRunnig", true);
            IsGameStart = true;
        }

    }
    private void FixedUpdate()
    {
        if (IsGameStart == true)
        {
            transform.Translate(Vector3.forward * SpeedPlayer * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            other.transform.gameObject.GetComponent<SmoothDamp>().enabled = true;
            other.transform.SetParent(transform.GetChild(1));
            isSmoothDamp(other.gameObject, 10);

        }
        else if (other.gameObject.CompareTag("Collectable1"))
        {
            other.transform.gameObject.GetComponent<SmoothDamp>().enabled = true;
            other.transform.SetParent(transform.GetChild(1));
            isSmoothDamp(other.gameObject, 15);

        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            GameObject Object = CollectableObject[CollectableObject.Count - 1];
            CollectableObject.Remove(Object);
            Destroy(Object);
            Destroy(other.gameObject);
        }

    }

    void isSmoothDamp(GameObject other, int ScoreIncrease)
    {
        if (CollectableObject.Count == 0)
        {
            other.transform.gameObject.GetComponent<SmoothDamp>().SetLeadTransform(transform.GetChild(0));
            other.transform.position = new Vector3(0, 0f, 2f) + transform.GetChild(1).position;
        }
        else
        {
            other.transform.gameObject.GetComponent<SmoothDamp>().SetLeadTransform(CollectableObject[CollectableObject.Count - 1].transform);
            other.transform.position = new Vector3(0, 0f, 2f) + CollectableObject[CollectableObject.Count - 1].transform.position;

        }
        CollectableObject.Add(other.gameObject);
        Score += ScoreIncrease;
        PointText.text = Score.ToString();
    }

    public IEnumerator GatheringObject2()
    {
        for (int i = 0; i < CollectableObject.Count; i++)
        {
            CollectableObject[i].transform.parent = null;
            CollectableObject[i].GetComponent<SmoothDamp>().enabled = false;

            CollectableObject[i].transform.position = CollectableFinishPoint.position;
            CollectableFinishPoint.position += OffsetFinishPoint;
            yield return new WaitForSeconds(0.5f);
            if (i == CollectableObject.Count - 1)
            {
                PanelGameOver.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
