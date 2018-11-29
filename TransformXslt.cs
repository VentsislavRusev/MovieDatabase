using System.Xml.Xsl;
using System.IO;

namespace MovieDB
{
	public class TransformXslt
	{
		private string XmlFile { get; set; }
		private string XsltFile { get; set; }
		private string Destination { get; set; }

		public TransformXslt(string xml, string xslt, string destination)
		{
			XmlFile = xml;
			XsltFile = xslt;
			Destination = destination;
		}

		public void TransformXml()
		{
			//xml
			FileStream fs = new FileStream(Destination, FileMode.Create);
			XslCompiledTransform xct = new XslCompiledTransform();
			xct.Load(XsltFile);
			//xml
			xct.Transform(XmlFile, null, fs);
			fs.Close();
		}
	}
}