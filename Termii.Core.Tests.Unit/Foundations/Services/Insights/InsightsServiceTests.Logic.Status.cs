using FluentAssertions;
using Force.DeepCloner;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalInsights;
using Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalTokens;
using Termii.Core.Models.Services.Foundations.Termii.Exceptions;
using Termii.Core.Models.Services.Foundations.Termii.Insights;
using Termii.Core.Models.Services.Foundations.Termii.Tokens;

namespace Termii.Core.Tests.Unit.Foundations.Services.Insights
{
    public partial class InsightsServiceTests
    {
        [Fact]
        public async Task ShouldPostStatusWithStatusRequestAsync()
        {
            // given 



            dynamic createRandomStatusRequestProperties =
              CreateRandomStatusRequestProperties();

            dynamic createRandomStatusResponseProperties =
                CreateRandomStatusResponseProperties();


            var randomExternalStatusRequest = new ExternalStatusRequest
            {
                ApiKey = createRandomStatusRequestProperties.ApiKey,
                PhoneNumber = createRandomStatusRequestProperties.PhoneNumber,
                CountryCode = createRandomStatusRequestProperties.CountryCode,

            };

            var randomExternalStatusResponse = new ExternalStatusResponse
            {

                Result = ((List<dynamic>)createRandomStatusResponseProperties.Result).Select(result =>
                {
                    return new ExternalStatusResponse.StatusResult
                    {
                         CountryDetail = new ExternalStatusResponse.CountryDetail
                         {
                             CountryCode = result.CountryDetail.CountryCode,
                             Iso = result.CountryDetail.Iso,
                             MobileCountryCode = result.CountryDetail.MobileCountryCode
                         },
                         OperatorDetail = new ExternalStatusResponse.OperatorDetail
                         {
                             CarrierIdentificationCode = result.OperatorDetail.CarrierIdentificationCode,
                             LineType = result.OperatorDetail.LineType,
                             MobileNumberCode = result.OperatorDetail.MobileNumberCode,
                             MobileRoutingCode = result.OperatorDetail.MobileRoutingCode,
                             OperatorCode = result.OperatorDetail.OperatorCode,
                             OperatorName = result.OperatorDetail.OperatorName,
                         },
                         RouteDetail = new ExternalStatusResponse.RouteDetail
                         {
                             Number = result.RouteDetail.Number,
                             Ported = result.RouteDetail.Ported,
                         },
                         Status = result.Status,
                    };

                }).ToList()
            };


            var randomStatusRequest = new StatusRequest
            {
                ApiKey = createRandomStatusRequestProperties.ApiKey,
                PhoneNumber = createRandomStatusRequestProperties.PhoneNumber,
                CountryCode = createRandomStatusRequestProperties.CountryCode,

            };

            var randomStatusResponse = new StatusResponse
            {
                Result = ((List<dynamic>)createRandomStatusResponseProperties.Result).Select(result =>
                {
                    return new StatusResponse.StatusResult
                    {
                        CountryDetail = new StatusResponse.CountryDetail
                        {
                            CountryCode = result.CountryDetail.CountryCode,
                            Iso = result.CountryDetail.Iso,
                            MobileCountryCode = result.CountryDetail.MobileCountryCode
                        },
                        OperatorDetail = new StatusResponse.OperatorDetail
                        {
                            CarrierIdentificationCode = result.OperatorDetail.CarrierIdentificationCode,
                            LineType = result.OperatorDetail.LineType,
                            MobileNumberCode = result.OperatorDetail.MobileNumberCode,
                            MobileRoutingCode = result.OperatorDetail.MobileRoutingCode,
                            OperatorCode = result.OperatorDetail.OperatorCode,
                            OperatorName = result.OperatorDetail.OperatorName,
                        },
                        RouteDetail = new StatusResponse.RouteDetail
                        {
                            Number = result.RouteDetail.Number,
                            Ported = result.RouteDetail.Ported,
                        },
                        Status = result.Status,
                    };

                }).ToList()

            };


            var randomStatus = new Status
            {
                Request = randomStatusRequest,
            };

            Status inputStatus = randomStatus;
            Status expectedStatus = inputStatus.DeepClone();
            expectedStatus.Response = randomStatusResponse;

            ExternalStatusRequest mappedExternalStatusRequest =
               randomExternalStatusRequest;

            ExternalStatusResponse returnedExternalStatusResponse =
                randomExternalStatusResponse;

            this.termiiBrokerMock.Setup(broker =>
                broker.GetPhoneNumberStatusAsync(It.Is(
                      SameExternalStatusRequestAs(mappedExternalStatusRequest))))
                     .ReturnsAsync(returnedExternalStatusResponse);

            // when
            Status actualCreateStatus =
               await this.insightsService.GetPhoneNumberStatusAsync(inputStatus);

            // then
            actualCreateStatus.Should().BeEquivalentTo(expectedStatus);

            this.termiiBrokerMock.Verify(broker =>
               broker.GetPhoneNumberStatusAsync(It.Is(
                   SameExternalStatusRequestAs(mappedExternalStatusRequest))),
                   Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
        }
    }
}
