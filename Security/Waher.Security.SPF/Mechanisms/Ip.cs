﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Waher.Security.SPF.Mechanisms
{
	/// <summary>
	/// Abstract base class for IP-based SPF mechanisms.
	/// </summary>
	public abstract class Ip : Mechanism
	{
		/// <summary>
		/// IP Address
		/// </summary>
		protected IPAddress address;

		/// <summary>
		/// CIDR
		/// </summary>
		protected int cidr;

		/// <summary>
		/// Abstract base class for IP-based SPF mechanisms.
		/// </summary>
		/// <param name="Term">Term</param>
		/// <param name="Qualifier">Qualifier</param>
		public Ip(Term Term, SpfQualifier Qualifier)
			: base(Term, Qualifier)
		{
			if (Term.PeekNextChar() != ':')
				throw new Exception(": expected.");

			Term.NextChar();

			int Start = Term.pos;
			char ch;

			while (Term.pos < Term.len && (ch = Term.s[Term.pos]) != '/' && ch > ' ')
				Term.pos++;

			if (!IPAddress.TryParse(Term.s.Substring(Start, Term.pos - Start), out this.address))
				throw new Exception("IP Address expected.");

			int Max;

			switch (this.address.AddressFamily)
			{
				case AddressFamily.InterNetwork:
					Max = 32;
					break;

				case AddressFamily.InterNetworkV6:
					Max = 128;
					break;

				default:
					throw new Exception("IP Address expected.");
			}

			if (Term.PeekNextChar() == '/')
			{
				Term.NextChar();

				this.cidr = Term.NextInteger();
				if (this.cidr < 0 || this.cidr > Max)
					throw new Exception("Invalid CIDR");
			}
			else
				this.cidr = Max;
		}

		/// <summary>
		/// Checks if the mechamism matches the current request.
		/// </summary>
		/// <returns>Match result</returns>
		public override Task<SpfResult> Matches()
		{
			bool Result = MechanismDomainCidrSpec.Matches(new IPAddress[] { this.address }, this.term, this.cidr);
			return Task.FromResult<SpfResult>(Result ? SpfResult.Pass : SpfResult.Fail);
		}

	}
}
