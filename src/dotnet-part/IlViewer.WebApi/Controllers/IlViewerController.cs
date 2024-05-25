using System;
using Microsoft.AspNetCore.Mvc;
using IlViewer.Core;
using IlViewer.Core.ResultOutput;
using IlViewer.WebApi.Models;

namespace IlViewer.WebApi.Controllers
{
	[Route("api/il")]
	public class IlViewerController : Controller
	{

		[HttpPost]
		public InspectionResult Post([FromBody] IlRequest request)
		{
			ArgumentNullException.ThrowIfNull(request);

			Console.WriteLine($"Request Params: ProjectFilePath {request.ProjectFilePath}");
			Console.WriteLine($"Request Params: Filename: {request.Filename}");

			try
			{
				InspectionResult result = IlGeneration.ExtractIl(request.ProjectFilePath, request.Filename);
				return result;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		[HttpGet]
		public string Get()
		{
			return "pong";
		}
	}
}