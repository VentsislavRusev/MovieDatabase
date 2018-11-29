using System.Xml.Xsl;
using System.IO;

namespace MovieDB
{
	public class TransformXslt
	{
		public string XmlFile { get; set; }
		public string XsltFile { get; set; }
		public string Destination { get; set; }

		public TransformXslt(string xml, string xslt, string destination)
		{
			this.XmlFile = xml;
			this.XsltFile = xslt;
			this.Destination = destination;
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