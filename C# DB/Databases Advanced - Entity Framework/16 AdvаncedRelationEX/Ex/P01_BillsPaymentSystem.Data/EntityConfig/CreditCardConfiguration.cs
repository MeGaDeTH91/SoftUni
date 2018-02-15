namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_BillsPaymentSystem.Data.Models;

    public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder.HasKey(x => x.CreditCardId);

            builder.Property(x => x.ExpirationDate)
                .IsRequired(true);

            builder.Property(x => x.Limit)
                .IsRequired(true);

            builder.Property(x => x.MoneyOwed)
                .IsRequired(true);

            builder.Ignore(x => x.LimitLeft);

            builder.Ignore(x => x.PaymentMethodId);
        }
    }
}
