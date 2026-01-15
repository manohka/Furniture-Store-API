using FurnitureStoreAPI.Patterns.Singleton;

namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Composite
{
    // Builder for Composite Structure
    public class FurnitureCatalog
    {
        public static FurnitureCollection BuildCompleteCatalog()
        {
            // Root catalog
            var catalog = new FurnitureCollection(
                "Furniture Catalog",
                "Complete furniture store catalog");

            // Living Room Collection
            var livingRoom = new FurnitureCollection(
                "Living Room Collection",
                "Everything you need for a cozy living room");

            livingRoom.Add(new FurnitureItem(
                "Modern Sofa",
                800m,
                1,
                25.5,
                "Comfortable 3-seater sofa",
                "Fabric",
                "Gray"));

            livingRoom.Add(new FurnitureItem(
                "Coffee Table",
                300m,
                1,
                15.0,
                "Elegant glass coffee table",
                "Glass & Metal",
                "Black"));

            livingRoom.Add(new FurnitureItem(
                "TV Stand",
                400m,
                1,
                20.0,
                "Wall-mounted TV stand",
                "Wood",
                "Walnut"));

            livingRoom.Add(new FurnitureItem(
                "Floor Lamp",
                150m,
                2,
                5.0,
                "Modern arc floor lamp",
                "Metal",
                "Silver"));

            // Bedroom Collection
            var bedroom = new FurnitureCollection(
                "Bedroom Collection",
                "Complete bedroom furniture set");

            bedroom.Add(new FurnitureItem(
                "Platform Bed",
                600m,
                1,
                40.0,
                "Queen-size platform bed",
                "Wood",
                "Oak"));

            bedroom.Add(new FurnitureItem(
                "Nightstand",
                150m,
                2,
                10.0,
                "Wooden nightstand with drawer",
                "Wood",
                "Oak"));

            bedroom.Add(new FurnitureItem(
                "Dresser",
                350m,
                1,
                35.0,
                "6-drawer dresser",
                "Wood",
                "Mahogany"));

            bedroom.Add(new FurnitureItem(
                "Wardrobe",
                500m,
                1,
                50.0,
                "3-door wardrobe cabinet",
                "Wood",
                "Walnut"));

            // Dining Collection
            var dining = new FurnitureCollection(
                "Dining Room Collection",
                "Premium dining furniture");

            dining.Add(new FurnitureItem(
                "Dining Table",
                500m,
                1,
                30.0,
                "Extendable dining table",
                "Wood",
                "Dark Brown"));

            dining.Add(new FurnitureItem(
                "Dining Chair",
                200m,
                4,
                8.0,
                "Comfortable dining chair",
                "Wood & Fabric",
                "Brown"));

            dining.Add(new FurnitureItem(
                "Buffet Cabinet",
                450m,
                1,
                45.0,
                "Large storage buffet",
                "Wood",
                "Cherry"));

            // Add collections to catalog
            catalog.Add(livingRoom);
            catalog.Add(bedroom);
            catalog.Add(dining);

            Logger.GetInstance().Log(
                "Composite: Built complete catalog");

            return catalog;
        }

        public static FurnitureCollection BuildSmallCollection()
        {
            var collection = new FurnitureCollection(
                "Small Studio Set",
                "Furniture for small apartments");

            collection.Add(new FurnitureItem(
                "Compact Sofa Bed",
                400m,
                1,
                20.0,
                "Space-saving sofa bed",
                "Fabric",
                "Beige"));

            collection.Add(new FurnitureItem(
                "Multi-purpose Table",
                200m,
                1,
                12.0,
                "Table that converts to bed",
                "Wood",
                "Natural"));

            collection.Add(new FurnitureItem(
                "Wall Shelves",
                150m,
                3,
                5.0,
                "Floating wall shelves",
                "Metal",
                "White"));

            return collection;
        }
    }
}
