using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OverHeadButton : MonoBehaviour
{

	public Button Button;
	public GameObject Description;

	public void WhenOver()
	{
		Description.SetActive(true);
	}
	public void WhenLeave()
	{
		Description.SetActive(false);
	}
}
