using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;
using CommbankServer.Models;

namespace CommbankServer.Tests
{
    public class GoalControllerTests : IClassFixture<TestFixture<Program>>
    {
        private readonly HttpClient _client;

        public GoalControllerTests(TestFixture<Program> fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async Task GetGoalsForUser_ShouldReturnGoalsWithIcon()
        {
            // Arrange
            string testUserId = "62a29c15f4605c4c9fa7f306";

            // Act
            var response = await _client.GetAsync($"/api/Goal/user/{testUserId}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var goals = JsonConvert.DeserializeObject<List<Goal>>(content);

            // Assert
            Assert.NotNull(goals);
            Assert.NotEmpty(goals);

            foreach (var goal in goals)
            {
                Assert.Equal(testUserId, goal.UserId);
                // Icon can be null or a string emoji
                Assert.True(goal.Icon == null || !string.IsNullOrWhiteSpace(goal.Icon));
            }
        }
    }
}
