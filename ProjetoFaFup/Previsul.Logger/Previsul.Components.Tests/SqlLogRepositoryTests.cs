using AutoFixture.Xunit2;
using FluentAssertions;
using Previsul.Components.Logging.Domain.Model;
using Previsul.Components.LoggingRepository;
using Xunit;

namespace Previsul.Components.Tests
{
    public class SqlLogRepositoryTests
    {
        [Theory, AutoData]
        public async void InsertSync_ShouldReturnSuccessful(SqlLogRepository sut, LogEntry log)
        {
            sut.ConnectionString = "Server=10.109.10.94,1460;Database=PBS_LOG;user id=APP_PBS_LOG;password=@4CUMAAVMNSL3O;Trusted_Connection=True; MultipleActiveResultSets=true;Integrated Security=False";
            
            var result = await sut.InsertSync(log);

            result.Should().BeTrue();
        }

        [Theory, AutoData]
        public void Insert_ShouldReturnSuccessful(SqlLogRepository sut, LogEntry log)
        {
            sut.ConnectionString = "Server=10.109.10.94,1460;Database=PBS_LOG;user id=APP_PBS_LOG;password=@4CUMAAVMNSL3O;Trusted_Connection=True; MultipleActiveResultSets=true;Integrated Security=False";

            var result = sut.Insert(log);

            result.Should().BeTrue();
        }
    }
}
