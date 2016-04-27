using System;
using System.Reflection;
using Content.Core.Infrastructure.Interface;
using Content.Core.Manager;
using Ninject;

namespace ContentConsole
{
	public static class Program
    {
        public static void Main(string[] args)
        {

			var kernel = new StandardKernel();
			kernel.Load(Assembly.GetExecutingAssembly());
			var bannedwords = kernel.Get<IBannedWords>();
			var ContentProcessManager = new ContentProcessManager(bannedwords);
	        string content = string.Empty;
			Console.WriteLine("Enter text to Scan:");
	         content = Console.ReadLine();
			Console.WriteLine(content);
			Console.WriteLine("Total Number of negative words: " + ContentProcessManager.GetNegativeWordCount(content));
			Console.WriteLine("Scanned the text:");
			Console.WriteLine("Filterd Applied:" + ContentProcessManager.FilterNegativeWords(content));
			Console.WriteLine("Do you want to Disable Filtering y/n");
			var choice = Console.ReadLine();
			if (choice != null)
				switch (choice.ToLower())
				{
					case "y":
						Console.WriteLine("Total Number of negative words: " + ContentProcessManager.GetNegativeWordCount(content));
						Console.WriteLine("Scanned the text:");
						Console.WriteLine("orginal Text" + content);
						break;
					case "n":
						break;
				}

			Console.WriteLine("Press ANY key to exit.");

			Console.ReadKey();
		}
    }

}
