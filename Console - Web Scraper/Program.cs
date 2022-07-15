// @nuget: HtmlAgilityPack

using System;
using System.Xml;
using System.IO;
using HtmlAgilityPack;

public class WebScraper
{
	string Html { get; set; }
	WebScraper(string html = @"https://www.vituity.com/three-trends-driving-healthcare-delivery/")
    {
		Html = html;

		HtmlWeb web = new HtmlWeb();

		var htmlDoc = web.Load(html);

		var node = htmlDoc.DocumentNode.SelectSingleNode("//main");

		foreach (var nNode in node.DescendantsAndSelf("section"))
		{
			if (nNode.NodeType == HtmlNodeType.Element)
			{
				Console.Write(nNode.Name);
				Console.Write(" | ");
				Console.WriteLine(nNode.Attributes["class"].Value);
				getChildren(nNode);
			}
		}
	}

	public static void Main()
	{
		WebScraper webScraper = new WebScraper();
	}

	public static void getChildren(HtmlNode nNode)
	{
		HtmlNodeCollection childNodes = nNode.ChildNodes;
		foreach (var childNode in childNodes)
		{
			if (childNode.NodeType == HtmlNodeType.Element)
			{
				Console.Write("|---->");
				Console.Write(childNode.Name);
				Console.Write(" | ");
				if (childNode.Attributes["class"] == null)
				{
					Console.WriteLine("[Empty Class]");
					continue;
				}
				Console.WriteLine(childNode.Attributes["class"].Value);
			}
			if (childNode.HasChildNodes)
			{
				Console.Write("     ");
				getChildren(childNode);
			}
		}
	}
}