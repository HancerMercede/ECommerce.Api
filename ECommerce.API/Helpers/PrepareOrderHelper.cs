namespace ECommerce.API.Helpers;

public static class PrepareOrderHelper
{
    public static InvoiceCreateDto PrepareHeader(InvoiceCreateDto model)
    {

        foreach (var detail in model.invoiceDetails)
        {

            detail.SubTotal = detail.Price * detail.Cuantity;
            detail.Iva = detail.SubTotal * ParameterIvaRate.IvaRate;
            detail.Total = detail.SubTotal + detail.Iva;
        }

        model.SubTotal = model.invoiceDetails.Sum(c => c.SubTotal);
        model.Iva = model.invoiceDetails.Sum(c => c.Iva);
        model.Total = model.invoiceDetails.Sum(c => c.Total);

        return model;
    }
}
