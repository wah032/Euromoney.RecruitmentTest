using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Content.Core.Infrastructure.Interface;

namespace Content.Core.Manager
{
	public class BannedWordManager
	{
		private IBannedWords BannedWordsRepository { get; set; }
		public BannedWordManager(IBannedWords bannedWordsRepository)
		{
			BannedWordsRepository = bannedWordsRepository;
		}

		public List<string> GetBannedWords()
		{
			return BannedWordsRepository.GetBannedWord();
		}

	}
}
