namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Bridge
{
    // Implementation Interface - Material Production
    public interface IMaterialProduction
    {
        string GetMaterialName();
        string GetProductionMethod();
        decimal GetMaterialCost();
        string GetDurability();
        string GetMaintenanceInfo();
    }
}
