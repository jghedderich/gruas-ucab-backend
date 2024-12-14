using Orders.Domain.Models;
using Orders.Domain.ValueObjects;

namespace Orders.Infrastructure.Data.Extensions;

internal class InitialData
{
    private static readonly List<Operator> _operators;
    private static readonly List<Policy> _policies;

    static InitialData()
    {
        _operators = [
            Operator.Create(
                    Guid.NewGuid(),
                    Name.Of("Alex", "Fergurson"),
                    Email.Of("pedromanuelrc132@gmail.com"),
                    Phone.Of("04242404544"),
                    Dni.Of(DniType.V, "27941859"),
                    Password.Of("123456")
                ),
            Operator.Create(
                    Guid.NewGuid(),
                    Name.Of("Juan", "Soto"),
                    Email.Of("juansoto@gmail.com"),
                    Phone.Of("04143333751"),
                    Dni.Of(DniType.V, "29483872"),
                    Password.Of("123456")
                ),
            ];

        _policies = [
                Policy.Create(
                        Guid.NewGuid(),
                        "Banesco",
                        120,
                        Price.Of(200,16),
                        Fee.Of(100, 10)
                    ),
                Policy.Create(
                        Guid.NewGuid(),
                        "Mercantil",
                        180,
                        Price.Of(150,20),
                        Fee.Of(100, 10)
                    ),
            ];



    }

    public static IEnumerable<Operator> Operators() => _operators;
    public static IEnumerable<Policy> Policies() => _policies;
    public static IEnumerable<Order> Orders() => _operators.SelectMany(o => o.Orders);




}
