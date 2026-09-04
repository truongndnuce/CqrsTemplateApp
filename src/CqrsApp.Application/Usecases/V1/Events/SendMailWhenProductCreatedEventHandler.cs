using Contract.Abtractions.Message ;
using Contract.Service.V1.Product ;
using Microsoft.Extensions.Logging ;

namespace CqrsApp.Application.Usecases.V1.Events ;

public class SendMailWhenProductCreatedEventHandler :
  IDomainEventHandler<DomainEvent.ProductCreated>
{
  private readonly ILogger<SendMailWhenProductCreatedEventHandler> _logger ;

  public SendMailWhenProductCreatedEventHandler( ILogger<SendMailWhenProductCreatedEventHandler> logger )
  {
    _logger = logger ;
  }

  public Task Handle( DomainEvent.ProductCreated notification, CancellationToken cancellationToken )
  {
    _logger.LogInformation(
      "[SendMail] Product created - To: admin@shop.com | Subject: New product added | Body: Product with Id={ProductId} has been successfully created.",
      notification.Id ) ;

    return Task.CompletedTask ;
  }
}