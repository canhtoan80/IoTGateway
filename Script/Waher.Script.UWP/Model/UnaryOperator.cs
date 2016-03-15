﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Waher.Script.Model
{
	/// <summary>
	/// Base class for all unary operators.
	/// </summary>
	public abstract class UnaryOperator : ScriptNode
	{
		/// <summary>
		/// Operand.
		/// </summary>
		protected ScriptNode op;

		/// <summary>
		/// Base class for all unary operators.
		/// </summary>
		/// <param name="Operand">Operand.</param>
		/// <param name="Start">Start position in script expression.</param>
		/// <param name="Length">Length of expression covered by node.</param>
		public UnaryOperator(ScriptNode Operand, int Start, int Length)
			: base(Start, Length)
		{
			this.op = Operand;
		}

		/// <summary>
		/// Operand.
		/// </summary>
		public ScriptNode Operand
		{
			get { return this.op; }
		}

	}
}
