using NUnit.Framework;
using Newtonsoft.Json;
namespace InterviewTestQA.InterviewTestAutomation
{
    // Marks this class as a test container
    [TestFixture]  
    public class JSONTest
    {
        private List<CostItem> _costItems;
        
        // This method runs **before each test**.
        // It is used to initialize common test data or objects.
        [SetUp]
        public void SetUp()
        {
            try
            {
                // 1. Read the JSON file content.
                string jsonPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "InterviewTestAutomation/Data/Cost Analysis.json");
                string json = File.ReadAllText(jsonPath);

                // 2. Instantiate the list and deserialize the JSON into it.
                _costItems = JsonConvert.DeserializeObject<List<CostItem>>(json);

                // Add a check to ensure deserialization was successful
                if (_costItems == null)
                {
                    NUnit.Framework.Assert.Fail("Deserialization resulted in a null object, The JSON file might be empty or invalid");
                }

            }
            catch (FileNotFoundException)
            {
                NUnit.Framework.Assert.Fail("File was not found, check properties in output setting");
            }

            catch (JsonException ex)
            {
                NUnit.Framework.Assert.Fail("File was not formatted correctly");
            }

            catch (Exception ex)
            {
                NUnit.Framework.Assert.Fail("An unexpected error");
            }
        }

        // This is a test method - Verifies that the JSON deserialization correctly populates the list of cost items.
        [Test]
        public void Deserialize_ShouldContainExpectedNumberOfItems()
        {
            Assert.That(_costItems, Is.Not.Null);
            Assert.That(_costItems.Count, Is.GreaterThan(0), "Cost items list should not be empty");
        }

        // This is a test method - Verifies that the JSON count actual numbers of cost items.
        [Test]
        public void Deserialize_ShouldCountExpectedNumberOfItems()
        {
            // Console.WriteLine(_costItems.Count); - 53
            Assert.That(_costItems.Count, Is.EqualTo(53), "Cost items list should have 53 cost items");
        }

        // Checks that the item with the highest cost is correctly retrieved using LINQ.
        [Test]
        public void LINQ_ShouldGetTopItemByCost()
        {
            var topItem = _costItems.OrderByDescending(c => c.Cost).FirstOrDefault();

            Assert.That(topItem, Is.Not.Null, "Top item should not be null");
            Assert.That(topItem.CountryId, Is.EqualTo(0).Or.GreaterThan(0), "CountryId should be valid");
        }

        // Ensures the total cost for items in the year 2016 is accurately summed using LINQ.
        [Test]
        public void LINQ_ShouldSumCostsFor2016()
        {
            var totalCost = _costItems
                            .Where(c => c.YearId == "2016")
                            .Sum(c => c.Cost);

            Assert.That(totalCost, Is.GreaterThan(0), "Total cost for 2016 should be greater than 0");
        }

        // Validates that the logic handles an empty list without throwing errors.
        [Test]
        public void NegativeTest_EmptyList()
        {
            var emptyList = new List<CostItem>();

            var topItem = emptyList.OrderByDescending(c => c.Cost).FirstOrDefault();

            Assert.That(topItem, Is.Null, "Top item should be null for an empty list");
        }

        // Confirms that entries with zero cost are present and handled as expected.
        [Test]
        public void BoundaryTest_ZeroCost()
        {
            var zeroCostItems = _costItems.Where(c => c.Cost == 0).ToList();

            Assert.That(zeroCostItems, Is.Not.Null);
            Assert.That(zeroCostItems.Count, Is.GreaterThanOrEqualTo(1), "There should be items with zero cost");
        }

        // Ensures that the item with the maximum cost is correctly identified.
        [Test]
        public void BoundaryTest_MaxCost()
        {
            var maxCost = _costItems.Max(c => c.Cost);
            var item = _costItems.First(c => c.Cost == maxCost);

            Assert.That(item.Cost, Is.EqualTo(maxCost), "Item should match the max cost");
        }
    }

}