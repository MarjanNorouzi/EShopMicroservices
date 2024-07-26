using BuildingBlocks.Messaging.Events;
using Mapster;
using MassTransit;
using Ordering.Application.Orders.Commands.CreateOrder;

namespace Ordering.Application.Orders.EventHandlers.Integration;

public class BasketCheckoutEventHandler
    (ISender sender, ILogger<BasketCheckoutEventHandler> logger)
    : IConsumer<BasketCheckoutEvent>
{
    public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
    {
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name);

        var command = MapToCreateOrderCommand(context.Message);
        await sender.Send(command);

        var order = Order.Create(
            OrderId.Of(context.Message.Id),
            CustomerId.Of(context.Message.CutomerId),
            OrderName.Of(""),
            Address.Of(context.Message.FirstName, context.Message.LastName, context.Message.EmailAddress, context.Message.AddressLine, context.Message.Country, context.Message.State, context.Message.ZipCode),
            Address.Of(context.Message.FirstName, context.Message.LastName, context.Message.EmailAddress, context.Message.AddressLine, context.Message.Country, context.Message.State, context.Message.ZipCode),
            Payment.Of(context.Message.CardName, context.Message.CardNumber, context.Message.Expiration, context.Message.CVV, context.Message.PaymentMethod));
        context.Message.Adapt<Order>();


        throw new NotImplementedException();
    }

    private CreateOrderCommand MapToCreateOrderCommand(BasketCheckoutEvent message)
    {
        var addressDto = new AddressDto(message.FirstName, message.LastName, message.EmailAddress, message.AddressLine, message.Country, message.State, message.ZipCode);
        var paymentDto = new PaymentDto(message.CardName, message.CardNumber, message.Expiration, message.CVV, message.PaymentMethod);
        var orderId = Guid.NewGuid();

        var orderDto = new OrderDto(
            orderId,
            message.CutomerId,
            message.UserName,
            addressDto,
            addressDto,
            paymentDto,
            OrderStatus.Pending,
            [
                new OrderItemDto(orderId, new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61"),2,500),
                new OrderItemDto(orderId, new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914"),1,400)
            ]);

        return new CreateOrderCommand(orderDto);
    }
}
