using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Waher.Content.Asn1.Test
{
	[TestClass]
	public class ParsingTests
	{
		internal static readonly string[] ImportFolders = new string[]
		{
			"Examples\\SNMPv1",
			"Examples\\SNMPv2",
			"Examples\\IEEE1451"
		};

		public static Asn1Document ParseAsn1Document(string FileName)
		{
			return Asn1Document.FromFile(Path.Combine("Examples", FileName), ImportFolders);
		}

		[TestMethod]
		public void Test_01_WorldSchema()
		{
			ParseAsn1Document("World-Schema.asn1");
		}

		[TestMethod]
		public void Test_02_MyShopPurchaseOrders()
		{
			ParseAsn1Document("MyShopPurchaseOrders.asn1");
		}

		[TestMethod]
		public void Test_03_RFC1155()
		{
			ParseAsn1Document("SNMPv1\\RFC1155-SMI.asn1");
		}

		[TestMethod]
		public void Test_04_RFC1157()
		{
			ParseAsn1Document("SNMPv1\\RFC1157-SNMP.asn1");
		}

		[TestMethod]
		public void Test_05_RFC1158()
		{
			ParseAsn1Document("SNMPv1\\RFC1158-MIB.asn1");
		}

		[TestMethod]
		public void Test_06_RFC1212()
		{
			ParseAsn1Document("SNMPv1\\RFC1212.asn1");
		}

		[TestMethod]
		public void Test_07_RFC1213()
		{
			ParseAsn1Document("SNMPv1\\RFC1213-MIB.asn1");
		}

		[TestMethod]
		public void Test_08_RFC1215()
		{
			ParseAsn1Document("SNMPv1\\RFC1215.asn1");
		}

		[TestMethod]
		public void Test_09_RFC1901_COMMUNITY_BASED_SNMPv2()
		{
			ParseAsn1Document("SNMPv2\\COMMUNITY-BASED-SNMPv2.asn1");
		}

		[TestMethod]
		public void Test_10_RFC2578_SNMPV2_SMI()
		{
			ParseAsn1Document("SNMPv2\\SNMPV2-SMI.asn1");
		}

		[TestMethod]
		public void Test_11_RFC2579_SNMPV2_TC()
		{
			ParseAsn1Document("SNMPv2\\SNMPV2-TC.asn1");
		}

		[TestMethod]
		public void Test_12_RFC2580_SNMPV2_CONF()
		{
			ParseAsn1Document("SNMPv2\\SNMPV2-CONF.asn1");
		}

		[TestMethod]
		public void Test_13_RFC3416_SNMPV2_PDU()
		{
			ParseAsn1Document("SNMPv2\\SNMPV2-PDU.asn1");
		}

		[TestMethod]
		public void Test_14_1451_1()
		{
			ParseAsn1Document("IEEE1451\\P21451-N1-T1-MIB.asn1");
		}

		[TestMethod]
		public void Test_15_1451_2()
		{
			ParseAsn1Document("IEEE1451\\P21451-N1-T2-MIB.asn1");
		}

		[TestMethod]
		public void Test_16_1451_3()
		{
			ParseAsn1Document("IEEE1451\\P21451-N1-T3-MIB.asn1");
		}
	}
}
