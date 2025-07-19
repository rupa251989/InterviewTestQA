using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
namespace InterviewTestQA.InterviewTestAutomation
{
    [TestFixture]
    public class JSONTest
    {
        private List<CostItem> _costItems;

        [SetUp]
        public void SetUp()
        {
        // Adjust this path as needed for your environment C:\Users\Ramesh\Workspace\Git\InterviewTestQA\InterviewTestAutomation\Data\Cost Analysis.json
            string jsonPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "InterviewTestAutomation/Data/Cost Analysis.json");
            Console.WriteLine(jsonPath);
            string json = File.ReadAllText(jsonPath);

            _costItems = JsonConvert.DeserializeObject<List<CostItem>>(json);
        }

        [Test]
        public void Deserialize_ShouldContainExpectedNumberOfItems()
        {
            Assert.That(_costItems, Is.Not.Null);
            Assert.That(_costItems.Count, Is.GreaterThan(0), "Cost items list should not be empty");
        }

        [Test]
        public void LINQ_ShouldGetTopItemByCost()
        {
            var topItem = _costItems.OrderByDescending(c => c.Cost).FirstOrDefault();

            Assert.That(topItem, Is.Not.Null, "Top item should not be null");
            Assert.That(topItem.CountryId, Is.EqualTo(0).Or.GreaterThan(0), "CountryId should be valid");
        }

        [Test]
        public void LINQ_ShouldSumCostsFor2016()
        {
            var totalCost = _costItems
                            .Where(c => c.YearId == "2016")
                            .Sum(c => c.Cost);

            Assert.That(totalCost, Is.GreaterThan(0), "Total cost for 2016 should be greater than 0");
        }

        [Test]
        public void NegativeTest_EmptyList()
        {
            var emptyList = new List<CostItem>();

            var topItem = emptyList.OrderByDescending(c => c.Cost).FirstOrDefault();

            Assert.That(topItem, Is.Null, "Top item should be null for an empty list");
        }

        [Test]
        public void BoundaryTest_ZeroCost()
        {
            var zeroCostItems = _costItems.Where(c => c.Cost == 0).ToList();

            Assert.That(zeroCostItems, Is.Not.Null);
            Assert.That(zeroCostItems.Count, Is.GreaterThanOrEqualTo(1), "There should be items with zero cost");
        }

        [Test]
        public void BoundaryTest_MaxCost()
        {
            var maxCost = _costItems.Max(c => c.Cost);
            var item = _costItems.First(c => c.Cost == maxCost);

            Assert.That(item.Cost, Is.EqualTo(maxCost), "Item should match the max cost");
        }
    }

}