using FurnitureStoreAPI.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

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

/*Key Bridge Pattern Benefits Here:


No Class Explosion - No need for WoodenChair, MetalChair, etc.

Flexible Combinations - 4 furniture types × 4 materials = 16 combos

Runtime Changes - Change material without creating new object

Independent Scaling - Add new furniture/ material easily

Single Responsibility - Furniture handles type, Material handles production*/