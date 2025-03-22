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
                        <h2 style=""font-weight: bold; color: #1e3a8a; white-space: nowrap; overflow: hidden; text-overflow: ellipsis;"">
                            {quantity}x {brand} {model}, {color}
                        </h2>
                        <h3 style=""font-style: italic; color: #475569;"">Ordered for ${$"{price:F2}"}</h3>
                    </section>
                </div>";
        }

        private static string FormatDate(DateTime dateTime, bool isDetailed = false)
        {
            string format = !isDetailed ? "dd MMMM yyyy" : "dd MMMM yyyy, HH:mm";
            return dateTime.ToString(format, CultureInfo.InvariantCulture);
        }

        public string GetReceipt()
        {
            StringBuilder sb = new();

            sb.Append($"<p>{this._order.Shipping.Type} Shipping</p>");
            sb.Append("<p style=\"font-style: italic; color: #475569;\">");
            sb.Append("Placed on:&nbsp;");
            sb.Append($"<span style=\"font-weight: bold;\">{FormatDate(this._order.CreatedAt, true)}</span>, ");
            sb.Append("Expected on:&nbsp;");
            sb.Append($"<span style=\"font-weight: bold;\">{FormatDate(this._order.CreatedAt.AddDays(this._order.Shipping.Days))}</span>");
            sb.Append("</p>");

            sb.Append("<div style=\"display: grid; grid-template-columns: 1fr; gap: 16px;\">");
            sb.Append(string.Join("", this._order.Items.Select(i => GenerateItemCard(i.Quantity, i.Phone.Brand.Name, i.Phone.Model.Name, i.Phone.Color.Name, i.Quantity * i.Phone.Price, i.Phone.ImagePath))));
            sb.Append($"Total: {this._order.Items.Count} item(s) for ${_order.Total:F2}");
            sb.Append("</div>");

            return sb.ToString();
        }
    }
}
