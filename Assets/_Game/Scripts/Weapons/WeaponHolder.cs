using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float offSet;

    void Update()
    {
        HandleAiming();
    }

    private void HandleAiming()
    {
        Vector2 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);

        Vector3 playerToMouseDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.position;
        playerToMouseDirection.z = 0;
        transform.position = player.position + (offSet * playerToMouseDirection.normalized);

        Vector3 localScale = Vector3.one;

        if(angle > 90 ||  angle < -90)
        {
            localScale.y = -1f;
        }else
        {
            localScale.y = 1;
        }

        transform.localScale = localScale;
    }
}
