using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.AI_Utility
{
	public enum EDataType
	{
		Add,
		Multiply,
	}
	public class Curve
	{
		[SerializeField]
		private AnimationCurve m_curve;
		[SerializeField]
		private float m_xNormValue;
		[SerializeField]
		private float m_yNormValue;

		[SerializeField]
		private EDataType m_type;

		public void Evaluate(float valueForCurve, ref float totalAdd, ref float totalMultiply)
		{
			var value = m_curve.Evaluate(valueForCurve / m_xNormValue) * m_yNormValue;

			if (m_type == EDataType.Add)
				totalAdd += value;
			else
				totalMultiply += value;
		}
	}
}