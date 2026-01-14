using FurnitureStoreAPI.Models;
using FurnitureStoreAPI.Patterns.Singleton;

namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Bridge
{
    
    /*public class Furniture
    {
    }*/

    // Abstract class using Bridge pattern

    public abstract class BridgeFurniture : IFurnitureType
    {
        // Bridge: Reference to implementation
        protected IMaterialProduction _materialProduction;

        protected string FurnitureType { get; set; }

        protected decimal BasePrice { get; set; }

        public BridgeFurniture(IMaterialProduction materialProduction)
        {
            _materialProduction = materialProduction;
            Logger.GetInstance().Log(
                $"Bridge: Creating {GetType().Name} " +
                $"with {materialProduction.GetMaterialName()}");
        }

        // Change implementation at runtime
        public void SetMaterialProduction(
            IMaterialProduction materialProduction)
        {
            _materialProduction = materialProduction;
            Logger.GetInstance().Log(
                $"Bridge: Changed material to " +
                $"{materialProduction.GetMaterialName()}");
        }

        public abstract string GetFurnitureType();

        public abstract string GetDescription();

        public virtual decimal CalculatePrice()
        {
            decimal totalPrice = BasePrice +
                _materialProduction.GetMaterialCost();
            return totalPrice;
        }

        public virtual FurnitureSpecification GetSpecification()
        {
            return new FurnitureSpecification
            {
                FurnitureType = GetFurnitureType(),
                Description = GetDescription(),
                Material =
                    _materialProduction.GetMaterialName(),
                ProductionMethod =
                    _materialProduction.GetProductionMethod(),
                BasePrice = BasePrice,
                MaterialCost =
                    _materialProduction.GetMaterialCost(),
                TotalPrice = CalculatePrice(),
                Durability =
                    _materialProduction.GetDurability(),
                MaintenanceInfo =
                    _materialProduction.GetMaintenanceInfo()
            };
        }
    }
    }
