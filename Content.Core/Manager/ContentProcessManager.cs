using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Content.Core.Infrastructure.Interface;

namespace Content.Core.Manager
{
	public class ContentProcessManager
	{

		private IBannedWords BannedWordsRepository { get; set; }

		public ContentProcessManager(IBannedWords bannedWordsRepository)
		{
			BannedWordsRepository = bannedWordsRepository;
		}
		public int GetNegativeWordCount(string phrase)
		{
			var bannedwordslist = BannedWordsRepository.GetBannedWord();
			return bannedwordslist.Sum(bannedword => phrase.Split(' ').Count(word => bannedword.Equals(word.Trim(new char[] {'.'}))));
		}

		public string FilterNegativeWords(string phrase)
		{
			var bannedwordslist = BannedWordsRepository.GetBannedWord();
			var newStringBuilder = new StringBuilder();
			foreach (var word in phrase.Split(' '))
			{
				var trimedword = word.Trim(new char[] { '.' });
				if (bannedwordslist.Contains(trimedword))
				{
					var replaceworldbuilder = new StringBuilder();
					var trimedwordarray = trimedword.ToCharArray();
					replaceworldbuilder.Append(trimedwordarray.FirstOrDefault());
					for (var i = 1; i < trimedwordarray.Length - 1; i++)
					{
						replaceworldbuilder.Append("#");
					}
					replaceworldbuilder.Append(trimedwordarray.LastOrDefault());
					if (word.EndsWith("."))
					{
						replaceworldbuilder.Append(".");
					}
					newStringBuilder.Append(replaceworldbuilder);
					newStringBuilder.Append(" ");
			}
				else
				{
					newStringBuilder.Append(word);
					newStringBuilder.Append(" ");
				}

			}
			return newStringBuilder.ToString().TrimEnd();
		}


	}
}
