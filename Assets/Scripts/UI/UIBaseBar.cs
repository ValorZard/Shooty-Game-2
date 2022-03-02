/*
    Programmer: Manhattan Calabro
*/

using UnityEngine;

abstract public class UIBaseBar : MonoBehaviour
{
    // Protected variables
        // The starting (max) value
        protected float startingValue;
        // The current value
        protected float currentValue;

    // Update is called once per frame
    void Update()
    {
        // Update the values
        UpdateValues();
    }

    // Update the display
    protected void UpdateDisplay()
    {
        // The percentage of the values
        float percentValue = currentValue / startingValue;

        // Scale the bar meter according to the percentage
        transform.localScale = new Vector3(percentValue, transform.localScale.y, transform.localScale.z);
    }

    // Update the bar meter
    abstract protected void UpdateValues();
}
