using Microsoft.EntityFrameworkCore.Storage;
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
                    Email.Of("alexfergurson@gmail.com"),
                    Phone.Of("04242404544"),
                    Dni.Of(DniType.V, "27941859")
                ),
            Operator.Create(
                    Guid.NewGuid(),
                    Name.Of("Juan", "Soto"),
                    Email.Of("juansoto@gmail.com"),
                    Phone.Of("04143333751"),
                    Dni.Of(DniType.V, "29483872")
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

        AddOrdersToOperator1(_operators[0], _policies[0]);
        AddOrdersToOperator2(_operators[1],_policies[1]);
    }

    public static IEnumerable<Operator> Operators() => _operators;
    public static IEnumerable<Policy> Policies() => _policies;
    public static IEnumerable<Order> Orders() => _operators.SelectMany(o => o.Orders);

    private static void AddOrdersToOperator1(Operator operatorN, Policy policy)
    {
        operatorN.AddOrder(
                Guid.NewGuid(),
                policy.Id,
                Client.Of(Name.Of("Carlos", "Herrera"), Dni.Of(DniType.V, "28761928"), Phone.Of("04128271627"), Email.Of("carlosherrera@gmail.com"), ClientVehicle.Of("Toyota","Fortuner",2012,VehicleType.Suv)),
                OrderStatus.Of(Status.ToBeAccepted),
                Address.Of("Avenida Teherán","Universidad Catolica Andres Bello","Caracas", "Distrito Capital", "1020"),
                Address.Of("Ruta C", "Los Campitos", "Caracas", "Distrito Capital", "1080"),
                new List<CostDetail>()
            );
        operatorN.AddOrder(
                Guid.NewGuid(),
                policy.Id,
                Client.Of(Name.Of("Gabriel", "Castellano"), Dni.Of(DniType.V, "27491702"), Phone.Of("04148291728"), Email.Of("gabrielcastellano@gmail.com"), ClientVehicle.Of("Ford", "Fiesta", 2008, VehicleType.Suv)),
                OrderStatus.Of(Status.Accepted),
                Address.Of("Parque Agustín Codazzi", "Padros del Este", "Caracas", "Distrito Capital", "1080"),
                Address.Of("Paseo Las Mercedes","Las Mercedes", "Caracas", "Distrito Capital", "1060"),
                new List<CostDetail>()
            );

    }

    private static void AddOrdersToOperator2(Operator operatorN, Policy policy)
    {
        operatorN.AddOrder(
                Guid.NewGuid(),
                policy.Id,
                Client.Of(Name.Of("Pablo", "Rodriguez"), Dni.Of(DniType.V, "30981738"), Phone.Of("04248271927"), Email.Of("pablorodriguez@gmail.com"), ClientVehicle.Of("Chevrolet", "Camaro", 2012, VehicleType.Suv)),
                OrderStatus.Of(Status.ToBeAccepted),
                Address.Of("Torre Phelps, Piso 6, Oficina B", "Plaza Venezuela", "Caracas", "Distrito Capital", "1050"),
                Address.Of("Avenida Francisco de Miranda, Torre La Primera, Oficina 12-A", "Chacao", "Caracas", "Distrito Capital", "1080"),
                new List<CostDetail>()
            );
        operatorN.AddOrder(
                Guid.NewGuid(),
                policy.Id,
                Client.Of(Name.Of("Kissy", "Santander"), Dni.Of(DniType.V, "28719282"), Phone.Of("04128291837"), Email.Of("kissysantander@gmail.com"), ClientVehicle.Of("Dodge", "Charger", 2008, VehicleType.Suv)),
                OrderStatus.Of(Status.Accepted),
                Address.Of("Calle Sucre, Quinta No. 23", "El Rosal", "Caracas", "Distrito Capital", "1010"),
                Address.Of("Calle Guaicaipuro", "Las Mercedes", "Caracas", "Distrito Capital", "1060"),
                new List<CostDetail>()
            );

    }
}
