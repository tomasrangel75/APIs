using ApiDemo1.DataAccess.Models;
using ApiDemo1.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDemo1.DataAccess.ServiceLayer
{
	public interface IService : IDisposable
	{
		Repository<Student> Students { get; }
	
	}
}
