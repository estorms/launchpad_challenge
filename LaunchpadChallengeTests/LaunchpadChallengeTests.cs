using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LaunchpadChallenge.HttpClients;
using LaunchpadChallenge.Interfaces;
using LaunchpadChallenge.Models;
using LaunchpadChallenge.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Internal;
using Moq;
using NUnit.Framework;

namespace LaunchpadChallenge.LaunchpadChallengeTests
{
    public class LaunchpadChallengeTests
    {
        private Mock<ISpaceXClient> _spaceXClientMock;
        private Mock<ILaunchpadRepo> _launchPadRepoMock;
        private Mock<ILogger<LaunchpadService>> _serviceLoggerMock;
        private Mock<IConfiguration> _configurationMock;
        private Mock<IConfigurationSection> _configurationSectionMock;
        
        [SetUp]
        public void Setup()
        {
            _launchPadRepoMock = new Mock<ILaunchpadRepo>();
            _spaceXClientMock = new Mock<ISpaceXClient>();
            _serviceLoggerMock = new Mock<ILogger<LaunchpadService>>();
            _serviceLoggerMock.Setup(x=>x.Log(LogLevel.Information, 0, It.IsAny<FormattedLogValues>(), It.IsAny<Exception>(),
                It.IsAny<Func<object, Exception, string>>())).Verifiable();
            _spaceXClientMock.Setup(x => x.RetrieveApiData()).ReturnsAsync(It.IsAny<List<Launchpad>>());
           
        }

        [Test]
        public async Task ConfigSetToExternalApiCallsSpaceXClient()
        {
            //Arrange
            SetupConfigurationMock(true);
            var launchpadService = new LaunchpadService(_serviceLoggerMock.Object, _configurationMock.Object, _launchPadRepoMock.Object, _spaceXClientMock.Object);
            
            //Act
            await launchpadService.RetrieveData();
            
            //Assert
            _spaceXClientMock.Verify(x => x.RetrieveApiData(), Times.Once);
            _serviceLoggerMock.Verify(x => x.Log(LogLevel.Information, 0, It.IsAny<FormattedLogValues>(), It.IsAny<Exception>(),
            It.IsAny<Func<object, Exception, string>>()), Times.Once);
        }
       

        private void SetupConfigurationMock(bool isExternalApi)
        {
            _configurationSectionMock = new Mock<IConfigurationSection>();
            _configurationMock = new Mock<IConfiguration>();
            if (isExternalApi)
            {
                _configurationSectionMock.Setup(x => x.Value).Returns("true");
                _configurationMock.Setup(a => a.GetSection(It.IsAny<string>())).Returns(_configurationSectionMock.Object);     
            }
            else
            {
                _configurationSectionMock.Setup(x => x.Value).Returns("false");
                _configurationMock.Setup(a => a.GetSection(It.IsAny<string>())).Returns(_configurationSectionMock.Object);     
            }
        }
    }
}