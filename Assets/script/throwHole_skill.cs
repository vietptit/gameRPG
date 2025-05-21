using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class throwHole_skill : Skill
{
    [Header("Skill info")]
    [SerializeField] private GameObject holeBlack;
    [SerializeField] private Vector2 launchForce;
    [SerializeField] private float swordGravity;
    [Space]
    [Header("Aim dots")]
    [SerializeField] private int numberOfDots;
    [SerializeField] private float spaceBeetweenDots;
    [SerializeField] private GameObject dotPrefab;
    [SerializeField] private Transform dotsParent;
    GameObject[] dots;






    Vector2 finalDir;




    protected override void Start()
    {
        base.Start();
        generateDots();
    }
    public void CreateSword()
    {

        if (_player != null) Debug.Log("khac nul player");
        if (holeBlack != null) Debug.Log("khac nul holeback");
        GameObject newhole = Instantiate(holeBlack, _player.transform.position, transform.rotation);
        blackHole_controler newholeScript = newhole.GetComponent<blackHole_controler>();
        newholeScript.SetupHole(finalDir, swordGravity);
        DotsActive(false);
    }

    public Vector2 AimDirection()
    {
        Vector2 playerPosition = _player.transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - playerPosition;

        return direction;
    }


    protected override void Update()
    {
        base.Update();

        if (Input.GetKey(KeyCode.Mouse0))
        {
            for (int i = 0; i < numberOfDots; i++)
            {
                dots[i].transform.position = dotsPosition(i * spaceBeetweenDots);
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
            finalDir = new Vector2(AimDirection().normalized.x * launchForce.x, AimDirection().normalized.y * launchForce.y);

    }


    void generateDots()
    {
        dots = new GameObject[numberOfDots];
        for (int i = 0; i < numberOfDots; i++)
        {
            dots[i] = Instantiate(dotPrefab, _player.transform.position, transform.rotation, dotsParent);
            dots[i].SetActive(false);
        }
    }

    Vector2 dotsPosition(float t)
    {
        Vector2 position = (Vector2)_player.transform.position +
        new Vector2(AimDirection().normalized.x * launchForce.x, AimDirection().normalized.y * launchForce.y)
        * t + 0.5f * (Physics2D.gravity * swordGravity) * t * t;

        return position;
    }

    public void DotsActive(bool check)
    {
        for (int i = 0; i < numberOfDots; i++)
        {
            dots[i].SetActive(check);
        }
    }
    


    


}
