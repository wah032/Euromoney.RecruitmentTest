using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Content.Core.Infrastructure.Interface;
using Content.Core.Infrastructure.Repositories;
using Ninject.Modules;

namespace ContentConsole.DI
{
	public class Bindings :NinjectModule
	{
		public override void Load()
		{
			Bind<IBannedWords>().To<BannedWordRepository>();
		}
	}
}
