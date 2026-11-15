using Unknown_Sun_Domain.Catalog;

namespace Unknown_Sun.Domain.Tests;

[TestClass]
public sealed class ItemTests
{
    [TestMethod]
    public void Can_Create_New_Item()
    {
        var item = new Item("Name", "Description", "Brand", 10.00m);

        Assert.AreEqual("Name", item.Name);
        Assert.AreEqual("Description", item.Description);
        Assert.AreEqual("Brand", item.Brand);
        Assert.AreEqual(10.00m, item.Price);
    }

    [TestMethod]
    public void Cannot_Create_Item_With_Empty_Name()
    {
        Assert.Throws<ArgumentNullException>(
            () => new Item("", "A comfortable shirt", "Unknown Sun", 19.99m));
    }

    [TestMethod]
    public void Cannot_Create_Item_With_Empty_Description()
    {
        Assert.Throws<ArgumentNullException>(
            () => new Item("T-shirt", "", "Unknown Sun", 19.99m));
    }

    [TestMethod]
    public void Cannot_Create_Item_With_Empty_Brand()
    {
        Assert.Throws<ArgumentNullException>(
            () => new Item("T-shirt", "A comfortable shirt", "", 19.99m));
    }

    [TestMethod]
    public void Cannot_Create_Item_With_Zero_Price()
    {
        Assert.Throws<ArgumentException>(
            () => new Item("T-shirt", "A comfortable shirt", "Unknown Sun", 0m));
    }

    [TestMethod]
    public void Cannot_Create_Item_With_Negative_Price()
    {
        Assert.Throws<ArgumentException>(
            () => new Item("T-shirt", "A comfortable shirt", "Unknown Sun", -1m));
    }

    [TestMethod]
    public void Can_Add_Rating_To_Item()
    {
        var item = new Item("T-shirt", "A comfortable shirt", "Unknown Sun", 19.99m);
        var rating = new Rating(5, "Mike", "Great fit!");

        item.AddRating(rating);

        Assert.HasCount(1, item.Ratings);
        Assert.AreSame(rating, item.Ratings[0]);
    }
}
