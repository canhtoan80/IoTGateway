﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace Waher.Networking.Cluster.Serialization.Properties
{
	/// <summary>
	/// Binary property
	/// </summary>
	public class BinaryProperty : Property
	{
		/// <summary>
		/// Property Type
		/// </summary>
		public override Type PropertyType => typeof(byte[]);

		/// <summary>
		/// Serializes the property value of an object.
		/// </summary>
		/// <param name="Output">Output</param>
		/// <param name="Value">Value to serialize</param>
		public override void Serialize(Serializer Output, object Value)
		{
			Output.WriteBinary((byte[])Value);
		}

		/// <summary>
		/// Deserializes the property value
		/// </summary>
		/// <param name="Input">Binary representation.</param>
		/// <param name="ExpectedType">Expected Type</param>
		/// <returns>Deserialized value.</returns>
		public override object Deserialize(Deserializer Input, Type ExpectedType)
		{
			return Input.ReadBinary();
		}
	}
}
