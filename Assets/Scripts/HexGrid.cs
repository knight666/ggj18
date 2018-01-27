using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGrid : MonoBehaviour
{
	public Material m_material;
	private Vector3 m_startVertex = new Vector3(0, 0, 0);
	private Vector3 m_cursorPosition;
	private Matrix4x4 m_cubeRotate = new Matrix4x4(
		new Vector4(Mathf.Sqrt(3.0f),         0,            0.0f, 0.0f),
		new Vector4(Mathf.Sqrt(3.0f) / 2.0f,  3.0f / 2.0f,  0.0f, 0.0f),
		new Vector4(0.0f,                     0.0f,         0.0f, 0.0f),
		new Vector4(0.0f,                     0.0f,         0.0f, 1.0f)
	);
	private Vector3[] m_corners = new Vector3[6];

	public const float outerRadius = 10f;
	public const float innerRadius = outerRadius * 0.866025404f;
	public static Vector3[] corners = {
		new Vector3(0f, 0f, outerRadius),
		new Vector3(innerRadius, 0f, 0.5f * outerRadius),
		new Vector3(innerRadius, 0f, -0.5f * outerRadius),
		new Vector3(0f, 0f, -outerRadius),
		new Vector3(-innerRadius, 0f, -0.5f * outerRadius),
		new Vector3(-innerRadius, 0f, 0.5f * outerRadius),
		new Vector3(0f, 0f, outerRadius)
	};

	public List<GameObject> m_controlPoints = new List<GameObject>();

	HexGrid()
	{
		m_cubeRotate *= Matrix4x4.Scale(new Vector3(10.0f, 10.0f, 1.0f));

		for (var i = 0; i < 6; ++i)
		{
			var angle = Mathf.Deg2Rad * (30.0f + (i * 60.0f));
			m_corners[i] = m_cubeRotate * new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0.0f);
		}
	}

	void Start()
	{
		var transforms = GetComponentsInChildren<Transform>();
		foreach (var transform in transforms)
		{
			Debug.Log(transform.gameObject.tag);
			if (transform.gameObject.tag == "Control")
			{
				m_controlPoints.Add(transform.gameObject);
			}
		}
	}

	void Update()
	{
		m_cursorPosition = Input.mousePosition;
		if (Input.GetKeyDown(KeyCode.Space))
		{
			m_startVertex = new Vector3(m_cursorPosition.x / Screen.width, m_cursorPosition.y / Screen.height, 0);
		}
	}

	void OnPostRender()
	{
		if (!m_material)
		{
			Debug.LogError("Please Assign a material on the inspector");
			return;
		}

		var toScreenSpace = new Vector3(1.0f / Screen.width, 1.0f / Screen.height, 1.0f);

		GL.PushMatrix();
		m_material.SetPass(0);
		GL.LoadOrtho();
		GL.Begin(GL.LINES);
		GL.Color(Color.red);

		GL.Vertex(m_startVertex);
		GL.Vertex(Vector3.Scale(m_cursorPosition, toScreenSpace));

		var position = m_cursorPosition;
		GL.Vertex(Vector3.Scale(corners[0] + position, toScreenSpace));

		for (var i = 1; i < 6; ++i)
		{
			GL.Vertex(Vector3.Scale(corners[i] + position, toScreenSpace));
		}

		GL.End();
		GL.PopMatrix();
	}
}
