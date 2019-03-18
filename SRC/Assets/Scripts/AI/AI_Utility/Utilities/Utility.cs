using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.AI_Utility
{
	public struct Utility : IEquatable<Utility>, IComparable<Utility>
	{
		private float m_value;
		private float m_weight;

		public float Value
		{
			get { return m_value; }
			set { m_value = Mathf.Clamp01(value); }
		}
		public float Weight
		{
			get { return m_weight; }
			set { m_weight = Mathf.Clamp01(value); }
		}

		public Utility(float value)
		{
			m_value = Mathf.Clamp01(value);
			m_weight = 1.0f;
		}

		public Utility(float value, float weight)
		{
			m_value = Mathf.Clamp01(value);
			m_weight = Mathf.Clamp01(weight);
		}


		public float Combined
		{
			get { return m_value * m_weight; }
		}

		public int CompareTo(Utility other)
		{
			return Combined.CompareTo(other.Combined);
		}

		public bool Equals(Utility other)
		{
			return AeqB(Value, other.Value) && AeqB(Weight, other.Weight);
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;

			var util = (Utility)obj;
			return Equals(util);
		}

		public override int GetHashCode()
		{
			return Combined.GetHashCode();
		}

		public override string ToString()
		{
			return string.Format("[Utility: Value={0}, Weight={1}, Combined={2}]", Value, Weight, Combined);
		}

		private static bool AeqB(float a, float b)
		{
			var df = Math.Abs(a - b);
			return Math.Abs(a - b) < Mathf.Epsilon;
		}

		#region operator


		/// <param name="a">The alpha component.</param>
		public static implicit operator Utility(float a)
		{
			return new Utility(a);
		}

		/// <param name="a">The alpha component.</param>
		/// <param name="b">The blue component.</param>
		public static bool operator ==(Utility a, Utility b)
		{
			return AeqB(a.Value, b.Value) && AeqB(a.Weight, b.Weight);
		}

		/// <param name="a">The alpha component.</param>
		/// <param name="b">The blue component.</param>
		public static bool operator !=(Utility a, Utility b)
		{
			return !AeqB(a.Value, b.Value) || !AeqB(a.Weight, b.Weight);
		}

		/// <param name="a">The alpha component.</param>
		/// <param name="b">The blue component.</param>
		public static bool operator >(Utility a, Utility b)
		{
			return a.Combined > b.Combined;
		}

		/// <param name="a">The alpha component.</param>
		/// <param name="b">The blue component.</param>
		public static bool operator <(Utility a, Utility b)
		{
			return a.Combined < b.Combined;
		}

		/// <param name="a">The alpha component.</param>
		/// <param name="b">The blue component.</param>
		public static bool operator >=(Utility a, Utility b)
		{
			return a.Combined >= b.Combined;
		}

		/// <param name="a">The alpha component.</param>
		/// <param name="b">The blue component.</param>
		public static bool operator <=(Utility a, Utility b)
		{
			return a.Combined <= b.Combined;
		}

		#endregion
	}
}
