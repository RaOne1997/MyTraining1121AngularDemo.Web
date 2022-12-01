using Abp.Application.Services;
using MyTraining1121AngularDemo.Tenants.Dashboard.Dto;

namespace MyTraining1121AngularDemo.Tenants.Dashboard
{
    public interface ITenantDashboardAppService : IApplicationService
    {
        GetMemberActivityOutput GetMemberActivity();

        GetHelloWorldOutput GetHelloWorldData(GetHelloWorldInput input);
        GetDashboardDataOutput GetDashboardData(GetDashboardDataInput input);

        GetDailySalesOutput GetDailySales();

        GetProfitShareOutput GetProfitShare();

        GetSalesSummaryOutput GetSalesSummary(GetSalesSummaryInput input);

        GetTopStatsOutput GetTopStats();

        GetRegionalStatsOutput GetRegionalStats();

        GetGeneralStatsOutput GetGeneralStats();
    }



    public class GetHelloWorldOutput
    {
        public string OutPutName { get; set; }
    }
    public class GetHelloWorldInput
    {
        public string Name { get; set; }
    }
}
