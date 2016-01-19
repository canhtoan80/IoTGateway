﻿using System;
using System.Collections.Generic;
using System.Text;
using Waher.Events;
using Waher.Things;

namespace Waher.Networking.XMPP.Control.ParameterTypes
{
	/// <summary>
	/// Set handler delegate for date and time control parameters.
	/// </summary>
	/// <param name="Sender">Sender of event.</param>
	/// <param name="Value">Value set.</param>
	public delegate void DateTimeSetHandler(ThingReference Node, DateTime Value);

	/// <summary>
	/// Get handler delegate for date and time control parameters.
	/// </summary>
	/// <param name="Sender">Sender of event.</param>
	/// <returns>Current value, or null if not available.</returns>
	public delegate DateTime? DateTimeGetHandler(ThingReference Node);

	/// <summary>
	/// DateTime control parameter.
	/// </summary>
	public class DateTimeControlParameter : ControlParameter
	{
		private DateTimeGetHandler getHandler;
		private DateTimeSetHandler setHandler;

		/// <summary>
		/// DateTime control parameter.
		/// </summary>
		/// <param name="Name">Parameter name.</param>
		public DateTimeControlParameter(string Name, DateTimeGetHandler GetHandler, DateTimeSetHandler SetHandler)
			: base(Name)
		{
			this.getHandler = GetHandler;
			this.setHandler = SetHandler;
		}

		/// <summary>
		/// Sets the value of the control parameter.
		/// </summary>
		/// <param name="Node">Node reference, if available.</param>
		/// <param name="Value">Value to set.</param>
		public void Set(ThingReference Node, DateTime Value)
		{
			try
			{
				this.setHandler(Node, Value);
			}
			catch (Exception ex)
			{
				Log.Critical(ex);
			}
		}

		/// <summary>
		/// Gets the value of the control parameter.
		/// </summary>
		/// <returns>Current value, or null if not available.</returns>
		public DateTime? Get(ThingReference Node)
		{
			try
			{
				return this.getHandler(Node);
			}
			catch (Exception ex)
			{
				Log.Critical(ex);
				return null;
			}
		}
	}
}
