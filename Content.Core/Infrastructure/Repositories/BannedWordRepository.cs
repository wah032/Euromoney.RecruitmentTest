using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Content.Core.Infrastructure.Interface;

namespace Content.Core.Infrastructure.Repositories
{
	public class BannedWordRepository: IBannedWords
	{


		public List<string> GetBannedWord()
		{
			var bannedwords = new List<string>() { "swine", "bad", "nasty", "horrible" };

			return bannedwords;
		}
	}
}
