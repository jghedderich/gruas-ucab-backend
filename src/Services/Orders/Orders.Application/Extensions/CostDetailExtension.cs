
using System.Reflection.Metadata.Ecma335;

namespace Orders.Application.Extensions;

public static class CostDetailExtensions
{
    public static IEnumerable<CostDetailDto> ToCostDetailDtoList(this IEnumerable<CostDetail> costDetails)
    {
        return costDetails.Select(c => new CostDetailDto(
                Id: c.Id,
                OrderId: c.OrderId,
                Description: c.Description,
                Amount: c.Amount,
                StatusC: c.StatusC.StatusCO.ToString()
            ));   
    }

    public static CostDetailDto ToCostDetailDto(this CostDetail costDetail)
    {
        return DtoFromCostDetail(costDetail);  
    }

    private static CostDetailDto DtoFromCostDetail(CostDetail costDetail)
    {
        return new CostDetailDto(
                Id: costDetail.Id,
                OrderId: costDetail.OrderId,
                Description: costDetail.Description,
                Amount: costDetail.Amount,
                StatusC: costDetail.StatusC.StatusCO.ToString()
            );
    }
}