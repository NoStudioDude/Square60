using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class ResizeBackgroundToScreen : MonoBehaviour {

	SpriteRenderer sr = null;
	void Start()
	{
		sr = GetComponent<SpriteRenderer>();
		if (sr == null)
			Debug.LogError("Can't find background sprite renderer");
		else
			ResizeSpriteToScreen();

	}
	void ResizeSpriteToScreen()
	{
		float sWidth = sr.bounds.size.x;
		float sHeight = sr.bounds.size.y;

		float sWorldHeight = Camera.main.orthographicSize * 2.0f;
		float sWorlWidth = sWorldHeight / Screen.height * Screen.width;

		Vector3 xWidth = transform.localScale;
		xWidth.x = (sWorlWidth / sWidth);

		transform.localScale = xWidth;

		Vector3 yHeight = transform.localScale;
		yHeight.y = (sWorldHeight / sHeight);

		transform.localScale = yHeight;

	}
}
