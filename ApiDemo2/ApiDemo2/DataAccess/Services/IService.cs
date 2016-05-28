using ApiDemo2.DataAccess;
using ApiDemo2.DataAccess.Repository;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDemo2.DataAccess.Services
{
	public interface IService : IDisposable
	{
		Repository<Blog> Blogs { get; }
	
	}
}
