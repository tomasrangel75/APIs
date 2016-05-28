using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(ApiDemo2.ProductionStartup))]

namespace ApiDemo2
{
	
		public class ProductionStartup
		{
			public void Configuration(IAppBuilder app)
			{
				app.Use((context, next) =>
				{
					TextWriter output = context.Get<TextWriter>("host.TraceOutput");
					return next().ContinueWith(result =>
					{
						output.WriteLine("Scheme {0} : Method {1} : Path {2} : MS {3} vai toma no cu",
						context.Request.Scheme, context.Request.Method, context.Request.Path, getTime());
					});
				});

				//app.Run(async context =>
				//{
				//	await context.Response.WriteAsync(getTime() + " My First OWIN App");
				//});
			}

			string getTime()
			{
				return DateTime.Now.Millisecond.ToString();
			}
		}
	

}