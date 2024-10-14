using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Visualizator
{
    private Image _directionImage;
    private TMP_Text _velocityText;

    public Visualizator(Image directionImage, TMP_Text velocityText)
    {
        _directionImage = directionImage;
        _velocityText = velocityText;
    }

    public void ShowDirection(Vector3 direction)
    {
        Vector2 direction2D = new Vector2 (-direction.x, direction.z);

        float angle = Mathf.Atan2(direction2D.x, direction2D.y) * Mathf.Rad2Deg;

        _directionImage.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void ShowVelocity(float velocity)
    {
        _velocityText.text = "Velocity: " + velocity.ToString("F2");
    }
}
