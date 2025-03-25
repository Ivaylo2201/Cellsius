using Api.Models;
using System.Globalization;
using System.Text;

namespace Api.Services
{
    public class ReceiptService(Order order)
    {
        private readonly Order _order = order;

        private static string GenerateItemCard(int quantity, string brand, string model, string color, decimal price, string imagePath)
        {
            return $@"
                <div style=""display: flex; border: 1px solid #e5e7eb; border-radius: 8px; align-items: center; justify-content: space-between; padding: 8px 16px;"">
                    <section style=""display: flex; flex-direction: column;"">
                        <h2 style=""font-weight: bold; color: #2b2b2b; white-space: nowrap; overflow: hidden; text-overflow: ellipsis;"">
                            {quantity}x {brand} {model}, {color}
                        </h2>
                        <h3 style=""font-weight: 300; font-style: italic; color: #475569;"">Ordered for ${price:F2}</h3>
                    </section>
                </div>";
        }

        private static string FormatDate(DateTime dateTime)
        {
            return dateTime.ToString("dd MMMM yyyy", CultureInfo.InvariantCulture);
        }

        public string GetReceipt()
        {
            StringBuilder sb = new();

            sb.Append($"<p style=\"color: #2b2b2b; font-size: 18px;\">{this._order.Shipping.Type} shipping: ${this._order.Shipping.Cost:F2}</p>");
            sb.Append("<p style=\"color: #2b2b2b; font-size: 16px;\">");
            sb.Append("Placed on:&nbsp;");
            sb.Append($"<span style=\"font-weight: bold;\">{FormatDate(this._order.CreatedAt)}</span>, ");
            sb.Append("Expected on:&nbsp;");
            sb.Append($"<span style=\"font-weight: bold;\">{FormatDate(this._order.CreatedAt.AddDays(this._order.Shipping.Days))}</span>");
            sb.Append("</p>");

            sb.Append("<div style=\"display: flex; flex-direction: column; margin: 1.5rem 0 1.5rem 0; gap: 15px;; \">");
            sb.Append(string.Join("", this._order.Items.Select(i => GenerateItemCard(i.Quantity, i.Phone.Brand!.Name, i.Phone.Model!.Name, i.Phone.Color!.Name, i.Quantity * i.Phone.Price, i.Phone.ImagePath))));        
            sb.Append("</div>");
            sb.Append($"<p style=\"font-size: 1.5rem; color: #2b2b2b;\">Total: {this._order.Items.Count} item(s) for <span style=\"font-weight: bold;\">${_order.Total:F2}</span></p>");

            return sb.ToString();
        }
    }
}
