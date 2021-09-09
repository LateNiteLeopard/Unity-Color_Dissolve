using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Sirenix.OdinInspector;

namespace Nieva.Effects
{
    public class TestSinDissolve : MonoBehaviour
    {
		[BoxGroup("Test Settings")]
        [SerializeField] private Material material;
		[BoxGroup("Test Settings"), ColorUsage(true, true)]
		[SerializeField] private Color color = Color.white;
		[BoxGroup("Test Settings")]
        [SerializeField] private AnimationCurve curve;
		[BoxGroup("Test Settings")]
		[SerializeField] private float waitAfter;
		[BoxGroup("Test Settings")]
		[SerializeField] private float speed;

		private void Start()
		{
			material = GetComponent<SpriteRenderer>().material;

			material.SetColor("_EdgeColor", color);

			waitAfter = Time.time + Random.Range(1.5f, 3);
			speed = Random.Range(0.25f, 1);
		}

		private void Update()
		{
			if (Time.time > waitAfter)
			{
				material.SetFloat("_ColorAmount", Mathf.Abs(Mathf.PingPong(Time.time * speed, 1) * -1));
			}
		}
	}
}
