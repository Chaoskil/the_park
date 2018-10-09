﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    [SerializeField]
    private float inactiveRotationSpeed = 100, activatedRotationSpeed = 300;

    [SerializeField]
    private float inactivatedScale = 1, activatedScale = 1.5f;

    [SerializeField]
    private Color inactivatedColor, activatedColor;

    private bool isActivated = false;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        UpdateRotation();
        UpdateScale();
    }

    private void UpdateColor()
    {
        Color color = inactivatedColor;

        if (isActivated)
        {
            color = activatedColor;
        }

        spriteRenderer.color = color;
    }
    private void UpdateScale()
    {
        float scale = inactivatedScale;

        if (isActivated)
        {
            scale = activatedScale;
        }

        transform.localScale = Vector3.one * scale;
    }
    private void UpdateRotation()
    {
        float rotationSpeed = inactiveRotationSpeed;

        if (isActivated)
        {
            rotationSpeed = activatedRotationSpeed;
        }

        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player_Character player = collision.GetComponent<Player_Character>();
            player.SetCurrentCheckpoint(this);
        }
        else
        {

        }
    }

    public void SetIsActivated(bool value)
    {
        isActivated = value;
        UpdateScale();
        UpdateColor();
    }
}
