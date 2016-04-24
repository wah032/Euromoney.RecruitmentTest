using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Core.Infrastructure.Interface
{
	public interface IBannedWords
	{
		List<string> GetBannedWord();
	}
}
