using CqrsApp.Application.Usecases.V1.Queries.Product;
using CqrsApp.Domain.Shared;
using CqrsApp.Presentation.Abstractions;
using DemoCICD.Contract.Services.V1.Product;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CqrsApp.Presentation.Controller.V1;

public class ProductController : ApiController
{
    public ProductController(ISender sender) : base(sender)
    {
        
    }
    [HttpGet]
    [ProducesResponseType(typeof(Result<IEnumerable<Response.ProductResponse>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProducts()
    {
        var result = await Sender.Send(new GetProductQuery());
        return Ok(result);
    }
}