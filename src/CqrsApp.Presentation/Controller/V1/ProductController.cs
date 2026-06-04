using Contract.Service.V1.Product;
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
    [HttpGet(Name = "GetProducts")]
    [ProducesResponseType(typeof(Result<IEnumerable<Response.ProductResponse>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Products()
    {
        //var result = await Sender.Send(new Query.GetProductsQuery());
        //return Ok(result);

        return null;
    }
}