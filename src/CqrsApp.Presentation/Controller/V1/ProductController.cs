using Contract.Service.V1.Product;
using CqrsApp.Domain.Shared;
using CqrsApp.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CqrsApp.Presentation.Controller.V1;

public class ProductController : ApiController
{
    public ProductController(ISender sender) : base(sender) { }

    [HttpGet]
    [ProducesResponseType(typeof(Result<IEnumerable<Response.ProductResponse>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProducts()
    {
        var result = await Sender.Send(new Query.GetProductQuery());
        return Ok(result);
    }

    [HttpGet("dapper")]
    [ProducesResponseType(typeof(Result<List<Response.ProductResponse>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProductsDapper()
    {
        var result = await Sender.Send(new Query.GetProductDapperQuery());
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateProduct([FromBody] Command.CreateProductCommand request)
    {
        var result = await Sender.Send(request);
        return result.IsSuccess ? Ok(result) : HandlerFailure(result);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] Command.UpdateProductCommand request)
    {
        if (id != request.Id)
            return BadRequest("Route id does not match body id.");

        var result = await Sender.Send(request);
        return result.IsSuccess ? Ok(result) : HandlerFailure(result);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        var result = await Sender.Send(new Command.DeleteProductCommand(id));
        return result.IsSuccess ? Ok(result) : HandlerFailure(result);
    }
}