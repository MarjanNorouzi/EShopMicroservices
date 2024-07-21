namespace Ordering.Application.Orders.Queries.GetOrderByName;

public record GetOrdersByNameQuery(string Name) : IQuery<GetOrdersByNameResult>;

public record GetOrdersByNameResult(IEnumerable<OrderDto> Orders);

public class GetOrdersByNameValidator : AbstractValidator<GetOrdersByNameQuery>
{
    public GetOrdersByNameValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is requireds");
    }
}
