using UnityEngine;
using System.Collections;


/// <summary>
/// Fading component that can help you fade in/out menu items (or anything on a canvas, really).
/// </summary>
[RequireComponent(typeof(CanvasRenderer))]
public class CanvasFader : MonoBehaviour {

    /// <summary>
    /// The time that the fade should take, in seconds.
    /// </summary>
    public float fadeTime = 2.0f;
    /// <summary>
    /// The time this fader should wait before it starts fading.
    /// </summary>
    public float fadeDelay = 2.0f;

    // internal flag for stopping a fade
    private bool stopFading = false;

    /// <summary>
    /// Hide the element immediately, stopping any fades.
    /// </summary>
    public void hide()
    {
        setAlpha(0.01f);
        this.stopFading = true;
    }

    /// <summary>
    /// Show the element immediately, stopping any fades.
    /// </summary>
    public void show()
    {
        setAlpha(1);
        this.stopFading = true;
    }

    /// <summary>
    /// Make the element slowly visible until it is fully opaque.
    /// </summary>
    public void fadeIn()
    {
        this.fadeIn(this.fadeTime, this.fadeDelay);
    }

    /// <summary>
    /// Make the element slowly visible in a certain timespan.
    /// </summary>
    /// <param name="fadeTime"></param>
    public void fadeIn(float fadeTime)
    {
        this.fadeIn(fadeTime, this.fadeDelay);
    }

    /// <summary>
    /// Make the element slowly visible, after the given delay, for the given time.
    /// </summary>
    /// <param name="fadeTime"></param>
    /// <param name="fadeDelay"></param>
    public void fadeIn(float fadeTime, float fadeDelay)
    {
        this.stopFading = false;
        StartCoroutine(fade(255, fadeTime, fadeDelay));
    }


    /// <summary>
    /// Make the element slowly invisible until it is fully opaque.
    /// </summary>
    public void fadeOut()
    {
        this.fadeOut(this.fadeTime, this.fadeDelay);
    }

    /// <summary>
    /// Make the element slowly invisible in a certain timespan.
    /// </summary>
    /// <param name="fadeTime"></param>
    public void fadeOut(float fadeTime)
    {
        this.fadeOut(fadeTime, this.fadeDelay);
    }

    /// <summary>
    /// Make the element slowly visible, after the given delay, for the given time.
    /// </summary>
    /// <param name="fadeTime"></param>
    /// <param name="fadeDelay"></param>
    public void fadeOut(float fadeTime, float fadeDelay)
    {
        this.stopFading = false;
        StartCoroutine(fade(0, fadeTime, fadeDelay));
    }

    /// <summary>
    /// Set the alpha value of our element (and all its children).
    /// </summary>
    /// <param name="a"></param>
    private void setAlpha(float a)
    {
        foreach (Transform child in transform)
        {
            CanvasRenderer r = child.GetComponent<CanvasRenderer>();
            if (r)
            {
                r.SetAlpha(a);
            }
        }
        this.GetComponent<CanvasRenderer>().SetAlpha(a);
    }

    /// <summary>
    /// Get the current alpha value for this element (does not read anything from the children).
    /// </summary>
    /// <returns>Current alpha as float between 0 and 1 (probably).</returns>
    private float getAlpha()
    {
        this.GetComponent<CanvasRenderer>().GetAlpha();
    }


    // actual fading coroutine
    private IEnumerator fade(float target, float fadeTime, float fadeDelay)
    {
        float a = getAlpha();

        for (float t = 0; t < fadeDelay; t += Time.deltaTime)
        {
            if (this.stopFading) { yield break; }
            yield return null;
        }
        for (float t = 0; t < fadeTime; t += Time.deltaTime)
        {
            if (this.stopFading) { yield break; }
            setAlpha(Mathf.Lerp(a, target, t / fadeTime));
            yield return null;
        }

        setAlpha(255);
    }


}
