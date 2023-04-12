using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pets_Store.Models;

namespace Pets_Store.Controllers
{
	[ApiController]
	[Route("client")]
	public class ClientController : ControllerBase
	{
		[HttpGet]
		[Route("list")]
		public dynamic ClientsList()
		{

			List<Client> clients = new List<Client>
			{
				new Client
				{
					id = "1",
					name = "Noel",
					age = "18",
					email = "noelrinaya318@gmail.com",

				}

			};
			return clients;
		}


		[HttpPost]
		[Route("save")]
		public dynamic SaveClient(Client client)
		{

			client.id = "3";
			return new
			{
				success = true,
				message = "Succesfully Saved",
				result = client
			};
		}

		[HttpGet]
		[Route("listbyid")]
		public dynamic ListClientById(string _id)
		{


			return new Client
			{
				id = _id,
				name = "Noel",
				age = "18",
				email = "noelrinaya318@gmail.com",

			};
		}

		[HttpPost]
		[Route("delete")]
		public dynamic DeleteClient(Client client)
		{
			string token = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;
			if (token != "aBscd73718")
			{
				return new
				{
					success = false,
					message = "Invalid Token/Credentials",
					result = "",
				};
			}
			else
			{
				return new
				{
					success = true,
					message = "Succesfully Deleted",
					result = client,
				};

			}

		}

	}
}