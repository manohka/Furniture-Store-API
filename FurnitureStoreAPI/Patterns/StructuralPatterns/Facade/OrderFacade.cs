using FurnitureStoreAPI.Models;
using FurnitureStoreAPI.Patterns.Singleton;

namespace FurnitureStoreAPI.Patterns.StructuralPatterns.Facade
{
    // FACADE: Simplifies complex order processing
    public class OrderFacade
    {
        // Complex subsystems (hidden from client)
        private readonly InventoryService _inventoryService;
        private readonly PaymentService _paymentService;
        private readonly ShippingService _shippingService;
        private readonly WarrantyService _warrantyService;
        private readonly NotificationService
            _notificationService;

        public OrderFacade()
        {
            _inventoryService = new InventoryService();
            _paymentService = new PaymentService();
            _shippingService = new ShippingService();
            _warrantyService = new WarrantyService();
            _notificationService = new NotificationService();
        }

        // SIMPLE METHOD: Hides all complexity
        public OrderResponse PlaceOrder(OrderRequest request, Furniture furniture)
        {
            Logger.GetInstance().Log(
                $"Starting order process for furniture: " +
                $"{furniture.Name}");

            try
            {
                // Step 1: Check Inventory
                _inventoryService.ReserveItem(
                    request.FurnitureId,
                    request.Quantity);

                // Step 2: Calculate Shipping
                decimal shippingCost =
                    _shippingService.CalculateShippingCost(
                        furniture.Price,
                        request.Quantity,
                        request.ShippingAddress);

                decimal totalAmount =
                    (furniture.Price * request.Quantity) +
                    shippingCost;

                // Step 3: Process Payment
                _paymentService.ProcessPayment(
                    request.CardNumber,
                    totalAmount,
                    request.CardholderName);

                // Step 4: Setup Warranty
                string warrantyId = _warrantyService
                    .SetupWarranty(
                        request.FurnitureId,
                        furniture.Price);

                // Step 5: Generate Order Details
                string orderId =
                    $"ORD-{DateTime.Now:yyyyMMddHHmmss}";
                string transactionId =
                    _paymentService.GenerateTransactionId();
                string trackingNumber =
                    _shippingService.GenerateTrackingNumber();

                // Step 6: Send Notifications
                _notificationService
                    .SendOrderConfirmation(
                        request.CustomerEmail,
                        orderId,
                        totalAmount);

                _notificationService
                    .SendShippingNotification(
                        request.CustomerEmail,
                        trackingNumber);

                Logger.GetInstance().Log(
                    $"Order {orderId} completed successfully");

                return new OrderResponse
                {
                    OrderId = orderId,
                    FurnitureId = request.FurnitureId,
                    Quantity = request.Quantity,
                    ItemPrice = furniture.Price,
                    ShippingCost = shippingCost,
                    TotalAmount = totalAmount,
                    TransactionId = transactionId,
                    TrackingNumber = trackingNumber,
                    WarrantyId = warrantyId,
                    Status = "Order Confirmed",
                    OrderDate = DateTime.Now
                };
            }
            catch (Exception ex)
            {

                Logger.GetInstance().Log(
                    $"Order failed: {ex.Message}");
                throw;
            }
        }
    }
}
